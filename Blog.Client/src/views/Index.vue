<template>
  <div>
    <hx-header></hx-header>
    <div class="container-fluid d-flex">
      <div class="flex-fill">
        <div class="d-flex">
          <div>
            <b-carousel
              class="h-100"
              fade
              indicators
              controls
              label-prev="前一张"
            >
              <b-carousel-slide
                caption="First slide"
                img-src="https://picsum.photos/1024/480/?image=10"
              ></b-carousel-slide>
              <b-carousel-slide
                caption="Second Slide"
                img-src="https://picsum.photos/1024/480/?image=12"
              ></b-carousel-slide>
              <b-carousel-slide
                caption="Third Slide"
                img-src="https://picsum.photos/1024/480/?image=22"
              ></b-carousel-slide>
              <b-carousel-slide
                caption="Fourth Slide"
                img-src="https://picsum.photos/1024/480/?image=23"
              ></b-carousel-slide>
            </b-carousel>
          </div>
        </div>
      </div>
      <div class="w-25"></div>
    </div>
  </div>
</template>
<script>
import HxHeader from "../components/HxHeader.vue";
import toast from "../components/toast/";
export default {
  data() {
    return {
      list: 1
    };
  },
  components: {
    HxHeader
  },
  methods: {
    showToast() {
      debugger;
      toast.show("测试", {
        variant: "danger",
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