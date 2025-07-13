import Vue from 'vue'
import Vuex, { StoreOptions } from 'vuex'

Vue.use(Vuex)

export interface Contract {
  id: number
  // Add other contract properties as needed
  [key: string]: any
}

export interface RootState {
  contracts: Contract[]
}

const store: StoreOptions<RootState> = {
  state: {
    contracts: [],
  },
  mutations: {
    SET_CONTRACTS(state: RootState, contracts: Contract[]) {
      state.contracts = contracts
    },
    ADD_CONTRACT(state: RootState, contract: Contract) {
      state.contracts.push(contract)
    },
    UPDATE_CONTRACT(state: RootState, payload: { index: number; contract: Contract }) {
      Vue.set(state.contracts, payload.index, payload.contract)
    },
    DELETE_CONTRACT(state: RootState, index: number) {
      state.contracts.splice(index, 1)
    },
  },
  actions: {
    createContract({ commit }, contract: Contract) {
      commit('ADD_CONTRACT', contract)
    },
    editContract({ commit }, payload: { index: number; contract: Contract }) {
      commit('UPDATE_CONTRACT', payload)
    },
    removeContract({ commit }, index: number) {
      commit('DELETE_CONTRACT', index)
    },
  },
  getters: {
    getContracts(state: RootState): Contract[] {
      fetch('https://api.example.com/contracts')
        .then((response) => {
          if (!response.ok) {
            throw new Error('Network response was not ok')
          }

          commit('SET_CONTRACTS', response.json())
          return response.json()
        })
        .catch((error) => {
          console.error('Error fetching contracts:', error)
        })
      return state.contracts
    },
    getContractById: (state: RootState) => (id: number) => {
      return state.contracts.find((contract) => contract.id === id)
    },
  },
}

export default new Vuex.Store<RootState>(store)
