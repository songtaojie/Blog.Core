<template>
  <div>
    <hx-header></hx-header>
    Index{{list}}
    <button @click="showToast">显示</button>
    <el-button type="primary" @click="send">发送请求</el-button>
  </div>
</template>
<script>
import HxHeader from '../components/HxHeader.vue'
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
      this.$message.success("这是一个成功提示");
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