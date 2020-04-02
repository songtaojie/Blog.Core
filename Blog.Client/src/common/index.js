/**
 * 判断给定值是否是字符串
 * @param {any} value 要验证的值
 * @returns {Boolean} true代表是字符串，false代表不是字符串
 */
export const isString = function (value) {
  return typeof value === 'string'
}
/**
 * 如果传递的值是JavaScript数组则返回true，否则返回false。
 * @param {Object} value 要测试的目标。
 * @returns {Boolean}
 */
export const isArray = function (value) {
  if ('isArray' in Array) {
    Array.isArray(value)
  } else {
    return toString.call(value) === '[object Array]'
  }
}
/**
 * 判断给定值是否为空
 * @param {any} value 要判断的值
 * @param {Boolean} allowEmptyString 是否允许空字符串
 * @returns {Boolean} true为空，false不为空
 */
export const isEmpty = function (value, allowEmptyString) {
  return value === undefined || value === null || (!allowEmptyString ? value === '' : false) || isArray(value) && value.length === 0
}

/**
 * 判断给定制是否是对象
 * @param {any} value 要验证的值
 * @returns {Boolean} true代表是对象，false代表不是对象
 */
export const isObject = function (value) {
  // eslint-disable-next-line no-useless-call
  if (toString.call(null) === '[object Object]') {
    // 在这里检查ownerDocument以排除DOM节点
    return value !== null && toString.call(value) === '[object Object]' && value.ownerDocument === undefined
  }

  return toString.call(value) === '[object Object]'

}

/**
 * 是否是简单地对象
 * @param {any} value 要验证的值
 * @returns {Boolean} true代表是简单对象，false代表不是简单对象
 */
export const isSimpleObject = function (value) {
  return value instanceof Object && value.constructor === Object
}
/**
 * 监察对象是否为空
 * @param {Object} object 要检查的对象
 * @return {Boolean} true不为空
 */
export const isEmptyObject = function(object) {
  var key
  for (key in object) {
      if (object.hasOwnProperty(key)) {
          return false
      }
  }

  return true
}
/**
 * 是否是boolean
 * @param {any} value 要验证的值
 * @returns {Boolean} true代表是Bool值，false代表不是Bool值
 */
export const isBoolean = function (value) {
  return typeof value === 'boolean'
}

/**
 * 如果传递的值是数字，则返回true。 对于非有限数，返回false。
 * @param {Object} value 要测试的值。
 * @return {Boolean} 如果传递的值是数字，则返回true。 对于非有限数，返回false。
 */
export const isNumber = function (value) {
  return typeof value === 'number' && isFinite(value)
}

/**
 * 如果传递的值是JavaScript函数则返回“true”，否则返回“false”。
 * @param {Object} value 要测试的值.
 * @return {Boolean} 如果传递的值是JavaScript函数则返回“true”，否则返回“false”。
 */
export const isFunction = function (value) {
  if (typeof document !== 'undefined' && typeof document.getElementsByTagName('body') === 'function') {
    return !!value && toString.call(value) === '[object Function]'
  }

  return !!value && typeof value === 'function'
}
/**
 * 生成四位随机的十六进制数字
 */
function s4() {
  return ((1 + Math.random()) * 0x10000 | 0).toString(16).substring(1)
}
export const guid = function() {
  return `${s4() + s4()}-${s4()}-${s4()}-${s4() + s4() + s4()}`
}

export function dateFormat(time, format) {
      var date = new Date(time)
      if(isEmpty(format)) {
        format = 'yyyy-MM-dd'
      }
      var o = {
        'M+' : date.getMonth() + 1, // 月份
        'd+' : date.getDate(), // 日
        'H+' : date.getHours(), // 小时
        'h+' : date.getHours(), // 小时
        'm+' : date.getMinutes(), // 分
        's+' : date.getSeconds(), // 秒
        'q+' : Math.floor((date.getMonth() + 3) / 3), // 季度
        'S'  : date.getMilliseconds() // 毫秒
    }
    if(/(y+)/.test(format)) {
      format = format.replace(RegExp.$1, `${date.getFullYear()}`.substr(4 - RegExp.$1.length))
    }
    for(var k in o) {
        if(new RegExp(`(${k})`).test(format)) {
          format = format.replace(RegExp.$1, RegExp.$1.length === 1 ? o[k] : `00${o[k]}`.substr(`${o[k]}`.length))
        }
    }
    return format
}
// 默认导出所有方法
export default {
  isString,
  isEmpty,
  isArray,
  isBoolean,
  isFunction,
  isNumber,
  isObject,
  isSimpleObject,
  isEmptyObject,
  guid,
  dateFormat
}
