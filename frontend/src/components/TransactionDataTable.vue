<template>
  <div class="datatable datatablelayout">
    <md-table v-model="this.elements" md-card md-fixed-header>
      <md-table-toolbar>
        <h1 class="md-title">{{ title }}</h1>
      </md-table-toolbar>

      <md-table-row :id="item.id" slot="md-table-row" slot-scope="{ item }">
        <md-table-cell md-label="Sender" class="text-row">
          {{ item.senderDisplayName }}
        </md-table-cell>
        <md-table-cell md-label="Recipient" class="text-row">
          {{ item.recipientDisplayName }}
        </md-table-cell>
        <md-table-cell md-label="Amount" numeric>
          {{ item.amount }}
        </md-table-cell>
        <md-table-cell md-label="Asset" class="text-row">
          {{ item.assetDisplayName }}
        </md-table-cell>
        <md-table-cell md-label="Status">
          <span v-if="item.blockchainStatus=='Confirmed'">
            <md-icon class="confirmation-icon">check_circle_outline</md-icon>
          </span>
          <span v-else>
            <md-progress-spinner :md-diameter="20" :md-stroke="3" md-mode="indeterminate"></md-progress-spinner>
          </span>
        </md-table-cell>
        <md-table-cell md-label="Creation Date" class="text-row">
          {{ getData(item.timestamp) }}
        </md-table-cell>
      </md-table-row>
    </md-table>
  </div>
</template>

<script>
  import moment from "moment";
  export default {
    name: 'transactiondatatable',
    props: ['title', 'elements', 'labels'],
    components: {
    },
    data: () => ({
    }),
    props: {
      title: String,
      elements: Array,
      labels: Array,
    },
    methods: {
      getData(timestamp){
        return moment(timestamp).format('MMM Do YYYY, h:mm:ss a')
      }
    },
    mounted(){
      // console.log("mounted");
    },
  }
</script>

<style lang="scss" scoped>
.datatable {
  padding-top: 10px;
  margin: auto;
  display: inline-block;
}
.datatablelayout {
  margin: auto;
  width: 1000px;
}
.text-row {
  text-align: left;
}
.table-btn {
  width: 5px;
}
.confirmation-icon {
  color: green !important;
}
</style>