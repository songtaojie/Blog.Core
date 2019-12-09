import Vue from 'vue'
import Router from 'vue-router'
import Index from '../views/Home/Index.vue'
// import Edit from '../views/Blog/Edit.vue'
import { isLogin } from '../store/user.js'
Vue.use(Router)
const routes = [{
  path: '',
  meta: {
    title: '这是第一个测试程序'
  },
  component: Index
}, {
  name: 'login',
  path: '/login',
  component: () => import('../views/Login.vue')
}, {
  path: '*',
  redirect: '/'
}, {
  path: '/blog/edit',
  component: () => import('../views/Blog/Edit.vue')
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
