<template>
  <!-- <ckeditor :editor="editor" v-model="editorData" :config="editorConfig"></ckeditor> -->
<div id="editor">
  hhhh
</div>
</template>

<script>
// ⚠️ NOTE: We don't use @ckeditor/ckeditor5-build-classic any more!
// Since we're building CKEditor from source, we use the source version of ClassicEditor.
import ClassicEditor from "@ckeditor/ckeditor5-editor-classic/src/classiceditor"
// import Essentials from "@ckeditor/ckeditor5-essentials/src/essentials"
// import Bold from "@ckeditor/ckeditor5-basic-styles/src/bold"
// import Italic from "@ckeditor/ckeditor5-basic-styles/src/italic"
// import Paragraph from '@ckeditor/ckeditor5-paragraph/src/paragraph';
import Font from "@ckeditor/ckeditor5-font/src/font"
// import Heading from "@ckeditor/ckeditor5-heading/src/heading";
export default {
  data() {
    return {
      // editor: ClassicEditor,
      editorData: "<p>Content of the editor.</p>",
      editorConfig: {
        plugins: [
          //Essentials,
          // Bold,
          // Italic,
          // Paragraph+
          // Font,
          // Heading
        ],

        toolbar: {
          items: [
            "fontSize",
            "fontFamily",
            "fontColor",
            "fontBackgroundColor"
          ]
        }
      }
    };
  }
};
</script>