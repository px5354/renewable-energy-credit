<template>
  <div>
    <!-- <datatable title="Green Credits"/> -->
    <div v-if="dataLoaded">
      <createbtn/>
      <datatable title="Green Credits" :elements="greenAssets"/>
    </div>
    <div v-else>
      <md-progress-spinner class="md-accent" md-mode="indeterminate"></md-progress-spinner>
    </div>
  </div>
</template>

<script>
  import * as apiService from "../services/apiService";
  import datatable from "@/components/DataTable";
  import createbtn from "@/components/CreateBtn";
  export default {
    name: "producer",
    components: {
      datatable,
      createbtn,
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

<style lang="scss" scoped>
.md-progress-spinner {
    margin: 24px;
    padding-top: 100px;
}
</style>