import Vue from 'vue'
import toast from './Toast.vue'
const ToastConstructor = Vue.extend(toast)

function showToast (text, duration = 2000) {
  const toastDom = new ToastConstructor({
    el: document.createElement('div'),
    data () {
      return {
        text: text,
        show: true
      }
    }
  })
  // 把实例化的toast添加到body中
  document.body.appendChild(toastDom.$el)

  setTimeout(() => {
    toastDom.show = false
  }, duration)
}

function registryToast () {
  // 将组建注册到vue的原型链中
  Vue.prototype.$toast = showToast
}

export default registryToast
