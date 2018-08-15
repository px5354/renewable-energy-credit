<template>
  <div>
    <div v-if="dataLoaded">
      <datatable title="Wallet" :elements="greenAssets"/>
    </div>
    <div v-else>
      <md-progress-spinner class="md-accent" md-mode="indeterminate"></md-progress-spinner>
    </div>
  </div>
</template>

<script>
import * as apiService from "../services/apiService";
import datatable from "@/components/DataTable";
export default {
  name: "client",
  components: {
    datatable,
  },
  data: () => ({
      greenAssets: null,
      dataLoaded: false,
  }),
  watch: {
    greenAssets(newData, oldData) {
      this.dataLoaded = true;
    }
  },
  methods: {
    getGreenAssets() {
      apiService.getAssets()
        .then(body => (this.greenAssets = body.data));
    },
  },
  mounted(){
    this.getGreenAssets();
  },
};
</script>