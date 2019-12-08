<template>
  <div>
    <hx-header></hx-header>
    <div class="container-fluid d-flex">
      <div class="flex-fill">
        <div class="d-flex">
          <div>
            <hx-carousel></hx-carousel>
          </div>
        </div>
      </div>
      <div class="w-25"></div>
    </div>
  </div>
</template>
<script>
import HxHeader from '../components/HxHeader.vue'
import { HxCarousel } from "../components/HxCarousel.vue"
import toast from '../components/toast/';
export default {
  data() {
    return {
      list: 1
    };
  },
  components: {
    HxHeader,
    HxCarousel
  },
  methods: {
    showToast() {
      debugger;
      toast.show('测试', {
        variant: 'danger',
        noAutoHide: true
      });
    },
    hideToast() {
      toast.hide();
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
};
</script>