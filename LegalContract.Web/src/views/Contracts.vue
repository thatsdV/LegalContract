<template>
  <div class="home">
    <h2>Contracts</h2>
    <div v-if="editingContract">
      <ContractForm :contract="editingContract" @save="saveEdit" @cancel="cancelEdit" />
    </div>
    <ul v-else>
      <li v-for="contract in contracts" :key="contract.id">
        Author: {{ contract.author }}<br />
        Entity Name: {{ contract.entityName }}<br />
        Description: {{ contract.description }}<br />
        Creation Date: {{ contract.creationDate }}<br />
        Update Date: {{ contract.updateDate }}<br />
        <button @click="editContract(contract.id)">Edit</button>
        <button @click="deleteContract(contract.id)">Delete</button>
      </li>
    </ul>
    <router-link to="/">Home</router-link>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue'
import ContractForm from '@/components/ContractForm.vue'

interface Contract {
  id: number
  author: string
  entityName: string
  description: string
  creationDate: string
  updateDate: string
}

export default defineComponent({
  name: 'Contracts',
  components: { ContractForm },
  setup() {
    const contracts = ref<Contract[]>([])
    const editingContract = ref<Contract | null>(null)

    onMounted(async () => {
      try {
        const response = await fetch('https://localhost:7171/api/LegalContract')
        if (!response.ok) throw new Error('Network response was not ok')
        contracts.value = await response.json()
      } catch (error) {
        console.error('Error fetching contracts:', error)
      }
    })

    const editContract = (id: number) => {
      const contract = contracts.value.find((c) => c.id === id) || null
      editingContract.value = contract
    }

    const saveEdit = async (updated: Contract) => {
      try {
        const response = await fetch('https://localhost:7171/api/LegalContract', {
          method: 'PUT',
          body: JSON.stringify(updated),
          headers: {
            'Content-Type': 'application/json',
          },
        })
        if (!response.ok) throw new Error('Network response was not ok')
        editingContract.value = null
        location.reload()
      } catch (error) {
        console.error('Error fetching contracts:', error)
      }
    }

    const cancelEdit = () => {
      editingContract.value = null
    }

    const deleteContract = async (id: number) => {
      try {
        const response = await fetch('https://localhost:7171/api/LegalContract?id=' + id, {
          method: 'DELETE',
        })
        if (!response.ok) throw new Error('Network response was not ok')
        location.reload()
      } catch (error) {
        alert(`The contract could not be deleted`)
        console.error('Error deleting contract', error)
      }
    }

    return { contracts, editContract, deleteContract, editingContract, saveEdit, cancelEdit }
  },
})
</script>

<style scoped>
.home {
  text-align: center;
  margin-top: 50px;
}
</style>
