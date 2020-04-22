
<template>
  <div class="hx-login-wrap">
    <div class="hx-login-content">
      <div class="hx-login-header">
        <b-link href="/" class="text-center mb-1">
          <img src="../assets/images/logo.png" />
        </b-link>
      </div>
      <div class="hx-login-form">
        <b-form ref="form" @submit.prevent="onlogin" validated novalidate>
          <h3 class="text-center mb-3">用户登录</h3>
          <b-form-row class="mb-3">
            <b-input-group>
              <b-input-group-prepend is-text>
                <i class="hx-icon-user"></i>
              </b-input-group-prepend>
              <b-form-input
                placeholder="请输入用户名"
                name="username"
                class="was-validated"
                v-model="form.username"
                required
              ></b-form-input>
              <b-form-invalid-feedback>请输入用户名</b-form-invalid-feedback>
            </b-input-group>
          </b-form-row>
          <b-form-row class="mb-3">
            <b-input-group>
              <b-input-group-prepend is-text>
                <i class="hx-icon-lock"></i>
              </b-input-group-prepend>
              <b-form-input
                type="password"
                v-model="form.password"
                class="was-validated"
                placeholder="请输入密码"
              ></b-form-input>
              <b-form-invalid-feedback>请输入密码</b-form-invalid-feedback>
            </b-input-group>
          </b-form-row>
          <b-form-row class="mb-3">
            <b-col class="my-auto">
              <b-form-checkbox
                name="Remember"
                v-model="form.remember"
                value="true"
                unchecked-value="false"
              >记住我</b-form-checkbox>
            </b-col>
            <b-col class="text-right">
              <b-button type="submit" :disabled="isLoading" variant="success" right>登录</b-button>
            </b-col>
          </b-form-row>
          <div>
            <h4>忘记密码?</h4>
            <p>
              不用担心, 点击
              <a href="javascript:;" class id="forget-password">这里</a>
              找回密码.
            </p>
          </div>
        </b-form>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      isLoading: false,
      form: {
        username: 'Admin',
        password: '123456',
        remember: false
      }
    }
  },
  methods: {
    onlogin() {
      const that = this
      window.from = that.$refs.form
      if (that.$refs.form.checkValidity()) {
        that.isLoading = true
        that.$api.login(that.form, () => {
          that.isLoading = false
          that.$router.replace(that.$route.query.redirect || '/')
        }, (error) => {
          that.$alert.show(error.data.message, {
            variant: 'danger'
          })
          that.isLoading = false
        })
      }
    }
  }
}
</script>
<style lang="scss" scoped>
.hx-login-wrap {
  background: rgba(239, 233, 242, 0.8) url("../assets/images/newbg.png")
    no-repeat bottom center;
  height: 100%;
  background-size: 96rem 25rem;
  .hx-login-content {
    width: 18.75rem;
    padding-top: 5rem;
    margin: 0 auto;
  }
  .hx-login-header {
    a {
      display: block;
    }
  }
  .hx-login-form {
    background-color: #fff;
    margin-bottom: 0px;
    padding: 2rem;
    padding-top: 1rem;
    padding-bottom: 1rem;
  }
}
</style>
