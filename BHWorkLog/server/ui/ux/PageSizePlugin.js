Ext.define("Sys.App.PageSizePlugin", {
    extend: 'Ext.form.ComboBox',
    cookieSizeName: null,
    initComponent: function (config) {
        var me = this;
        me.store = new Ext.data.SimpleStore({
            fields: ['text', 'value'],
            data: [['15条', 15], ['18条', 18], ['20条', 20], ['30条', 30], ['50条', 50], ['100条', 100]]
        });
        me.mode = 'local';
        me.displayField = 'text';
        me.valueField = 'value';
        me.editable = false;
        me.allowBlank = false;
        me.triggerAction = 'all';
        me.fieldLabel = '每页显示';
        me.width = 120;
        me.labelWidth = 60;
        Ext.apply(me, config);
        me.callParent(arguments);
    },
    init: function (paging) {
        paging.on('render', this.onInitView, this);
    },
    onInitView: function (paging) {
        paging.add('-',
            this,
            '-'
        );
        this.setValue(paging.store.pageSize);
        this.on('select', this.onPageSizeChanged, paging);
    },

    onPageSizeChanged: function (combo) {
        this.store.pageSize = parseInt(combo.getValue());
        if (combo.cookieSizeName) {
            var cookieprovider = new Ext.state.CookieProvider();
            Ext.state.Manager.setProvider(cookieprovider);
            cookieprovider.set(combo.cookieSizeName, this.store.pageSize);
        }
        this.moveFirst();
    }
});

