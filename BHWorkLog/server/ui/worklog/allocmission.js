Sys.App.WorkLog.AllocMissionMain = function (mainPanel, node) {
    var datamodel = Ext.define('WLOGProjectTreeModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: 'text', type: 'string' },
            //{ name: 'class', type: 'string' },
			{ name: 'id', type: 'id' }
        ]
    });
    var wlogprojecttree = Sys.DB.WLOGProjectTree;
    var handerurl = Sys.App.WorkLog.ProjectTreeCommon.handlerUrl;
    var tbarhandler = {

    };
    var wlogprojecttreedata = Ext.create('Ext.data.TreeStore', {
        model: datamodel,
        proxy: {
            type: 'ajax',
            url: handerurl + 'allocmissiontree',
            actionMethods: { read: 'POST' }
        },
        folderSort: true
    });

    var missiongrid = Sys.App.WorkLog.WLOGMissions(datamodel);
    var wlogprojecttreegrid = Ext.create('Ext.tree.Panel', {
        store: wlogprojecttreedata,
        region: 'center',
        width: 400,
        margins : '0 0 0 5',
        viewConfig: {
            plugins: {
                ptype: 'treeviewdragdrop',
                appendOnly: false,
                ddGroup: 'selDD'
            },
            listeners: {
                beforedrop: function (node, data) {
                    console.log(data);
                    data.records[0].set('leaf', true);
                    data.records[0].set('checked', null);
                    return false;
                },
                drop: function (node, data, dropRec, dropPosition) {
                    missiongrid.store.remove(data.records[0]);

                }
            }
        },

        tbar: [
			{ text: '删除所选工作项', tooltip: '删除所选', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord }
        ]
    });


    var wlogprojecttreetopwindow = Ext.create('Ext.window.Window', {
        title: '工作项归档（从左往右栏进行拖动后保存）',    //窗口名称
        width: 830, //界面初始化时宽、高
        height: 350,    //
        minWidth: 830,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 350, //
        border: true,
        layout: {
            type: 'border',
            padding: 5
        },
        buttonAlign: 'center',
        iconCls: Sys.App.Icon.configuration,
        items: [wlogprojecttreegrid, missiongrid],
        buttons: [
            { minWidth: 80, text: '保存' },
            { minWidth: 80, text: '关闭' }
        ]

    });
    wlogprojecttreedata.load();
    wlogprojecttreetopwindow.show();
    
}

Sys.App.WorkLog.WLOGMissions = function (datamodel) {
    var wlogmission = Sys.DB.WLOGMission;
    var handerurl = Sys.App.WorkLog.WLOGMissionCommon.handlerUrl + 'allocmissionall';
    var tbarhandler = {
        
        refreshrecord: function () {
            wlogmissiondata.reload();
        }

    };
    var wlogmissiondata = Ext.create('Ext.data.Store', {
        model: datamodel,
        proxy: {
            type: 'ajax',
            url: handerurl,
            actionMethods: { read: 'POST' },
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        listeners: {
            beforeload: function () {
                Ext.apply(this.proxy.extraParams, this.lastOptions.params);
            }
        },
        autoLoad: true
    });
    var wlogmissiongrid = Ext.create('Sys.App.TabInnerGrid', {
        store: wlogmissiondata,
        region: 'west',
        width: 400,
        tbar: [
            { text: '查询条件', tooltip: '新增子目录/如未选择则新增根项节点', iconCls: Sys.App.Icon.addrecord }, '-',
            { text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord }
        ],
        viewConfig: {
            plugins: [
            Ext.create('Ext.grid.plugin.DragDrop', {
                ddGroup: 'selDD',
                enableDrop: true
            })]
        },

        columns: [
			{ xtype: 'rownumberer', width: 20 },
			{ text: "任务编号", dataIndex: 'id', hidden: true, sortable: true },
			{ text: "任务描述", dataIndex: 'text', flex: 2, sortable: true }
        ]
    });

    return wlogmissiongrid;

}
