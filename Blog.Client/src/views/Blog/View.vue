<template>
  <div>
    <hx-header></hx-header>
    <article class="container bg-white">
      <div>
        <h4 class="article-title">{{detail.title}}</h4>
        <div class="article-meta">
          <span class="muted">
            <i class="fa fa-list-alt"></i>
            <a href="https://cuiqingcai.com/category/technique/python">Python</a>
          </span>
          <span class="muted">
            <i class="fa fa-user"></i>
            <a href="https://cuiqingcai.com/author/cqcre">{{detail.nickName}}</a>
          </span>
          <time class="muted">
            <i class="fa fa-clock-o"></i>
            {{detail.publishDate}}
          </time>
        </div>
      </div>
    </article>
  </div>
</template>

<script>
import HxHeader from '@/components/HxHeader.vue'
export default {
  // name:'view',
  data() {
    return {
      userName: this.$route.params.userName,
      id: this.$route.params.id,
      detail: {}
    }
  },
  components: {
    HxHeader
  },
  methods: {
    findById() {
      var that = this
      that.$api.post(`/api/blog/FindById?userName=${that.userName}&id=${that.id}`)
        .then(res => {
          if (res && res.success) {
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
.article-title {
  font-size: 24px;
  font-weight: normal;
  padding: 20px 0;
  color: #242525;
}
</style>