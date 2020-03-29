<template>
<div>
  <b-form-select :value="value" :required="required" :options="items" :placeholder="placeholder"
  :value-field="valueField" :text-field="textField" @change="onChange">
  </b-form-select>
</div>
</template>
<script>
import {isEmpty} from '../common/index'
export default {
  name: 'HxSelect',
  props:{
    value: {
      type: String,
      default: null
    },
    placeholder:{
      type:String,
      default:''
    },
    required: {
      type: Boolean,
      default: true
    },
    api:{
      type:String,
      default:''
    },
    valueField:{
      type:String,
      default:'id'
    },
    textField:{
      type:String,
      default:'name'
    }
  },
  data() {
    return {
      selected: '',
      items:[]
    }
  },
  methods: {
    onChange(val) {
      this.$emit('input', val)
    }
  },
  created() {
    var that = this
    if(!isEmpty(that.api)) {
        that.$api.post(that.api)
        .then(res => {
          if(res && res.success) {
            that.items = res.data
            that.items.splice(0, 0, { id: null, name: that.placeholder || '--请选择--' })
          }
        }).catch(() => {

        })
    }
  }
}
</script>