import Vue from 'vue'
import Vuex from 'vuex'
import auth from './auth.js'
import { AUTH_KEY, TOKEN_KEY } from '../common/constkey.js'
Vue.use(Vuex)
const sessionStoragePlugin = store => {
  // 当 store 初始化后调用
  store.subscribe((mutation, state) => {
    // 每次 mutation 之后调用
    // mutation 的格式为 { type, payload }
    sessionStorage.setItem(AUTH_KEY, JSON.stringify(state.auth))
    sessionStorage.setItem(TOKEN_KEY, state.auth.token)
    console.log(state)
    if (mutation.type === 'CLEAR_AUTH') {
      sessionStorage.removeItem(AUTH_KEY)
      sessionStorage.removeItem(TOKEN_KEY)
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
