<style lang="scss" scoped>
  .hx-header{
    background-color: #343a40 !important;
  }
</style>
<template>
  <el-menu :default-active="activeIndex" mode="horizontal"
   background-color="#545c64" text-color="#FFF" active-text-color="#ffd04b">
    <el-menu-item index="1">首页</el-menu-item>
  </el-menu>
</template>
<script>
export default {
  data() {
    return {
      activeIndex:'1'
    }
  }
}
</script>