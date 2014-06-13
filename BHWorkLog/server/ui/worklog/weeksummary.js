/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhlfy
***创建时间：2013-04-25 22:30:23
***公司：山西博华科技有限公司
***修改人：
***修改时间：2013-04-25 22:30:23
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义

Sys.App.WorkLog.WLOGWeekSummaryCommon = {
    handlerUrl: 'handler/worklog/WLOGWeekSummary.ashx?action=',
    listStartRecord: 0,
    pagesizeCookieName: 'WLOGWeekSummaryCommon'
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="wlogweeksummaryData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.WorkLog.WLOGWeekSummaryEdit = function (isadd, wlogweeksummaryData, currentrows) {
    var wlogweeksummary = Sys.DB.WLOGWeekSummary;
    var handerurl = Sys.App.WorkLog.WLOGWeekSummaryCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonselectmission: function(){
            Sys.App.WorkLog.WLOGMissionCheck(wlogweeksummaryeditform, isadd);
        },
        buttonclose: function () {
            wlogweeksummarytopwindow.close();
        },
        buttonsave: function () {
            var editform = wlogweeksummaryeditform.getForm();
            if (!editform.isValid())
                return;
            //此处只要form提交，会默认传输到服务端界面上元素的值。
            if (editform.findField(wlogweeksummary.startDate).getValue().getDay() != 1) {
                Sys.App.MsgFailure('当前所选开始时间必须为星期一！');
                return;
            }
            editform.submit({
                url: handerurl,
                method: 'post',
                success: function (frm, action) {
                    var result = action.result;
                    if (result.success == 'true') {
                        Sys.App.MsgSuccess('保存成功！');
                        wlogweeksummaryData.reload();
                        wlogweeksummarytopwindow.close();
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
    var wlogweeksummaryeditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '周总结流水号', name: wlogweeksummary.summaryId, hidden: true, xtype: 'textfield' },
			{ fieldLabel: '周编号', name: wlogweeksummary.weekBH, hidden:true, maxLength: 8, xtype: 'textfield' },
            {
                fieldLabel: '开始日期',
                name: wlogweeksummary.startDate,
                allowBlank: false,
                format: Sys.App.Config.dateFormat,
                xtype: 'datefield',
                listeners: {
                    'select': function (a, b) {
                        var editform = wlogweeksummaryeditform.getForm();
                        editform.setValues({
                            endDate: Ext.Date.add(b, Ext.Date.DAY, 6)
                        });

                    }
                }
            },
			{ fieldLabel: '结束日期', name: wlogweeksummary.endDate, readOnly:true, allowBlank: false, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
            {
                fieldLabel: '录入人',
                name: wlogweeksummary.writeUser,
                store: Sys.App.Common.storeUser,
                hiddenName: 'userid',
                editable: false,
                queryMode: 'local',
                readOnly: true,
                displayField: 'fullName',
                valueField: 'userid',
                xtype: 'combo'
            },
            {
                fieldLabel: '是否提交',
                name: wlogweeksummary.submited,
                store: Sys.App.BusinessCommon.storeSubmitedState,
                hiddenName: wlogweeksummary.submited,
                allowBlank: false,
                editable: false,
                queryMode: 'local',
                flex: 1,
                displayField: 'describe',
                valueField: wlogweeksummary.submited,
                xtype: 'combo',
                listeners: {
                    'beforerender': function () {
                        //Sys.App.Common.cityBeforeRender(this, foodcompanyeditform.down('#' + foodcompany.County));
                    },
                    'select': function (combo, record) {
                        var editform = wlogweeksummaryeditform.getForm();
                        if(record[0].data.submited)
                            editform.setValues({ submitTime: new Date() });
                        else
                            editform.setValues({ submitTime: '' });
                    }
                }
            },
            { fieldLabel: '工作项编号（旧串）', name: 'oldMissionId', hidden: true, xtype: 'textfield' },
            { fieldLabel: '工作项编号（新串）', name: 'missionId', hidden: true, xtype: 'textfield' },
            { fieldLabel: '工作项数量', name: 'missionCount', xtype: 'textfield' },
			{ fieldLabel: '提交时刻', name: wlogweeksummary.submitTime, readOnly: true, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入时刻', name: wlogweeksummary.writeTime, readOnly: true, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人IP地址', name: wlogweeksummary.writeIp, maxLength: 30, hidden: true, xtype: 'textfield' }
        ]
    });
    var wlogweeksummarytopwindow = Ext.create('Sys.App.TopWindow', {
        title: '周工作总结信息维护界面',    //窗口名称
        width: 400, //界面初始化时宽、高
        height: 290,    //
        iconCls: Sys.App.Icon.addrecord,
        items: wlogweeksummaryeditform,
        buttons: [
            { minWidth: 100, text: '选择工作项', handler: edithandler.buttonselectmission},
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = wlogweeksummaryeditform.getForm();
                if (!isadd) {
                    editform.findField(wlogweeksummary.startDate).disable();
                    editform.findField(wlogweeksummary.endDate).disable();
                    Ext.Ajax.request({
                        url: Sys.App.WorkLog.WLOGMissionCommon.handlerUrl + 'summarymissionsid',
                        params: { summaryId: currentrows[0].data.summaryId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                var missionsidlength = (result.missionId == '') ? '0' : result.missionId.split(',').length;
                                editform.setValues({
                                    oldMissionId: result.missionId,
                                    missionId: result.missionId,
                                    missionCount: missionsidlength
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
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({
                        summaryId: '1',
                        writeTime: new Date(),
                        submited: false,
                        writeUser: Sys.Paramters.userid
                    });
                }
            }
        }
    });
    wlogweeksummarytopwindow.show();
}
/// 查询条件界面的定义
/// <param name="wlogweeksummarygrid">引用了列表框对象</param>
Sys.App.WorkLog.WLOGWeekSummaryQuery = function (wlogweeksummarygrid) {
    var wlogweeksummary = Sys.DB.WLOGWeekSummary;
    var applicationuser = Sys.DB.ApplicationUser;
    var queryhandler = {
        buttonclose: function () {
            wlogweeksummarytopwindow.close();
        },
        buttonquery: function () {
            var queryform = wlogweeksummaryqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(wlogweeksummarygrid.store.proxy.extraParams, {                
                writeUser: getvalue(applicationuser.userid),
                weekBH: getvalue(wlogweeksummary.weekBH),
                submited: getvalue(wlogweeksummary.submited),
                startDate: getvalue(wlogweeksummary.startDate),
                endDate: getvalue(wlogweeksummary.endDate)
            });
            wlogweeksummarygrid.down('#pagingToolbar').moveFirst();
            wlogweeksummarytopwindow.close();
        }
    }
    var wlogweeksummaryqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [			
			{
			    fieldLabel: '用户名',
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
			{ fieldLabel: '周编号', name: wlogweeksummary.weekBH, maxLength: 8, xtype: 'textfield' },
			{
			    fieldLabel: '是否提交',
			    name: wlogweeksummary.submited,
			    store: Sys.App.BusinessCommon.storeSubmitedState,
			    hiddenName: wlogweeksummary.submited,
			    allowBlank: true,
			    editable: false,
			    queryMode: 'local',
			    flex: 1,
			    displayField: 'describe',
			    valueField: wlogweeksummary.submited,
			    xtype: 'combo'
			},
			{ fieldLabel: '开始时刻', name: wlogweeksummary.startDate, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '结束时刻', name: wlogweeksummary.endDate, format: Sys.App.Config.dateFormat, xtype: 'datefield' }			
        ]
    });
    var wlogweeksummarytopwindow = Ext.create('Sys.App.TopWindow', {
        title: '周工作总结信息查询界面',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 233,    //
        resizable: false,
        items: wlogweeksummaryqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    wlogweeksummarytopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.WorkLog.WLOGWeekSummaryMain = function (mainPanel, node) {
    var wlogweeksummary = Sys.DB.WLOGWeekSummary;
    var handerurl = Sys.App.WorkLog.WLOGWeekSummaryCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.WorkLog.WLOGWeekSummaryEdit(true, wlogweeksummarydata);
        },
        updaterecord: function () {
            Sys.App.WorkLog.WLOGWeekSummaryEdit(false, wlogweeksummarydata, wlogweeksummarygrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = wlogweeksummarygrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { summaryId: currentselectrows[0].data.summaryId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                wlogweeksummarydata.reload();
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
            Sys.App.WorkLog.WLOGWeekSummaryQuery(wlogweeksummarygrid);
        },
        refreshrecord: function () {
            wlogweeksummarydata.reload();
        },
        clearquery: function () {
            wlogweeksummarygrid.store.proxy.extraParams = {};
            wlogweeksummarygrid.down('#pagingToolbar').moveFirst();
        },

        outputexcel: function () {
            var currentselectrows = wlogweeksummarygrid.getSelectionModel().getSelection();
            Sys.App.ExportSummaryExcel(currentselectrows[0].data, handerurl + 'outputsummary');
        }

    };
    Ext.define('WLOGWeekSummaryModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: wlogweeksummary.summaryId, type: 'int' },
			{ name: wlogweeksummary.writeUser, type: 'string' },
			{ name: 'missioncount', type: 'int' },
			{ name: wlogweeksummary.weekBH, type: 'string' },
			{ name: wlogweeksummary.startDate, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogweeksummary.endDate, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogweeksummary.submited, type: 'bool' },
			{ name: wlogweeksummary.submitTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogweeksummary.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: wlogweeksummary.writeIp, type: 'string' }
        ]
    });
    var wlogweeksummarydata = Ext.create('Ext.data.Store', {
        model: 'WLOGWeekSummaryModel',
        defaultPageSize: Sys.App.Common.getCookie(Sys.App.WorkLog.WLOGWeekSummaryCommon.pagesizeCookieName),
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
    var wlogweeksummarygrid = Ext.create('Sys.App.TabInnerGrid', {
        store: wlogweeksummarydata,
        columns: [
			{ xtype: 'rownumberer', width: 35 },
			{ text: "周总结流水号", dataIndex: wlogweeksummary.summaryId, hidden:true, sortable: true },
			{ text: "周编号", dataIndex: wlogweeksummary.weekBH, hidden: true, flex: 1, sortable: true },
			{ text: "开始日期", dataIndex: wlogweeksummary.startDate, flex: 1, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat), sortable: true },
			{ text: "结束日期", dataIndex: wlogweeksummary.endDate, flex: 1, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat), sortable: true },
			{ text: '工作项个数', dataIndex: 'missioncount', sortable: true },
			{ text: "录入人", dataIndex: wlogweeksummary.writeUser, flex: 1, renderer: Sys.App.Common.getUserfullName, sortable: true },
			{ text: "是否提交", dataIndex: wlogweeksummary.submited, renderer: Sys.App.BusinessCommon.getSubmitedStateName, sortable: true },
			{ text: "提交时刻", dataIndex: wlogweeksummary.submitTime, flex: 1, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true },
			{ text: "录入人IP地址", dataIndex: wlogweeksummary.writeIp, hidden: true, sortable: true },
			{ text: "录入时刻", dataIndex: wlogweeksummary.writeTime, flex: 1, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true }
        ],
        tbar: [
			{ text: '查询条件', tooltip: '查询条件', iconCls: Sys.App.Icon.queryrecord, handler: tbarhandler.queryrecord }, '-',
            { text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
            { text: '新增', tooltip: '新增', iconCls: Sys.App.Icon.addrecord, handler: tbarhandler.addrecord }, '-',
			{ text: '编辑', tooltip: '编辑', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',
			{ text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord },
            '->', { text: '清除查询条件', tooltip: '清除查询条件', iconCls: Sys.App.Icon.clearquerycondition, handler: tbarhandler.clearquery }, '-',
			{ text: '导出表格',  tooltip: '导出表格', itemId: 'outputexcelBtn', disabled: true, iconCls: Sys.App.Icon.excelexport, handler: tbarhandler.outputexcel }
        ],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: wlogweeksummarydata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin({
                cookieSizeName: Sys.App.WorkLog.WLOGWeekSummaryCommon.pagesizeCookieName
            })]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    wlogweeksummarygrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    var delbusiness = false;
		    if (sm.getSelection().length > 0)
		        delbusiness = (sm.getSelection()[0].data.writeUser != Sys.Paramters.userid);
		    wlogweeksummarygrid.down('#editBtn').setDisabled((sm.getCount() != 1) || delbusiness);
		    wlogweeksummarygrid.down('#outputexcelBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    wlogweeksummarygrid.down('#removeBtn').setDisabled((sm.getCount() < 1) || delbusiness);
		}
	);
    mainPanel.viewContent(node, wlogweeksummarygrid);
}

Sys.App.WorkLog.WLOGMissionCheck = function (wlogweeksummaryeditform, isadd) {
    var wlogmission = Sys.DB.WLOGMission;
    var handerurl = Sys.App.WorkLog.WLOGMissionCommon.handlerUrl;
    handerurl += (isadd) ? 'summarymissionadd' : 'summarymissionupdate';
    var tbarhandler = {
        addrecord: function () {
            var editform = wlogweeksummaryeditform.getForm();

            var selects = wlogmissiongrid.getSelectionModel().getSelection();
            var missionsid = '';
            for (var i = 0; i < selects.length; i++) {
                var temp = selects[i].data.missionId;
                if (i != selects.length - 1)
                    temp += ',';
                missionsid += temp;
            }
            editform.setValues({
                missionId: missionsid,
                missionCount: missionsid.split(',').length
            });
            wlogmissiontopwindow.close();
        },
        refreshrecord: function () {
            wlogmissiondata.reload();
        }

    };
    Ext.define('WLOGMissionModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: wlogmission.missionId, type: 'int' },
			{ name: wlogmission.summaryId, type: 'string' },
			{ name: wlogmission.writeUser, type: 'string' },
			{ name: wlogmission.missionBH, type: 'string' },
			{ name: wlogmission.missionName, type: 'string' },
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
        proxy: {
            type: 'ajax',
            url: handerurl,
            actionMethods: { read: 'POST' },
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        listeners: {
            beforeload: function () {
                var editform = wlogweeksummaryeditform.getForm();
                Ext.apply(this.proxy.extraParams, {
                    summaryId: editform.findField(wlogmission.summaryId).getValue(),
                    writeUser: editform.findField(wlogmission.writeUser).getValue()
                });
            }
        }
    });
    var wlogmissiongrid = Ext.create('Sys.App.TabInnerGrid', {
        store: wlogmissiondata,
        selModel: Ext.create('Ext.selection.CheckboxModel'),
        columns: [
			{ xtype: 'rownumberer', width: 20 },
			{ text: "任务项流水号", dataIndex: wlogmission.missionId, hidden: true, sortable: true },
			{ text: "周总结流水号", dataIndex: wlogmission.summaryId, hidden: true, sortable: true },
			{ text: "任务编号", dataIndex: wlogmission.missionBH, sortable: true },
			{ text: "任务描述", dataIndex: wlogmission.missionName, flex: 2, sortable: true },
			{ text: "录入人", dataIndex: wlogmission.writeUser, renderer: Sys.App.Common.getUserfullName, sortable: true },
			{ text: "计划内？", dataIndex: wlogmission.planned, renderer: Sys.App.Common.getUsableName, sortable: true },
			//{ text: "计划工期（天）", dataIndex: wlogmission.plantimelimit, sortable: true },
			{ text: "任务输出", dataIndex: wlogmission.outputResult, hidden: true, sortable: true },
			//{ text: "任务开始日期", dataIndex: wlogmission.startDate, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat), sortable: true },
			//{ text: "审核状态", dataIndex: wlogmission.reviewState, renderer: Sys.App.BusinessCommon.getReviewStateName, sortable: true },
			//{ text: "任务状态", dataIndex: wlogmission.missionState, renderer: Sys.App.BusinessCommon.getWorkStateName, sortable: true },
			//{ text: "是否删除", dataIndex: wlogmission.deleted, hidden: true, sortable: true },
			//{ text: "可用性", dataIndex: wlogmission.usable, renderer: Sys.App.Common.getUsableName, sortable: true },
			//{ text: "更新时刻", dataIndex: wlogmission.updated, hidden: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true },
			//{ text: "删除时刻", dataIndex: wlogmission.deleteTime, hidden: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true },
			{ text: "录入时刻", dataIndex: wlogmission.writeTime, flex: 2, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true },
			{ text: "录入人IP地址", dataIndex: wlogmission.writeIp, hidden: true, sortable: true }
        ]
    });

    var wlogmissiontopwindow = Ext.create('Sys.App.TopWindow', {
        title: '选择工作项所对应的工作项',    //窗口名称
        width: 700, //界面初始化时宽、高
        height: 240,    //
        minWidth: 700,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 240, //
        maximizable: true,
        border: false,
        iconCls: Sys.App.Icon.addrecord,
        items: wlogmissiongrid,
        buttons: [
			{ minWidth: 80, text: '确认选择', handler: tbarhandler.addrecord },
			{ minWidth: 80, text: '关闭', handler: function () { wlogmissiontopwindow.close(); } }
        ]
    });
    wlogmissiondata.load({
        callback: function (records, operation, success) {
            wlogmissiontopwindow.show();
            var oldmissionsid = wlogweeksummaryeditform.getForm().findField('oldMissionId').getValue().split(',');

            var selMod = wlogmissiongrid.getSelectionModel();

            for (var m = 0; m < wlogmissiondata.getCount() ; m++) {
                for (var n = 0 ; n < oldmissionsid.length; n++) {
                    var current = wlogmissiondata.getAt(m)
                    if (current.data.missionId == oldmissionsid[n]) {
                        selMod.select(current.index, true, false);
                    }
                }
            }
        }
    });
    
}
