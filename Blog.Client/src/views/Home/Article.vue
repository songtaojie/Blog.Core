<template>
  <div>
    <div v-for="item in blogList" :key="item.HexId">
      <h4>{{item.Title}}</h4>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      blogList: []
    }
  },
  created() {
    this.getList()
  },
  methods: {
    getList:function () {
      var that = this
      that.$api.post('api/blog/getlist')
      .then(res => {
        debugger
        if(res && res.success) {
          that.blogList = res.data
        }
      })
    }
  }
}
</script>