import Vue from 'vue'
import App from './App.vue'
import router from './routers'
import store from './store'

// bootstrap
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import './assets/fonts/iconfont.css'
import './sass/root.scss'
Vue.use(BootstrapVue)
Vue.config.productionTip = false

import api from './api/http.js'
Vue.prototype.$api = api

import toast from './components/toast/index'
Vue.prototype.$toast = toast

import alert from './components/alert/index'
Vue.prototype.$alert = alert

import VueWechatTitle from 'vue-wechat-title'
Vue.use(VueWechatTitle)
// md编辑器
import mavonEditor from 'mavon-editor'
import 'mavon-editor/dist/css/index.css'
// use
Vue.use(mavonEditor)
// 帮助类
import utils from './common'
window.utils = utils
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
