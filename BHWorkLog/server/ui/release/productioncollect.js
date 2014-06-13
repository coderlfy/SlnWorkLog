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
Sys.App.Release.ProductionCollectCommon = {
    handlerUrl: 'handler/release/ProductionCollect.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="productioncollectData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Release.ProductionCollectEdit = function (isadd, productioncollectData, currentrows) {
    var productioncollect = Sys.DB.ProductionCollect;
    var handerurl = Sys.App.Release.ProductionCollectCommon.handlerUrl;
    handerurl += 'update';
    var edithandler = {
        buttonclose: function () {
            productioncollecttopwindow.close();
        },
        buttonsave: function () {
            var editform = productioncollecteditform.getForm();
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
                        productioncollectData.reload();
                        productioncollecttopwindow.close();
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
    var productioncollecteditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '生产部汇总Id', hidden: true, name: productioncollect.productionCollectId, xtype: 'textfield' },
            { fieldLabel: '汇总分类Id', hidden: true, name: productioncollect.collectTypeId, xtype: 'textfield' },
			{ fieldLabel: '系统名称', name: productioncollect.systemName, xtype: 'textfield' },
			{ fieldLabel: '归档编号', name: productioncollect.fileNo, xtype: 'textfield' },
            { fieldLabel: '归档时间', name: productioncollect.fileTime, flex: 1, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人', hidden: true, name: productioncollect.writeUser, xtype: 'textfield' },
            { fieldLabel: '录入时刻', name: productioncollect.writeTime, readOnly: true, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人Ip', hidden: true, name: productioncollect.writeIp, xtype: 'textfield' }
        ]
    });
    var productioncollecttopwindow = Ext.create('Sys.App.TopWindow', {
        title: '对生产部发布汇总界面',    //窗口名称
        width: 350, //界面初始化时宽、高
        height: 210,//
        minWidth: 350,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 210, //
        iconCls: Sys.App.Icon.addrecord,
        items: productioncollecteditform,
        buttons: [
             { minWidth: 80, text: '保存', handler: edithandler.buttonsave },
             { minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = productioncollecteditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({ productionCollectId: '1', writeTime: new Date() });
                }
            }
        }
    });
    productioncollecttopwindow.show();
}
/// 查询条件界面的定义
/// <param name="productioncollectgrid">引用了列表框对象</param>
Sys.App.Release.ProductionCollectQuery = function (productioncollectgrid) {
    var productioncollect = Sys.DB.ProductionCollect;
    var queryhandler = {
        buttonclose: function () {
            productioncollecttopwindow.close();
        },
        buttonquery: function () {
            var queryform = productioncollectqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(productioncollectgrid.store.proxy.extraParams, {
                productionCollectId: getvalue(productioncollect.productionCollectId),
                collectTypeId: getvalue(productioncollect.collectTypeId),
                systemName: getvalue(productioncollect.systemName),
                fileNo: getvalue(productioncollect.fileNo),
                fileTime: getvalue(productioncollect.fileTime),
                writeUser: getvalue(productioncollect.writeUser),
                writeTime: getvalue(productioncollect.writeTime),
                writeIp: getvalue(productioncollect.writeIp)
            });
            productioncollectgrid.down('#pagingToolbar').moveFirst();
            productioncollecttopwindow.close();
        }
    }
    var productioncollectqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right' //标签内容靠左\右
            ///msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '生产部汇总Id', hidden: true, name: productioncollect.productionCollectId, xtype: 'textfield' },
            { fieldLabel: '汇总分类Id', hidden: true, name: productioncollect.collectTypeId, xtype: 'textfield' },
			{ fieldLabel: '系统名称', name: productioncollect.systemName, xtype: 'textfield' },
			{ fieldLabel: '归档编号', name: productioncollect.fileNo, xtype: 'textfield' },
            { fieldLabel: '归档时间', name: productioncollect.fileTime, flex: 1, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人', hidden: true, name: productioncollect.writeUser, xtype: 'textfield' },
            { fieldLabel: '录入时刻', name: productioncollect.writeTime, xtype: 'datefield', format: Sys.App.Config.dateFormat },
            { fieldLabel: '录入人Ip', hidden: true, name: productioncollect.writeIp, xtype: 'textfield' }
        ]
    });
    var productioncollecttopwindow = Ext.create('Sys.App.TopWindow', {
        title: '对生产部发布汇总查询界面',    //窗口名称
        iconCls: 'icon-queryRecord',
        width: 350, //界面初始化时宽、高
        height: 210,    //
        minWidth: 350,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 210, //
        items: productioncollectqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    productioncollecttopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Release.ProductionCollectMain = function (mainPanel, node) {
    var productioncollect = Sys.DB.ProductionCollect;
    var handerurl = Sys.App.Release.ProductionCollectCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Release.ProductionCollectEdit(true, productioncollectdata);
        },
        updaterecord: function () {
            Sys.App.Release.ProductionCollectEdit(false, productioncollectdata, productioncollectgrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = productioncollectgrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { productionCollectId: currentselectrows[0].data.productionCollectId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                productioncollectdata.reload();
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
            Sys.App.Release.ProductionCollectQuery(productioncollectgrid);
        },
        outputtoexcel: function () {
            Sys.App.ExportExcel(productioncollectgrid, handerurl + 'outputexcel');
        },
        refreshrecord: function () {
            productioncollectdata.reload();
        }
    };
    Ext.define('ProductionCollectModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: productioncollect.productionCollectId, type: 'int' },
			{ name: productioncollect.collectTypeId, type: 'int' },
			{ name: productioncollect.systemName, type: 'string' },
			{ name: productioncollect.fileNo, type: 'string' },
			{ name: productioncollect.fileTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: productioncollect.writeUser, type: 'int' },
			{ name: productioncollect.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: productioncollect.writeIp, type: 'string' }
        ]
    });
    var productioncollectdata = Ext.create('Ext.data.Store', {
        model: 'ProductionCollectModel',
        defaultPageSize: Sys.App.Release.ProductionCollectCommon.listPagesize,
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
    var productioncollectgrid = Ext.create('Sys.App.TabInnerGrid', {
        store: productioncollectdata,
        columns: [
           { xtype: 'rownumberer' },
           { text: "生产部汇总Id", hidden: true, dataIndex: productioncollect.productionCollectId, sortable: true },
           { text: "汇总分类Id", hidden: true, dataIndex: productioncollect.collectTypeId, sortable: true },
           { text: "系统名称", flex: true, dataIndex: productioncollect.systemName, sortable: true },
           { text: "归档编号", flex: true, dataIndex: productioncollect.fileNo, sortable: true },
           { text: "归档时间", flex: true, dataIndex: productioncollect.fileTime, sortable: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat) },
           { text: "录入人", hidden: true, dataIndex: productioncollect.writeUser, sortable: true },
		   { text: "录入时刻", flex: true, dataIndex: productioncollect.writeTime, sortable: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat) },
           { text: "录入人Ip", hidden: true, flex: true, dataIndex: productioncollect.writeIp, sortable: true }
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
            store: productioncollectdata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    productioncollectgrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    productioncollectgrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    productioncollectgrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, productioncollectgrid);
}
