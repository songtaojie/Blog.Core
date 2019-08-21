<template>
  <div>
    <hx-header></hx-header>
    Index{{list}}
    <button @click="showToast">显示</button>
    <b-button @click="send" variant="primary">发送请求</b-button>
  </div>
</template>
<script>
import HxHeader from '../components/HxHeader.vue'
import { ToastPlugin } from 'bootstrap-vue'
export default {
  data() {
    return {
      list: 1
    };
  },
  components:{
    HxHeader
  },
  methods: {
    showToast() {
      debugger
      window.Test = ToastPlugin;
      // ToastPlugin.toast('sss',{
      //   title:'测试'
      // })
    },
    send() {
      const _that = this
      _that.$api
        .get("api/values/1")
        .then(r => {
          debugger;
        })
        .catch(err => {
          _that.$api.ajaxError(err)
        });
    }
  }
  // created() {
  //   this.$api.get('api/values/1')
  //   .then(r=>{
  //     debugger
  //   }).catch(r=>{
  //     debugger
  //   })
  // }
};
</script>