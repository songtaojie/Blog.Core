import Vue from 'vue'
import {
  post,
  ajaxError
} from '../api/http.js'
import {
  isFunction,
  isEmpty
} from '../utils'
export const SIGNIN = 'SIGNIN' // 登录
export const SIGNOUT = 'SIGNOUT' // 登出
export const LOGIN_API = 'api/login'
const AUTH_KEY = 'storage_auth'

let stateData = {
  isLogin: false,
  token: null,
  userId: null,
  userName: null,
  nickName: null,
  avatarUrl: null
}

const sessionStoragePlugin = store => {
  debugger
  // 当 store 初始化后调用
  store.subscribe((mutation, state) => {
    debugger
    // 每次 mutation 之后调用
    // mutation 的格式为 { type, payload }
    sessionStorage.setItem(AUTH_KEY, JSON.stringify(state))
  })
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
        token: state.token
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
        if (r && r.success) {
          this.commit('UPDATE_AUTH', r.data)
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
  },
  plugins: [sessionStoragePlugin]
}
export default auth