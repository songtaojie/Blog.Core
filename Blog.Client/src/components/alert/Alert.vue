<template>
  <!-- <b-toast v-model="visible" :variant="variant" :toaster="toaster"
  :auto-hide-delay="autoHideDelay" :no-auto-hide = "noAutoHide" solid>
      <div slot="toast-title" class="d-flex flex-grow-1 align-items-baseline">
        <strong class="mr-auto">{{title}}</strong>
      </div>{{content}}
  </b-toast>-->
  <!-- class="position-fixed fixed-bottom m-0 rounded-0" -->
  <b-alert
      class="position-fixed fixed-top m-0 rounded-0"
      :show="dismissCountDown"
      dismissible
      :variant="variant"
      @dismissed="dismissCountDown=0"
      @dismiss-count-down="countDownChanged"
  >{{content}}</b-alert>
</template>

<script>
export default {
  name: 'alert',
  data() {
    return {
      visible: true,
      variant: 'info',
      title: '提示',
      content: '',
      toaster: 'b-toaster-top-center',
      autoHideDelay: 5000,
      dismissCountDown: 0,
      noAutoHide: false
    }
  },
  methods:{
    countDownChanged(dismissCountDown) {
      debugger
      this.dismissCountDown = dismissCountDown
    }
  },
  created() {
    this.dismissCountDown = this.autoHideDelay / 1000
  }
}
</script>