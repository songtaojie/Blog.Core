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
        target: 'https://localhost:44354/',
        changeOrigin: true,
        ws: true,
        pathRewrite: {}
      }
    }
  }
}
