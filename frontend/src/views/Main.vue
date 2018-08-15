<template>
  <div>
    <div>
      <headerbar @clicked="onClickPage"/>
    </div>
    <div>
      <component :is="currentPage"></component>
    </div>
  </div>
</template>

<script>
import headerbar from "@/components/HeaderBar";
import producer from "@/components/Producer";
import broker from "@/components/Broker";
import client from "@/components/Client";
export default {
  name: "mainview",
  components: {
    headerbar,
    producer,
    broker,
    client,
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
