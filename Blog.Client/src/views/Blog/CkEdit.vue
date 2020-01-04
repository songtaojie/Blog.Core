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
            <ckeditor :editor="editor" v-model="formData.Content" :config="editorConfig"></ckeditor>
          </b-col>
        </b-form-row>
        <b-form-row  class="mb-2">
          <b-col class="d-flex align-items-center">
            <label class="text-left mb-1 blog-category-label">个人分类：</label>
            <hx-input
              v-for="item in formData.PersonTags"
              :id="item.Id"
              :key="item.Id"
              v-model.trim="item.value"
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
          Id: '111',
          value: 'ssss',
          editable: false
        }]
      },
      editor: ClassicEditor,
      editorConfig: {
        placeholder: '开始编写博客!',
        removePlugins: ['Link', 'BlockQuote', 'MediaEmbed'],
        toolbar: {
          items:['heading', '|', 'bold', 'italic', '|', 'bulletedList', 'numberedList', '|', 'outdent', 'indent', '|', 'imageUpload', 'insertTable', '|', 'undo', 'redo']
        },
        ckfinder: {
          // Upload the images to the server using the CKFinder QuickUpload command.
          uploadUrl:
            '/file/upload?command=QuickUpload&type=Images&responseType=json',
          // Define the CKFinder configuration (if necessary).
          options: {
            resourceType: 'Images'
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
    },
    onInputBlur(input) {
      this.removeTag(input)
    },
    onAddTag() {
      this.formData.PersonTags.push({
        Id: guid(),
        editable: true,
        value: ''
      })
    },
    onEnter(input) {
      this.removeTag(input)
    },
    removeTag(input, isClear) {
      var id = input.id
      var tags = this.formData.PersonTags
      var index = tags.findIndex(p => {return p.Id === id})
      if (index >= 0) {
        var o = tags[index]
        var value = o.value
        if (isClear) {
          this.formData.PersonTags.splice(index, 1)
        } else {
          if (isEmpty(o.value)) {
            this.formData.PersonTags.splice(index, 1)
          } else {
            var filterTags = tags.filter(p => {return p.value === value})
            if (filterTags.length > 1) {
              this.formData.PersonTags.splice(index, 1)
            } else {
              this.formData.PersonTags[index].editable = false
              input.blur()
            }
          }
        }
      }
    }
  },
  created: function () {
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