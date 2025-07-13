import { createRouter, createWebHistory } from 'vue-router'
import Home from '@/views/Home.vue'
import Contracts from '@/views/Contracts.vue'

export default createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/',
      component: Home,
    },
    {
      path: '/contracts',
      component: Contracts,
    },
  ],
})
