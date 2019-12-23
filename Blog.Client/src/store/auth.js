import {isEmpty} from '../common'
import {AUTH_KEY } from '../common/constkey'
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
    UPDATE_AUTH(state, payload) {
      debugger
      Object.assign(state, payload, {
        isLogin: true
      })
    },
    UPDATE_TOKEN(state, token) {
      debugger
      state.token = token
    },
    UPDATE_EXPIRE(state, tokenExpire) {
      debugger
      state.tokenExpire = tokenExpire
    },
    CLEAR_AUTH(state) {
      Object.assign(state, {
        isLogin: false,
        token: null,
        tokenExpire: null,
        userId: null,
        userName: null,
        nickName: null,
        avatarUrl: null
      })
    }
  },
  actions: {
  }
}
export default auth