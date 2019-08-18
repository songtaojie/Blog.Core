<template>
  <div class="float-wrap">
    <div class="toast">
      <div class="toast-text">我是弹窗</div>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.float-wrap {
  position: absolute;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  pointer-events: none;
  overflow: visible;
  
  align-items: center;
  justify-content: center;
  z-index: 9999;
  background: transparent;
  .toast {
    display: flex;
    flex-direction: column;
    margin: 0;
    box-shadow: 2px 2px 5px 0 rgba(0, 0, 0, 0.12),
      2px 2px 5px 0 rgba(0, 0, 0, 0.08);
    border-color: #e1e1e1;
    border-style: solid;
    border-width: 0;
    color: #fff;
      border-radius: 2px;
      background: rgba(48, 48, 48, 0.8);
      font: 400 14px/18px Roboto, sans-serif;
      padding: 8px;
    .toast-text {
     text-align: center;
    }
  }
  p {
    padding: 12px 22px;
    font-size: 18px;
    
  }
}
</style>
<script>
export default {
  name: "toast"
};
</script>