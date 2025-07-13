import { createRouter, createWebHistory } from 'vue-router'
import Home from '@/views/Home.vue'
import ContractDetail from '@/views/ContractDetail.vue'

export default createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/',
      component: Home,
    },
    {
      path: '/contract/:id',
      name: 'ContractDetail',
      component: ContractDetail,
      props: true,
    },
  ],
})
