<template>
  <div class="container">
    <!-- <md-table v-model="this.orderData" md-card md-fixed-header @selected="onSelect"> -->
    <md-table v-model="this.orderBookData" md-card md-fixed-header>
    <!-- <md-table v-model="users" md-card md-fixed-header> -->
      <md-table-toolbar>
        <h1 class="md-title">{{ title }}</h1>
      </md-table-toolbar>
      <!-- <md-table-row slot="md-table-row" slot-scope="{ item }"> -->
      <md-table-row slot="md-table-row" slot-scope="{ item }">
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
        <md-table-cell md-label="Price (CAD)" md-numeric>{{ item.price.toFixed(3) }}</md-table-cell>
        <md-table-cell :md-label="`Amount(${energyType.shortName})`" md-numeric>{{ item.amount.toFixed(3) }}</md-table-cell>
        <md-table-cell md-label="Sum(CAD)" md-numeric>{{ item.total.toFixed(3) }}</md-table-cell>
      </md-table-row>
    </md-table>
  </div>
</template>

<script>
export default {
  name: "formcard",
  props: ['title', 'energyType', 'orderBookData'],
  props: {
    title: String,
    energyType: Object,
    orderBookData: Array,
  },
  data: () => ({
    factoryId: null,
    email: null,
    price: null,
    amount: null,
    total: null,
    sending: false,
    currentSum: 0,
    // orderData: [
    //   {
    //     price: 1000,
    //     energyAmount: 200,
    //   },
    // ]
  }),
  methods: {
    getSumMoneyAmount(e) {
      // this.currentSum += e.price * e.amount;
      return (e.price * e.amount).toFixed(3);
      // return this.currentSum.toFixed(3);
    }
  },
  mounted() {
    this.currentSum = 0;
  },
};
</script>

<style lang="scss" scoped>
.container {
  padding-top: 10px;
  margin: auto;
  width: 500px;
  display: inline-block;
  padding-bottom: 10px;
}
.list-enter-active {
  transition: all 5s;
}
.list-enter {
  background: yellow;
}
</style>
