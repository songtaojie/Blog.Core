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

// 默认导出所有方法
export default {
  isString,
  isEmpty,
  isArray,
  isBoolean,
  isFunction,
  isNumber,
  isObject,
  isSimpleObject
}
