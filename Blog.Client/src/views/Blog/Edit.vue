<template>
  <ckeditor :editor="editor" v-model="editorData" :config="editorConfig"></ckeditor>
</template>

<script>
import CKEditor from "@ckeditor/ckeditor5-vue";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import "@ckeditor/ckeditor5-build-classic/build/translations/zh-cn";
export default {
  components: {
    ckeditor: CKEditor.component
  },
  data() {
    return {
      editor: ClassicEditor,
      editorData: "<p>Content of the editor.</p>",
      editorConfig: {
        removePlugins: ["Link", "BlockQuote", "MediaEmbed"],
        ckfinder: {
          // Upload the images to the server using the CKFinder QuickUpload command.
          uploadUrl:
            "/file/upload?command=QuickUpload&type=Images&responseType=json",
          // Define the CKFinder configuration (if necessary).
          options: {
            resourceType: "Images"
          }
        },
        language: "zh-cn"
      }
    };
  },
  created: function() {}
};
</script>