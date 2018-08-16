<template>
  <div>
    <div>
      <!-- <headerbar @clicked="onClickPage"/> -->
      <headerbar/>
    </div>
    <!-- <div>
      <component :is="currentPage"></component>
    </div> -->
  </div>
</template>

<script>
import headerbar from "@/components/HeaderBar";
// import producer from "@/components/Producer";
// import broker from "@/components/Broker";
// import client from "@/components/Client";
export default {
  name: "mainview",
  components: {
    headerbar,
  },
  data: () => {
    return {
      currentPage: 'producer',
    };
  },
  methods: {
    onClickPage (e) {
      this.currentPage = e;
    }
  }
};
</script>
