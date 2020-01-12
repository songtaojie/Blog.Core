<template>
  <div>
    <hx-header></hx-header>
    <div class="hx-editor hx-container bg-white py-3 px-2">
      <b-form ref="ckeditForm" @submit.stop.prevent="onSubmit" novalidate validated class="was-validated">
        <b-form-row class="mb-2">
          <b-col class="flex-fill col-sm-8 mb-2 mb-sm-0">
            <b-form-input
            class="was-validated"
              v-model="formData.Title"
              type="text"
              required
              placeholder="文章标题,请控制在100字以内"
            ></b-form-input>
          </b-col>
          <b-col class="col-sm-4">
            <hx-select v-model="formData.CategoryId" api="/api/enum/getcategorylist" placeholder="请选择系统分类"></hx-select>
          </b-col>
        </b-form-row>
        <b-form-row class="mb-2">
          <b-col>
            <ckeditor :editor="editor" v-model="formData.Content" :config="editorConfig" @ready="onEditorReady"></ckeditor>
          </b-col>
        </b-form-row>
        <b-form-row  class="mb-2">
          <b-col class="d-flex align-items-center">
            <label class="text-left mb-1 blog-category-label">个人分类：</label>
            <hx-input
              v-for="item in formData.PersonTags"
              :id="item.id"
              :key="item.id"
              v-model.trim="item.name"
              :editable="item.editable"
              @clear="onClear"
              @blur="onInputBlur"
              @enter="onEnter"
            ></hx-input>
            <b-button
              variant="link"
              class="hx-icon-square hx-tag-btn d-flex align-items-center"
              @click="onAddTag"
            >添加分类</b-button>
          </b-col>
        </b-form-row>
        <b-form-row class="mb-2">
          <b-col class="col-sm-9 col-md-5">
            <b-form-group label="">
              <!-- <b-form-checkbox
                v-for="option in tagList"
                v-model="tagSelected"
                :key="option.id"
                :value="option.id"
                @change="onTagChange"
                inline
              >
                {{ option.name }}
              </b-form-checkbox> -->
              <b-form-checkbox-group
                v-model="tagSelected"
                value-field="id"
                text-field="name"
                :options="tagList"
              ></b-form-checkbox-group>
            </b-form-group>
          </b-col>
        </b-form-row>
        <b-form-row  class="mb-2">
          <b-col class="col-sm-4 col-xs-12">
            <hx-select v-model="formData.BlogTypeId" api="/api/enum/GetBlogTypeList" placeholder="请选择文章类型"></hx-select>
          </b-col>
          <b-col class="col-sm-8 col-xs-12">
            <div class="mt-2 ml-2">
              <b-form-checkbox
                v-model="formData.PersonTop"
                value="Y"
                unchecked-value="N"
                inline
              >个人置顶</b-form-checkbox>
              <b-form-checkbox v-model="formData.Private" value="Y" unchecked-value="N" inline>仅自己可见</b-form-checkbox>
              <b-form-checkbox v-model="formData.CanCmt" value="Y" unchecked-value="N" inline>允许评论</b-form-checkbox>
            </div>
          </b-col>
        </b-form-row>
        <b-form-row  class="mb-2">
          <b-col>
            <b-button type="submit" @click="formData.Publish = 'Y'" variant="success">发布文章</b-button>
            <b-button type="submit"  @click="formData.Publish = 'N'" variant="secondary" class="ml-2">保存草稿</b-button>
          </b-col>
        </b-form-row>
      </b-form>
    </div>
  </div>
</template>

<script>
import CKEditor from '@ckeditor/ckeditor5-vue'
import ClassicEditor from '@ckeditor/ckeditor5-build-classic'
import MyUploadAdapter from '@/components/ckeditor/MyUploadAdapter.js'
import '@ckeditor/ckeditor5-build-classic/build/translations/zh-cn'
import '@/sass/hxeditor.scss'
import HxHeader from '@/components/HxHeader.vue'
import HxInput from '@/components/HxInput.vue'
import { guid, isEmpty } from '../../common/index'
import HxSelect from '@/components/HxSelect.vue'
export default {
  components: {
    ckeditor: CKEditor.component,
    HxHeader,
    HxInput,
    HxSelect
  },
  data() {
    return {
      tagList:[],
      tagSelected:[],
      formData: {
        MarkDown:'N',
        BlogTypeId: null,
        CategoryId: null,
        Title: '',
        PersonTop: 'N',
        Private: 'N',
        CanCmt: 'Y',
        Content:'',
        Publish: 'N',
        PersonTags: [{
          id: '111',
          name: 'ssss',
          editable: false
        }]
      },
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
    onSubmit() {
      debugger
      var that = this
      if(this.$refs.ckeditForm.checkValidity()) {
        if(isEmpty(that.formData.Content)) {
          that.$toast.show('请输入博客内容', {
            variant: 'danger'
          })

          return
        }
        that.$api.post('/api/blog/Save', this.formData)
        .then(res => {
          debugger
          console.log(res)
        })
      }
    },
    onClear(input) {
      this.removeTag(input, true)
      var index = this.tagSelected.findIndex(t => {return t === input.id})
      if(index >= 0) {
        this.tagSelected.splice(index, 1)
      }
    },
    onInputBlur(input) {
      this.removeTag(input)
    },
    onAddTag() {
      this.formData.PersonTags.push({
        id: `newData${guid()}`,
        editable: true,
        name: ''
      })
    },
    onEnter(input) {
      this.removeTag(input)
    },
    removeTag(input, isClear) {
      var id = input.id
      var tags = this.formData.PersonTags
      var index = tags.findIndex(p => {return p.id === id})
      if (index >= 0) {
        var o = tags[index]
        var name = o.name
        if (isClear) {
          tags.splice(index, 1)
        } else {
          if (isEmpty(name)) {
            tags.splice(index, 1)
          } else {
            var filterTags = tags.filter(p => {return p.name === name})
            if (filterTags.length > 1) {
              tags.splice(index, 1)
            } else {
              tags.editable = false
              input.blur()
            }
          }
        }
      }
    },
    removeTag2(id) {
      var tags = this.formData.PersonTags
      var index = tags.findIndex(p => {return p.id === id})
      if (index >= 0) {
        var o = tags[index]
        var name = o.name
         if (isEmpty(name)) {
            this.formData.PersonTags.splice(index, 1)
          } else {
            var filterTags = tags.filter(p => {return p.name === name})
            if (filterTags.length > 1) {
              this.formData.PersonTags.splice(index, 1)
            } else {
              this.formData.PersonTags[index].editable = false
            }
          }
      }
    },
    onEditorReady(editor) {
      const url = editor.config.get('file.uploadUrl')
      editor.plugins.get('FileRepository').createUploadAdapter = (loader) => {
          return new MyUploadAdapter(loader, url, editor.t)
      }
    },
    getBlogTagList() {
      var that = this
      this.$api.post('/api/blog/QueryTagList')
      .then(res => {
        if(res && res.success) {
          that.tagList = res.data
        }
      })
    }
  },
  watch: {
    tagSelected:function (newTags, oldTags) {
      var that = this
      var personTags = that.formData.PersonTags
      var tagList = that.tagList
      oldTags.forEach(t => {
        var index = personTags.findIndex(p => p.id === t)
        if(index >= 0) {
          personTags.splice(index, 1)
        }
      })
      newTags.forEach(t => {
        var index = personTags.findIndex(p => p.id === t)
        var o = tagList.find(p => p.id === t)
        if(index < 0) {
          personTags.push(o)
        }
      })
    }
  },
  created: function () {
    this.getBlogTagList()
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