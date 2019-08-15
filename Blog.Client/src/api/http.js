import axios from 'axios'
import QS from 'qs'
// 设置环境切换时的接口url前缀
if (process.env.NODE_ENV === 'development') {
  axios.defaults.baseURL = 'https://localhost:44354/'
} else if (process.env.NODE_ENV === 'production') {
  axios.defaults.baseURL = 'https://localhost:44354/'
} else if (process.env.NODE_ENV === 'debug') {
  axios.defaults.baseURL = 'https://localhost:44354/'
}
// 设置请求超时
axios.defaults.timeout = 5000
// 设置post请求头
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=UTF-8'

/**
 * get请求
 * @param {String} url 请求的api
 * @param {Object} params 传递的参数
 */
export function get (url, params) {
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
  new Promise((resolve, reject) => {
    axios.post(url, QS.stringify(params)).then(res => {
      resolve(res)
    }).catch(err => {
      reject(err)
    })
  })
}
