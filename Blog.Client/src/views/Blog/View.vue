<template>
  <div>
    <hx-header></hx-header>
    <div class="container">
      <header>
        <h4 class="article-title">
          <b-link> {{detail.title}}</b-link>
        </h4>
      </header>
      <article>

      </article>
    </div>
  </div>
</template>

<script>
import HxHeader from '@/components/HxHeader.vue'
export default {
  // name:'view',
  data() {
    return {
      userName:this.$route.params.userName,
      id:this.$route.params.id,
      detail:{}
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
          if(res && res.success) {
            that.detail = res.data
          }
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
.article-title{
  margin-bottom: 10px;
}
</style>