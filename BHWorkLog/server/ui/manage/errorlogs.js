/****************************************
***生成器版本：V1.2.3.15644
***创建人：bhfl
***创建时间：2012-10-12 15:06:54
***公司：iCat Studio
***修改人：
***修改时间：2012-10-12 15:06:54
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Manage.ErrorLogsCommon = {
    handlerUrl: 'handler/manage/ErrorLogs.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="errorlogsData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Manage.ErrorLogsEdit = function (isadd, errorlogsData, currentrows) {
    var errorlogs = Sys.DB.ErrorLogs;
    var handerurl = Sys.App.Manage.ErrorLogsCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            errorlogstopwindow.close();
        }
    };
    var errorlogseditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '99%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '错误事件编号', name: errorlogs.errorId,readOnly: true,hidden: true, xtype: 'textfield' },
            {
                fieldLabel: '操作人', name: errorlogs.userid,
                itemId: errorlogs.userid,
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
			{ fieldLabel: '操作人Ip地址', name: errorlogs.writeIp, maxLength: 30, readOnly: true, xtype: 'textfield' },
			{ fieldLabel: '发生时间', name: errorlogs.writeTime, format: Sys.App.Config.datetimeFormat, readOnly: true, xtype: 'datefield' },
			{ fieldLabel: '错误事件内容', height: 220, name: errorlogs.Content, readOnly:true,  xtype: 'textarea' }
		]
    });
    var errorlogstopwindow = Ext.create('Sys.App.TopWindow', {
        title: '系统错误日志',    //窗口名称
        width: 600, //界面初始化时宽、高
        height: 350,    //
        minWidth: 500,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 300, //
        iconCls: Sys.App.Icon.viewrecord,
        items: errorlogseditform,
        listeners: {
            'show': function () {
                var editform = errorlogseditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                }
            }
        }
    });
    errorlogstopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Manage.ErrorLogsMain = function (mainPanel, node) {
    var errorlogs = Sys.DB.ErrorLogs;
    var handerurl = Sys.App.Manage.ErrorLogsCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Manage.ErrorLogsEdit(true, errorlogsdata);
        },
        updaterecord: function () {
            Sys.App.Manage.ErrorLogsEdit(false, errorlogsdata, errorlogsgrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("确定删除该日志吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = errorlogsgrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { errorId: currentselectrows[0].data.errorId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                errorlogsdata.reload();
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
            errorlogsdata.reload();
        }
    };
    
    Ext.define('ErrorLogsModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: errorlogs.errorId, type: 'int' },
			{ name: errorlogs.userid, type: 'string' },
			{ name: errorlogs.writeIp, type: 'string' },
			{ name: errorlogs.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: errorlogs.Content, type: 'auto' }
		]
    });
    var errorlogsdata = Ext.create('Ext.data.Store', {
        model: 'ErrorLogsModel',
        defaultPageSize: Sys.App.Manage.ErrorLogsCommon.listPagesize,
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
    var errorlogsgrid = Ext.create('Sys.App.TabInnerGrid', {
        store: errorlogsdata,
        columns: [
            { xtype: 'rownumberer', width: 35, width: 35 },
			{ text: "错误事件编号", hidden: true, dataIndex: errorlogs.errorId, flex: 1, sortable: true },
			{ text: "操作人", flex: true, dataIndex: errorlogs.userid, renderer: Sys.App.Common.getUserfullName, sortable: true },
            { text: "错误事件内容", width: 400, dataIndex: errorlogs.Content, flex:3, sortable: true },
			{ text: "操作人Ip地址", flex: true, dataIndex: errorlogs.writeIp, sortable: true },
			{ text: "发生时间", flex: true, dataIndex: errorlogs.writeTime, flex: 1, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true }
		],
        tbar: [
			{ text: '刷新', tooltip: '刷新', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
			{ text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord },
            '->', { text: '查看', tooltip: '查看', iconCls: Sys.App.Icon.viewrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }
		],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: errorlogsdata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    errorlogsgrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    errorlogsgrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    errorlogsgrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, errorlogsgrid);
}
