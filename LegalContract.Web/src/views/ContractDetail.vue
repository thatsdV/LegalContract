<template>
  <div class="contract-detail">
    <h1>Contract Details</h1>
    <ContractView :contract="contract" />
    <div class="actions">
      <router-link :to="{ name: 'edit-contract', params: { id: contract.id } }"
        >Edit Contract</router-link
      >
      <button @click="deleteContract">Delete Contract</button>
    </div>
  </div>
</template>

<script>
// import { mapGetters } from 'vuex';
// import ContractView from '../components/ContractView.vue';

// export default {
//   components: {
//     ContractView
//   },
//   data() {
//     return {
//       contract: null
//     };
//   },
//   computed: {
//     ...mapGetters(['getContractById']),
//   },
//   created() {
//     const contractId = this.$route.params.id;
//     this.contract = this.getContractById(contractId);
//   },
//   methods: {
//     deleteContract() {
//       this.$store.dispatch('deleteContract', this.contract.id);
//       this.$router.push({ name: 'home' });
//     }
//   }
// };
</script>

<style scoped>
.contract-detail {
  padding: 20px;
}
.actions {
  margin-top: 20px;
}
</style>
