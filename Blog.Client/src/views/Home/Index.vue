<template>
  <div v-wechat-title="this.title">
    <hx-header></hx-header>
    <div class="container-fluid hx-container d-flex mt-1">
      <div class="flex-fill">
        <div class="d-flex flex-column pt-1">
          <div class="flex-fill d-flex flex-column flex-sm-row">
            <div class="h-100 w-100 w-sm-70 hx-carousel">
              <hx-carousel :Items="ImgItems" ></hx-carousel>
            </div>
            <div class="ml-sm-2 mt-2 mt-sm-0 w-100 w-sm-30 hx-carousel">
              <div class="d-flex flex-row flex-sm-column carousel-thumbnail">
                <a class="mb-2 w-50 w-sm-100">
                  <img src="https://picsum.photos/1024/480/?image=10" class="img-thumbnail" />
                </a>
                <a class="w-50 w-sm-100 ml-1 ml-sm-0">
                  <img src="https://picsum.photos/1024/480/?image=12" class="img-thumbnail" />
                </a>
              </div>
            </div>
          </div>
          <div>
            <hx-article></hx-article>
          </div>
        </div>
      </div>
      <div class="d-none d-md-block pt-1">
        <hx-card></hx-card>
      </div>
    </div>
  </div>
</template>
<script>
import HxHeader from '@/components/HxHeader.vue'
import HxCarousel from '@/components/HxCarousel.vue'
import HxCard from './Card'
import HxArticle from './Article'
import toast from '@/components/toast/'
export default {
  data() {
    return {
      title:'海·星の博客',
      list: 1,
      ImgItems: [
        {
          src: 'https://picsum.photos/1024/480/?image=10'
        }
        // {
        //   src: 'https://picsum.photos/1024/480/?image=12'
        // }
      ]
    }
  },
  components: {
    HxHeader,
    HxCarousel,
    HxCard,
    HxArticle
  },
  methods: {
    showToast() {
      toast.show('测试', {
        variant: 'danger',
        noAutoHide: true
      })
    },
    hideToast() {
      toast.hide()
    },
    send() {
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
}
</script>
<style lang="scss" scoped>
.carousel-thumbnail {
  a {
    overflow: hidden;
    height: 100%;

    img {
      opacity: 0.75;
    }

    &:hover {
      img {
        transform: scale(1.1);
        opacity: 1;
      }
    }
  }
}
.carousel-thumbnail a img,
.carousel-item img {
    height: 100%;
    width: 100%;
    -moz-transition: all .5s ease;
    -webkit-transition: all .5s ease;
    -ms-transition: all .5s ease;
    -o-transition: all .5s ease;
    transition: all .5s ease;
    transition: all 0.5s;
}
</style>