<style lang="scss" scoped>
.login-container {
  background: rgba(239, 233, 242, 0.8) url("../assets/newbg.png") no-repeat
    bottom center;
  background-size: 96rem 25rem;
  .login-wrap {
     padding-top: 6rem;
    .login {
      width: 20rem;
      margin: 0 auto;
    }
  }
}
</style>
<template>
  <div class="login-container h-100">
    <div class="login-wrap">
      <!-- <el-form :model="form" :rules="rules" ref="loginForm" status-icon label-width="80px" class="login" >
        <el-form-item label="用户名" required prop="username">
          <el-input v-model="form.username" prefix-icon="el-icon-user-solid" placeholder="请输入用户名"></el-input>
        </el-form-item>
        <el-form-item label="密码" required prop="password">
          <el-input type="password" v-model="form.password" prefix-icon="el-icon-lock-solid" placeholder="请输入密码"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button @click="login('loginForm')" type="primary" class="w-100">登录</el-button>
        </el-form-item>
      </el-form> -->
    </div>
  </div>
</template>
<script>
import { mapActions } from "vuex"
import { SIGNIN } from '../store/user.js'
export default {
  data(){
    return {
      form:{
        username:'Admin',
        password:'123456'
      },
      rules:{
        username:[{required:true,message:'请输入用户名!',trigger:true}],
        password:[{required:true,message:'请输入密码!',trigger:true}]
      }
    }
  },
  methods:{
    ...mapActions([SIGNIN]),
    login(formName) {
      const _that = this;
      _that.$refs[formName].validate((valid) => {
        if(valid) {
          _that.SIGNIN({
            user:_that.form,
            success:function() {
              _that.$router.replace(_that.$route.query.redirect || '/')
            }
          })
        }
      })
    }
  }
}
</script>
