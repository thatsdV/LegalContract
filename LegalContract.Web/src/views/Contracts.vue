<template>
  <div class="home">
    <h2>Contracts</h2>
    <div v-if="editingContract || isContractCreation">
      <ContractForm
        :contract="editingContract"
        @save="saveEdit"
        @cancel="cancelEdit"
        @create="createContract"
        :isCreate="isContractCreation"
      />
    </div>
    <ul v-else>
      <li v-for="contract in contracts" :key="contract.id">
        Author: {{ contract.author }}<br />
        Entity Name: {{ contract.entityName }}<br />
        Description: {{ contract.description }}<br />
        Creation Date: {{ contract.creationDate }}<br />
        Update Date: {{ contract.updateDate }}<br />
        <div class="item-actions">
          <button @click="editContract(contract.id)">Edit</button>
          <button @click="deleteContract(contract.id)">Delete</button>
        </div>
      </li>
    </ul>
    <div v-if="!(editingContract || isContractCreation)" class="actions">
      <button @click="$router.push('/')">Back</button>
      <button type="button" @click="onCreateClickHandler">Create new contract</button>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue'
import ContractForm from '@/components/ContractForm.vue'
import type { Contract } from '../types'

export default defineComponent({
  name: 'Contracts',
  components: { ContractForm },
  setup() {
    const contracts = ref<Contract[]>([])
    const editingContract = ref<Contract | null>(null)
    const isContractCreation = ref(false)

    onMounted(async () => {
      try {
        const response = await fetch('https://localhost:7171/api/LegalContract')
        if (!response.ok) throw new Error('Network response was not ok')
        contracts.value = await response.json()
      } catch (error) {
        console.error('Failed to retrieve contracts', error)
      }
    })

    const editContract = (id: number) => {
      const contract = contracts.value.find((c) => c.id === id) || null
      editingContract.value = contract
    }

    const onCreateClickHandler = () => {
      isContractCreation.value = true
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
      isContractCreation.value = false
    }

    const createContract = async (newContract: Contract) => {
      try {
        const response = await fetch('https://localhost:7171/api/LegalContract', {
          method: 'POST',
          body: JSON.stringify(newContract),
          headers: {
            'Content-Type': 'application/json',
          },
        })
        if (!response.ok) throw new Error('Network response was not ok')
        isContractCreation.value = false
        location.reload()
      } catch (error) {
        console.error('Error creating contract:', error)
      }
    }

    const deleteContract = async (id: number) => {
      try {
        if (!confirm('Are you sure you want to delete this contract?')) return
        const response = await fetch(`https://localhost:7171/api/LegalContract?id=${id}`, {
          method: 'DELETE',
        })
        if (!response.ok) throw new Error('Network response was not ok')
        location.reload()
      } catch (error) {
        alert(`The contract could not be deleted`)
        console.error('Error deleting contract', error)
      }
    }

    return {
      contracts,
      editContract,
      deleteContract,
      editingContract,
      saveEdit,
      cancelEdit,
      isContractCreation,
      onCreateClickHandler,
      createContract,
    }
  },
})
</script>

<style scoped>
.home {
  text-align: center;
  margin-top: 50px;
}

.actions {
  display: flex;
  justify-content: center;
  gap: 1rem;
}

ul {
  margin-top: 50px;
  list-style-type: none;
  padding: 0;
}

li {
  text-align: center;
  margin: 10px 0;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  display: flex;
  justify-content: center;
  flex-direction: column;
  gap: 1rem;
}

.item-actions {
  margin-top: 10px;
  display: flex;
  gap: 1rem;

  justify-content: center;
}
</style>
