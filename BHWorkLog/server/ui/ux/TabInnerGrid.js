Ext.define('Sys.App.TabInnerGrid', {
    extend: 'Ext.grid.Panel',
    initComponent: function (config) {
        var me = this;
        Ext.apply(me, config);
        me.stripeRows = true;
        me.columnLines = true;
        //me.border = true;
        me.autoScroll = true;
        me.enableColumnResize = true;
        me.loadMask = true;
        me.cls = 'x-define-panel-body';
        me.callParent(arguments);
    }
});