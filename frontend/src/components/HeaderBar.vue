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
    </md-toolbar>
    <md-drawer :md-active.sync="showNavigation">
      <md-toolbar class="md-transparent" md-elevation="0">
        <span class="md-title">My App name</span>
      </md-toolbar>

      <md-list>
        <md-list-item>
          <md-icon>move_to_inbox</md-icon>
          <span class="md-list-item-text"><router-link to="/">Home</router-link></span>
        </md-list-item>

        <md-list-item>
          <md-icon>move_to_inbox</md-icon>
          <span class="md-list-item-text"><router-link to="/producer">Producer</router-link></span>
        </md-list-item>

        <md-list-item>
          <md-icon>send</md-icon>
          <span class="md-list-item-text">Broker</span>
        </md-list-item>

        <md-list-item>
          <md-icon>delete</md-icon>
          <span class="md-list-item-text">Client</span>
        </md-list-item>
      </md-list>
    </md-drawer>
  </div>
</template>

<script>
export default {
  name: "headerbar",
  data() {
    return {
      title: "Renewable Energy Credits",
      inline: null,
      showNavigation: false,
    };
  }
};
</script>

<style lang="scss" scoped>
.md-focused label {
  font-weight: 500;
}
#toolbar {
  position: fixed;
  z-index: 10;
}
#searchbar {
  width: 200px;
}
#logo {
  width: 50px;
}
.md-drawer {
  width: 230px;
  max-width: calc(100vw - 125px);
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
