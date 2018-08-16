<template>
  <div class="datatable datatablelayout">
    <!-- <md-table v-model="users" md-sort="name" md-sort-order="asc" md-card md-fixed-header> -->
    <md-table v-if="this.elements && this.elements.length > 0" v-model="this.elements" md-card md-fixed-header>
    <!-- <md-table v-model="users" md-card md-fixed-header> -->
      <md-table-toolbar>
        <md-button id="back-btn" class="md-icon-button" @click="goToPreviousPage">
          <md-icon>arrow_back</md-icon>
        </md-button>
        <h1 class="md-title">{{ title }}</h1>
      </md-table-toolbar>
      <md-table-row  slot="md-table-row" slot-scope="{ item }">
        <md-table-cell md-label="Recipient" class="text-row">{{ item.recipient }}</md-table-cell>
        <md-table-cell md-label="Amount" md-numeric>{{ item.amount }}</md-table-cell>
        <md-table-cell md-label="Date" class="text-row">{{ item.date }}</md-table-cell>
      </md-table-row>
    </md-table>
    <md-table v-else v-model="this.elements" md-card md-fixed-header>
    <!-- <md-table v-model="users" md-card md-fixed-header> -->
      <md-table-toolbar>
        <md-button id="back-btn" class="md-icon-button" @click="goToPreviousPage">
          <md-icon>arrow_back</md-icon>
        </md-button>
        <h1 class="md-title">{{ title }}</h1>
      </md-table-toolbar>
      <span>No data to show</span> 
    </md-table>
  </div>
</template>

<script>
  export default {
    name: 'producerdatatable',
    props: ['title', 'elements', 'labels'],
    data: () => ({
    }),
    props: {
      title: String,
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
      console.log(this.elements);
  },
  }
</script>

<style lang="scss" scoped>
.datatable {
  // padding-top: 100px;
}
.datatablelayout {
  margin: auto;
  width: 800px;
}
.md-title {
  margin-right: 50px;
}
.text-row {
  text-align: left;
}
</style>