
<template>
  <div>
    <b-carousel class="carousel-img-border" fade indicators controls label-prev="前一张">
      <b-carousel-slide v-for="item in ImgItems" :key="item.Id">
        <template v-slot:img>
          <img
            class="d-block img-fluid w-100 h-100"
            :class="{'img-thumbnail':Border}"
            :src="item.src"
          />
        </template>
      </b-carousel-slide>
      <!-- <b-carousel-slide caption="First slide" img-src="https://picsum.photos/1024/480/?image=10"></b-carousel-slide>
      <b-carousel-slide caption="Second Slide" img-src="https://picsum.photos/1024/480/?image=12"></b-carousel-slide>
      <b-carousel-slide caption="Third Slide" img-src="https://picsum.photos/1024/480/?image=22"></b-carousel-slide>
      <b-carousel-slide caption="Fourth Slide" img-src="https://picsum.photos/1024/480/?image=23"></b-carousel-slide>-->
    </b-carousel>
  </div>
</template>
<script>
import { isEmpty } from '../common/'
export default {
  name: 'HxCarousel',
  props: {
    // 轮播图片的集合
    Items: {
      type: Array,
      required: true
    },
    // 是否有边框
    Border: {
      type: Boolean,
      required: false,
      default: true
    }
  },
  data() {
    return {
      show: false
    }
  },
  computed: {
    ImgItems: function () {
      var that = this
      var imgItems = []
      if (isEmpty(that.Items)) return []
      that.Items.forEach(function (v, i) {
        v.Id = i
        imgItems.push(v)
      })

      return imgItems
    }
  }
}
</script>
<style lang="scss" scoped>
</style>