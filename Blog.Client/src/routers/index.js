import Vue from 'vue'
import Router from 'vue-router'
import Index from '../views/Index.vue'
Vue.use(Router)
const routes = [{
  path: '',
  meta: {
    title: '这是第一个测试程序'
  },
  component: Index
  }, {
    path:'/home',
    component: () => import('../views/Home.vue')
  },{
    path:'/login',
    component: () => import('../views/Login.vue')
  }]
const router = new Router({
  routes
})
export default router
