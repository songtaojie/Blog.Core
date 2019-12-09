<template>
  <div>
    <hx-header></hx-header>
    <div class="container-fluid d-flex mt-1">
      <div class="flex-fill d-flex flex-column flex-sm-row">
          <div class="h-100 w-100 w-sm-70">
            <hx-carousel :Items="ImgItems"></hx-carousel>
          </div>
          <div class="ml-sm-2 mt-2 mt-sm-0 w-100 w-sm-30"></div>
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
      ImgItems:[{
        src:'https://picsum.photos/1024/480/?image=10'
      }]
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