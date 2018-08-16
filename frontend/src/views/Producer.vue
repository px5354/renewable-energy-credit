<template>
  <div>
    <headerbar/>
    <titlecard title="Producer"/>
    <!-- <datatable title="Green Credits"/> -->
    <div v-if="dataLoaded">
      <datatable title="Green Credits" :elements="getGreenAssets" :labels="labels"/>
    </div>
    <div v-else>
      <md-progress-spinner class="md-accent" md-mode="indeterminate"></md-progress-spinner>
    </div>
  </div>
</template>

<script>
  import * as apiService from "../services/apiService";
  import moment from "moment";
  import datatable from "@/components/ProducerDataTable";
  import headerbar from "@/components/HeaderBar";
  import titlecard from "@/components/TitleCard";
  export default {
    name: "producer",
    components: {
      headerbar,
      datatable,
      titlecard,
    },
    data: () => ({
      greenAssets: null,
      dataLoaded: false,
      labels: [
        {
          key: "name",
          label: "Name",
        },
        {
          key: "creationDate",
          label: "Creation Date",
        },
      ],      
    }),
    watch: {
      greenAssets(newData, oldData) {
        this.dataLoaded = true;
      }
    },
    computed: {
      getGreenAssets() {
        return this.greenAssets.map(e => {
          return {
            id: e.id,
            name: e.name,
            creationDate: e.creationDate ? moment(e.creationDate).format('MMM Do YYYY, h:mm:ss a') : e.creationDate,
          };
        }); 
      }
    },
    methods: {
      fetchGreenAssets() {
        apiService.getAssets()
          .then(body => (this.greenAssets = body.data));
      },
    },
    mounted(){
      this.fetchGreenAssets();
    },
  };
</script>

<style lang="scss" scoped>
.md-progress-spinner {
    margin: 24px;
    padding-top: 100px;
}
</style>