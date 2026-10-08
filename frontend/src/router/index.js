import { createRouter, createWebHistory } from 'vue-router'

// Import your pages
import CustomerCRUD from '../pages/CustomerCRUD.vue'
import SalesRepCRUD from '../pages/SalesRepCRUD.vue'
import HomePage from '../pages/HomePage.vue'
import ProductCRUD from '../pages/ProductCRUD.vue'

const routes = [
  { path: '/', component: HomePage },
  { path: '/customers', component: CustomerCRUD },
  { path: '/salesreps', component: SalesRepCRUD },
  { path: '/products', component: ProductCRUD}
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
