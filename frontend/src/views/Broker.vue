<template>
  <div>
    <headerbar/>
    <titlecard title="Broker"/>
    <div v-if="dataLoaded">
      <datatable title="Transfer" :elements="balances"/>
    </div>
    <div v-else>
      <md-progress-spinner class="md-accent" md-mode="indeterminate"></md-progress-spinner>
    </div>
  </div>
</template>

<script>
import * as apiService from "../services/apiService";
import datatable from "@/components/TransferDataTable";
import headerbar from "@/components/HeaderBar";
import titlecard from "@/components/TitleCard";
export default {
  name: "broker",
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