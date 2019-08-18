module.exports = {
  devServer: {
    proxy: {
      'api/*': {
        target: 'https://localhost:44354/',
        changeOrigin: true,
        ws: true,
        pathRewrite: {
        }
      }
    }
  }
}
