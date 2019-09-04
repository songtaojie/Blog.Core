import Vue from 'vue'
import App from './App.vue'
import router from './routers'
import store from './store'
import api from './api/http.js'
// bootstrap
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
// 富文本编辑器
import CKEditor from '@ckeditor/ckeditor5-vue'

import './assets/fonts/iconfont.css'
import './sass/root.scss'

Vue.config.productionTip = false
Vue.prototype.$api = api
Vue.use(BootstrapVue)
Vue.use(CKEditor)
// Vue.use(CkEditor)
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
