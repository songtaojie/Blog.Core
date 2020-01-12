<template>
  <div class="ml-sm-1 p-1 mt-sm-0 hx-about-me">
    <h2 class="mx-2 my-3 about-header">关于我</h2>
    <p>网名：演绎~陌路离殇</p>
    <p>职业：Web前端设计师、后端开发</p>
    <p>现居：河南省-郑州市</p>
    <p>Email：stjworkemail@163.com</p>
    <div class="d-none d-md-flex align-items-center justify-content-around">
      <a class="about-info" href="/" target="_blank" title="网站地址">
        <i class="hx-icon-home hx-3x text-info"></i>
      </a>
      <a
        class="about-info"
        href="http://mail.qq.com/cgi-bin/qm_share?t=qm_mailme&email=977601042@qq.com"
        target="_blank"
        title="邮箱"
      >
        <i class="hx-icon-email hx-3x hx-text-orange"></i>
      </a>
      <a class="about-info" href="#" target="_blank" title="QQ">
        <i class="hx-icon-qq hx-3x text-info"></i>
      </a>
      <a class="about-info" href="#" target="_blank" title="微信">
        <i class="hx-icon-weixin hx-3x hx-text-green"></i>
      </a>
    </div>
  </div>
</template>
<script>
export default {
  name: 'card'
}
</script>
<style lang="scss" scoped>
  .hx-about-me {
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
        font-size: 0.75em;
        padding-left: 0.5rem;
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
        i{
          vertical-align: middle;
          text-align: center;
        }
    }
  }
</style>