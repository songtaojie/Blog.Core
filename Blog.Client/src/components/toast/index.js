import Vue from 'vue'
import { isEmpty } from '../../common/'
import toast from './Toast.vue'

const ToastConstructor = Vue.extend(toast)

var $toast

function show (content, options) {
  if (isEmpty(content)) return
  options = options || {}
  $toast = new ToastConstructor({
    el: document.createElement('div'),
    data () {
      return {
        content: content,
        ...options
      }
    }
  })
  // 把实例化的toast添加到body中
  document.body.appendChild($toast.$el)
}
function hide () {
  $toast && ($toast.visible = false)
}
export default {
  show,
  hide
}
