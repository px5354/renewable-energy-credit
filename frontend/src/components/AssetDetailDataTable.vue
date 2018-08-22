<template>
  <div class="datatable">
    <!-- <md-table v-model="users" md-sort="name" md-sort-order="asc" md-card md-fixed-header> -->
    <md-table class="datatablelayout" v-if="this.elements && this.elements.length > 0" v-model="this.elements" md-card md-fixed-header>
    <!-- <md-table v-model="users" md-card md-fixed-header> -->
      <md-table-toolbar>
        <md-button id="back-btn" class="md-icon-button" @click="goToPreviousPage">
          <md-icon>arrow_back</md-icon>
        </md-button>
        <h1 class="md-title">{{ title }}</h1>
        <issuebtn :energyDisplayName="title" :assetId="this.$route.params.assetId"/>
      </md-table-toolbar>
      <md-table-row  slot="md-table-row" slot-scope="{ item }">
        <md-tooltip v-if="item.status!='Confirmed'" md-direction="right">
          Applying operations in blockchain
        </md-tooltip>
        <md-table-cell md-label="Recipient" class="text-row">{{ item.recipient }}</md-table-cell>
        <md-table-cell md-label="Amount" md-numeric>{{ item.amount }}</md-table-cell>
        <md-table-cell md-label="Date" class="text-row">{{ item.status == 'Confirmed' ? item.date : 'Applying operations in blockchain...' }}</md-table-cell>
      </md-table-row>
    </md-table>
    <md-table v-else v-model="this.elements" md-card md-fixed-header>
    <!-- <md-table v-model="users" md-card md-fixed-header> -->
      <md-table-toolbar>
        <md-button id="back-btn" class="md-icon-button" @click="goToPreviousPage">
          <md-icon>arrow_back</md-icon>
        </md-button>
        <h1 class="md-title">{{ title }}</h1>
        <issuebtn :energyDisplayName="title" :energyId="assetId"/>
      </md-table-toolbar>
      <span>No data to show</span> 
    </md-table>
  </div>
</template>

<script>
import issuebtn from "@/components/IssueBtn";
  export default {
    name: 'assetdetaildatatable',
    components: {
      issuebtn,
    },
    props: ['title', 'assetId','elements', 'labels'],
    data: () => ({
    }),
    props: {
      title: String,
      assetId: String,
      elements: Array,
      labels: Array,
    },
    methods: {
      goToPreviousPage(){
        this.$router.push({ path: `/producer` });
      },
    },
    mounted(){
      console.log("mounted");
      console.log(this.$route.params.assetId);     
  },
  }
</script>

<style lang="scss" scoped>
.datatable {
  margin-left: 100px;
  margin-right: 100px;
}
.datatablelayout {
  margin: auto;
  // width: 800px;
}
.md-title {
  margin-right: 50px;
}
.text-row {
  text-align: left;
}
</style>