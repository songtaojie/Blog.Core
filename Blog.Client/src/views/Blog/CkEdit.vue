<template>
  <div>
     <ckeditor :editor="editor" :value="value" :config="editorConfig" @ready="onEditorReady"
     :disabled="!editable"
      @input="onEditorInput"></ckeditor>
  </div>
</template>
<script>
import CKEditor from '@ckeditor/ckeditor5-vue'
import ClassicEditor from '@ckeditor/ckeditor5-build-classic'
import MyUploadAdapter from '@/components/ckeditor/MyUploadAdapter.js'
import '@ckeditor/ckeditor5-build-classic/build/translations/zh-cn'
import '@/sass/hxeditor.scss'
import {isEmpty } from '../../common/index'
export default {
  name:'CkEdit',
  props:{
    value: {
      type: String,
      default: ''
    },
    editable: {
      type: Boolean,
      default: true
    }
  },
  components: {
    ckeditor: CKEditor.component
  },
  data() {
    return {
      editor: ClassicEditor,
      editorConfig: {
        placeholder: '开始编写博客!',
        removePlugins: ['Link', 'BlockQuote', 'MediaEmbed', 'CKFinder'],
        // extraPlugins:[MyUploadPlugin],
        toolbar: {
          items:['heading', '|', 'bold', 'italic', '|', 'bulletedList', 'numberedList', '|', 'outdent', 'indent', '|', 'imageUpload', 'insertTable', '|', 'undo', 'redo']
        },
        file: {
          // Upload the images to the server using the CKFinder QuickUpload command.
          uploadUrl:
            '/api/attach/upload?command=QuickUpload&type=Images&responseType=json',
          // Define the CKFinder configuration (if necessary).
          options: {
            resourceType: 'Images',
            onInit: function(finder) {
              debugger
              finder.on('files:choose', evt => {
                console.log('files:choose')
                console.log(evt)
              })
            }
          }
        },
        language: 'zh-cn'
      }
    }
  },
  methods: {
    onEditorReady(editor) {
      const url = editor.config.get('file.uploadUrl')
      if(isEmpty(url)) {
        throw new Error('url is required')
      }
      editor.plugins.get('FileRepository').createUploadAdapter = (loader) => {
          return new MyUploadAdapter(loader, url, editor.t)
      }
    },
    onEditorInput(value) {
     this.$emit('input', value)
    }
  }
}
</script>
<style lang="scss" scoped>
.hx-tag-btn:hover {
  text-decoration: none !important;
}
.hx-icon-square::before {
  font-size: 1.35em;
}
</style>