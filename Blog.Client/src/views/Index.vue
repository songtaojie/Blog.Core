<template>
  <div>
    <hx-header></hx-header>
    Index{{list}}
    <button @click="showToast">显示</button>
    <b-button @click="hideToast" variant="info">隐藏</b-button>
    <b-button @click="send" variant="primary">发送请求</b-button>
  </div>
</template>
<script>
import HxHeader from '../components/HxHeader.vue'
import toast from '../components/toast/'
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
      toast.show('测试',{
        variant:'danger',
        noAutoHide:true
      })
    },
    hideToast() {
      toast.hide();
    },
    send() {
      // const _that = this
      // _that.$api
      //   .get("api/values/1")
      //   .then(r => {
      //     debugger;
      //   })
      //   .catch(err => {
      //     _that.$api.ajaxError(err)
      //   });
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