<template>
  <div id="app">
    <!-- <img src="./assets/logo.png"> -->
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">Travelcy</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item active">
            <router-link class="nav-link" v-if="authenticated" to="/login" v-on:click.native="logout()" replace>Logout</router-link>
          </li>
          <li class="nav-item">
            <span class="nav-link" v-if="authenticated">{{ curUsername }}</span>
          </li>
          <li class="nav-item active">
            <router-link class="nav-link" v-if="authenticated" to="/flight" replace>Flight</router-link>
          </li>
          <li class="nav-item active">
            <router-link class="nav-link" v-if="authenticated" to="/hotel" replace>Hotel</router-link>
          </li>
        </ul>
      </div>
    </nav>
    <!-- <router-view/> -->
    <router-view @authenticated="setAuthenticated" @currentuser="setCurUser"/>
  </div>
</template>

<script>
// export default {
//   name: 'App'
// }

export default {
  name: 'App',
  data() {
    return {
      authenticated: false,
      curUsername: ''
    }
  },
  mounted() {
    if (!this.authenticated) {
      this.$router.replace({ name: "login" })
    }
  },
  methods: {
    setAuthenticated(status) {
      this.authenticated = status
    },
    logout() {
      this.authenticated = false
    },
    setCurUser(usr) {
      this.curUsername = usr
    }
  }
}
</script>

<style>
/* #app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
} */
body {
  /* background-color: #f0f0f0; */
}
/* h1 {
  padding: 0;
  margin-top: 0;
} */
#app {
  /* font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale; */
  /* width: 1024px; */
  margin: auto;

  height: 100vh;
  width: 100vw;
  background-color: red;
  background: url("https://source.unsplash.com/category/nature/1920x1080") no-repeat center center fixed;
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
}
</style>
