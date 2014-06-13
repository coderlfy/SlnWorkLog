Ext.define('GB.view.CKeditor', {
    extend: 'Ext.Component',
    alias: 'widget.ckeditor',
    initComponent: function () {
        this.html = "<textarea id='" + this.getId() + "-input' name='" + this.name + "'></textarea>";
        this.callParent(arguments);
        this.on("boxready", function (t) {
            this.inputEL = Ext.get(this.getId() + "-input");
            this.editor = KindEditor.create('textarea[name="' + this.name + '"]', {
                width: t.getWidth(),
                height: t.getHeight() - 4,
                resizeType: 2,
                uploadJson: '../kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',
                allowPreviewEmoticons: false,
                allowFileManager : true,
                allowImageUpload: true,
                items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template',
                    'code', 'cut', 'copy', 'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft',
                    'justifycenter', 'justifyright', 'justifyfull', 'insertorderedlist', 'insertunorderedlist',
                    'indent', 'outdent', 'subscript', 'superscript', 'clearhtml', 'quickformat',
                    'selectall', '|', 'fullscreen', '/', 'formatblock', 'fontname', 'fontsize', '|',
                    'forecolor', 'hilitecolor', 'bold', 'italic', 'underline', 'strikethrough',
                    'lineheight', 'removeformat', '|', 'image', 'flash', 'media', 'table', 'hr',
                    'emoticons', 'pagebreak', 'anchor', 'link', 'unlink']
            });
        });

        this.on("resize", function (t, w, h) {
            this.editor.resize(w, h - 4)

        });
    },
    setValue: function (value) {
        if (this.editor) {
            this.editor.html(value);
        }
    },
    reset: function () {
        if (this.editor) {
            this.editor.html('');
        }
    },
    setRawValue: function (value) {
        if (this.editor) {
            this.editor.text(value);
        }
    },
    getValue: function () {
        if (this.editor) {
            return this.editor.html();
        } else {
            return ''
        }
    },
    getRawValue: function () {
        if (this.editor) {
            return this.editor.text();
        } else {
            return ''
        }
    }
});

