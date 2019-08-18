<template>
  <div>
    Index{{list}}
    <button @click="showToast">显示</button>
    <el-button type="primary" @click="send">发送请求</el-button>
  </div>
</template>
<script>
export default {
  data() {
    return {
      list: 1
    };
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