import axios from 'axios'
import {isEmpty} from '../../common/index'
const CancelToken = axios.CancelToken
export default class MyUploadAdapter {
  constructor(loader, url, t) {
    // Save Loader instance to update upload progress.
    this.loader = loader
    this.url = url
    this.t = t
  }

  async upload() {
    var that = this
    const file = await this.loader.file
    const t = this.t
    const url = this.url
    if(isEmpty(url)) return
    const data = new FormData()
    const genericError = `${t('Cannot upload file:')} ${file.name}.`
    data.append('file', file)
    if(isEmpty(this.url)) return

    return new Promise((resolve, reject) => {
      axios.post(url, data, {
        'Content-Type':'multipart/form-data',
        cancelToken: new CancelToken(function executor(c) {
          that.cancel = c
          // console.log(c)
          // 这个参数 c 就是CancelToken构造函数里面自带的取消请求的函数，这里把该函数当参数用
        })
      })
      .then(res => {
        if(res && res.success) {
          resolve({
            default: res.data
          })
        }
        else{
          return reject(res && res.message ? res.message : genericError)
        }
      })
      .catch(error => {
        reject(error)
      })
    })
  }

  abort() {
		if (this.cancel) {
			this.cancel()
		}
	}
}