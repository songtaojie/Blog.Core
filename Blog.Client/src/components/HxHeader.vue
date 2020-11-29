<template>
  <header class="hx-header fixed-top">
    <b-navbar
      toggleable="md"
      class="mx-auto justify-content-center"
      type="dark"
      variant="dark"
    >
      <b-navbar-brand
        href="/"
        class="py-0 hx-3x"
      >海·星の博客</b-navbar-brand>
      <b-navbar-toggle
        target="nav-collapse"
        class="hx-navbar-toggler thin-toggler"
        v-on:click="doClick"
      >
        <span class="hx-navbar-toggler-icon"></span>
      </b-navbar-toggle>
      <b-collapse
        id="nav-collapse"
        @show="colClassShow = true"
        @hidden="colClassShow = false"
        v-on:click="doColClick"
        ref="collapse"
        class="flex-grow-0"
        :class="{'hx-show':colClassShow}"
        v-model="colVisible"
        is-nav
      >
        <b-navbar-nav>
          <b-nav-item
            href="#"
            link-classes="text-white px-3 py-0"
            active
          >网站首页</b-nav-item>
          <b-nav-item
            href="#"
            link-classes="text-white px-3 py-0"
          >关于我</b-nav-item>
          <b-nav-item
            href="#"
            link-classes="text-white px-3 py-0"
          >模板分享</b-nav-item>
          <b-nav-item
            href="#"
            link-classes="text-white px-3 py-0"
          >博客日记</b-nav-item>
        </b-navbar-nav>
      </b-collapse>

      <span
        class="nav-item my-auto p-absolute login"
        v-if="!isLogin"
      >
        <router-link
          to="/login"
          class="text-white hx-1x"
        >
          <i class="hx-icon-login"></i> 登录
        </router-link>
      </span>
      <b-navbar-nav
        v-else
        class="p-absolute"
      >
        <b-nav-dropdown
          toggle-class="p-0 hx-dropdown-toggle"
          menu-class="hx-dropdown-menu"
          :class="{'hx-dropdown':true,'hx-show':dropClassShow}"
          @show="onDropShow"
          @hidden="dropClassShow = false"
          ref="dropdown"
        >
          <template slot="button-content">
            <!-- <em>{{user.username}}</em> -->
            <b-img
              :src="imgUrl"
              rounded="circle"
            ></b-img>
            <!-- <img src="../assets/images/avatar1_small.jpg" alt=""> -->
          </template>
          <b-dropdown-item :to="editRoute">
            <span class="hx-icon-edit mr-1"></span>写博客
          </b-dropdown-item>
          <b-dropdown-item @click="onClick">
            <i class="hx-icon-user mr-1"></i>个人中心
          </b-dropdown-item>
          <b-dropdown-item>
            <i class="hx-icon-cfg mr-1"></i>系统管理
          </b-dropdown-item>
          <b-dropdown-item @click="onSignOut">
            <i class="hx-icon-logout-solid mr-1"></i>退出
          </b-dropdown-item>
        </b-nav-dropdown>
        <!-- <b-nav-item href="#" link-classes="text-white px-3 py-0" active>网站首页</b-nav-item>
          <b-nav-item href="#" link-classes="text-white px-3 py-0">关于我</b-nav-item>
          <b-nav-item href="#" link-classes="text-white px-3 py-0">模板分享</b-nav-item>
        <b-nav-item href="#" link-classes="text-white px-3 py-0">博客日记</b-nav-item>-->
      </b-navbar-nav>
    </b-navbar>
  </header>
</template>
<script>
import { mapState } from 'vuex'
import imgUrl from '../assets/images/avatar1_small.jpg'
export default {
  data () {
    var that = this

    return {
      editRoute: {
        name: 'edit',
        params: {
          useMdEdit: that.$store.getters.user.useMdEdit
        }
      },
      imgUrl,
      colClassShow: false,
      dropClassShow: false,
      colVisible: false,
      screenWidth: document.body.clientWidth // 屏幕宽度
    }
  },
  methods: {
    doClick () {
      console.log(111)
      if (!this.colClassShow) this.colClassShow = !this.colClassShow
    },
    doColClick () {
      console.log('dddd')
    },
    onDropShow () {
      const that = this
      console.log('onDropShow')
      if (that.colVisible) that.colVisible = false
      if (that.screenWidth < 768) that.dropClassShow = true
    },
    onClick () {
      this.$router.push({
        path: '/blog/edit',
        params: {
          Id: '1123213',
          isMd: false
        }
      })
    },
    // 退出
    onSignOut () {
      this.$store.commit('CLEAR_AUTH')
    }
  },
  computed: mapState({
    isLogin: function () {
      return this.$store.getters.auth.isLogin
    }
    // colClass: function () {
    //   return {
    //     'hx-show': this.colClassShow
    //   }
    // }
  }),
  // watch: {
  //   screenWidth () {
  //     const $col = this.$refs.collapse
  //     const $dropdown = this.$refs.dropdown
  //     if ($col.show) $col.show = false
  //     if ($dropdown.visible) $dropdown.visible = false
  //   }
  // },
  mounted () {
    // const $col = this.$refs.collapse
    const that = this
    // const $col = this.$refs.collapse
    const $dropdown = this.$refs.dropdown
    window.onresize = function () {
      that.screenWidth = document.body.clientWidth
      that.colVisible = false
      if ($dropdown && $dropdown.visible) $dropdown.visible = false
    }
  }
}
</script>
<style lang="scss" scoped>
.hx-header {
  line-height: 2.5em;
  height: 3.5rem;
  z-index: 9999;
  &::before {
    background: #000
      linear-gradient(
        to left,
        #4cd964,
        #5ac8fa,
        #007aff,
        #34aadc,
        #5856d6,
        #ff2d55
      );
    content: "";
    height: 5px;
    position: absolute;
    top: 0;
    width: 100%;
    z-index: 10;
  }
  .navbar-nav {
    .nav-link {
      &:hover,
      &:focus,
      &.active {
        // color:rgb(255, 208, 75)
        color: #00c1de !important;
      }
    }
  }
  .login {
    line-height: 2.4rem;
    &:hover,
    &:focus,
    &.active {
      a {
        color: #00c1de !important;
      }
      // color:rgb(255, 208, 75)
    }
  }
  .p-absolute {
    position: absolute;
    cursor: pointer;
    padding-right: 0.75rem;
    right: 0.05rem;
    &.login {
      top: 0.5rem;
    }
  }

  .navbar-collapse {
    &.hx-show {
      width: 100%;
      height: auto;
      background: rgba(0, 0, 0, 0.5);
      position: fixed;
      z-index: 9999;
      top: 3.25rem;
      li {
        background: rgba(18, 183, 222, 0.8);
        display: block;
        font-weight: bold;
        text-align: left;
        min-width: 10rem;
        width: 8.25rem;
        &:last-child {
          padding-bottom: 100%;
        }
      }
      a {
        color: #fff;
        display: block;
        width: 100%;
        text-align: left;
        padding: 0;
        border-bottom: #49ccea 1px solid;
      }
      .navbar-nav {
        .nav-link {
          &:hover,
          &:focus,
          &.active {
            background: #12b7de;
            // color:rgb(255, 208, 75)
            color: #fff !important;
          }
        }
      }
    }
  }
  .hx-icon-logout-solid,
  .hx-icon-cfg {
    font-size: 1.25em;
    margin-left: -2px;
  }
}
@media (min-width: 768px) {
  .hx-header {
    .p-absolute {
      position: static;
      padding-right: 0.75rem;
      right: auto;
    }
  }
}
</style>
