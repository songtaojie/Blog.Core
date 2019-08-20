import Vue from 'vue'
import { post, ajaxError } from '../api/http.js'
import { isFunction } from '../utils'
export const SIGNIN = 'SIGNIN'// 登录
export const SIGNOUT = 'SIGNOUT'// 登出
export const LOGIN_API = 'api/login'

export function isLogin () {
  const token = window.sessionStorage.getItem('Token')
  if (token && token.length >= 128) {
    return true
  }
  return false
}
const user = {
  state: function () {
    const userJson = window.sessionStorage.getItem('user')
    if (userJson) {
      return JSON.parse(userJson) || {}
    }
    return {}
  },
  mutations: {
    [SIGNIN] (state, { user, success, failure }) {
      post(LOGIN_API, user).then(r => {
        window.sessionStorage.setItem('Token', r.resultdata)
        window.sessionStorage.setItem('user', JSON.stringify(user))
        Object.assign(state, user)
        if (isFunction(success)) {
          success.call(this, r)
        }
      }).catch(e => {
        if (isFunction(failure)) {
          failure.call(this, e)
        } else {
          ajaxError(e)
        }
      })
    },
    [SIGNOUT] (state) {
      window.sessionStorage.removeItem('Token')
      window.sessionStorage.removeItem('user')
      Object.keys(state).forEach(k => Vue.delete(state, k))
    }
  },
  actions: {
    [SIGNIN] ({ commit }, { user, success, failure }) {
      commit(SIGNIN, { user, success, failure })
    },
    [SIGNOUT] ({ commit }) {
      commit(SIGNOUT)
    }
  }

}
export default user

