import Vue from 'vue'
import Router from 'vue-router'
import Index from '../views/Home/Index.vue'
const islogin = true
Vue.use(Router)
const routes = [{
  path: '/',
  name:'home',
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
  name:'edit',
  path: '/blog/edit',
  component: () => import('../views/Blog/Edit.vue')
}, {
  name:'view',
  path: '/article/:userName/:id',
  component: () => import('../views/Blog/View.vue')
}]
const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})
router.beforeEach((to, from, next) => {
  if(to.meta.title) {
    document.title = to.meta.title
  }
  if (to.meta.auth) {
    debugger
    if (islogin) {
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
