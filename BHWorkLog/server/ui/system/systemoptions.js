/****************************************
***生成器版本：V1.0.1.39969
***创建人：bhlfy
***创建时间：2013-03-05 15:33:49
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：2013-03-05 15:33:49
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.System.SiteInformationCommon = {
    handlerUrl: 'handler/system/SiteInformation.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="siteinformationData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.System.SiteInformationEdit = function (isadd, siteinformationData, currentrows) {
    var siteinformation = Sys.DB.SiteInformation;
    var handerurl = Sys.App.System.SiteInformationCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            siteinformationtopwindow.close();
        },
        buttonsave: function () {
            var editform = siteinformationeditform.getForm();
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
                        siteinformationData.reload();
                    }
                    else {
                        if (result.msg != null)
                            Sys.App.MsgFailure(result.msg);
                    }
                    siteinformationtopwindow.close();
                },
                failure: function (frm, action) {
                    Sys.App.Error(action);
                }
            });
        }
    };
    var siteinformationeditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 140, //可微调，以适应不同的界面。
            anchor: '95%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '站点编号', name: siteinformation.siteId, hidden:true, xtype: 'textfield' },
			{ fieldLabel: '录入人编号', name: siteinformation.writeUser, hidden: true, xtype: 'textfield' },
			{ fieldLabel: '版权所属公司', name: siteinformation.copyrightCompany, maxLength: 510, xtype: 'textfield' },
			{ fieldLabel: '研发单位电话', name: siteinformation.companyTel, maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '研发单位Email', name: siteinformation.companyEmail, maxLength: 400, xtype: 'textfield' },
			{ fieldLabel: '网站所属单位', name: siteinformation.belongtoCompany, maxLength: 510, xtype: 'textfield' },
			{ fieldLabel: '网站所属单位电话', name: siteinformation.belongtoTel, maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '网站所属地的Email', name: siteinformation.belongtoEmail, maxLength: 510, xtype: 'textfield' },
			{ fieldLabel: '网站上线时间', name: siteinformation.createTime, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '网站最后更新时间', name: siteinformation.updated, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '备案注册信息头', name: siteinformation.registerTitle, maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '备案注册详细信息', name: siteinformation.registerInformation, maxLength: 1000, xtype: 'textareafield' },
			{ fieldLabel: 'Logo', name: siteinformation.logoPath, itemId: siteinformation.logoPath, maxLength: 510, xtype: 'filefield' },
			{ fieldLabel: '录入时刻', name: siteinformation.writeTime, hidden: true, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: 'ip地址', name: siteinformation.writeIp, hidden: true, maxLength: 30, xtype: 'textfield' }
        ]
    });
    var siteinformationtopwindow = Ext.create('Sys.App.TopWindow', {
        title: '站点信息维护界面',    //窗口名称
        width: 500, //界面初始化时宽、高
        height: 440,    //
        minWidth: 500,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 440, //
        iconCls: Sys.App.Icon.addrecord,
        items: siteinformationeditform,
        buttons: [
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = siteinformationeditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.editrecord);
                    siteinformationeditform.down('#logoPath').setRawValue(currentrows[0].data.logoPath);
                }
                else {
                    editform.setValues({
                        siteId: '1',
                        createTime: new Date(),
                        updated: new Date(),
                        writeTime: new Date(),
                        copyrightCompany: '山西ICat Studio有限公司',
                        companyTel: '0351-7037628',
                        companyEmail: '13403692778@126.com',
                        registerTitle: '备案信息'
                    });
                }
            }
        }
    });
    siteinformationtopwindow.show();
}
/// 查询条件界面的定义
/// <param name="siteinformationgrid">引用了列表框对象</param>
Sys.App.System.SiteInformationQuery = function (siteinformationgrid) {
    var siteinformation = Sys.DB.SiteInformation;
    var queryhandler = {
        buttonclose: function () {
            siteinformationtopwindow.close();
        },
        buttonquery: function () {
            var queryform = siteinformationqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(siteinformationgrid.store.proxy.extraParams, {
                siteId: getvalue(siteinformation.siteId),
                writeUser: getvalue(siteinformation.writeUser),
                copyrightCompany: getvalue(siteinformation.copyrightCompany),
                companyTel: getvalue(siteinformation.companyTel),
                companyEmail: getvalue(siteinformation.companyEmail),
                belongtoCompany: getvalue(siteinformation.belongtoCompany),
                belongtoTel: getvalue(siteinformation.belongtoTel),
                belongtoEmail: getvalue(siteinformation.belongtoEmail),
                createTime: getvalue(siteinformation.createTime),
                updated: getvalue(siteinformation.updated),
                registerTitle: getvalue(siteinformation.registerTitle),
                registerInformation: getvalue(siteinformation.registerInformation),
                logoPath: getvalue(siteinformation.logoPath),
                writeTime: getvalue(siteinformation.writeTime),
                writeIp: getvalue(siteinformation.writeIp)
            });
            siteinformationgrid.down('#pagingToolbar').moveFirst();
            siteinformationtopwindow.close();
        }
    }
    var siteinformationqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '站点编号', name: siteinformation.siteId, xtype: 'textfield' },
			{ fieldLabel: '录入人编号', name: siteinformation.writeUser, xtype: 'textfield' },
			{ fieldLabel: '版权所属公司', name: siteinformation.copyrightCompany, maxLength: 510, xtype: 'textfield' },
			{ fieldLabel: '研发单位电话', name: siteinformation.companyTel, maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '研发单位Email', name: siteinformation.companyEmail, maxLength: 400, xtype: 'textfield' },
			{ fieldLabel: '网站所属单位', name: siteinformation.belongtoCompany, maxLength: 510, xtype: 'textfield' },
			{ fieldLabel: '网站所属单位电话', name: siteinformation.belongtoTel, maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '网站所属地的Email', name: siteinformation.belongtoEmail, maxLength: 510, xtype: 'textfield' },
			{ fieldLabel: '网站上线时间', name: siteinformation.createTime, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '网站最后更新时间', name: siteinformation.updated, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '备案注册信息头', name: siteinformation.registerTitle, maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '备案注册详细信息', name: siteinformation.registerInformation, maxLength: 1000, xtype: 'textfield' },
			{ fieldLabel: 'Logo的路径', name: siteinformation.logoPath, maxLength: 510, xtype: 'textfield' },
			{ fieldLabel: '录入时刻', name: siteinformation.writeTime, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: 'ip地址', name: siteinformation.writeIp, maxLength: 30, xtype: 'textfield' }
        ]
    });
    var siteinformationtopwindow = Ext.create('Sys.App.TopWindow', {
        title: '站点信息查询界面',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 220,    //
        minWidth: 300,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 190, //
        items: siteinformationqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    siteinformationtopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.System.SiteInformationMain = function (mainPanel, node) {
    var siteinformation = Sys.DB.SiteInformation;
    var handerurl = Sys.App.System.SiteInformationCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.System.SiteInformationEdit(true, siteinformationdata);
        },
        updaterecord: function () {
            Sys.App.System.SiteInformationEdit(false, siteinformationdata, siteinformationgrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = siteinformationgrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { siteId: currentselectrows[0].data.siteId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                siteinformationdata.reload();
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
            Sys.App.System.SiteInformationQuery(siteinformationgrid);
        },
        refreshrecord: function () {
            siteinformationdata.reload();
        }
    };
    Ext.define('SiteInformationModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: siteinformation.siteId, type: 'int' },
			{ name: siteinformation.writeUser, type: 'int' },
			{ name: siteinformation.copyrightCompany, type: 'string' },
			{ name: siteinformation.companyTel, type: 'string' },
			{ name: siteinformation.companyEmail, type: 'string' },
			{ name: siteinformation.belongtoCompany, type: 'string' },
			{ name: siteinformation.belongtoTel, type: 'string' },
			{ name: siteinformation.belongtoEmail, type: 'string' },
			{ name: siteinformation.createTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: siteinformation.updated, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: siteinformation.registerTitle, type: 'string' },
			{ name: siteinformation.registerInformation, type: 'string' },
			{ name: siteinformation.logoPath, type: 'string' },
			{ name: siteinformation.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: siteinformation.writeIp, type: 'string' }
        ]
    });
    var siteinformationdata = Ext.create('Ext.data.Store', {
        model: 'SiteInformationModel',
        defaultPageSize: Sys.App.System.SiteInformationCommon.listPagesize,
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
    var siteinformationgrid = Ext.create('Sys.App.TabInnerGrid', {
        store: siteinformationdata,
        columns: [
			{ xtype: 'rownumberer', width: 35 },
			{ text: "站点编号", dataIndex: siteinformation.siteId, hidden: true, sortable: true },
			{ text: "录入人编号", dataIndex: siteinformation.writeUser, hidden: true, sortable: true },
			{ text: "网站所属单位", dataIndex: siteinformation.belongtoCompany, flex: 2, sortable: true },
			{ text: "网站所属单位电话", dataIndex: siteinformation.belongtoTel, flex: 1, sortable: true },
			{ text: "网站所属地的Email", dataIndex: siteinformation.belongtoEmail, flex: 2, sortable: true },
			{ text: "网站上线时间", dataIndex: siteinformation.createTime, flex: 1, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true },
			{ text: "网站最后更新时间", dataIndex: siteinformation.updated, flex: 1, hidden: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true },
			{ text: "Logo的路径", dataIndex: siteinformation.logoPath,flex:2, sortable: true },
			{ text: "录入时刻", dataIndex: siteinformation.writeTime,hidden:true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true },
			{ text: "ip地址", dataIndex: siteinformation.writeIp, hidden: true, sortable: true }
        ],
        tbar: [
			//{ text: '新增', tooltip: '新增', iconCls: Sys.App.Icon.addrecord, handler: tbarhandler.addrecord }, '-',
			{ text: '编辑', tooltip: '编辑', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',
			//{ text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord }, '-',
			{ text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }
        ],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: siteinformationdata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    siteinformationgrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    siteinformationgrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //siteinformationgrid.down('#removeBtn').setDisabled(sm.getCount() != 1);
		}
	);
    mainPanel.viewContent(node, siteinformationgrid);
}
