<template>
  <div>
    <headerbar/>
    <titlecard title="Client"/>
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
import datatable from "@/components/ProducerDataTable";
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