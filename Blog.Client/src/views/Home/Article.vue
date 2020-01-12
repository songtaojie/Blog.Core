<template>
  <article class="d-flex flex-column justify-content-start hx-blog">
    <div v-for="item in blogList" :key="item.id" class="mb-2 bg-white blog-item">
      <div class="blog-item-title">
        <h4>{{item.title}}</h4>
      </div>
      <div class="blog-item-summary blog-content-nowrap">
        <p>{{item.homeContent}}</p>
      </div>
      <div class="blog-item-user d-flex justify-content-start align-items-center">
                <div class="hx-avatar _32x32  hx-circle mr-2">
                    <a>
                        <img :src="avatarUrl" />
                    </a>
                </div>
                <div class="mr-1">@(UserContext.GetDisplayName(blog.User))</div>
                <div class="mr-1">@(WebHelper.GetDispayDate(blog.PublishDate))</div>
                <div class="blog-read ml-auto">
                    <a>
                        <span class="hx-text-gray">阅读</span>
                        <span class="hx-text-blue">@blog.ReadCount</span>
                    </a>
                </div>
                <div class="blog-comment ml-2">
                    <a>
                        <span class="hx-text-gray">评论</span>
                        <span class="hx-text-blue">@blog.CmtCount</span>
                    </a>
                </div>
            </div>
    </div>
  </article>
</template>
<script>
export default {
  name: 'HxArticle',
  data() {
    return {
      avatarUrl:'',
      blogList: []
    }
  },
  created() {
    this.getList()
  },
  methods: {
    getList: function () {
      var that = this
      that.$api.post('api/blog/QueryBlogList')
        .then(res => {
          if (res && res.success) {
            that.blogList = res.data
          }
        })
    }
  }
}
</script>
<style lang="scss" scoped>
.hx-blog {
  .blog-item {
    padding: 1rem 1.5rem;
    background: #fff;
    border-bottom: 1px solid #dee2e6;
    width: 100%;
    min-height: 0;
    background: 0 0;
    border-radius: 0;
    box-shadow: none;
    transition: box-shadow 0.2s ease;
    transition: box-shadow 0.2s ease, -webkit-box-shadow 0.1s ease;
    .blog-item-title {
      width: 100%;
    }
    .blog-item-summary {
      margin-bottom: 0.35rem;
      color: #999;
      font-size: 1em;
      line-height: 2.1rem;
    }
    .blog-content-nowrap {
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap;
    }
    .blog-item-user {
      margin: .5rem 0 0;
      color: rgba(0,0,0,.4);
      box-shadow: none;
      transition: color .1s ease;
  }
  }
}
</style>