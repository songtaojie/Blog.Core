<template>
  <div>
    <hx-header></hx-header>
    <div class="hx-editor hx-container bg-white py-3 px-2">
      <b-form>
        <b-form-row class="mb-2">
          <b-col class="flex-fill col-sm-8 mb-2 mb-sm-0">
            <b-form-input
              v-model="fromData.title"
              type="text"
              required
              placeholder="文章标题,请控制在100字以内"
            ></b-form-input>
          </b-col>
          <b-col class="col-sm-4">
            <select class="form-control" data-prompt="系统分类" required name="CatId">
              <option value selected="selected">请选择系统分类</option>
            </select>
          </b-col>
        </b-form-row>
        <b-form-row class="mb-2">
          <b-col>
            <ckeditor :editor="editor" v-model="editorData" :config="editorConfig"></ckeditor>
          </b-col>
        </b-form-row>
        <b-form-row>
          <b-col class="d-flex align-items-center">
            <label class="text-left mb-1 blog-category-label">个人分类：</label>
            <hx-input  v-for="item in fromData.personTags" :id="item.Id"
            :key="item.Id"
            v-model.trim="item.value"
            :editable="item.editable"
            @clear="onClear"
             @blur="onInputBlur"
             @enter="onEnter"></hx-input>
            <b-button
              variant="link"
              class="hx-icon-square hx-tag-btn d-flex align-items-center"
              @click="onAddTag"
            >添加分类</b-button>
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
import {guid, isEmpty} from '../../common/index'
export default {
  components: {
    ckeditor: CKEditor.component,
    HxHeader: HxHeader,
    HxInput
  },
  data() {
    return {
      fromData: {
        title: '',
        personTags: [{
          Id:'111',
          value:'ssss',
          editable:false
        }]
      },
      editor: ClassicEditor,
      editorData: '<p>Content of the editor.</p>',
      editorConfig: {
        removePlugins: ['Link', 'BlockQuote', 'MediaEmbed'],
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
  methods:{
    onClear(input) {
     this.removeTag(input, true)
    },
    onInputBlur(input) {
      this.removeTag(input)
    },
    onAddTag() {
      this.fromData.personTags.push({
        Id: guid(),
        editable:true,
        value:''
      })
    },
    onEnter(input) {
      this.removeTag(input)
    },
    removeTag(input, isClear) {
      var id = input.id
      var tags = this.fromData.personTags
      var index = tags.findIndex(p => {return p.Id === id})
      if(index >= 0) {
        var o = tags[index]
        var value = o.value
        if(isClear) {
          this.fromData.personTags.splice(index, 1)
        }else {
          if(isEmpty(o.value)) {
            this.fromData.personTags.splice(index, 1)
          }else {
            var filterTags = tags.filter(p => {return p.value === value})
            if(filterTags.length > 1) {
              this.fromData.personTags.splice(index, 1)
            }else {
              this.fromData.personTags[index].editable = false
              input.blur()
            }
          }
        }
      }
    }
  },
  created: function () { }
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