<template>
  <div id="app">
    <Header/>
    <Navbar />
    <Content/>
    <DialogEmployee />
  </div>
</template>

<script>
import Navbar from "./components/layout/TheNavbar"
import Header from "./components/layout/TheHeader"
import Content from "./components/layout/TheContent"
import DialogEmployee from "./components/dialog/DialogEmployee"
export default {
  name: 'App',
  components: {
    Navbar,
    Content,
    Header,
    DialogEmployee
  }
}
</script>

<style lang="scss">
@import "./styles/index.scss";
#app {
  font-family: Tahoma_Regular;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
