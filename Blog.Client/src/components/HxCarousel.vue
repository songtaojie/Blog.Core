
<template>
  <div>
    <b-carousel class="h-100" fade indicators controls label-prev="前一张">
      <b-carousel-slide caption="First slide" img-src="https://picsum.photos/1024/480/?image=10"></b-carousel-slide>
      <b-carousel-slide caption="Second Slide" img-src="https://picsum.photos/1024/480/?image=12"></b-carousel-slide>
      <b-carousel-slide caption="Third Slide" img-src="https://picsum.photos/1024/480/?image=22"></b-carousel-slide>
      <b-carousel-slide caption="Fourth Slide" img-src="https://picsum.photos/1024/480/?image=23"></b-carousel-slide>
    </b-carousel>
  </div>
</template>
<script>
import { mapState } from 'vuex'
export default {
  data() {
    return {
      imgUrl,
      show: false
    }
  },
  methods: {},
  mounted() {}
}
</script>
<style lang="scss" scoped>
</style>