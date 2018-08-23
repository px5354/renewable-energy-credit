<template>
  <div>
    <headerbar/>
    <titlecard title="Client"/>
    <div v-if="balanceLoaded && transLoaded">
      <div>
        <walletdatatable title="Wallet" :elements="balances"/>
      </div>
      <div>
        <transdatatable title="Transactions" :elements="transactions" :afterIssueAmount="afterIssueAmount"/>
      </div>
    </div>
    <div v-else>
      <md-progress-spinner class="md-accent" md-mode="indeterminate"></md-progress-spinner>
    </div>
  </div>
</template>

<script>
import * as apiService from "../services/apiService";
import walletdatatable from "@/components/TransferDataTable";
import transdatatable from "@/components/TransactionDataTable";
import headerbar from "@/components/HeaderBar";
import titlecard from "@/components/TitleCard";
export default {
  name: "client",
  components: {
    walletdatatable,
    transdatatable,
    headerbar,
    titlecard,
  },
  data: () => ({
      balances: null,
      transactions: null,
      balanceLoaded: false,
      transLoaded: false,
  }),
  watch: {
    balances(newData, oldData) {
      this.balanceLoaded = true;
    },
    transactions(newData, oldData) {
      this.transLoaded = true;
    },
  },
  methods: {
    getBalances() {
      apiService.getBalances()
        .then(body => (this.balances = body.data));
    },
    getTransactions() {
      apiService.getTransactions()
        .then(body => (
          this.transactions = body.data
            .filter(e => e.senderDisplayName != "Issue Asset")
            .sort((a,b) => {
              if(a.blockchainStatus !== 'Confirmed') {
                return -1
              }
              return (a.timestamp < b.timestamp) ? 1 : ((b.timestamp < a.timestamp) ? -1 : 0);
            })
        ));
    },
    afterIssueAmount() {
      this.$vm.$forceUpdate();
    }
  },
  mounted(){
    this.getBalances();
    this.getTransactions();
  },
};
</script>