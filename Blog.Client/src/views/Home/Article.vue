<template>
  <article class="d-flex mt-2 flex-column justify-content-start hx-blog">
    <div v-for="item in blogList" :key="item.id" class="mb-2 bg-white blog-item">
      <div class="blog-item-title">
        <h4>
          <b-link target="_blank" :href="'/article/'+ item.userName+ '/' + item.id">{{item.title}}</b-link>
        </h4>
      </div>
      <div class="blog-item-summary blog-content-nowrap">
        <p>{{item.pureContent}}</p>
      </div>
      <div class="blog-item-user d-flex justify-content-start align-items-center">
        <div class="hx-avatar _32x32 hx-circle mr-2">
          <a>
            <img :src="item.avatarUrl?item.avatarUrl:avatarUrl" />
          </a>
        </div>
        <div class="mr-1">{{isEmpty(item.nickName)?item.userName:item.nickName}}</div>
        <div class="mr-1">{{dateFormat(item.publishDate)}}</div>
        <div class="blog-read ml-auto">
          <a>
            <span class="hx-text-gray">阅读</span>
            <span class="hx-text-blue">{{item.readCount}}</span>
          </a>
        </div>
        <div class="blog-comment ml-2">
          <a>
            <span class="hx-text-gray">评论</span>
            <span class="hx-text-blue">{{item.cmtCount}}</span>
          </a>
        </div>
      </div>
    </div>
  </article>
</template>
<script>
import { dateFormat, isEmpty } from '../../common/'
export default {
  name: 'HxArticle',
  data() {
    return {
      avatarUrl: require('../../assets/images/avatar1_small.jpg'),
      blogList: [],
      queryParam: {
        PageIndex:0,
        PageSize:2,
        SortKey:'',
        SortType:0
      }
    }
  },
  created() {
    this.getList()
  },
  methods: {
    isEmpty,
    dateFormat,
    getList: function () {
      var that = this
      that.$api.post('api/blog/QueryBlogList', that.queryParam)
        .then(res => {
          if (res && res.success) {
            that.blogList = res.data.items
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
      a {
        color: #3d3d3d;
        font-weight: 700;
        &:hover {
          color: #4183c4;
          text-decoration: none;
        }
      }
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
      margin: 0.5rem 0 0;
      color: rgba(0, 0, 0, 0.4);
      box-shadow: none;
      transition: color 0.1s ease;
    }
    .blog-comment,
    .blog-read {
      cursor: pointer;
      &:hover {
        span {
          color: #157dcf;
        }
      }
    }
  }
}
</style>