<template>
  <div class="home">
    <h1>Welcome to the Legal Contracts App</h1>
    <p>This application allows you to create, edit, view, and delete legal contracts.</p>
    <router-link to="/contracts">View Contracts</router-link>
    <router-link to="/create-contract">Create a New Contract</router-link>
  </div>
</template>

<script>
export default {
  name: 'Home',
};
</script>

<style scoped>
.home {
  text-align: center;
  margin-top: 50px;
}
</style>