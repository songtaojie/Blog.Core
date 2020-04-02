<template>
  <div>
    <hx-header></hx-header>
    <div class="hx-editor hx-container bg-white py-3 px-2">
      <b-form ref="ckeditForm" @submit.stop.prevent="onSubmit" novalidate validated class="was-validated">
        <b-form-row class="mb-2">
          <b-col class="flex-fill col-sm-8 mb-2 mb-sm-0">
            <b-form-input
            class="was-validated"
              v-model="formData.title"
              type="text"
              required
              placeholder="文章标题,请控制在100字以内"
            ></b-form-input>
          </b-col>
          <b-col class="col-sm-4">
            <hx-select v-model="formData.categoryId" api="/api/enum/getcategorylist" placeholder="请选择系统分类"></hx-select>
          </b-col>
        </b-form-row>
        <b-form-row class="mb-2">
          <b-col v-if="isUseMdEdit">
            <md-edit v-model="formData.content" @getHtml="getHtml"></md-edit>
          </b-col>
          <b-col v-else>
            <ck-edit v-model="formData.content"></ck-edit>
          </b-col>
        </b-form-row>
        <b-form-row  class="mb-2">
          <b-col class="d-flex align-items-center">
            <label class="text-left mb-1 blog-category-label">个人分类：</label>
            <hx-input
              v-for="item in formData.personTags"
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
            <hx-select v-model="formData.blogTypeId" api="/api/enum/GetBlogTypeList" placeholder="请选择文章类型"></hx-select>
          </b-col>
          <b-col class="col-sm-8 col-xs-12">
            <div class="mt-2 ml-2">
              <b-form-checkbox
                v-model="formData.personTop"
                value="Y"
                unchecked-value="N"
                inline
              >个人置顶</b-form-checkbox>
              <b-form-checkbox v-model="formData.private" value="Y" unchecked-value="N" inline>仅自己可见</b-form-checkbox>
              <b-form-checkbox v-model="formData.canCmt" value="Y" unchecked-value="N" inline>允许评论</b-form-checkbox>
            </div>
          </b-col>
        </b-form-row>
        <b-form-row  class="mb-2">
          <b-col>
            <b-button type="submit" @click="formData.publish = 'Y'" variant="success">发布文章</b-button>
            <b-button type="submit"  @click="formData.publish = 'N'" variant="secondary" class="ml-2">保存草稿</b-button>
          </b-col>
        </b-form-row>
      </b-form>
    </div>
  </div>
</template>

<script>
import HxHeader from '@/components/HxHeader.vue'
import HxInput from '@/components/HxInput.vue'
import { guid, isEmpty } from '../../common/index'
import HxSelect from '@/components/HxSelect.vue'
export default {
  name:'edit',
  components: {
    CkEdit: resolve => require(['./CkEdit.vue'], resolve),
    MdEdit: resolve => require(['./MdEdit.vue'], resolve),
    HxHeader,
    HxInput,
    HxSelect
  },
  data() {
    var useMdEdit = this.$route.params.useMdEdit
    return {
      tagList:[],
      tagSelected:[],
      isUseMdEdit:true, // 是否是markdown编辑器
      formData: {
        markDown:useMdEdit,
        blogTypeId: null,
        categoryId: null,
        title: '',
        personTop: 'N',
        private: 'N',
        canCmt: 'Y',
        content:'',
        contentHtml:'',
        publish: 'N',
        personTags: [{
          id: 'newData111',
          name: 'ssss',
          editable: false
        }]
      }
    }
  },
  methods: {
    onSubmit() {
      debugger
      var that = this
      if(this.$refs.ckeditForm.checkValidity()) {
        if(isEmpty(that.formData.content)) {
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
      this.formData.personTags.push({
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
      var tags = this.formData.personTags
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
      var tags = this.formData.personTags
      var index = tags.findIndex(p => {return p.id === id})
      if (index >= 0) {
        var o = tags[index]
        var name = o.name
         if (isEmpty(name)) {
            this.formData.personTags.splice(index, 1)
          } else {
            var filterTags = tags.filter(p => {return p.name === name})
            if (filterTags.length > 1) {
              this.formData.personTags.splice(index, 1)
            } else {
              this.formData.personTags[index].editable = false
            }
          }
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
    },
    getHtml(data) {
      this.formData.contentHtml = data
    }
  },
  watch: {
    tagSelected:function (newTags, oldTags) {
      var that = this
      var personTags = that.formData.personTags
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