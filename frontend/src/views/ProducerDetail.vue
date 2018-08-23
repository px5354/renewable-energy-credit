<template>
  <div>
    <headerbar/>
    <titlecard title="Producer"/>
    <!-- <datatable title="Green Credits"/> -->
    <div v-if="dataLoaded">
      <datatable :title="getEnergyType" :elements="getEnergyDetail"/>
    </div>
    <div v-else>
      <md-progress-spinner class="md-accent" md-mode="indeterminate"></md-progress-spinner>
    </div>
  </div>
</template>

<script>
  import * as apiService from "../services/apiService";
  import moment from "moment";
  import datatable from "@/components/AssetDetailDataTable";
  import createbtn from "@/components/CreateBtn";
  import headerbar from "@/components/HeaderBar";
  import titlecard from "@/components/TitleCard";
  export default {
    name: "producerdetail",
    components: {
      headerbar,
      datatable,
      createbtn,
      titlecard
    },
    data: () => ({
      energyDetails: null,
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
      energyDetails(newData, oldData) {
        this.dataLoaded = true;
      }
    },
    computed: {
      getEnergyDetail() {
        return this.energyDetails.batches.map(e => {
          return {
            id: e.id,
            status: e.blockchainStatus,
            assetId: e.assetId,
            recipient: e.recipientDisplayName,
            amount: e.amount,
            date: moment(e.timestamp).format('MMM Do YYYY, h:mm:ss a'),
          };
        }); 
      },

      getEnergyType() {
        return this.energyDetails ? this.energyDetails.assetDisplayName : null;
      }
    },
    methods: {
      fetchGreenAssetDetail(assetId) {
        apiService.getAssetDetails(assetId)
        .then(body =>(this.energyDetails = body.data));
      },
    },
    mounted(){
      console.log(this.$route.params.assetId);
      this.fetchGreenAssetDetail(this.$route.params.assetId);
    },
  };
</script>
