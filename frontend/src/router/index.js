import { createRouter, createWebHistory } from 'vue-router'

// Import your pages
import CustomerCRUD from '../pages/CustomerCRUD.vue'
import HomePage from '../pages/HomePage.vue'

const routes = [
  { path: '/', component: HomePage },
  { path: '/customers', component: CustomerCRUD }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
