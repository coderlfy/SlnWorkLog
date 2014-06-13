/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhlfy
***创建时间：2013-04-26 18:08:02
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：2013-04-26 18:08:02
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.WorkLog.WLOGMissionCommon = {
    handlerUrl: 'handler/worklog/WLOGMission.ashx?action=',
    listStartRecord: 0,
    pagesizeCookieName: 'WLOGMissionCommon'
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="wlogmissionData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.WorkLog.WLOGMissionEdit = function (isadd, wlogmissionData, currentrows) {
    var wlogmission = Sys.DB.WLOGMission;
    var handerurl = Sys.App.WorkLog.WLOGMissionCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonchecklogs: function () {
            Sys.App.WorkLog.WLOGPersonLogCheck(wlogmissioneditform, isadd);
        },
        buttonclose: function () {
            wlogmissiontopwindow.close();
        },
        buttonsave: function () {
            var editform = wlogmissioneditform.getForm();
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
                        wlogmissionData.reload();
                        wlogmissiontopwindow.close();
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
    var wlogmissioneditform = Ext.create('Ext.form.Panel', {
        baseCls: 'x-plain',
        padding: '5 5 0 5',
        fieldDefaults: {
            labelWidth: 80, //可微调，以适应不同的界面。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [{
            xtype: 'fieldset',
            title: '任务表述',
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
                    fieldLabel: '项目架构',
                    itemId: wlogmission.projectId,
                    name: wlogmission.projectId,
                    //allowBlank: false,
                    flex: 1,
                    storeUrl: Sys.App.WorkLog.ProjectTreeCommon.handlerUrl + 'listtree',
                    xtype: 'comboboxtree'
                }, {
                    fieldLabel: '任务开始日期',
                    name: wlogmission.startDate,
                    format: Sys.App.Config.dateFormat,
                    flex: 1,
                    xtype: 'datefield'
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [{
                    fieldLabel: '任务编号',
                    name: wlogmission.missionBH,
                    maxLength: 40,
                    flex: 1,
                    xtype: 'textfield'
                }, {
                    fieldLabel: '录入人',
                    name: wlogmission.writeUser,
                    store: Sys.App.Common.storeUser,
                    hiddenName: 'userid',
                    editable: false,
                    queryMode: 'local',
                    flex: 1,
                    readOnly: true,
                    displayField: 'fullName',
                    valueField: 'userid',
                    xtype: 'combo'
                }]
            }, {
                fieldLabel: '任务描述',
                name: wlogmission.missionName,
                height: 60,
                maxLength: 1000,
                xtype: 'textareafield'
            }, {
                fieldLabel: '任务输出',
                name: wlogmission.outputResult,
                height: 40,
                maxLength: 300,
                xtype: 'textareafield'
            }, {
                fieldLabel: '备注',
                name: wlogmission.missionRemark,
                height: 40,
                maxLength: 300, xtype: 'textareafield'
            }, {
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [{
                    fieldLabel: '计划工期',
                    name: wlogmission.plantimelimit,
                    flex: 1,
                    xtype: 'numberfield'
                }, {
                    fieldLabel: '实际工期',
                    name: 'facttime',
                    emptyText: '选择工作日志后系统自动统计该项',
                    flex: 1,
                    readOnly: true,
                    xtype: 'textfield'
                }]
            }]
        }, {
            xtype: 'fieldset',
            title: '任务状态',
            defaultType: 'textfield',
            collapsible: true,
            collapsed: true,
            layout: 'anchor',
            defaults: {
                anchor: '100%'
            },
            items: [{
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [{
                    fieldLabel: '任务状态',
                    name: wlogmission.missionState,
                    store: Sys.App.BusinessCommon.storeWorkState,
                    hiddenName: 'workState',
                    allowBlank: false,
                    editable: false,
                    queryMode: 'local',
                    flex: 1,
                    displayField: 'describe',
                    valueField: 'workState',
                    xtype: 'combo'
                }, {
                    fieldLabel: '是否在计划内',
                    name: wlogmission.planned,
                    store: Sys.App.Common.storeUsable,
                    hiddenName: 'usable',
                    allowBlank: false,
                    editable: false,
                    flex: 1,
                    queryMode: 'local',
                    displayField: 'describe',
                    valueField: 'usable',
                    xtype: 'combo'
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [{
                    fieldLabel: '更新时刻',
                    name: wlogmission.updated,
                    readOnly: true,
                    flex: 1,
                    format: Sys.App.Config.datetimeFormat,
                    xtype: 'datefield'
                }, {
                    fieldLabel: '审核状态',
                    name: wlogmission.reviewState,
                    store: Sys.App.BusinessCommon.storeReviewState,
                    hiddenName: wlogmission.reviewState,
                    allowBlank: false,
                    editable: false,
                    queryMode: 'local',
                    flex: 1,
                    displayField: 'describe',
                    valueField: wlogmission.reviewState,
                    xtype: 'combo'
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [{
                    fieldLabel: '录入时刻',
                    name: wlogmission.writeTime,
                    readOnly: true,
                    flex: 1,
                    format: Sys.App.Config.datetimeFormat,
                    xtype: 'datefield'
                }, {
                    fieldLabel: '可用性',
                    name: wlogmission.usable,
                    store: Sys.App.Common.storeUsable,
                    hiddenName: wlogmission.usable,
                    allowBlank: false,
                    editable: false,
                    flex: 1,
                    queryMode: 'local',
                    displayField: 'describe',
                    valueField: wlogmission.usable,
                    xtype: 'combo'
                }]
            }]
        },
		{
		    fieldLabel: '任务项流水号',
		    name: wlogmission.missionId,
		    flex: 1,
		    hidden: true,
		    xtype: 'textfield'
		},
        { fieldLabel: '工作日志编号（旧串）', name: 'oldlogId', hidden: true, xtype: 'textfield' },
        { fieldLabel: '工作日志编号（新串）', name: 'logId', hidden: true, xtype: 'textfield' },
		{ fieldLabel: '周总结流水号', name: wlogmission.summaryId, hidden: true, xtype: 'textfield' },
		{ fieldLabel: '是否删除', name: wlogmission.deleted, hidden: true, xtype: 'textfield' },
		{
		    fieldLabel: '删除时刻',
		    name: wlogmission.deleteTime,
		    hidden: true,
		    format: Sys.App.Config.dateFormat,
		    xtype: 'datefield'
		}]
    });
    var wlogmissiontopwindow = Ext.create('Sys.App.TopWindow', {
        title: '工作项（任务）信息维护界面',    //窗口名称
        width: 700, //界面初始化时宽、高
        //height: 440,    //
        minWidth: 600,  //界面最小宽高，每个弹出页面必须设置
        //minHeight: 440, //
        maximizable: true,
        iconCls: Sys.App.Icon.addrecord,
        items: wlogmissioneditform,
        buttons: [
            { minWidth: 80, text: '选择工作日志', handler: edithandler.buttonchecklogs },
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = wlogmissioneditform.getForm();

                if (!isadd) {
                    Ext.Ajax.request({
                        url: Sys.App.WorkLog.WLOGPersonLogCommon.handlerUrl + 'missionpersonlogsid',
                        params: { missionId: currentrows[0].data.missionId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                var logsidlength = (result.logsid == '') ? '0' : result.logsid.split(',').length;
                                editform.setValues({
                                    oldlogId: result.logsid,
                                    logId: result.logsid,
                                    facttime: logsidlength
                                });
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
                    editform.setValues(currentrows[0].data);
                    var projectid = currentrows[0].data.projectId;
                    wlogmissioneditform.down('#' + wlogmission.projectId).setLocalValue(Sys.App.BusinessCommon.getProjectName(projectid), projectid);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({
                        missionId: '1',
                        usable: true,
                        writeTime: new Date(),
                        updated: new Date(),
                        reviewState: false,
                        writeUser: Sys.Paramters.userid
                    });
                }
                if (Sys.Paramters.roleId == Sys.App.EnumRoleType.CoderLevel)
                    editform.findField(wlogmission.reviewState).disable();
            }
        }
    });
    wlogmissiontopwindow.show();
}
/// 查询条件界面的定义
/// <param name="wlogmissiongrid">引用了列表框对象</param>
Sys.App.WorkLog.WLOGMissionQuery = function (wlogmissiongrid) {
    var wlogmission = Sys.DB.WLOGMission;
    var applicationuser = Sys.DB.ApplicationUser;
    var queryhandler = {
        buttonclose: function () {
            wlogmissiontopwindow.close();
        },
        buttonquery: function () {
            var queryform = wlogmissionqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(wlogmissiongrid.store.proxy.extraParams, {
                writeUser: getvalue(applicationuser.userid),
                missionBH: getvalue(wlogmission.missionBH),
                missionName: getvalue(wlogmission.missionName),
                planned: getvalue(wlogmission.planned),
                reviewState: getvalue(wlogmission.reviewState),
                missionState: getvalue(wlogmission.missionState),
                usable: getvalue(wlogmission.usable)
            });
            wlogmissiongrid.down('#pagingToolbar').moveFirst();
            wlogmissiontopwindow.close();
        }
    }
    var wlogmissionqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{
			    fieldLabel: '录入人',
			    name: applicationuser.userid,
			    store: Sys.App.Common.storeUser,
			    hiddenName: applicationuser.userid,
			    allowBlank: true,
			    editable: false,
			    flex: 1,
			    queryMode: 'local',
			    rawValue: 'userid',
			    displayField: 'fullName',
			    valueField: applicationuser.userid,
			    xtype: 'combo'
			},
			{ fieldLabel: '任务编号', name: wlogmission.missionBH, maxLength: 20, xtype: 'textfield' },
			{ fieldLabel: '任务描述', name: wlogmission.missionName, maxLength: 1000, xtype: 'textfield' },
			{
			    fieldLabel: '是否在计划内',
			    name: wlogmission.planned,
			    store: Sys.App.Common.storeUsable,
			    hiddenName: 'usable',
			    allowBlank: true,
			    editable: false,
			    flex: 1,
			    queryMode: 'local',
			    displayField: 'describe',
			    valueField: 'usable',
			    xtype: 'combo'
			},
            {
                fieldLabel: '审核状态',
                name: wlogmission.reviewState,
                store: Sys.App.BusinessCommon.storeReviewState,
                hiddenName: wlogmission.reviewState,
                allowBlank: true,
                editable: false,
                queryMode: 'local',
                flex: 1,
                displayField: 'describe',
                valueField: wlogmission.reviewState,
                xtype: 'combo'
            },
            {
                fieldLabel: '任务状态',
                name: wlogmission.missionState,
                store: Sys.App.BusinessCommon.storeWorkState,
                hiddenName: 'workState',
                allowBlank: true,
                editable: false,
                queryMode: 'local',
                flex: 1,
                displayField: 'describe',
                valueField: 'workState',
                xtype: 'combo'
            },
			{
			    fieldLabel: '可用性',
			    name: wlogmission.usable,
			    store: Sys.App.Common.storeUsable,
			    hiddenName: wlogmission.usable,
			    allowBlank: true,
			    editable: false,
			    flex: 1,
			    queryMode: 'local',
			    displayField: 'describe',
			    valueField: wlogmission.usable,
			    xtype: 'combo'
			}
        ]
    });
    var wlogmissiontopwindow = Ext.create('Sys.App.TopWindow', {
        title: '工作项（任务）信息查询界面',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 290,    //
        resizable: false,
        items: wlogmissionqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    wlogmissiontopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.WorkLog.WLOGMissionMain = function (mainPanel, node) {
    var wlogmission = Sys.DB.WLOGMission;
    var handerurl = Sys.App.WorkLog.WLOGMissionCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.WorkLog.WLOGMissionEdit(true, wlogmissiondata);
        },
        updaterecord: function () {
            Sys.App.WorkLog.WLOGMissionEdit(false, wlogmissiondata,
                wlogmissiongrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = wlogmissiongrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { missionId: currentselectrows[0].data.missionId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                wlogmissiondata.reload();
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
            Sys.App.WorkLog.WLOGMissionQuery(wlogmissiongrid);
        },
        refreshrecord: function () {
            wlogmissiondata.reload();
        },
        clearquery: function () {
            wlogmissiongrid.store.proxy.extraParams = {};
            wlogmissiongrid.down('#pagingToolbar').moveFirst();
        },
        viewpersonlog: function () {
            var currentselectrows = wlogmissiongrid.getSelectionModel().getSelection();
            Sys.App.WorkLog.WLOGPersonLogView(currentselectrows[0].data.missionId, currentselectrows[0].data.writeUser);
        }
    };
    Ext.define('WLOGMissionModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: wlogmission.missionId, type: 'int' },
			{ name: 'personlogcount', type: 'int' },
			{ name: wlogmission.summaryId, type: 'string' },
			{ name: wlogmission.writeUser, type: 'string' },
			{ name: wlogmission.projectId, type: 'int' },
			{ name: wlogmission.missionBH, type: 'string' },
			{ name: wlogmission.missionName, type: 'string' },
			{ name: wlogmission.missionRemark, type: 'string' },
			{ name: wlogmission.planned, type: 'bool' },
			{ name: wlogmission.plantimelimit, type: 'int' },
			{ name: wlogmission.outputResult, type: 'string' },
			{ name: wlogmission.startDate, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogmission.reviewState, type: 'bool' },
			{ name: wlogmission.missionState, type: 'int' },
			{ name: wlogmission.deleted, type: 'bool' },
			{ name: wlogmission.usable, type: 'bool' },
			{ name: wlogmission.updated, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogmission.deleteTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogmission.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogmission.writeIp, type: 'string' }
        ]
    });
    var wlogmissiondata = Ext.create('Ext.data.Store', {
        model: 'WLOGMissionModel',
        defaultPageSize: Sys.App.Common.getCookie(Sys.App.WorkLog.WLOGMissionCommon.pagesizeCookieName),
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
    var wlogmissiongrid = Ext.create('Sys.App.TabInnerGrid', {
        store: wlogmissiondata,
        columns: [
			{ xtype: 'rownumberer', width: 35 },
			{ text: "任务项流水号", dataIndex: wlogmission.missionId, hidden: true, sortable: true },
			{ text: "周总结流水号", dataIndex: wlogmission.summaryId, hidden: true, sortable: true },
			{ text: "任务编号", dataIndex: wlogmission.missionBH, hidden: true, sortable: true },
			{ text: "任务描述", dataIndex: wlogmission.missionName, flex: 2, sortable: true },
			{ text: "录入人", dataIndex: wlogmission.writeUser, renderer: Sys.App.Common.getUserfullName, sortable: true },
			{ text: "是否在计划内", dataIndex: wlogmission.planned, renderer: Sys.App.Common.getUsableName, sortable: true },
			{ text: "计划工期（天）", dataIndex: wlogmission.plantimelimit, sortable: true },
			{ text: "实际工期（天）", dataIndex: 'personlogcount', sortable: true },
			{ text: "任务输出", dataIndex: wlogmission.outputResult, hidden: true, sortable: true },
			{ text: "任务开始日期", dataIndex: wlogmission.startDate, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat), sortable: true },
			{ text: "审核状态", dataIndex: wlogmission.reviewState, hidden: true, renderer: Sys.App.BusinessCommon.getReviewStateName, sortable: true },
			{ text: "任务状态", dataIndex: wlogmission.missionState, renderer: Sys.App.BusinessCommon.getWorkStateName, sortable: true },
			{ text: "是否删除", dataIndex: wlogmission.deleted, hidden: true, sortable: true },
			{ text: "可用性", dataIndex: wlogmission.usable, renderer: Sys.App.Common.getUsableName, sortable: true },
			{ text: "更新时刻", dataIndex: wlogmission.updated, hidden: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true },
			{ text: "删除时刻", dataIndex: wlogmission.deleteTime, hidden: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true },
			{ text: "录入人IP地址", dataIndex: wlogmission.writeIp, hidden: true, sortable: true },
			{ text: "录入时刻", dataIndex: wlogmission.writeTime, flex: 2, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true }
        ],
        tbar: [
			{ text: '查询条件', tooltip: '查询条件', iconCls: Sys.App.Icon.queryrecord, handler: tbarhandler.queryrecord }, '-',
            { text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
            { text: '新增', tooltip: '新增', iconCls: Sys.App.Icon.addrecord, handler: tbarhandler.addrecord }, '-',
			{ text: '编辑', tooltip: '编辑', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',
            { text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord }, '-',
            '->', { text: '清除查询条件', tooltip: '清除查询条件', iconCls: Sys.App.Icon.clearquerycondition, handler: tbarhandler.clearquery }, '-',
            { text: '查看工作日志', tooltip: '查看所选项对应的工作日志', iconCls: Sys.App.Icon.viewrecord, itemId: 'viewlogBtn', disabled: true, handler: tbarhandler.viewpersonlog }
        ],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: wlogmissiondata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin({
                cookieSizeName: Sys.App.WorkLog.WLOGMissionCommon.pagesizeCookieName
            })]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    wlogmissiongrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    wlogmissiongrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    wlogmissiongrid.down('#viewlogBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    wlogmissiongrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, wlogmissiongrid);

    switch (Sys.Paramters.roleId) {
        case Sys.App.EnumRoleType.CoderLevel:
            wlogmissiondata.proxy.extraParams = { writeUser: Sys.Paramters.userid };
            break;
        default:
            break;
    }
    wlogmissiongrid.down('#pagingToolbar').moveFirst();
}

Sys.App.WorkLog.WLOGPersonLogView = function (missionId, writeUser) {
    var wlogpersonlog = Sys.DB.WLOGPersonLog;
    var handerurl = Sys.App.WorkLog.WLOGPersonLogCommon.handlerUrl;
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
			{ name: wlogpersonlog.deleted, type: 'bool' },
			{ name: wlogpersonlog.deleteTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogpersonlog.usable, type: 'bool' },
			{ name: wlogpersonlog.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogpersonlog.writeIp, type: 'string' }
        ]
    });
    var wlogpersonlogdata = Ext.create('Ext.data.Store', {
        model: 'WLOGPersonLogModel',
        proxy: {
            type: 'ajax',
            url: handerurl + 'missonspersonlogs',
            actionMethods: { read: 'POST' },
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        listeners: {
            beforeload: function () {
                Ext.apply(this.proxy.extraParams, {
                    missionId: missionId,
                    writeUser: writeUser
                });
            }
        },
        autoLoad: true
    });

    var wlogpersonloggrid = Ext.create('Sys.App.TabInnerGrid', {
        store: wlogpersonlogdata,
        columns: [

			{ xtype: 'rownumberer', width: 35 },
			{ text: "任务项流水号", dataIndex: wlogpersonlog.missionId, hidden: true, sortable: true },
            { text: "日志编号", dataIndex: wlogpersonlog.logId, hidden: true, sortable: true },
			{ text: "日志内容", dataIndex: wlogpersonlog.logContent, flex: 2, sortable: true },
			{ text: "录入人", dataIndex: wlogpersonlog.writeUser, renderer: Sys.App.Common.getUserfullName, sortable: true },
			{ text: "当天日期", dataIndex: wlogpersonlog.logDate, flex: 1, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat), sortable: true },
			{ text: "工作完成状态", dataIndex: wlogpersonlog.workState, renderer: Sys.App.BusinessCommon.getWorkStateName, sortable: true }
        ]
    });
    var wlogpersonlogtopwindow = Ext.create('Sys.App.TopWindow', {
        title: '工作项所对应的工作日志',    //窗口名称
        width: 600, //界面初始化时宽、高
        height: 240,    //
        minWidth: 500,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 240, //
        maximizable: true,
        border: false,
        iconCls: Sys.App.Icon.viewrecord,
        items: wlogpersonloggrid,
        buttons: [
			{ minWidth: 80, text: '关闭', handler: function () { wlogpersonlogtopwindow.close(); } }
        ]
    });
    wlogpersonlogtopwindow.show();

}

Sys.App.WorkLog.WLOGPersonLogCheck = function (wlogmissioneditform, missionIsAdd) {
    var wlogpersonlog = Sys.DB.WLOGPersonLog;
    var handerurl = Sys.App.WorkLog.WLOGPersonLogCommon.handlerUrl;
    handerurl += (missionIsAdd) ? 'missonspersonlogsnull' : 'missionupdateviewpersonlogs';
    var tbarhandler = {
        addrecord: function () {
            var editform = wlogmissioneditform.getForm();

            var selects = wlogpersonloggrid.getSelectionModel().getSelection();
            var logsId = '';
            for (var i = 0; i < selects.length; i++) {
                var temp = selects[i].data.logId;
                if (i != selects.length - 1)
                    temp += ',';
                logsId += temp;
            }
            editform.setValues({
                logId: logsId,
                facttime: logsId.split(',').length
            });
            wlogpersonlogtopwindow.close();
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
			{ name: wlogpersonlog.deleted, type: 'bool' },
			{ name: wlogpersonlog.deleteTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogpersonlog.usable, type: 'bool' },
			{ name: wlogpersonlog.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogpersonlog.writeIp, type: 'string' }
        ]
    });
    var wlogpersonlogdata = Ext.create('Ext.data.Store', {
        model: 'WLOGPersonLogModel',
        proxy: {
            type: 'ajax',
            url: handerurl,
            actionMethods: { read: 'POST' },
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        listeners: {
            'beforeload': function () {
                var editform = wlogmissioneditform.getForm();
                Ext.apply(this.proxy.extraParams, {
                    missionId: editform.findField(wlogpersonlog.missionId).getValue(),
                    writeUser: editform.findField(wlogpersonlog.writeUser).getValue()
                });
            }
        }
    });
    var wlogpersonloggrid = Ext.create('Sys.App.TabInnerGrid', {
        store: wlogpersonlogdata,
        selModel: Ext.create('Ext.selection.CheckboxModel'),
        columns: [

			{ xtype: 'rownumberer', width: 20 },
			{ text: "任务项流水号", dataIndex: wlogpersonlog.missionId, hidden: true, sortable: true },
            { text: "日志编号", dataIndex: wlogpersonlog.logId, hidden: true, sortable: true },
			{ text: "日志内容", dataIndex: wlogpersonlog.logContent, flex: 2, sortable: true },
			{ text: "录入人", dataIndex: wlogpersonlog.writeUser, renderer: Sys.App.Common.getUserfullName, sortable: true },
			{ text: "当天日期", dataIndex: wlogpersonlog.logDate, flex: 1, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat), sortable: true },
			{ text: "工作完成状态", dataIndex: wlogpersonlog.workState, renderer: Sys.App.BusinessCommon.getWorkStateName, sortable: true }
        ]
    });
    var wlogpersonlogtopwindow = Ext.create('Sys.App.TopWindow', {
        title: '选择工作项所对应的工作日志',    //窗口名称
        width: 600, //界面初始化时宽、高
        height: 240,    //
        minWidth: 500,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 240, //
        maximizable: true,
        border: false,
        iconCls: Sys.App.Icon.addrecord,
        items: wlogpersonloggrid,
        buttons: [
			{ minWidth: 80, text: '确认选择', handler: tbarhandler.addrecord },
			{ minWidth: 80, text: '关闭', handler: function () { wlogpersonlogtopwindow.close(); } }
        ]
    });
    wlogpersonlogdata.load({
        callback: function (records, operation, success) {
            wlogpersonlogtopwindow.show();
            var oldlogsid = wlogmissioneditform.getForm().findField('oldlogId').getValue().split(',');

            var selMod = wlogpersonloggrid.getSelectionModel();

            for (var m = 0; m < wlogpersonlogdata.getCount() ; m++) {
                for (var n = 0 ; n < oldlogsid.length; n++) {
                    var current = wlogpersonlogdata.getAt(m)
                    if (current.data.logId == oldlogsid[n]) {
                        selMod.select(current.index, true, false);
                    }
                }
            }
        }
    });
}
