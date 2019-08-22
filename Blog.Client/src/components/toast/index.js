import Vue from 'vue'
import { isEmpty } from '../../utils'
import toast from './Toast.vue'

const ToastConstructor = Vue.extend(toast)

function showToast (content, options) {
  if (isEmpty(content)) return
  const toastDom = new ToastConstructor({
    el: document.createElement('div'),
    data () {
      return {
        content: content,
        ...options
        // ...options
      }
    }
  })
  // 把实例化的toast添加到body中
  document.body.appendChild(toastDom.$el)
  // setTimeout(() => {
  //   toastDom.show = false
  // }, duration)
}

export default showToast
