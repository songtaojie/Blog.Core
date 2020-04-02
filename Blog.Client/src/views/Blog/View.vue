<template>
  <div>
    <hx-header></hx-header>
    <article class="container bg-white mt-2">
      <div class="article-header py-2 px-3">
        <h4 class="article-title">{{detail.title}}</h4>
        <div class="article-meta">
          <span>
            <i class="hx-icon-user mr-1"></i>
            {{detail.nickName}}
          </span>
          <span>
            <i class="hx-icon-clock hx-2x"></i>
            {{dateFormat(detail.publishDate,'yyyy-MM-dd HH:mm')}}
          </span>
          <span>
            <i class="hx-icon-eye hx-2x"></i>
            {{detail.readCount}}浏览
          </span>
          <span>
            <i class="hx-icon-comments-o hx-2x"></i>
            {{detail.readCount}}评论
          </span>
        </div>
      </div>
      <!-- <div v-html="detail.content" class=""></div> -->
      <div class="article-content p-2">
        <md-view v-if="detail.isMarkDown" v-model="detail.content"></md-view>
      </div>
    </article>
  </div>
</template>

<script>
import HxHeader from '@/components/HxHeader.vue'
import MdView from './MdView.vue'
import { dateFormat } from '../../common/'
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
    HxHeader,
    MdView
  },
  methods: {
    dateFormat,
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
.article-header {
  margin-left: -15px;
  margin-right: -15px;
  border-bottom: 1px solid #eee;
  .article-title {
    font-size: 24px;
    font-weight: normal;
    padding: 20px 0;
    color: #242525;
  }
  .article-meta {
    color: #999;
  }
}

.article-content {
  font-size: 16px;
  color: #4d4d4d;
  font-weight: 400;
  line-height: 26px;
  margin: 0 0 16px;
}
</style>