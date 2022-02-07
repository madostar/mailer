import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/home.vue'
import Inbox from '../views/inbox.vue'
import Message from '../views/message.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/inbox',
    name: 'Inbox',
    component: Inbox
  },
  {
    path: '/message/:id',
    name: 'Message',
    component: Message
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
