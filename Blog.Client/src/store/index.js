import Vue from 'vue'
import Vuex from 'vuex'
import auth from './auth.js'
Vue.use(Vuex)
const AUTH_KEY = 'STORAGE_AUTH_KEY'
const sessionStoragePlugin = store => {
  // 当 store 初始化后调用
  store.subscribe((mutation, state) => {
    // 每次 mutation 之后调用
    // mutation 的格式为 { type, payload }
    sessionStorage.setItem(AUTH_KEY, JSON.stringify(state.auth))
    console.log(state)
    if (mutation.type === 'CLEAR_AUTHEN') {
      sessionStorage.removeItem(AUTH_KEY)
    }
  })
}
export default new Vuex.Store({
  strict: process.env.NODE_ENV !== 'production', // 在非生产环境下，使用严格模式
  modules: {
    auth
  },
  plugins:[sessionStoragePlugin]
})
