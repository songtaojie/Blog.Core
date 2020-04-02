<template>
  <div class="md-view">
     <mavon-editor
        v-model="value"
        :subfield="false"
        :boxShadow="false"
        defaultOpen="preview"
        :toolbarsFlag="false"
      />
  </div>
</template>

<script>
export default {
   name:'MdView',
  props:{
    value: {
      type: String,
      default: ''
    }
  }
}
</script>

<style  scoped>
.md-view .markdown-body{
   border: none;
}
</style>