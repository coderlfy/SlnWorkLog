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
Sys.App.Release.CollectTypeCommon = {
    handlerUrl: 'handler/release/CollectType.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="collecttypeData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Release.CollectTypeEdit = function (isadd, collecttypeData, currentrows) {
    var collecttype = Sys.DB.CollectType;
    var handerurl = Sys.App.Release.CollectTypeCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            collecttypetopwindow.close();
        },
        buttonsave: function () {
            var editform = collecttypeeditform.getForm();
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
                        collecttypeData.reload();
                        collecttypetopwindow.close();
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
    var collecttypeeditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
            { fieldLabel: '汇总分类Id', hidden: true, name: collecttype.collectTypeId, xtype: 'textfield' },
			{ fieldLabel: '发布编号', name: collecttype.releaseNo, xtype: 'textfield' },
            {
                fieldLabel: '发布类型',
                itemId: 'releaseType',
                name: collecttype.releaseType,
                store: Sys.App.Common.storeReleaseType,
                hiddenName: 'releaseType',   //很关键的配置
                allowBlank: false,
                editable: false,
                queryMode: 'local',
                displayField: 'releaseTypeName',
                valueField: 'releaseType',
                xtype: 'combo'
            },
            { fieldLabel: '发布时间', name: collecttype.releaseTime, flex: 1, format: Sys.App.Config.dateFormat, xtype: 'datefield', allowBlank: false },
			{ fieldLabel: '录入人', hidden: true, name: collecttype.writeUser, xtype: 'textfield' },
            { fieldLabel: '录入时刻', name: collecttype.writeTime, readOnly: true, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人Ip', hidden: true, name: collecttype.writeIp, xtype: 'textfield' }
        ]
    });
    var collecttypetopwindow = Ext.create('Sys.App.TopWindow', {
        title: '汇总分类界面',    //窗口名称
        width: 350, //界面初始化时宽、高
        height: 210,//
        minWidth: 350,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 210, //
        iconCls: Sys.App.Icon.addrecord,
        items: collecttypeeditform,
        buttons: [
             { minWidth: 80, text: '保存', handler: edithandler.buttonsave },
             { minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = collecttypeeditform.getForm();
                if (!isadd) {
                    collecttypeeditform.down('#releaseType').setReadOnly(true);
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    collecttypeeditform.down('#releaseType').setReadOnly(false);
                    editform.setValues({ collectTypeId: '1', writeTime: new Date() });
                }
            }
        }
    });
    collecttypetopwindow.show();
}
/// 查询条件界面的定义
/// <param name="collecttypegrid">引用了列表框对象</param>
Sys.App.Release.CollectTypeQuery = function (collecttypegrid) {
    var collecttype = Sys.DB.CollectType;
    var queryhandler = {
        buttonclose: function () {
            collecttypetopwindow.close();
        },
        buttonquery: function () {
            var queryform = collecttypequeryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(collecttypegrid.store.proxy.extraParams, {
                collectTypeId: getvalue(collecttype.collectTypeId),
                releaseNo: getvalue(collecttype.releaseNo),
                releaseType: getvalue(collecttype.releaseType),
                releaseTime: getvalue(collecttype.releaseTime),
                writeUser: getvalue(collecttype.writeUser),
                writeTime: getvalue(collecttype.writeTime),
                writeIp: getvalue(collecttype.writeIp)
            });
            collecttypegrid.down('#pagingToolbar').moveFirst();
            collecttypetopwindow.close();
        }
    }
    var collecttypequeryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right' //标签内容靠左\右
            ///msgTarget: 'side'
        },
        items: [
            { fieldLabel: '汇总分类Id', hidden: true, name: collecttype.collectTypeId, xtype: 'textfield' },
			{ fieldLabel: '发布编号', name: collecttype.releaseNo, xtype: 'textfield' },
            {
                fieldLabel: '发布类型',
                name: collecttype.releaseType,
                store: Sys.App.Common.storeReleaseType,
                hiddenName: 'releaseType',   //很关键的配置
                allowBlank: false,
                editable: false,
                queryMode: 'local',
                displayField: 'releaseTypeName',
                valueField: 'releaseType',
                xtype: 'combo'
            },
            { fieldLabel: '发布时间', name: collecttype.releaseTime, flex: 1, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人', hidden: true, name: collecttype.writeUser, xtype: 'textfield' },
            { fieldLabel: '录入时刻', name: collecttype.writeTime, xtype: 'datefield', format: Sys.App.Config.dateFormat },
            { fieldLabel: '录入人Ip', hidden: true, name: collecttype.writeIp, xtype: 'textfield' }
        ]
    });
    var collecttypetopwindow = Ext.create('Sys.App.TopWindow', {
        title: '汇总分类查询界面',    //窗口名称
        iconCls: 'icon-queryRecord',
        width: 350, //界面初始化时宽、高
        height: 210,    //
        minWidth: 350,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 210, //
        items: collecttypequeryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    collecttypetopwindow.show();
}
/// 维护发布信息界面的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="releaseContents">对应类型的内容</param>
/// <param name="releaseType">发布类型</param>
/// <param name="collectTypeId">类型Id</param>
Sys.App.Release.ReleaseMessageEdit = function (isadd, releaseContents, releaseType, collectTypeId) {
    var collecttype = Sys.DB.CollectType;
    var insidecollect = Sys.DB.InsideCollect;
    var productioncollect = Sys.DB.ProductionCollect;
    var projectcollect = Sys.DB.ProjectCollect;
    var handerurl = Sys.App.Release.CollectTypeCommon.handlerUrl;
    if (isadd == "true") {
        isadd = true;
    }
    else {
        if (releaseType == "1") {
            _insidecollect = releaseContents;
        }
        else if (releaseType == "2") {
            _productioncollect = releaseContents;
        }
        else if (releaseType == "3") {
            _projectcollect = releaseContents;
        }
        isadd = false;
    }
    handerurl += (isadd) ? '_add' : '_update';
    handerurl += "&releaseType=" + releaseType + "&collectTypeId=" + collectTypeId + "";
    var edithandler = {
        buttonclose: function () {
            _insidecollecttopwindow.close();
            _productioncollecttopwindow.close();
            _projectcollecttopwindow.close();
        },
        buttonsave: function () {
            var editform = "";
            if (releaseType == "1") {
                editform = _insidecollecteditform.getForm();
            }
            else if (releaseType == "2") {
                editform = _productioncollecteditform.getForm();
            }
            else if (releaseType == "3") {
                editform = _projectcollecteditform.getForm();
            }
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
                        _insidecollecttopwindow.close();
                        _productioncollecttopwindow.close();
                        _projectcollecttopwindow.close();
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
    //对内发布界面
    var _insidecollecteditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },        
        items: [
			{ fieldLabel: '内部汇总Id', hidden: true, name: insidecollect.insideCollectId, xtype: 'textfield' },
            { fieldLabel: '汇总分类Id', hidden: true, name: insidecollect.collectTypeId, xtype: 'textfield' },
			{ fieldLabel: '系统名称', name: insidecollect.systemName, xtype: 'textfield' },
			{ fieldLabel: '归档编号', name: insidecollect.fileNo, xtype: 'textfield' },
            { fieldLabel: '归档时间', name: insidecollect.fileTime, flex: 1, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人', hidden: true, name: insidecollect.writeUser, xtype: 'textfield' },
            { fieldLabel: '录入时刻', name: insidecollect.writeTime, readOnly: true, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人Ip', hidden: true, name: insidecollect.writeIp, xtype: 'textfield' }
        ]
    });
    var _insidecollecttopwindow = Ext.create('Sys.App.TopWindow', {
        title: '对内发布汇总界面',    //窗口名称
        width: 350, //界面初始化时宽、高
        height: 210,//
        minWidth: 350,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 210, //
        iconCls: Sys.App.Icon.addrecord,
        items: _insidecollecteditform,
        buttons: [
             { minWidth: 80, text: '保存', handler: edithandler.buttonsave },
             { minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = _insidecollecteditform.getForm();
                if (!isadd) {
                    editform.setValues(_insidecollect);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({ insideCollectId: '1', writeTime: new Date() });
                }
            }
        }
    });
    //对生产部发布界面
    var _productioncollecteditform = Ext.create('Sys.App.TopForm', {
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
            { fieldLabel: '归档时间', name: productioncollect.fileTime, flex: 1, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人', hidden: true, name: productioncollect.writeUser, xtype: 'textfield' },
            { fieldLabel: '录入时刻', name: productioncollect.writeTime, readOnly: true, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人Ip', hidden: true, name: productioncollect.writeIp, xtype: 'textfield' }
        ]
    });
    var _productioncollecttopwindow = Ext.create('Sys.App.TopWindow', {
        title: '对生产部发布汇总界面',    //窗口名称
        width: 350, //界面初始化时宽、高
        height: 210,//
        minWidth: 350,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 210, //
        iconCls: Sys.App.Icon.addrecord,
        items: _productioncollecteditform,
        buttons: [
             { minWidth: 80, text: '保存', handler: edithandler.buttonsave },
             { minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = _productioncollecteditform.getForm();
                if (!isadd) {
                    editform.setValues(_productioncollect);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({ productionCollectId: '1', writeTime: new Date() });
                }
            }
        }
    });
    //对工程部发布
    var _projectcollecteditform = Ext.create('Sys.App.TopForm', {
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
            { fieldLabel: '归档时间', name: projectcollect.fileTime, flex: 1, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人', hidden: true, name: projectcollect.writeUser, xtype: 'textfield' },
            { fieldLabel: '录入时刻', name: projectcollect.writeTime, readOnly: true, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人Ip', hidden: true, name: projectcollect.writeIp, xtype: 'textfield' }
        ]
    });
    var _projectcollecttopwindow = Ext.create('Sys.App.TopWindow', {
        title: '对工程部发布汇总界面',    //窗口名称
        width: 380, //界面初始化时宽、高
        height: 240,//
        minWidth: 380,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 240, //
        iconCls: Sys.App.Icon.addrecord,
        items: _projectcollecteditform,
        buttons: [
             { minWidth: 80, text: '保存', handler: edithandler.buttonsave },
             { minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = _projectcollecteditform.getForm();
                if (!isadd) {
                    editform.setValues(_projectcollect);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({ projectCollectId: '1', writeTime: new Date() });
                }
            }
        }
    });
    if (releaseType == "1") {
        _insidecollecttopwindow.show();
    }
    else if (releaseType == "2") {
        _productioncollecttopwindow.show();
    }
    else if (releaseType == "3") {
        _projectcollecttopwindow.show();
    }
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Release.CollectTypeMain = function (mainPanel, node) {
    var collecttype = Sys.DB.CollectType;
    var handerurl = Sys.App.Release.CollectTypeCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Release.CollectTypeEdit(true, collecttypedata);
        },
        updaterecord: function () {
            Sys.App.Release.CollectTypeEdit(false, collecttypedata, collecttypegrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            var hrefurl = "handler/release/IsExitReleaseConent.ashx?releaseType=" + collecttypegrid.getSelectionModel().getSelection()[0].data.releaseType + "&collectTypeId=" + collecttypegrid.getSelectionModel().getSelection()[0].data.collectTypeId + "";
            Ext.Ajax.request({
                url: hrefurl,
                success: function (response) {
                    var result = Ext.decode(response.responseText);
                    if (result.exit == "true") {
                        Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                            if (btn == 'yes') {
                                var currentselectrows = collecttypegrid.getSelectionModel().getSelection();
                                Ext.Ajax.request({
                                    url: handerurl + 'delete',
                                    params: { collectTypeId: currentselectrows[0].data.collectTypeId },
                                    success: function (response) {
                                        var result = Ext.decode(response.responseText);
                                        if (result.success == 'true') {
                                            Sys.App.MsgSuccess('删除成功！');
                                            collecttypedata.reload();
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
                    }
                    else {
                        Sys.App.MsgFailure('"该类型下存在具体内容，请删除内容后再删除类型~"');
                    }
                },
                failure: function (response, opts) {
                    Sys.App.MsgFailure('"服务端失败，状态码：" ' + response.status);
                }
            });
        },
        queryrecord: function () {
            Sys.App.Release.CollectTypeQuery(collecttypegrid);
        },
        outputtoexcel: function () {
            Sys.App.ExportExcel(collecttypegrid, handerurl + 'outputexcel');
        },
        refreshrecord: function () {
            collecttypedata.reload();
        },
        editreleaserecord: function () {
            var hrefurl = "handler/release/IsExitReleaseConent.ashx?releaseType=" + collecttypegrid.getSelectionModel().getSelection()[0].data.releaseType + "&collectTypeId=" + collecttypegrid.getSelectionModel().getSelection()[0].data.collectTypeId + "";
            Ext.Ajax.request({
                url: hrefurl,
                success: function (response) {
                    var result = Ext.decode(response.responseText);
                    Sys.App.Release.ReleaseMessageEdit(result.exit, result.topics[0], collecttypegrid.getSelectionModel().getSelection()[0].data.releaseType, collecttypegrid.getSelectionModel().getSelection()[0].data.collectTypeId);
                },
                failure: function (response, opts) {
                    Sys.App.MsgFailure('"服务端失败，状态码：" ' + response.status);
                }
            });
        }
    };
    Ext.define('CollectTypeModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: collecttype.collectTypeId, type: 'int' },
			{ name: collecttype.releaseNo, type: 'string' },
			{ name: collecttype.releaseType, type: 'int' },
			{ name: collecttype.releaseTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: collecttype.writeUser, type: 'int' },
			{ name: collecttype.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: collecttype.writeIp, type: 'string' }
        ]
    });
    var collecttypedata = Ext.create('Ext.data.Store', {
        model: 'CollectTypeModel',
        defaultPageSize: Sys.App.Release.CollectTypeCommon.listPagesize,
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
    var collecttypegrid = Ext.create('Sys.App.TabInnerGrid', {
        store: collecttypedata,
        columns: [
           { xtype: 'rownumberer' },
           { text: "汇总分类Id", hidden: true, dataIndex: collecttype.collectTypeId, sortable: true },
           { text: "发布编号", flex: true, dataIndex: collecttype.releaseNo, sortable: true },
           { text: "发布类型", flex: true, dataIndex: collecttype.releaseType, renderer: Sys.App.Common.getReleaseTypeName, sortable: true },
           { text: "发布时间", flex: true, dataIndex: collecttype.releaseTime, sortable: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat) },
           { text: "录入人", hidden: true, dataIndex: collecttype.writeUser, sortable: true },
		   { text: "录入时刻", flex: true, dataIndex: collecttype.writeTime, sortable: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat) },
           { text: "录入人Ip", hidden: true, flex: true, dataIndex: collecttype.writeIp, sortable: true }
        ],
        tbar: [
			{ text: '查询条件', tooltip: '查询条件', iconCls: Sys.App.Icon.queryrecord, handler: tbarhandler.queryrecord }, '-',
            { text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
            { text: '新增', tooltip: '新增', iconCls: Sys.App.Icon.addrecord, handler: tbarhandler.addrecord }, '-',
			{ text: '编辑', tooltip: '编辑', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',
			{ text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord },
            '->', { text: '维护发布内容', tooltip: '维护发布内容', disabled: true, itemId: 'editreleaseBtn', iconCls: Sys.App.Icon.editrecord, handler: tbarhandler.editreleaserecord }, '-',
            { text: '导出表格', tooltip: '导出表格', iconCls: Sys.App.Icon.excelexport, handler: tbarhandler.outputtoexcel }
        ],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: collecttypedata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    collecttypegrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    collecttypegrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    collecttypegrid.down('#editreleaseBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    collecttypegrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, collecttypegrid);
}
