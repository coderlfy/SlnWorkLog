/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhlfy
***创建时间：2013-04-25 19:08:07
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：2013-04-25 19:08:07
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.WorkLog.WLOGPersonLogCommon = {
    handlerUrl: 'handler/worklog/WLOGPersonLog.ashx?action=',
    listStartRecord: 0,
    pagesizeCookieName: 'WLOGPersonLogCommon'
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="wlogpersonlogData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.WorkLog.WLOGPersonLogEdit = function (isadd, wlogpersonlogData, currentrows) {
    var wlogpersonlog = Sys.DB.WLOGPersonLog;
    var handerurl = Sys.App.WorkLog.WLOGPersonLogCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            wlogpersonlogtopwindow.close();
        },
        buttonsave: function () {
            var editform = wlogpersonlogeditform.getForm();
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
                        wlogpersonlogData.reload();
                        wlogpersonlogtopwindow.close();
                    }
                    else {
                        if (result.msg != null) {
                            if (result.msg != 'sessioninvalid')
                                Sys.App.MsgFailure(result.msg);
                            else
                                Sys.App.Manage.ApplicationUserReLogon();
                        }
                    }
                },
                failure: function (frm, action) {
                    Sys.App.Error(action);
                }
            });
        }
    };
    var wlogpersonlogeditform = Ext.create('Ext.form.Panel', {
        baseCls: 'x-plain',
        padding: '5 5 0 5',
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
            {
                xtype: 'fieldset',
                title: '日志表述',
                defaultType: 'textfield',
                layout: 'anchor',
                defaults: {
                    anchor: '100%'
                },
                items: [{
                    xtype: 'container',
                    layout: 'hbox',
                    style: 'margin-bottom:5px',
                    items: [{
                        fieldLabel: '当天日期',
                        name: wlogpersonlog.logDate,
                        allowBlank: false,
                        flex: 1,
                        format: Sys.App.Config.dateFormat, xtype: 'datefield'
                    }, {
                        fieldLabel: '录入人',
                        name: wlogpersonlog.writeUser,
                        store: Sys.App.Common.storeUser,
                        hiddenName: 'userid',
                        allowBlank: false,
                        editable: false,
                        queryMode: 'local',
                        flex: 1,
                        readOnly: true,
                        displayField: 'fullName',
                        valueField: 'userid',
                        xtype: 'combo'
                    }]
                },
			    { fieldLabel: '日志内容', name: wlogpersonlog.logContent, maxLength: 500, height: 100, xtype: 'textareafield' },
			    { fieldLabel: '日志流水号', name: wlogpersonlog.logId, hidden: true, xtype: 'textfield' },
			    { fieldLabel: '工作成果', name: wlogpersonlog.workResult, maxLength: 300, height: 40, xtype: 'textareafield' }

                ]
            },
            {
                xtype: 'fieldset',
                title: '日志状态',
                defaultType: 'textfield',
                layout: 'anchor',
                defaults: {
                    anchor: '100%'
                },
                items: [{
                    xtype: 'container',
                    layout: 'hbox',
                    style: 'margin-bottom:5px',
                    items: [{
                        fieldLabel: '工作完成状态',
                        name: wlogpersonlog.workState,
                        store: Sys.App.BusinessCommon.storeWorkState,
                        hiddenName: wlogpersonlog.workState,
                        allowBlank: false,
                        editable: false,
                        queryMode: 'local',
                        flex: 1,
                        displayField: 'describe',
                        valueField: wlogpersonlog.workState,
                        xtype: 'combo'
                    }, {
                        fieldLabel: '是否提交',
                        name: wlogpersonlog.submited,
                        store: Sys.App.BusinessCommon.storeSubmitedState,
                        hiddenName: wlogpersonlog.submited,
                        allowBlank: false,
                        editable: false,
                        queryMode: 'local',
                        flex: 1,
                        displayField: 'describe',
                        valueField: wlogpersonlog.submited,
                        xtype: 'combo'
                    }
                ]},{
                        xtype: 'container',
                        layout: 'hbox',
                        style: 'margin-bottom:5px',
                        items: [{
                            fieldLabel: '可用性',
                            name: wlogpersonlog.usable,
                            store: Sys.App.Common.storeUsable,
                            hiddenName: wlogpersonlog.usable,
                            allowBlank: false,
                            editable: false,
                            flex: 1,
                            queryMode: 'local',
                            displayField: 'describe',
                            valueField: wlogpersonlog.usable,
                            xtype: 'combo'
                        }, {
                            fieldLabel: '是否在任务项',
                            name: wlogpersonlog.isMission,
                            store: Sys.App.Common.storeUsable,
                            hiddenName: wlogpersonlog.usable,
                            allowBlank: false,
                            editable: false,
                            flex: 1,
                            queryMode: 'local',
                            displayField: 'describe',
                            valueField: wlogpersonlog.usable,
                            xtype: 'combo'
                        }]
                    },{
                        xtype: 'container',
                        layout: 'hbox',
                        style: 'margin-bottom:5px',
                        items: [{
                            fieldLabel: '录入时刻',
                            name: wlogpersonlog.writeTime,
                            readOnly: true,
                            flex: 1,
                            format: Sys.App.Config.datetimeFormat,
                            xtype: 'datefield'
                        }]
                    }
                ]
            }
			//{ fieldLabel: '是否删除', name: wlogpersonlog.deleted, xtype: 'textfield' },
			//{ fieldLabel: '删除时刻', name: wlogpersonlog.deleteTime, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			//{ fieldLabel: '录入人IP地址', name: wlogpersonlog.writeIp, maxLength: 30, xtype: 'textfield' }
        ]
    });
    var wlogpersonlogtopwindow = Ext.create('Sys.App.TopWindow', {
        title: '个人日志信息维护界面',    //窗口名称
        width: 600, //界面初始化时宽、高
        height: 420,    //
        minWidth: 600,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 420, //
        iconCls: Sys.App.Icon.addrecord,
        items: wlogpersonlogeditform,
        buttons: [
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = wlogpersonlogeditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    editform.findField(wlogpersonlog.logDate).disable();
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({
                        logId: '1',
                        logDate: new Date(),
                        writeTime: new Date(),
                        usable: true,
                        submited: true,
                        workState: 2,
                        isMission: true,
                        writeUser: Sys.Paramters.userid
                    });
                }
            }
        }
    });
    wlogpersonlogtopwindow.show();
}
/// 查询条件界面的定义
/// <param name="wlogpersonloggrid">引用了列表框对象</param>
Sys.App.WorkLog.WLOGPersonLogQuery = function (wlogpersonloggrid) {
    var wlogpersonlog = Sys.DB.WLOGPersonLog;
    var applicationuser = Sys.DB.ApplicationUser;
    var queryhandler = {
        buttonclose: function () {
            wlogpersonlogtopwindow.close();
        },
        buttonquery: function () {
            var queryform = wlogpersonlogqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            if (Sys.Paramters.roleId == Sys.App.EnumRoleType.CoderLevel) {
                while (Sys.Paramters.userid != getvalue(applicationuser.userid)) {
                    Sys.App.MsgFailure("您权限不够，不能够查看别人日志，请和管理员联系");
                    return;
                }
            }
            Ext.apply(wlogpersonloggrid.store.proxy.extraParams, {
                writeUser: getvalue(applicationuser.userid),
                logContent: getvalue(wlogpersonlog.logContent),
                logDate: getvalue(wlogpersonlog.logDate),
                workState: getvalue(wlogpersonlog.workState),
                workResult: getvalue(wlogpersonlog.workResult),
                deleteTime: getvalue(wlogpersonlog.deleteTime),
                usable: getvalue(wlogpersonlog.usable),
                submited:getvalue(wlogpersonlog.submited)
            });           
            wlogpersonloggrid.down('#pagingToolbar').moveFirst();
            wlogpersonlogtopwindow.close();
        }
    }
    var wlogpersonlogqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '任务项流水号', name: wlogpersonlog.missionId, xtype: 'textfield',hidden:true },
			{ fieldLabel: '日志流水号', name: wlogpersonlog.logId, xtype: 'textfield', hidden: true },
			{
			    fieldLabel: '录入人',
			    name: applicationuser.userid,
			    store: Sys.App.Common.storeUser,
			    hiddenName: applicationuser.userid,
			    allowBlank: true,
			    editable: false,
			    flex: 1,
			    queryMode: 'local',
			    rawValue:'userid',
			    displayField: 'fullName',
			    valueField: applicationuser.userid,
			    xtype: 'combo'
			},
			{ fieldLabel: '当前项目节点编号', name: wlogpersonlog.projectItem, xtype: 'textfield',hidden:true },
			{ fieldLabel: '日志内容', name: wlogpersonlog.logContent, maxLength: 1000, xtype: 'textfield' },
			{ fieldLabel: '查询日期', name: wlogpersonlog.logDate, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{
			    fieldLabel: '工作完成状态',
			    name: wlogpersonlog.workState,
			    store: Sys.App.BusinessCommon.storeWorkState,
			    hiddenName: wlogpersonlog.workState,
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    flex: 1,
			    displayField: 'describe',
			    valueField: wlogpersonlog.workState,
			    xtype: 'combo'
			},
			{ fieldLabel: '工作成果', name: wlogpersonlog.workResult, maxLength: 600, xtype: 'textfield' },
			{
			    fieldLabel: '是否提交',
			    name: wlogpersonlog.submited,
			    store: Sys.App.BusinessCommon.storeSubmitedState,
			    hiddenName: wlogpersonlog.submited,
			    allowBlank: true,
			    editable: false,
			    queryMode: 'local',
			    flex: 1,
			    displayField: 'describe',
			    valueField: wlogpersonlog.submited,
			    xtype: 'combo'
			},
			{ fieldLabel: '是否删除', name: wlogpersonlog.deleted, xtype: 'textfield', hidden: true },
			{ fieldLabel: '删除时刻', name: wlogpersonlog.deleteTime, format: Sys.App.Config.dateFormat, xtype: 'datefield', hidden: true },
			{
			    fieldLabel: '可用性',
			    name: wlogpersonlog.usable,
			    store: Sys.App.Common.storeUsable,
			    hiddenName: wlogpersonlog.usable,
			    allowBlank: true,
			    editable: false,
			    flex: 1,
			    queryMode: 'local',
			    displayField: 'describe',
			    valueField: wlogpersonlog.usable,
			    xtype: 'combo'
			},
			{ fieldLabel: '录入时刻', name: wlogpersonlog.writeTime, format: Sys.App.Config.dateFormat, xtype: 'datefield', hidden: true },
			{ fieldLabel: '录入人IP地址', name: wlogpersonlog.writeIp, maxLength: 30, xtype: 'textfield', hidden: true }
        ]
    });
    var wlogpersonlogtopwindow = Ext.create('Sys.App.TopWindow', {
        title: '个人日志信息查询界面',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 290,    //
        resizable: false,
        items: wlogpersonlogqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    wlogpersonlogtopwindow.show();
},
///通过角色控制权限
Sys.App.WorkLog.RoleControl = function (rcontrol) {
    var rolestring = '';
    switch (rcontrol) {
        case Sys.App.EnumRoleType.CoderLevel:
            rolestring = Sys.Paramters.userid;
            break;
        default:
            rolestring = '';
            break;
    }
    return rolestring;
},
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.WorkLog.WLOGPersonLogMain = function (mainPanel, node) {
    var wlogpersonlog = Sys.DB.WLOGPersonLog;
    var handerurl = Sys.App.WorkLog.WLOGPersonLogCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.WorkLog.WLOGPersonLogEdit(true, wlogpersonlogdata);
        },
        updaterecord: function () {
            Sys.App.WorkLog.WLOGPersonLogEdit(false, wlogpersonlogdata, wlogpersonloggrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = wlogpersonloggrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { logId: currentselectrows[0].data.logId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                wlogpersonlogdata.reload();
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
            Sys.App.WorkLog.WLOGPersonLogQuery(wlogpersonloggrid);
        },
        outputtoexcel: function(){
            Sys.App.ExportExcel(wlogpersonloggrid, handerurl + 'outputexcel');
        },
        clearquery: function(){
            wlogpersonlogdata.proxy.extraParams = {
                writeUser: Sys.App.WorkLog.RoleControl(Sys.Paramters.roleId)
            };
            wlogpersonloggrid.down('#pagingToolbar').moveFirst();
        },
        refreshrecord: function () {
            wlogpersonlogdata.reload();
        }
    };
    Ext.define('WLOGPersonLogModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: wlogpersonlog.missionId, type: 'int' },
			{ name: wlogpersonlog.logId, type: 'int' },
			{ name: wlogpersonlog.writeUser, type: 'string' },
			{ name: wlogpersonlog.projectItem, type: 'int' },
			{ name: wlogpersonlog.logContent, type: 'string' },
			{ name: wlogpersonlog.logDate, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogpersonlog.workState, type: 'int' },
			{ name: wlogpersonlog.workResult, type: 'string' },
			{ name: wlogpersonlog.submited, type: 'bool' },
			{ name: wlogpersonlog.isMission, type: 'bool' },
			{ name: wlogpersonlog.deleted, type: 'bool' },
			{ name: wlogpersonlog.deleteTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogpersonlog.usable, type: 'bool' },
			{ name: wlogpersonlog.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogpersonlog.writeIp, type: 'string' }
        ]
    });
    var wlogpersonlogdata = Ext.create('Ext.data.Store', {
        model: 'WLOGPersonLogModel',
        defaultPageSize: Sys.App.Common.getCookie(Sys.App.WorkLog.WLOGPersonLogCommon.pagesizeCookieName),
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
        }
    });
    var wlogpersonloggrid = Ext.create('Sys.App.TabInnerGrid', {
        store: wlogpersonlogdata,
        columns: [
			{ xtype: 'rownumberer', width: 35 },
			{ text: "任务项流水号", dataIndex: wlogpersonlog.missionId,hidden:true, sortable: true },
			//{ text: "日志流水号", dataIndex: wlogpersonlog.logId, sortable: true },
			{ text: "日志内容", dataIndex: wlogpersonlog.logContent,flex:2, sortable: true },
			{ text: "录入人", dataIndex: wlogpersonlog.writeUser, renderer: Sys.App.Common.getUserfullName, sortable: true },
			{ text: "当天日期", dataIndex: wlogpersonlog.logDate,flex:1, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat), sortable: true },
			{ text: "工作完成状态", dataIndex: wlogpersonlog.workState, renderer: Sys.App.BusinessCommon.getWorkStateName, sortable: true },
			{ text: "工作成果", dataIndex: wlogpersonlog.workResult,hidden:true, sortable: true },
			{ text: "是否提交", dataIndex: wlogpersonlog.submited, renderer: Sys.App.BusinessCommon.getSubmitedStateName, sortable: true },
			//{ text: "是否删除", dataIndex: wlogpersonlog.deleted, sortable: true },
			//{ text: "删除时刻", dataIndex: wlogpersonlog.deleteTime, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true },
			{ text: "可用性", dataIndex: wlogpersonlog.usable, renderer: Sys.App.Common.getUsableName, sortable: true },
			{ text: "录入人IP地址", dataIndex: wlogpersonlog.writeIp, hidden:true, sortable: true },
			{ text: "录入时刻", dataIndex: wlogpersonlog.writeTime, flex: 1, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true }
        ],
        tbar: [
			{ text: '查询条件', tooltip: '查询条件', iconCls: Sys.App.Icon.queryrecord, handler: tbarhandler.queryrecord }, '-',
            { text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
            { text: '新增', tooltip: '新增', iconCls: Sys.App.Icon.addrecord, handler: tbarhandler.addrecord }, '-',
			{ text: '编辑', tooltip: '编辑', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',
			{ text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord },
            '->',{ text: '清除查询条件', tooltip: '清除查询条件', iconCls: Sys.App.Icon.clearquerycondition, handler: tbarhandler.clearquery }, '-',
            { text: '导出表格', tooltip: '导出表格', iconCls: Sys.App.Icon.excelexport, handler: tbarhandler.outputtoexcel }
        ],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: wlogpersonlogdata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin({
                cookieSizeName: Sys.App.WorkLog.WLOGPersonLogCommon.pagesizeCookieName
            })]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    wlogpersonloggrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    wlogpersonloggrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    wlogpersonloggrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, wlogpersonloggrid);

    switch (Sys.Paramters.roleId) {
        case Sys.App.EnumRoleType.CoderLevel:
            wlogpersonlogdata.proxy.extraParams = { writeUser: Sys.Paramters.userid };
            break;
        default:
            break;
    }
    wlogpersonloggrid.down('#pagingToolbar').moveFirst();
}
