module.exports = {
  lintOnSave: 'error',
  css: {
    loaderOptions: {
      sass: {
        data: '@import "~@/sass/_variable.scss";'
      }
    }
  },
  devServer: {
    proxy: {
      'api/*': {
        target: 'http://localhost:52909/',
        changeOrigin: true,
        ws: true,
        pathRewrite: {}
      }
    }
  }
}
