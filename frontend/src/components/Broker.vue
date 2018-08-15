<template>
  <div>
    <datatable title="Broker"/>
  </div>
</template>

<script>
import * as apiService from "../services/apiService";
import datatable from "@/components/DataTable";
export default {
  name: "broker",
  components: {
    datatable,
  }
};
</script>