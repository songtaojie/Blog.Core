import Vue from 'vue'
import { isEmpty } from '../../common/'
import alert from './Alert.vue'

const AlertConstructor = Vue.extend(alert)

var $alert

function show (content, options) {
  if (isEmpty(content)) return
  options = options || {}
  $alert = new AlertConstructor({
    el: document.createElement('div'),
    data () {
      return {
        content: content,
        ...options
      }
    }
  })
  // 把实例化的toast添加到body中
  document.body.appendChild($alert.$el)
}
function hide () {
  $alert && ($alert.visible = false)
}
export default {
  show,
  hide
}
