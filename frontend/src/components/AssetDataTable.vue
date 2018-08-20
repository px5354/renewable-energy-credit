<template>
  <div class="datatable">
    <!-- <md-table v-model="users" md-sort="name" md-sort-order="asc" md-card md-fixed-header> -->
    <md-table class="datatablelayout" v-model="this.elements" md-card md-fixed-header @md-selected="onSelect">
    <!-- <md-table v-model="users" md-card md-fixed-header> -->
      <md-table-toolbar>
        <h1 class="md-title">{{ title }}</h1>
        <createbtn/>
      </md-table-toolbar>
      <md-table-row
        :id="item.id"
        slot="md-table-row"
        slot-scope="{ item }"
        v-bind:class="[item.status != 'Confirmed' ? 'disableclick' : '']"
        :md-selectable="item.status == 'Confirmed' ? 'single' : null"
      >
        <md-tooltip v-if="item.status!='Confirmed'" md-direction="right">
          Applying operations in blockchain
        </md-tooltip>
        <md-table-cell md-label="Asset" class="text-row long-text">{{ item.name }}</md-table-cell>
        <md-table-cell md-label="Creation Date" class="text-row">{{ item.creationDate }}</md-table-cell>
      </md-table-row>
    </md-table>
  </div>
</template>

<script>
  import createbtn from "@/components/CreateBtn";
  export default {
    name: 'assetdatatable',
    props: ['title', 'elements', 'labels'],
    components: {
      createbtn,
    },
    data: () => ({
    }),
    props: {
      title: String,
      elements: Array,
      labels: Array,
    },
    methods: {
      onSelect(item){
        this.$router.push({ path: `/producer/${item.id}` });
      }
    },
    mounted(){
      console.log("mounted");
      console.log(this.elements);
  },
  }
</script>

<style lang="scss" scoped>
.datatable {
  // padding-top: 100px;
  margin-left: 50px;
  margin-right: 50px;
}
.datatablelayout {
  margin: auto;
  // width: 1200px;
}
.text-row {
  text-align: left;
}
.long-text {
  // width: 10px;
}
.disableclick {
  cursor: wait;
}
</style>