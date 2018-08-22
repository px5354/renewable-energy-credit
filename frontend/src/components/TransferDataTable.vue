<template>
  <div class="datatable datatablelayout">
    <!-- <md-table v-model="users" md-sort="name" md-sort-order="asc" md-card md-fixed-header> -->
    <md-table v-model="this.elements" md-card md-fixed-header>
    <!-- <md-table v-model="users" md-card md-fixed-header> -->
      <md-table-toolbar>
        <h1 class="md-title">{{ title }}</h1>
      </md-table-toolbar>

      <md-table-row :id="item.id" slot="md-table-row" slot-scope="{ item }">
        <!-- <md-table-cell md-label="ID" md-sort-by="id" md-numeric>{{ item.id }}</md-table-cell>
        <md-table-cell md-label="Name" md-sort-by="name">{{ item.name }}</md-table-cell>
        <md-table-cell md-label="Email" md-sort-by="email">{{ item.email }}</md-table-cell>
        <md-table-cell md-label="Gender" md-sort-by="gender">{{ item.gender }}</md-table-cell>
        <md-table-cell md-label="Job Title" md-sort-by="title">{{ item.title }}</md-table-cell> -->    
        <!-- <md-table-cell md-label="ID" md-numeric>{{ item.id }}</md-table-cell>
        <md-table-cell md-label="Name">{{ item.name }}</md-table-cell>
        <md-table-cell md-label="Email">{{ item.email }}</md-table-cell>
        <md-table-cell md-label="Gender">{{ item.gender }}</md-table-cell>
        <md-table-cell md-label="Job Title">{{ item.title }}</md-table-cell> -->
        <!-- <md-table-cell :v-for="label in this.labels" :md-label="label.label">
          {{ item[label.label] }}
        </md-table-cell> -->
        <md-table-cell md-label="Asset" class="text-row">
          {{ item.displayName }}
        </md-table-cell>
        <md-table-cell md-label="Amount">
          {{ item.remainingAmount }}
        </md-table-cell>
        <md-table-cell class="text-row table-btn">
          <transferbtn :selectedAsset="item"/>
        </md-table-cell>
      </md-table-row>
    </md-table>
  </div>
</template>

<script>
  import transferbtn from "@/components/TransferBtn";
  export default {
    name: 'transferdatatable',
    props: ['title', 'elements', 'labels'],
    components: {
      transferbtn,
    },
    data: () => ({
    }),
    props: {
      title: String,
      elements: Array,
      labels: Array,
    },
    methods: {
    },
    mounted(){
      // console.log("mounted");
    },
  }
</script>

<style lang="scss" scoped>
.datatable {
  // padding-top: 100px;
}
.datatablelayout {
  margin: auto;
  width: 500px;
}
.text-row {
  text-align: left;
}
.table-btn {
  width: 5px;
}
</style>