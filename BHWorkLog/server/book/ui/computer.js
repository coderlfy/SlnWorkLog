/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***创建时间：2013-08-16 17:20:32
***公司：山西博华科技有限公司
***修改人：
***修改时间：2013-08-16 17:20:32
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Book.ComputerCommon = {
    handlerUrl: 'book/handler/Computer.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="computerData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Book.ComputerEdit = function (isadd, computerData, currentrows) {
    var computer = Sys.DB.Computer;
    var handerurl = Sys.App.Book.ComputerCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            computertopwindow.close();
        },
        buttonsave: function () {
            var editform = computereditform.getForm();
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
                        computerData.reload();
                        computertopwindow.close();   
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
    var computereditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '计算机参数', hidden: true, name: computer.computerId, xtype: 'textfield' },
            { fieldLabel: '人员姓名', name: computer.userName, xtype: 'textfield' },
			{ fieldLabel: '使用人Ip', name: computer.userIp, xtype: 'textfield' },
			{ fieldLabel: 'MAC地址', name: computer.MACAddress, xtype: 'textfield' },
			{
			    fieldLabel: 'Ip使用状态',
			    name: computer.IpUseStatus,
			    store: Sys.App.Common.storeIpUseStatus,
			    hiddenName: 'ipUseStatus',   //很关键的配置
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    displayField: 'ipUseStatusName',
			    valueField: 'ipUseStatus',
			    xtype: 'combo'
			},
			{
			    fieldLabel: '工作状态',
			    name: computer.workStatus,
			    store: Sys.App.Common.storeWorkStatus,
			    hiddenName: 'workStatus',   //很关键的配置
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    displayField: 'workStatusName',
			    valueField: 'workStatus',
			    xtype: 'combo'
			},
			{
			    fieldLabel: '计算机类型',
			    name: computer.computerType,
			    store: Sys.App.Common.storeComputerType,
			    hiddenName: 'computerType',   //很关键的配置
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    displayField: 'computerTypename',
			    valueField: 'computerType',
			    xtype: 'combo'
			},
			{ fieldLabel: '录入人', hidden: true, name: computer.writeUser, xtype: 'textfield' },
            { fieldLabel: '录入时刻', name: computer.writeTime, readOnly: true, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人Ip', hidden: true, name: computer.writeIp, xtype: 'textfield' },
			{ fieldLabel: '备注', name: computer.remark, maxLength: 200, height: 70, xtype: 'textareafield' }
        ]
    });
    var computertopwindow = Ext.create('Sys.App.TopWindow', {
        title: '计算机信息界面',    //窗口名称
        width: 550, //界面初始化时宽、高
        height: 385,//
        minWidth: 550,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 385, //
        iconCls: Sys.App.Icon.addrecord,
        items: computereditform,
        buttons: [
             { minWidth: 80, text: '保存', handler: edithandler.buttonsave },
             { minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = computereditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({ computerId: '1', writeTime: new Date() });
                }
            }
        }
    });
    computertopwindow.show();
}
/// 查询条件界面的定义
/// <param name="computergrid">引用了列表框对象</param>
Sys.App.Book.ComputerQuery = function (computergrid) {
    var computer = Sys.DB.Computer;
    var queryhandler = {
        buttonclose: function () {
            computertopwindow.close();
        },
        buttonquery: function () {
            var queryform = computerqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(computergrid.store.proxy.extraParams, {
                computerId: getvalue(computer.computerId),
                userName: getvalue(computer.userName),
                userIp: getvalue(computer.userIp),
                MACAddress: getvalue(computer.MACAddress),
                IpUseStatus: getvalue(computer.IpUseStatus),
                workStatus: getvalue(computer.workStatus),
                computerType: getvalue(computer.computerType),
                writeUser: getvalue(computer.writeUser),
                writeTime: getvalue(computer.writeTime),
                writeIp: getvalue(computer.writeIp),
                remark: getvalue(computer.remark)
            });
            computergrid.down('#pagingToolbar').moveFirst();
            computertopwindow.close();
        }
    }
    var computerqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right' //标签内容靠左\右
            ///msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '计算机参数', hidden: true, name: computer.computerId, xtype: 'textfield' },
            { fieldLabel: '人员姓名', name: computer.userName, xtype: 'textfield' },
			{ fieldLabel: '使用人Ip', name: computer.userIp, xtype: 'textfield' },
			{ fieldLabel: 'MAC地址', name: computer.MACAddress, xtype: 'textfield' },
			{
			    fieldLabel: 'Ip使用状态',
			    name: computer.IpUseStatus,
			    store: Sys.App.Common.storeIpUseStatus,
			    hiddenName: 'ipUseStatus',   //很关键的配置
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    displayField: 'ipUseStatusName',
			    valueField: 'ipUseStatus',
			    xtype: 'combo'
			},
			{
			    fieldLabel: '工作状态',
			    name: computer.workStatus,
			    store: Sys.App.Common.storeWorkStatus,
			    hiddenName: 'workStatus',   //很关键的配置
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    displayField: 'workStatusName',
			    valueField: 'workStatus',
			    xtype: 'combo'
			},
			{
			    fieldLabel: '计算机类型',
			    name: computer.computerType,
			    store: Sys.App.Common.storeComputerType,
			    hiddenName: 'computerType',   //很关键的配置
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    displayField: 'computerTypename',
			    valueField: 'computerType',
			    xtype: 'combo'
			},
			{ fieldLabel: '录入人', hidden: true, name: computer.writeUser, xtype: 'textfield' },
			{ fieldLabel: '录入时刻', name: computer.writeTime, xtype: 'datefield', format: Sys.App.Config.dateFormat },
			{ fieldLabel: '录入人Ip', hidden: true, name: computer.writeIp, xtype: 'textfield' },
			{ fieldLabel: '备注', name: computer.remark, maxLength: 200, height: 70, xtype: 'textareafield' }
        ]
    });
    var computertopwindow = Ext.create('Sys.App.TopWindow', {
        title: '计算机信息查询界面',    //窗口名称
        iconCls: 'icon-queryRecord',
        width: 550, //界面初始化时宽、高
        height: 385,    //
        minWidth: 550,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 385, //
        items: computerqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    computertopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Book.ComputerMain = function (mainPanel, node) {
    var computer = Sys.DB.Computer;
    var handerurl = Sys.App.Book.ComputerCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Book.ComputerEdit(true, computerdata);
        },
        updaterecord: function () {
            Sys.App.Book.ComputerEdit(false, computerdata, computergrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = computergrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { computerId: currentselectrows[0].data.computerId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                computerdata.reload();
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
            Sys.App.Book.ComputerQuery(computergrid);
        },
        outputtoexcel: function () {
            Sys.App.ExportExcel(computergrid, handerurl + 'outputexcel');
        },
        refreshrecord: function () {
            computerdata.reload();
        }
    };
    Ext.define('ComputerModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: computer.computerId, type: 'int' },
			{ name: computer.userName, type: 'string' },
			{ name: computer.userIp, type: 'string' },
			{ name: computer.MACAddress, type: 'string' },
			{ name: computer.IpUseStatus, type: 'int' },
			{ name: computer.workStatus, type: 'int' },
			{ name: computer.computerType, type: 'int' },
			{ name: computer.writeUser, type: 'int' },
			{ name: computer.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: computer.writeIp, type: 'string' },
			{ name: computer.remark, type: 'string' }
        ]
    });
    var computerdata = Ext.create('Ext.data.Store', {
        model: 'ComputerModel',
        defaultPageSize: Sys.App.Book.ComputerCommon.listPagesize,
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
    var computergrid = Ext.create('Sys.App.TabInnerGrid', {
        store: computerdata,
        columns: [
           { xtype: 'rownumberer' },
           { text: "计算机参数", hidden: true, dataIndex: computer.computerId, sortable: true },
           { text: "人员姓名", flex: true, dataIndex: computer.userName, sortable: true },
           { text: "使用人Ip", flex: true, dataIndex: computer.userIp, sortable: true },
           { text: "MAC地址", flex: true, dataIndex: computer.MACAddress, sortable: true },
           { text: "Ip使用状态", hidden: true, flex: true, dataIndex: computer.IpUseStatus, renderer: Sys.App.Common.getIpUseStatusName, sortable: true },
           { text: "工作状态", hidden: true, flex: true, dataIndex: computer.workStatus, renderer: Sys.App.Common.getWorkStatusName, sortable: true },
           { text: "计算机类型", hidden: true, flex: true, dataIndex: computer.computerType, renderer: Sys.App.Common.getComputerTypeName, sortable: true },
           { text: "录入人", hidden: true, dataIndex: computer.writeUser, sortable: true },
		   { text: "录入时刻", flex: true, dataIndex: computer.writeTime, sortable: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat) },
           { text: "录入人Ip", hidden: true, flex: true, dataIndex: computer.writeIp, sortable: true },
           { text: "备注", flex: true, dataIndex: computer.remark, sortable: true }
        ],
        tbar: [
			{ text: '查询条件', tooltip: '查询条件', iconCls: Sys.App.Icon.queryrecord, handler: tbarhandler.queryrecord }, '-',
            { text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
            { text: '新增', tooltip: '新增', iconCls: Sys.App.Icon.addrecord, handler: tbarhandler.addrecord }, '-',
			{ text: '编辑', tooltip: '编辑', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',
			{ text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord },
            '->', { text: '导出表格', tooltip: '导出表格', iconCls: Sys.App.Icon.excelexport, handler: tbarhandler.outputtoexcel }
        ],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: computerdata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    computergrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    computergrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    computergrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, computergrid);
}
