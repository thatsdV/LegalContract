<template>
  <form @submit.prevent="submitForm">
    <h3>Edit Contract</h3>
    <div>
      <label for="author">Author:</label>
      <input id="author" v-model="form.author" required />
    </div>
    <div>
      <label for="entityName">Entity Name:</label>
      <input id="entityName" v-model="form.entityName" required />
    </div>
    <div>
      <label for="description">Description:</label>
      <textarea id="description" v-model="form.description" required></textarea>
    </div>
    <button type="submit">Save</button>
    <button type="button" @click="$emit('cancel')">Cancel</button>
  </form>
</template>

<script lang="ts">
import { defineComponent, type PropType, reactive } from 'vue'

interface Contract {
  id: number
  author: string
  entityName: string
  description: string
  creationDate: string
  updateDate: string
}

export default defineComponent({
  name: 'ContractForm',
  props: {
    contract: {
      type: Object as PropType<Contract>,
      required: true,
    },
  },
  setup(props, { emit }) {
    const form = reactive({ ...props.contract })

    const submitForm = () => {
      emit('save', { ...form })
    }

    return { form, submitForm }
  },
})
</script>

<style scoped>
form {
  display: flex;
  flex-direction: column;
  gap: 10px;
  max-width: 400px;
  margin: 0 auto;
}
</style>
