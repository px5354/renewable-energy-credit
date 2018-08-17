<template>
  <div>
    <headerbar/>
    <titlecard title="Client"/>
    <div v-if="dataLoaded">
      <datatable title="Wallet" :elements="balances"/>
    </div>
    <div v-else>
      <md-progress-spinner class="md-accent" md-mode="indeterminate"></md-progress-spinner>
    </div>
  </div>
</template>

<script>
import * as apiService from "../services/apiService";
import datatable from "@/components/WalletDataTable";
import headerbar from "@/components/HeaderBar";
import titlecard from "@/components/TitleCard";
export default {
  name: "client",
  components: {
    datatable,
    headerbar,
    titlecard,
  },
  data: () => ({
      balances: null,
      dataLoaded: false,
  }),
  watch: {
    balances(newData, oldData) {
      this.dataLoaded = true;
    }
  },
  methods: {
    getBalances() {
      apiService.getBalances()
        .then(body => (this.balances = body.data));
    },
  },
  mounted(){
    this.getBalances();
  },
};
</script>