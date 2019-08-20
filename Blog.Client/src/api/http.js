import axios from 'axios'
import QS from 'qs'
import {
  Message
} from 'element-ui'
import {
  isString,
  isObject,
  isArray,
  isEmpty
} from '../utils'
import router from '../routers'
// 设置环境切换时的接口url前缀
// if (process.env.NODE_ENV === 'development') {
//   axios.defaults.baseURL = 'https://localhost:44354/'
// } else if (process.env.NODE_ENV === 'production') {
//   axios.defaults.baseURL = 'https://localhost:44354/'
// } else if (process.env.NODE_ENV === 'debug') {
//   axios.defaults.baseURL = 'https://localhost:44354/'
// }
// 设置请求超时
axios.defaults.timeout = 5000
// 设置post请求头
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=UTF-8'

axios.interceptors.request.use((r) => {
  if (window.sessionStorage.Token && window.sessionStorage.Token.length >= 128) {
    r.headers.Authorization = 'Bearer ' + window.sessionStorage.Token
  }
  return r
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
  debugger
  if (e.response.status === 401) {
    router.push({
      path: '/login',
      query: {
        redirect: router.path
      }
    })
  }
  return Promise.reject(e)
})

/**
 * 参数过滤
 * @param {*} o 参数
 */
function filterNull (o) {
  for (var key in o) {
    if (isEmpty(o[key])) {
      delete o[key]
    }
    if (isString(o[key])) {
      o[key] = o[key].trim()
    } else if (isObject(o[key])) {
      o[key = filterNull(o[key])]
    } else if (isArray(o[key])) {
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
  if (!isEmpty(params)) {
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
export function post (url, params) {
  if (!isEmpty(params)) {
    params = filterNull(params)
  }
  return new Promise((resolve, reject) => {
    axios.post(url, QS.stringify(params)).then(res => {
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
  if (!isEmpty(params)) {
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
  if (!isEmpty(params)) {
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
  debugger
  if (err) {
    let r
    if (err.isAxiosError) {
      r = err.response
    } else {
      r = err
    }
    if (r) {
      var result = r.data || {}
      if (result.hasOwnProperty('success') && !result.success) {
        const msg = result.message || r.statusText || err.message
        Message.error(msg || '服务器忙，请稍后重试!')
      }
    }
  }
}

export default {
  get,
  post,
  put,
  del,
  ajaxError
}
