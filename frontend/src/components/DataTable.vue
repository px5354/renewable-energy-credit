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
        <md-table-cell md-label="Name">{{ item.name }}</md-table-cell>
        <md-table-cell md-label="Creation Date">{{ getDate(item.creationDate) }}</md-table-cell>
      </md-table-row>
    </md-table>
  </div>
</template>

<script>
  import moment from "moment";
  export default {
    name: 'datatable',
    props: ['title', 'elements', 'labels'],
    data: () => ({
      users: [
        {
          id: 1,
          name: "Shawna Dubbin",
          email: "sdubbin0@geocities.com",
          gender: "Male",
          title: "Assistant Media Planner"
        },
        {
          id: 2,
          name: "Odette Demageard",
          email: "odemageard1@spotify.com",
          gender: "Female",
          title: "Account Coordinator"
        },
      ]
    }),
    methods: {
      getDate(date){
        return moment(date).format('MMM Do YYYY, h:mm:ss a');;
      },
    },
    props: {
      title: String,
      elements: Array,
      labels: Array,
    },
    mounted(){
      console.log("mounted");
      console.log(this.elements);
  },
  }
</script>

<style lang="scss" scoped>
.datatable {
  padding-top: 100px;
}
.datatablelayout {
  margin: auto;
  width: 500px;
}
</style>