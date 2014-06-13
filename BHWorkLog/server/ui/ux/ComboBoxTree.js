/*!
* @author caizhiping
* 下拉树
*/
Ext.define('Ext.ux.TreeComboBox', {
    extend: 'Ext.form.field.ComboBox',
    alias: 'widget.comboboxtree',
    xtype: 'comboboxtree',
    store: new Ext.data.ArrayStore({ fields: [], data: [[]] }),
    editable: false,
    listConfig: { resizable: true, minWidth: 100, maxWidth: 350 },
    _idValue: null,
    _txtValue: null,
    storeUrl:null,
    initComponent: function () {
        this.treeObj = new Ext.tree.Panel({
            border: false,
            height: 250,
            width: 350,
            autoScroll: true,
            store: Ext.create('Ext.data.TreeStore', {
                //fields: ['id', 'text', 'leaf', 'urls', 'clazz'],
                autoLoad: false,
                proxy: {
                    type: 'ajax',
                    url: this.storeUrl
                },
                root: {
                    expanded: true,
                    text: '请选择',
                    id: ''
                }
            })
        }),
        this.treeRenderId = Ext.id();
        this.tpl = "<tpl><div id='" + this.treeRenderId + "'></div></tpl>";
        this.callParent(arguments);
        this.on({
            'expand': function () {
                if (!this.treeObj.rendered && this.treeObj && !this.readOnly) {
                    Ext.defer(function () {
                        this.treeObj.render(this.treeRenderId);
                    }, 300, this);
                }
            }
        });
        this.treeObj.on('itemclick', function (view, rec) {
            if (rec) {
                this.setValue(this._txtValue = rec.get('text'));
                this._idValue = rec.get('id');
                this.collapse();
            }
        }, this);
    },
    getValue: function () {//获取id值
        return this._idValue;
    },
    getTextValue: function () {//获取text值
        return this._txtValue;
    },
    setLocalValue: function (txt, id) {//设值
        this._idValue = id;
        this.setValue(this._txtValue = txt);
    }
});