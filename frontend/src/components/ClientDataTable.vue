<template>
  <div class="datatable datatablelayout">
    <!-- <md-table v-model="users" md-sort="name" md-sort-order="asc" md-card md-fixed-header> -->
    <md-table v-model="this.elements" md-card md-fixed-header @md-selected="onSelect">
    <!-- <md-table v-model="users" md-card md-fixed-header> -->
      <md-table-toolbar>
        <h1 class="md-title">{{ title }}</h1>
        <createbtn/>
      </md-table-toolbar>

      <md-table-row :id="item.id" slot="md-table-row" slot-scope="{ item }" md-selectable="single">
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
        <md-table-cell md-label="Energy Type" class="text-row">{{ item.name }}</md-table-cell>
        <md-table-cell md-label="Creation Date" class="text-row">{{ item.creationDate }}</md-table-cell>
      </md-table-row>
    </md-table>
  </div>
</template>

<script>
  import createbtn from "@/components/CreateBtn";
  export default {
    name: 'producerdatatable',
    props: ['title', 'elements', 'labels'],
    components: {
      createbtn,
    },
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
}
.datatablelayout {
  margin: auto;
  width: 500px;
}
.text-row {
  text-align: left;
}
</style>