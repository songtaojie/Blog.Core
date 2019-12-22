import Vue from 'vue'
import {
  post,
  ajaxError
} from '../api/http.js'
import {
  isFunction,
  isEmpty
} from '../common'
import { SIGNIN, SIGNOUT, LOGIN_API, AUTH_KEY } from '../common/constkey'
let stateData = {
  isLogin: false,
  token: null,
  tokenExpire: null,
  userId: null,
  userName: null,
  nickName: null,
  avatarUrl: null
}

if (!isEmpty(sessionStorage.getItem(AUTH_KEY))) {
  stateData = JSON.parse(sessionStorage.getItem(AUTH_KEY))
}
const state = Object.assign(stateData)
const auth = {
  state: state,
  getters: {
    auth: state => {
      return {
        isLogin: state.isLogin,
        token: state.token,
        tokenExpire: state.tokenExpire
      }
    },
    user: state => {
      return {
        userId: state.userId,
        userName: state.userName,
        nickName: state.nickName,
        avatarUrl: state.avatarUrl
      }
    }
  },
  mutations: {
    [SIGNIN](state, {
      form,
      success,
      failure
    }) {
      post(LOGIN_API, form).then(r => {
        debugger
        if (r && r.success) {
          this.commit('UPDATE_AUTH', r.data)
          var curTime = new Date()
          var expiredate = new Date(curTime.setSeconds(curTime.getSeconds() + r.data.expires)) // 定义过期时间
          this.commit('saveTokenExpire', expiredate) // 保存过期时间
          window.localStorage.refreshtime = expiredate // 保存刷新时间，这里的和过期时间一致
          if (isFunction(success)) {
            success.call(this, r)
          }
        } else {
          if (isFunction(failure)) {
            failure.call(this, r)
          } else {
            ajaxError(r)
          }
        }
      }).catch(e => {
        if (isFunction(failure)) {
          failure.call(this, e)
        } else {
          ajaxError(e)
        }
      })
    },
    [SIGNOUT](state) {
      window.sessionStorage.removeItem('Token')
      Object.keys(state).forEach(k => Vue.delete(state, k))
    },
    UPDATE_AUTH(state, payload) {
      Object.assign(state, payload, {
        isLogin: true
      })
    },
    UPDATE_TOKEN(state, token) {
      state.token = token
    },
    saveTokenExpire(state, tokenExpire) {
      state.tokenExpire = tokenExpire
    }
  },
  actions: {
    [SIGNIN]({
      commit
    }, payload) {
      commit(SIGNIN, payload)
    },
    [SIGNOUT]({
      commit
    }) {
      commit(SIGNOUT)
    }
  }
}
export default auth