/****************************************
***生成器版本：V1.2.6.25443
***创建人：bhlfy
***创建时间：2012-11-14 15:31:04
***公司：iCat Studio
***修改人：
***修改时间：2012-11-14 15:31:04
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Manage.UsbKeyCommon = {
    handlerUrl: '../handler/manage/Usbkey.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="usbkeyData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Manage.UsbKeyEdit = function (isadd, usbkeyData, currentrows) {
    var usbkey = Sys.DB.UsbKey;
    var handerurl = Sys.App.Manage.UsbKeyCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            usbkeytopwindow.close();
        },
        buttonsave: function () {
            var editform = usbkeyeditform.getForm();
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
                        usbkeyData.reload();
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
            usbkeytopwindow.close();
        }
    };
    var usbkeyeditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 120, //可微调，以适应不同的界面。
            anchor: '98%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '发放usbkey的编号', name: usbkey.keyId, hidden:true, xtype: 'textfield' },
			{ fieldLabel: '密钥使用者全名', name: usbkey.fullname, maxLength: 40, allowBlank: false, xtype: 'textfield' },
			{ fieldLabel: '发放时间', name: usbkey.giveoutTime, allowBlank: false, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
            { fieldLabel: '录入人用户编号', name: usbkey.writeUserid, hidden: true, xtype: 'textfield' },
            {
                fieldLabel: '是否可用',
                name: usbkey.usable,
                store: Sys.App.Common.storeUsable,
                hiddenName: usbkey.usable,   //很关键的配置
                allowBlank: false,
                editable: false,
                queryMode: 'local',
                displayField: 'describe',
                valueField: usbkey.usable,
                xtype: 'combo'
            }
		]
    });
    var usbkeytopwindow = Ext.create('Sys.App.TopWindow', {
        title: '密钥（USBKEY）信息维护界面',    //窗口名称
        width: 450, //界面初始化时宽、高
        height: 160,    //
        minWidth: 450,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 160, //
        iconCls: Sys.App.Icon.lockedusbkey,
        items: usbkeyeditform,
        buttons: [
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
		],
        listeners: {
            'show': function () {
                var editform = usbkeyeditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.lockedusbkey);
                }
                else {
                    editform.setValues({ keyId: '1' });
                }
            }
        }
    });
    usbkeytopwindow.show();
}
/// 查询条件界面的定义
/// <param name="usbkeygrid">引用了列表框对象</param>
Sys.App.Manage.UsbKeyQuery = function (usbkeygrid) {
    var usbkey = Sys.DB.UsbKey;
    var queryhandler = {
        buttonclose: function () {
            usbkeytopwindow.close();
        },
        buttonquery: function () {
            var queryform = usbkeyqueryform.getForm();
            if (!queryform.isValid())
                return;
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(usbkeygrid.store.proxy.extraParams, {
                OrgName: getvalue('OrgName'),
                fullname: getvalue(usbkey.fullname),
                mingiveoutTime: getvalue('mingiveoutTime'),
                maxgiveoutTime: getvalue('maxgiveoutTime'),
                usable: getvalue(usbkey.usable)
            });
            usbkeygrid.down('#pagingToolbar').moveFirst();
            usbkeytopwindow.close();
        }
    }
    var usbkeyqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 110, //可微调，以适应不同的界面。
            anchor: '95%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '单位名称', name: 'OrgName', maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '密钥持有人姓名', name: usbkey.fullname, maxLength: 40, xtype: 'textfield' },
			{ fieldLabel: '发放时间从', name: 'mingiveoutTime', format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '到', name: 'maxgiveoutTime', format: Sys.App.Config.dateFormat, xtype: 'datefield' },
            {
                fieldLabel: '密钥是否可用',
                name: usbkey.usable,
                store: Sys.App.Common.storeUsable,
                hiddenName: usbkey.usable,   //很关键的配置
                allowBlank: false,
                editable: false,
                emptyText: '请选择',
                queryMode: 'local',
                displayField: 'describe',
                valueField: usbkey.usable,
                xtype: 'combo'
            }
		]
    });
    var usbkeytopwindow = Ext.create('Sys.App.TopWindow', {
        title: '密钥（USBKEY）信息查询界面',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 220,    //
        minWidth: 300,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 220, //
        items: usbkeyqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
		],
        listeners: {
            'show': function () {
                var querybasicform = usbkeyqueryform.getForm();
                querybasicform.setValues({ maxgiveoutTime: new Date() });
            }
        }
    });
    usbkeytopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Manage.UsbKeyMain = function (mainPanel, node) {
    var usbkey = Sys.DB.UsbKey;
    var handerurl = Sys.App.Manage.UsbKeyCommon.handlerUrl;
    var tbarhandler = {
        clearquerycondition: function () {
            usbkeydata.proxy.extraParams = {};
            usbkeygrid.down('#pagingToolbar').moveFirst();
        },
        updaterecord: function () {
            Sys.App.Manage.UsbKeyEdit(false, usbkeydata, usbkeygrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = usbkeygrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { keyId: currentselectrows[0].data.keyId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                usbkeydata.reload();
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
        queryrecord: function () {
            Sys.App.Manage.UsbKeyQuery(usbkeygrid);
        },
        refreshrecord: function () {
            usbkeydata.reload();
        }
    };
    Ext.define('UsbKeyModel', {
        extend: 'Ext.data.Model',
        fields: [
            { name: 'orgname', type: 'string' },
			{ name: usbkey.keyId, type: 'int' },
			{ name: usbkey.userid, type: 'int' },
			{ name: usbkey.writeUserid, type: 'int' },
			{ name: usbkey.fullname, type: 'string' },
			{ name: usbkey.giveoutTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: usbkey.giveoutPerson, type: 'int' },
			{ name: usbkey.usable, type: 'bool' },
			{ name: usbkey.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: usbkey.writeIp, type: 'string' }
		]
    });
    var usbkeydata = Ext.create('Ext.data.Store', {
        model: 'UsbKeyModel',
        defaultPageSize: Sys.App.Manage.UsbKeyCommon.listPagesize,
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
    var usbkeygrid = Ext.create('Sys.App.TabInnerGrid', {
        store: usbkeydata,
        columns: [
			{ xtype: 'rownumberer', width: 35 },
			{ text: "发放usbkey的编号", dataIndex: usbkey.keyId, hidden: true, sortable: true },
			{ text: "录入人用户编号", dataIndex: usbkey.writeUserid, hidden: true, sortable: true },
			{ text: "密钥使用者全名", dataIndex: usbkey.fullname, sortable: true },
			{ text: "所属单位名称", dataIndex: 'orgname', flex: 2, sortable: true },
			{ text: "发放日期", dataIndex: usbkey.giveoutTime, xtype: 'datecolumn', renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat), sortable: true },
			{ text: "是否可用", dataIndex: usbkey.usable, renderer: Sys.App.Common.getUsableName, sortable: true },
			{ text: "录入人IP", dataIndex: usbkey.writeIp, hidden: true, sortable: true },
			{ text: "录入时刻", dataIndex: usbkey.writeTime, xtype: 'datecolumn', flex: 1, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true }
		],
        tbar: [
			{ text: '查询条件', tooltip: '查询条件', iconCls: Sys.App.Icon.queryrecord, handler: tbarhandler.queryrecord }, '-',
			{ text: '清除查询条件', tooltip: '清除查询条件', iconCls: Sys.App.Icon.clearquerycondition, handler: tbarhandler.clearquerycondition }, '-',
            { text: '锁定/解锁密钥', tooltip: '锁定/解锁密钥', iconCls: Sys.App.Icon.lockedusbkey, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',
			{ text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
            { text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord }
		],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: usbkeydata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    usbkeygrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    usbkeygrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    usbkeygrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, usbkeygrid);
}
