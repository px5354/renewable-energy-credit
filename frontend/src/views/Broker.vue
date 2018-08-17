<template>
  <div>
    <headerbar/>
    <titlecard title="Broker"/>
  </div>
</template>

<script>
import * as apiService from "../services/apiService";
import datatable from "@/components/AssetDataTable";
import headerbar from "@/components/HeaderBar";
import titlecard from "@/components/TitleCard";
export default {
  name: "broker",
  components: {
    datatable,
    headerbar,
    titlecard,
  }
};
</script>