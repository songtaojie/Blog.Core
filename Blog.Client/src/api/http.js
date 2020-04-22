import axios from 'axios'
import QS from 'qs'
import utils from '../common'
import {LOGIN_API, REFRESH_TOKEN_API, TOKEN_TYPE } from '../common/constkey.js'
import router from '../routers'
import toast from '../components/toast/'
import store from '../store'

// 设置环境切换时的接口url前缀
// if (process.env.NODE_ENV === 'development') {
//   axios.defaults.baseURL = 'https://localhost:44354/'
// } else if (process.env.NODE_ENV === 'production') {
//   axios.defaults.baseURL = 'https://localhost:44354/'
// } else if (process.env.NODE_ENV === 'debug') {
//   axios.defaults.baseURL = 'https://localhost:44354/'
// }
// 设置请求超时
axios.defaults.timeout = 30000
// 设置post请求头
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=UTF-8'

export const saveRefreshtime = () => {
  const nowtime = new Date()
  const tokenExpire = store.getters.auth.tokenExpire
  let lastRefreshtime = window.localStorage.refreshtime ? new Date(window.localStorage.refreshtime) : new Date(-1)
  const expiretime = new Date(Date.parse(tokenExpire))

  const refreshCount = 1 // 滑动系数
  if (lastRefreshtime >= nowtime) {
      lastRefreshtime = nowtime > expiretime ? nowtime : expiretime
      lastRefreshtime.setMinutes(lastRefreshtime.getMinutes() + refreshCount)
      window.localStorage.refreshtime = lastRefreshtime
  }else {
      window.localStorage.refreshtime = new Date(-1)
  }
}
function loginSuccess(res) {
  var curTime = new Date()
  var expiredate = new Date(curTime.setSeconds(curTime.getSeconds() + res.data.expires)) // 定义过期时间
  res.data.tokenExpire = expiredate
  store.commit('UPDATE_AUTH', res.data)
  window.localStorage.refreshtime = expiredate // 保存刷新时间，这里的和过期时间一致
}
function toLogin() {
  store.commit('CLEAR_AUTH')
  router.push({
    path: '/login',
    query: {
      redirect: router.path
    }
  })
}

/**
 * 参数过滤
 * @param {*} o 参数
 */
function filterNull (o) {
  for (var key in o) {
    if (utils.isEmpty(o[key])) {
      delete o[key]
    }
    if (utils.isString(o[key])) {
      o[key] = o[key].trim()
    } else if (utils.isObject(o[key])) {
      o[key = filterNull(o[key])]
    } else if (utils.isArray(o[key])) {
      o[key] = filterNull(o[key])
    }
  }

return o
}

/**
 * get请求
 * @param {String} url 请求的api
 * @param {Object} params 传递的参数
 */
export function get (url, params) {
  if (!utils.isEmpty(params)) {
    params = filterNull(params)
  }

return new Promise((resolve, reject) => {
    axios.get(url, {
      params: params
    }).then(res => {
      resolve(res)
    }).catch(err => {
      reject(err)
    })
  })
}

/**
 * post骑牛
 * @param {String} url 请求的url地址
 * @param {Object} params 请求时传递的参数
 */
export function post (url, data, cfg) {
  if (!utils.isEmpty(data)) {
    data = filterNull(data)
  }
  // cfg = cfg || {}
  return new Promise((resolve, reject) => {
    debugger
    // var d = QS.stringify(data)
    axios.post(url, data, cfg).then(res => {
      resolve(res)
    }).catch(err => {
      reject(err)
    })
  })
}
/**
 * put请求
 * @param {String} url 请求的url地址
 * @param {Object} params 请求时传递的参数
 */
export function put (url, params) {
  if (!utils.isEmpty(params)) {
    params = filterNull(params)
  }

  return new Promise((resolve, reject) => {
    axios.put(url, QS.stringify(params)).then(res => {
      resolve(res)
    }).catch(err => {
      reject(err)
    })
  })
}
/**
 * put请求
 * @param {String} url 请求的url地址
 * @param {Object} params 请求时传递的参数
 */
export function del (url, params) {
  if (!utils.isEmpty(params)) {
    params = filterNull(params)
  }

  return new Promise((resolve, reject) => {
    axios.delete(url, QS.stringify(params)).then(res => {
      resolve(res)
    }).catch(err => {
      reject(err)
    })
  })
}

/**
 * 异常的处理方式
 * @param {*} err axios异常对象
 */
export function ajaxError (err) {
  if (err) {
    let r
    if (err.isAxiosError) {
      r = err.response
    } else {
      r = err
    }
    if (r) {
      var result = r.data
      var msg
      if (result && result.hasOwnProperty('success')) {
        if (!result.success) {
          msg = result.message || r.statusText || err.message
        }
      } else {
        msg = r.statusText
      }
      toast.show(msg || '服务器忙，请稍后重试!', {
        variant: 'danger'
      })
    }
  }
}
/**
 * 登录功能
 * @param {Object} form 登录参数
 * @param {Function} success 成功的回调
 * @param {Function} failure 失败的回调
 */
export function login(form, success, failure) {
  if(utils.isEmptyObject(form)) throw new Error('empty login parameters ')
  post(LOGIN_API, form).then(res => {
    if (res && res.success) {
      loginSuccess(res)
      if (utils.isFunction(success)) {
        success.call(this, res)
      }
    } else {
      if (utils.isFunction(failure)) {
        failure.call(this, res)
      } else {
        ajaxError(res)
      }
    }
  }).catch(e => {
    if (utils.isFunction(failure)) {
      failure.call(this, e)
    } else {
      ajaxError(e)
    }
  })
}

axios.interceptors.request.use((req) => {
  var token = store.getters.auth.token
  var tokenExpire = store.getters.auth.tokenExpire
  var curTime = new Date()
  var expiretime = new Date(Date.parse(tokenExpire))
  if (token && tokenExpire && curTime < expiretime) {
    req.headers.Authorization = TOKEN_TYPE + token
  }
  saveRefreshtime()

  return req
}, (e) => {
  return Promise.reject(e)
})

// 返回状态判断(添加响应拦截器)
axios.interceptors.response.use((res) => {
  // 对响应数据做些事
  if (res.data.success === false) {
    return Promise.reject(res)
  }

  return res.data
}, (e) => {
  switch (e.response && e.response.status) {
    case 401:
      var curTime = new Date()
      var refreshtime = new Date(Date.parse(window.localStorage.refreshtime))
      if(window.localStorage.refreshtime && curTime <= refreshtime) {
        var token = store.getters.auth.token
        post(REFRESH_TOKEN_API, {token: token})
        .then(res => {
          if(res && res.success) {
            debugger
            loginSuccess(res)
            e.config.__isRetryRequest = true
            e.config.headers.Authorization = TOKEN_TYPE + res.data.token

            return axios(e.config)
          }
          // 刷新token失败 清除token信息并跳转到登录页面
          toLogin()
        })
      }else {
        toLogin()
      }

      return null
    case 403:
      toast.show('您没有该操作的权限!', {
        variant: 'danger'
      })

      return null
    default:
      break
  }

  return Promise.reject(e)
})

export default {
  get,
  post,
  put,
  del,
  ajaxError,
  login,
  saveRefreshtime
}
