<template>
  <div id="app">
    <!-- <div id="nav">
        <router-link v-if="authenticated" to="/login" v-on:click.native="logout()" replace>Logout</router-link>
    </div> -->
    <router-view/>    
    <!-- <router-view/> -->
  </div>
</template>

<script>
import { USER_REQUEST } from '@/store/actions/user'
export default {
  name: "App",
  created: function () {
    if (this.$store.getters.isAuthenticated) {
      this.$store.dispatch(USER_REQUEST)
    }
  },
};
</script>

<style>
#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100%;
}
</style>
