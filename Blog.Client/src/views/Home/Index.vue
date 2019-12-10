<template>
  <div>
    <hx-header></hx-header>
    <div class="container-fluid d-flex mt-1">
      <div class="flex-fill d-flex flex-column flex-sm-row">
        <div class="h-100 w-100 w-sm-70">
          <hx-carousel :Items="ImgItems"></hx-carousel>
        </div>
        <div class="ml-sm-2 mt-2 mt-sm-0 w-100 w-sm-30 about-me ">
          <h2 class="mx-2 my-3 about-header">关于我</h2>
          <p>网名：演绎~陌路离殇</p>
          <p>职业：Web前端设计师、后端开发</p>
          <p>现居：河南省-郑州市</p>
          <p>Email：stjworkemail@163.com</p>
          <div class="d-none d-lg-flex align-items-center justify-content-around">
            <a class="hx-about-info" href="/" target="_blank" title="网站地址">
              <i class="fa fa-home fa-2x text-info"></i>
            </a>
            <a
              class="about-info"
              href="http://mail.qq.com/cgi-bin/qm_share?t=qm_mailme&email=977601042@qq.com"
              target="_blank"
              title="邮箱"
            >
              <i class="fa fa-envelope fa-2x hx-text-orange"></i>
            </a>
            <a class="about-info" href="#" target="_blank" title="QQ">
              <i class="fa fa-qq fa-2x text-info"></i>
            </a>
            <a class="about-info" href="#" target="_blank" title="微信">
              <i class="fa fa-wechat hx-3x hx-text-green"></i>
            </a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import HxHeader from '@/components/HxHeader.vue'
import HxCarousel from '@/components/HxCarousel.vue'
import toast from '@/components/toast/'
export default {
  data() {
    return {
      list: 1,
      ImgItems: [
        {
          src: 'https://picsum.photos/1024/480/?image=10'
        },
        {
          src: 'https://picsum.photos/1024/480/?image=12'
        }
      ]
    }
  },
  components: {
    HxHeader,
    HxCarousel
  },
  methods: {
    showToast() {
      debugger
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
  .about-me {
    box-shadow: 0px 1px 0px rgba(255,255,255,.1), inset 0px 1px 1px rgba(0,0,0,.7);
    border-radius: 3px;
    background: url(/images/quote-bg.png) no-repeat top right rgba(42,42,42,1);
    overflow: hidden;
    border: 0.25rem solid #fff;
    .about-header {
        font-size: 1.375rem;
        color: #89919a;
    }

    p {
        font-size: 0.75 * $font-size;
        padding-left: 1rem;
        text-shadow: 0px 1px 2px rgba(0,0,0,.5);
        color: #d0d2d4;
        -webkit-animation: animations2 5s ease-in-out 5s;
        -moz-animation: animations2 5s ease-in-out 5s;
        -o-animation: animations2 5s ease-in-out 5s;
        -ms-animation: animations2 5s ease-in-out 5s;
        animation: animations2 5s ease-in-out 5s;
    }

    .about-info {
        display: block;
        overflow: hidden;
        box-shadow: 0px 1px 0px rgba(255,255,255,.1), inset 0px 1px 1px rgba(0,0,0,.7);
        border-radius: 50%;
        padding: 0.5rem 0.6rem;

        &:hover {
            opacity: 0.65;
        }
    }
  }
</style>