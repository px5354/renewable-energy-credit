<template>
  <div>
    <md-drawer md-permanent="full">
      <md-toolbar class="md-transparent" md-elevation="0">
        Navigation
      </md-toolbar>
      <md-list>
        <md-list-item>
          <md-icon>move_to_inbox</md-icon>
          <span class="md-list-item-text">Producer</span>
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
  name: "sidebar",
  data() {
    return {
      title: "Renewable Energy Credits",
      inline: null
    };
  }
};
</script>