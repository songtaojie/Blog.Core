<template>
  <el-form label-width="80px" class="login">
    <el-form-item label="用户名" >
      <el-input prefix-icon="el-icon-user-solid" placeholder="请输入用户名"></el-input>
    </el-form-item>
    <el-form-item label="密码">
      <el-input prefix-icon="el-icon-code-solid" placeholder="请输入密码"></el-input>
    </el-form-item>
  </el-form>
</template>
<style lang="scss" scoped>
  .login{
    width:20rem;
    margin: 3rem auto;
  }
</style>