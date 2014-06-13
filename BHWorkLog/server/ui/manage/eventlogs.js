/****************************************
***生成器版本：V1.2.3.15644
***创建人：bhfl
***创建时间：2012-10-12 15:12:19
***公司：iCat Studio
***修改人：bhlfy
***修改时间：2012-11-14 15:12:19
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Manage.EventLogsCommon = {
    handlerUrl: '../handler/EventLogs.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="eventlogsData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Manage.EventLogsEdit = function (isadd, eventlogsData, currentrows) {
    var eventlogs = Sys.DB.EventLogs;
    var handerurl = Sys.App.Manage.EventLogsCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            eventlogstopwindow.close();
        }
    };
    var eventlogseditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 120, //可微调，以适应不同的界面。
            anchor: '99%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '事件编号', name: eventlogs.eventId, readOnly: true, hidden: true, xtype: 'textfield' },
            {
                fieldLabel: '发生事件操作人', name: eventlogs.userid,
                itemId: eventlogs.userid,
                store: Sys.App.Common.storeUser,
                hiddenName: 'userid',   //很关键的配置
                allowBlank: false,
                readOnly: true,
                editable: false,
                queryMode: 'local',
                displayField: 'fullName',
                valueField: 'userid',
                xtype: 'combo'
            },
			{ fieldLabel: '操作人IP地址', name: eventlogs.writeIp, maxLength: 30, readOnly: true, xtype: 'textfield' },
            {
                fieldLabel: '事件类型', name: eventlogs.eventType,
                itemId: eventlogs.eventType,
                store: Sys.App.Common.storeSystemEventType,
                hiddenName: 'eventtype',   //很关键的配置
                allowBlank: false,
                editable: false,
                readOnly: true,
                queryMode: 'local',
                displayField: 'describe',
                valueField: 'eventtype',
                xtype: 'combo'
            },
			{ fieldLabel: '发生时间', name: eventlogs.writeTime, format: Sys.App.Config.datetimeFormat, readOnly: true, xtype: 'datefield' },
			{ fieldLabel: '发生的事件内容描述', height: 150, name: eventlogs.Content, readOnly: true, xtype: 'textarea' }
		]
    });
    var eventlogstopwindow = Ext.create('Sys.App.TopWindow', {
        title: '查看重要业务日志',    //窗口名称
        width: 600, //界面初始化时宽、高
        height: 315,    //
        minWidth: 500,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 190, //
        iconCls: Sys.App.Icon.viewrecord,
        items: eventlogseditform,
        listeners: {
            'show': function () {
                var editform = eventlogseditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                }
            }
        }
    });
    eventlogstopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Manage.EventLogsMain = function (mainPanel, node) {
    
    var eventlogs = Sys.DB.EventLogs;
    var handerurl = Sys.App.Manage.EventLogsCommon.handlerUrl;
    var tbarhandler = {
        updaterecord: function () {
            Sys.App.Manage.EventLogsEdit(false, eventlogsdata, eventlogsgrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("确定删除该日志吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = eventlogsgrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { eventId: currentselectrows[0].data.eventId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                eventlogsdata.reload();
                            }
                            else {
                                if (result.msg != null)
                                    Sys.App.MsgFailure(result.msg);
                            }
                        },
                        failure: function (response, opts) {
                            Sys.App.Error(response);
                        }
                    });
                }
            });
        },
        refreshrecord: function () {
            eventlogsdata.reload();
        }
    };
    Ext.define('EventLogsModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: eventlogs.eventId, type: 'int' },
			{ name: eventlogs.userid, type: 'string' },
			{ name: eventlogs.writeIp, type: 'string' },
			{ name: eventlogs.eventType, type: 'string' },
			{ name: eventlogs.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: eventlogs.Content, type: 'auto' }
		]
    });
    var eventlogsdata = Ext.create('Ext.data.Store', {
        model: 'EventLogsModel',
        defaultPageSize: Sys.App.Manage.EventLogsCommon.listPagesize,
        proxy: {
            type: 'ajax',
            url: handerurl + 'list',
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
    var eventlogsgrid = Ext.create('Sys.App.TabInnerGrid', {
        store: eventlogsdata,
        columns: [
            { xtype: 'rownumberer', width: 35 },
			{ text: "事件编号", hidden: true, dataIndex: eventlogs.eventId, sortable: true },
			{ text: "操作人", dataIndex: eventlogs.userid, renderer: Sys.App.Common.getUserfullName, sortable: true },
            { text: "发生的事件内容描述", dataIndex: eventlogs.Content, flex: 3, sortable: true },
			{ text: "操作人IP地址", dataIndex: eventlogs.writeIp, sortable: true },
			{ text: "事件类型", dataIndex: eventlogs.eventType, renderer: Sys.App.Common.getSystemEventTypeName, sortable: true },
			{ text: "发生时间", flex: 1, dataIndex: eventlogs.writeTime, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true }
		],
        tbar: [
			{ text: '刷新', tooltip: '刷新', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
            { text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord },
            '->', { text: '查看', tooltip: '查看', iconCls: Sys.App.Icon.viewrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }
		],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: eventlogsdata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    eventlogsgrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    eventlogsgrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    eventlogsgrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, eventlogsgrid);
}
