<template>
  <div>
    <md-toolbar id="toolbar">
      <div class="md-toolbar-section-start">
        <md-button class="md-icon-button" @click="showNavigation = true">
          <md-icon>menu</md-icon>
        </md-button>
        <img id="logo" src="../assets/logo.png">
        <h3 class="md-title">{{title}}</h3>
      </div>
      <div class="md-toolbar-section-end">
        <div v-if="isProfileLoaded">
          <span id="username">{{ `Welcome, ${name}` }}</span>
        </div>
        <div v-if="isAuthenticated" @click="logout">
          <md-button class="logout md-primary">Logout</md-button>
        </div>
        <div class="right-side" v-if="!isAuthenticated && !authLoading">
          <router-link to="/login">Login</router-link>
        </div>
      </div>      
    </md-toolbar>
    <md-drawer :md-active.sync="showNavigation">
      <md-toolbar class="md-transparent" md-elevation="0">
        <span class="md-title">My App name</span>
      </md-toolbar>

      <md-list>
        <!-- <md-list-item v-on:click="onClickPage">
          <md-icon>move_to_inbox</md-icon>      
          <span class="md-list-item-text">Home</span >
        </md-list-item> -->

        <md-list-item v-on:click="this.$router.push({ path: `/producer` });">
          <md-icon>how_to_reg</md-icon>
          <span class="md-list-item-text"><router-link to="/producer">Producer</router-link></span>
          <!-- <span class="md-list-item-text">Producer</span > -->
        </md-list-item>

        <md-list-item v-on:click="this.$router.push({ path: `/broker` });">
          <md-icon>swap_horiz</md-icon>
          <!-- <md-icon>swap_horizontal_circle</md-icon> -->          
          <!-- <span class="md-list-item-text">Broker</span > -->
          <span class="md-list-item-text"><router-link to="/broker">Broker</router-link></span>
        </md-list-item>

        <md-list-item v-on:click="this.$router.push({ path: `/client` });">
          <md-icon>account_balance_wallet</md-icon>
          <!-- <span class="md-list-item-text">Client</span > -->
          <span class="md-list-item-text"><router-link to="/client">Client</router-link></span>
        </md-list-item>
      </md-list>
    </md-drawer>
  </div>
</template>

<script>
import { mapGetters, mapState } from 'vuex';
import { AUTH_LOGOUT } from '@/store/actions/auth';
export default {
  name: "headerbar",
  data() {
    return {
      title: "Renewable Energy Credits",
      inline: null,
      showNavigation: false,
    };
  },
  methods: {
    onClickPage(e) {
      this.$emit('clicked', e)
    },
    logout: function () {
      this.$store.dispatch(AUTH_LOGOUT).then(() => this.$router.push('/login'))
    },  
  },
  computed: {
    ...mapGetters(['getProfile', 'isAuthenticated', 'isProfileLoaded']),
    ...mapState({
      authLoading: state => state.auth.status === 'loading',
      name: state => `${state.user.profile.title} ${state.user.profile.name}`,
    })
  },  
};
</script>

<style lang="scss" scoped>
.md-focused label {
  font-weight: 500;
}
#toolbar {
  position: fixed;
  z-index: 10;
  flex: 1;
}
#logo {
  width: 50px;
}
a {
    color: rgb(0, 96, 182);
    text-decoration: none;
}
a:hover 
{
  color:#00A0C6; 
  text-decoration:none; 
  cursor:pointer;  
}
</style>
