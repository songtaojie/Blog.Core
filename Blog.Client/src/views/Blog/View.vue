<template>
  <div>
    <hx-header></hx-header>
    <div>{{userName + id}}</div>
  </div>
</template>

<script>
import HxHeader from '@/components/HxHeader.vue'
export default {
  name:'view',
  data() {
    return {
      userName:this.$route.params.userName,
      id:this.$route.params.id
    }
  },
  components:{
    HxHeader
  },
  methods: {
    findById() {
      var that = this
      that.$api.post(`/api/blog/FindById?userName=${that.userName}&id=${that.id}`)
        .then(res => {
          debugger
          console.log(res)
        })
    }
  },
  watch: {
  },
  created: function () {
    this.findById()
  }
}
</script>
<style lang="scss" scoped>

</style>