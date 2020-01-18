import Vue from 'vue'
import App from './App.vue'
import router from './routers'
import store from './store'
import api from './api/http.js'
// bootstrap
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import './assets/fonts/iconfont.css'
import './sass/root.scss'
import toast from './components/toast/index'
Vue.config.productionTip = false
Vue.prototype.$api = api
Vue.prototype.$toast = toast
Vue.use(BootstrapVue)
// md编辑器
import mavonEditor from 'mavon-editor'
import 'mavon-editor/dist/css/index.css'
// use
Vue.use(mavonEditor)
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
