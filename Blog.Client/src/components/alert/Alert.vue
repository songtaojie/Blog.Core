<template>
  <!-- <b-toast v-model="visible" :variant="variant" :toaster="toaster"
  :auto-hide-delay="autoHideDelay" :no-auto-hide = "noAutoHide" solid>
      <div slot="toast-title" class="d-flex flex-grow-1 align-items-baseline">
        <strong class="mr-auto">{{title}}</strong>
      </div>{{content}}
  </b-toast>-->
  <!-- class="position-fixed fixed-bottom m-0 rounded-0" -->
  <b-alert
    class="b-alert"
    :class="alerter"
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
      variant: 'danger',
      title: '提示',
      content: '',
      alerter: 'b-alert-top-center',
      autoHideDelay: 5000,
      dismissCountDown: 0,
      noAutoHide: false
    }
  },
  methods:{
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown
    }
  },
  created() {
    this.dismissCountDown = this.autoHideDelay / 1000
  }
}
</script>
<style lang="scss" scoped>
.b-alert{
    position: absolute;
    max-width: 350px;
    width: 100%;
    left: 0;
    right: 0;
    margin: 0;
}
.b-alert.b-alert-top-center,
.b-alert.b-alert-top-left,
.b-alert.b-alert-top-right{
  top: .5rem;
}
.b-alert.b-alert-bottom-center,
.b-alert.b-alert-bottom-left,
.b-alert.b-alert-bottom-right{
  bottom: .5rem;
}
.b-alert.b-alert-top-center,
.b-alert.b-alert-top-left,
.b-alert.b-alert-bottom-left,
.b-alert.b-alert-bottom-center{
  margin-right: auto;
}
.b-alert.b-alert-top-center,
.b-alert.b-alert-top-right,
.b-alert.b-alert-bottom-right,
.b-alert.b-alert-bottom-center{
  margin-left: auto;
}
</style>