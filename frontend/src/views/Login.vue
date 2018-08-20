<template>
  <div class="login-container">
    <md-card>
      <md-card-header>
          <md-card-header-text>
              <div class="md-title">Energy Credits</div>
              <div class="md-subhead">Sign in</div>
          </md-card-header-text>
      </md-card-header>
      <form class="login" @submit.prevent="login">
        <md-card-content>
            <md-field>
                <label for="username">Email</label>
                <md-input type="email" name="username" id="username" v-model="username" placeholder="Email"/>
            </md-field>
            <md-field>
                <label for="password">Password</label>
                <md-input type="password" name="password" id="password" v-model="password" placeholder="Password"/>
            </md-field>
        </md-card-content>
        <md-card-actions>
            <md-button type="submit">Login</md-button>
        </md-card-actions>
      </form>
    </md-card>
  </div>
</template>

<style>
  .login-container {
    align-content: center;
    width: 300px;
    margin-left: auto;
    margin-right: auto;
    margin-top:200px;
  }
  /* .login {
    align-content: center;
    width: 300px;
    padding: 10px;
  } */
</style>

<script>
//   import {AUTH_REQUEST} from 'actions/auth'
  export default {
    name: 'login',
    data () {
      return {
        username: '',
        password: '',
      }
    },
    methods: {
      login: function () {
        const { username, password } = this
        this.$store.dispatch("AUTH_REQUEST", { username, password }).then(() => {
          this.$router.push('/')
        })
      }
    },
  }
</script>