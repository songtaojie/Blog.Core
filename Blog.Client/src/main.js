import Vue from 'vue'
import App from './App.vue'
import router from './routers'
import api from './api/http.js'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import './assets/fonts/iconfont.css'
Vue.use(ElementUI)
Vue.config.productionTip = false
Vue.prototype.$api = api
new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
