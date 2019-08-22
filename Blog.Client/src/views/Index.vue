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
import showToast from '../components/toast/'
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
      showToast('测试',{
        variant:'info'
      })
      // ToastPlugin.toast('sss',{
      //   title:'测试'
      // })
    },
    send() {
      debugger
       this.$bvToast.toast('Toast body content', {
          title: `Variant `,
          variant: 'primary',
          solid: true,
noAutoHide:true
        })
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