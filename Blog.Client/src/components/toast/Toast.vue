<template>
  <b-toast v-model="visible" :variant="variant" :toaster="toaster"
  :auto-hide-delay="autoHideDelay" :no-auto-hide = "noAutoHide" solid>
      <div slot="toast-title" class="d-flex flex-grow-1 align-items-baseline">
        <!-- <b-img blank blank-color="#ff5555" class="mr-2" width="12" height="12"></b-img> -->
        <strong class="mr-auto">{{title}}</strong>
      </div>{{content}}
    </b-toast>
</template>

<script>
export default {
  name: 'toast',
  data() {
    return {
      visible:true,
      variant:'danger',
      title:'提示',
      content:'',
      toaster:'b-toaster-top-center',
      autoHideDelay:5000,
      noAutoHide:false
    }
  }
}
</script>