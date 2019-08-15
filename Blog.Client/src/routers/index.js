import Vue from 'vue'
import Router from 'vue-rooter'
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
    component:() => import('../views/Home.vue')
  }]
const router = new Router({
  routes
})
export default router
