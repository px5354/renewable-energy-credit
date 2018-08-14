<template>
  <div>
    <headerbar/>  
  </div>
</template>

<script>
import * as apiService from "../services/apiService";
import headerbar from "@/components/HeaderBar";
export default {
  name: "producerview",
  components: {
    headerbar,
  },
  data: {
    assets: [],
    transactions: [],
  }
};
</script>