import Vue from 'vue'
import Router from 'vue-router'
import Index from '../views/Index.vue'
import { isLogin } from '../store/user.js'
Vue.use(Router)
const routes = [{
  path: '',
  meta: {
    title: '这是第一个测试程序'
  },
  component: Index
}, {
  path: '/home',
  meta: {
    auth: true
  },
  component: () => import('../views/Home.vue')
}, {
  name: 'login',
  path: '/login',
  component: () => import('../views/Login.vue')
}, {
  path: '*',
  redirect: '/'
}]
const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})
router.beforeEach((to, from, next) => {
  if (to.meta.auth) {
    debugger
    if (isLogin()) {
      next()
    } else {
      next({
        path: '/login',
        query: {
          redirect: to.fullPath
        }
      })
    }
  } else {
    next()
  }
})
export default router
