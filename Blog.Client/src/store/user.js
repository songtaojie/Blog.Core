import Vue from 'vue'
import { post, ajaxError } from '../api/http.js'
export const SIGNIN = 'SIGNIN'// 登录
export const SIGNOUT = 'SIGNOUT'// 登出
export const LOGIN_API = 'api/login'
const user = {
  state: function () {
    const userJson = window.sessionStorage.getItem('user')
    if (userJson) {
      return JSON.parse(userJson) || {}
    }
    return {}
  },
  mutations: {
    [SIGNIN] (state, user) {
      debugger
      post(LOGIN_API, user).then(r => {
        window.sessionStorage.setItem('Token', r.resultdata)
        window.sessionStorage.setItem('user', JSON.stringify(user))
        Object.assign(state, user)
      }).catch(e => {
        ajaxError(e)
      })
    },
    [SIGNOUT] (state) {
      window.sessionStorage.removeItem('Token')
      window.sessionStorage.removeItem('user')
      Object.keys(state).forEach(k => Vue.delete(state, k))
    }
  },
  actions: {
    [SIGNIN] ({ commit }, user) {
      debugger
      commit(SIGNIN, user)
    },
    [SIGNOUT] ({ commit }) {
      commit(SIGNOUT)
    }
  }

}
export default user

