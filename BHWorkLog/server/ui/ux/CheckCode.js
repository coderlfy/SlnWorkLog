Ext.define('Sys.App.CheckCode', {
    extend: 'Ext.form.field.Text',
    alias: 'widget.checkcode',
    codeUrl: Ext.BLANK_IMAGE_URL, //生成验证码对应的URL
    isLoader: true,
    
    checkcodeWidth: this.checkcodeWidth || 143, //设置验证码宽度
    initComponent: function () {
        var self = this;
        Ext.apply(this, {
            hiddenValue: '',
            listeners: {
                afterrender: function () {
                    this.codeEl = this.bodyEl.createChild({ tag: 'img', title: '点击刷新', src: Ext.BLANK_IMAGE_URL });
                    this.inputEl.setWidth(this.width - this.labelWidth - (this.checkcodeWidth + 10)); //这里减掉验证码的宽度
                    this.codeEl.on('click', this.loadCodeImg, this);
                    this.codeEl.addCls('x-form-code');
                    if (this.isLoader) this.loadCodeImg();
                }
            }
        });
        this.callParent(arguments);
    },
    loadCodeImg: function () {
        this.hiddenValue = Math.random();
        this.codeEl.set({ src: this.codeUrl + '?id=' + this.hiddenValue });
    }
});