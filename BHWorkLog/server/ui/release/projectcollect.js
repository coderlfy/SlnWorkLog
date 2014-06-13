/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***创建时间：2013-08-16 17:20:32
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：2013-08-16 17:20:32
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Release.ProjectCollectCommon = {
    handlerUrl: 'handler/release/ProjectCollect.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="projectcollectData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Release.ProjectCollectEdit = function (isadd, projectcollectData, currentrows) {
    var projectcollect = Sys.DB.ProjectCollect;
    var handerurl = Sys.App.Release.ProjectCollectCommon.handlerUrl;
    handerurl += 'update';
    var edithandler = {
        buttonclose: function () {
            projectcollecttopwindow.close();
        },
        buttonsave: function () {
            var editform = projectcollecteditform.getForm();
            if (!editform.isValid())
                return;
            //此处只要form提交，会默认传输到服务端界面上元素的值。
            editform.submit({
                url: handerurl,
                method: 'post',
                success: function (frm, action) {
                    var result = action.result;
                    if (result.success == 'true') {
                        Sys.App.MsgSuccess('保存成功！');
                        projectcollectData.reload();
                        projectcollecttopwindow.close();
                    }
                    else {
                        if (result.msg != null)
                            Sys.App.MsgFailure(result.msg);
                    }
                },
                failure: function (frm, action) {
                    Sys.App.Error(action);
                }
            });
        }
    };
    var projectcollecteditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '工程部汇总Id', hidden: true, name: projectcollect.projectCollectId, xtype: 'textfield' },
            { fieldLabel: '汇总分类Id', hidden: true, name: projectcollect.collectTypeId, xtype: 'textfield' },
            { fieldLabel: '工程项目名称', name: projectcollect.projectItemName, xtype: 'textfield' },
            { fieldLabel: '系统名称', name: projectcollect.systemName, xtype: 'textfield' },
			{ fieldLabel: '归档编号', name: projectcollect.fileNo, xtype: 'textfield' },
            { fieldLabel: '归档时间', name: projectcollect.fileTime, flex: 1, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人', hidden: true, name: projectcollect.writeUser, xtype: 'textfield' },
            { fieldLabel: '录入时刻', name: projectcollect.writeTime, readOnly: true, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人Ip', hidden: true, name: projectcollect.writeIp, xtype: 'textfield' }
        ]
    });
    var projectcollecttopwindow = Ext.create('Sys.App.TopWindow', {
        title: '对工程部发布汇总界面',    //窗口名称
        width: 380, //界面初始化时宽、高
        height: 240,//
        minWidth: 380,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 240, //
        iconCls: Sys.App.Icon.addrecord,
        items: projectcollecteditform,
        buttons: [
             { minWidth: 80, text: '保存', handler: edithandler.buttonsave },
             { minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = projectcollecteditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({ projectCollectId: '1', writeTime: new Date() });
                }
            }
        }
    });
    projectcollecttopwindow.show();
}
/// 查询条件界面的定义
/// <param name="projectcollectgrid">引用了列表框对象</param>
Sys.App.Release.ProjectCollectQuery = function (projectcollectgrid) {
    var projectcollect = Sys.DB.ProjectCollect;
    var queryhandler = {
        buttonclose: function () {
            projectcollecttopwindow.close();
        },
        buttonquery: function () {
            var queryform = projectcollectqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(projectcollectgrid.store.proxy.extraParams, {
                projectCollectId: getvalue(projectcollect.projectCollectId),
                collectTypeId: getvalue(projectcollect.collectTypeId),
                projectItemName: getvalue(projectcollect.projectItemName),
                systemName: getvalue(projectcollect.systemName),
                fileNo: getvalue(projectcollect.fileNo),
                fileTime: getvalue(projectcollect.fileTime),
                writeUser: getvalue(projectcollect.writeUser),
                writeTime: getvalue(projectcollect.writeTime),
                writeIp: getvalue(projectcollect.writeIp)
            });
            projectcollectgrid.down('#pagingToolbar').moveFirst();
            projectcollecttopwindow.close();
        }
    }
    var projectcollectqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right' //标签内容靠左\右
            ///msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '工程部汇总Id', hidden: true, name: projectcollect.projectCollectId, xtype: 'textfield' },
            { fieldLabel: '汇总分类Id', hidden: true, name: projectcollect.collectTypeId, xtype: 'textfield' },
            { fieldLabel: '工程项目名称', name: projectcollect.projectItemName, xtype: 'textfield' },
			{ fieldLabel: '系统名称', name: projectcollect.systemName, xtype: 'textfield' },
			{ fieldLabel: '归档编号', name: projectcollect.fileNo, xtype: 'textfield' },
            { fieldLabel: '归档时间', name: projectcollect.fileTime, flex: 1, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人', hidden: true, name: projectcollect.writeUser, xtype: 'textfield' },
            { fieldLabel: '录入时刻', name: projectcollect.writeTime, xtype: 'datefield', format: Sys.App.Config.dateFormat },
            { fieldLabel: '录入人Ip', hidden: true, name: projectcollect.writeIp, xtype: 'textfield' }
        ]
    });
    var projectcollecttopwindow = Ext.create('Sys.App.TopWindow', {
        title: '对工程部发布汇总查询界面',    //窗口名称
        iconCls: 'icon-queryRecord',
        width: 380, //界面初始化时宽、高
        height: 240,    //
        minWidth: 380,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 240, //
        items: projectcollectqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    projectcollecttopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Release.ProjectCollectMain = function (mainPanel, node) {
    var projectcollect = Sys.DB.ProjectCollect;
    var handerurl = Sys.App.Release.ProjectCollectCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Release.ProjectCollectEdit(true, projectcollectdata);
        },
        updaterecord: function () {
            Sys.App.Release.ProjectCollectEdit(false, projectcollectdata, projectcollectgrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = projectcollectgrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { projectCollectId: currentselectrows[0].data.projectCollectId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                projectcollectdata.reload();
                            }
                            else {
                                if (result.msg != null)
                                    Sys.App.MsgFailure(result.msg);
                            }
                        },
                        failure: function (response, opts) {
                            Sys.App.MsgFailure('"服务端失败，状态码：" ' + response.status);
                        }
                    });
                }
            });
        },
        queryrecord: function () {
            Sys.App.Release.ProjectCollectQuery(projectcollectgrid);
        },
        outputtoexcel: function () {
            Sys.App.ExportExcel(projectcollectgrid, handerurl + 'outputexcel');
        },
        refreshrecord: function () {
            projectcollectdata.reload();
        }
    };
    Ext.define('ProjectCollectModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: projectcollect.projectCollectId, type: 'int' },
			{ name: projectcollect.collectTypeId, type: 'int' },
            { name: projectcollect.projectItemName, type: 'string' },
			{ name: projectcollect.systemName, type: 'string' },
			{ name: projectcollect.fileNo, type: 'string' },
			{ name: projectcollect.fileTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: projectcollect.writeUser, type: 'int' },
			{ name: projectcollect.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: projectcollect.writeIp, type: 'string' }
        ]
    });
    var projectcollectdata = Ext.create('Ext.data.Store', {
        model: 'ProjectCollectModel',
        defaultPageSize: Sys.App.Release.ProjectCollectCommon.listPagesize,
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
    var projectcollectgrid = Ext.create('Sys.App.TabInnerGrid', {
        store: projectcollectdata,
        columns: [
           { xtype: 'rownumberer' },
           { text: "工程部汇总Id", hidden: true, dataIndex: projectcollect.projectCollectId, sortable: true },
           { text: "汇总分类Id", hidden: true, dataIndex: projectcollect.collectTypeId, sortable: true },
           { text: "工程项目名称", flex: true, dataIndex: projectcollect.projectItemName, sortable: true },
           { text: "系统名称", flex: true, dataIndex: projectcollect.systemName, sortable: true },
           { text: "归档编号", flex: true, dataIndex: projectcollect.fileNo, sortable: true },
           { text: "归档时间", flex: true, dataIndex: projectcollect.fileTime, sortable: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat) },
           { text: "录入人", hidden: true, dataIndex: projectcollect.writeUser, sortable: true },
		   { text: "录入时刻", flex: true, dataIndex: projectcollect.writeTime, sortable: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat) },
           { text: "录入人Ip", hidden: true, flex: true, dataIndex: projectcollect.writeIp, sortable: true }
        ],
        tbar: [
			{ text: '查询条件', tooltip: '查询条件', iconCls: Sys.App.Icon.queryrecord, handler: tbarhandler.queryrecord }, '-',
            { text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
			{ text: '编辑', tooltip: '编辑', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',
			{ text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord },
            '->', { text: '导出表格', tooltip: '导出表格', iconCls: Sys.App.Icon.excelexport, handler: tbarhandler.outputtoexcel }
        ],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: projectcollectdata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    projectcollectgrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    projectcollectgrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    projectcollectgrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, projectcollectgrid);
}
