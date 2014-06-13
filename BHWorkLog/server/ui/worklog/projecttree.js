/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhlfy
***创建时间：2013-04-25 10:36:07
***公司：山西博华科技有限公司
***修改人：
***修改时间：2013-04-25 10:36:07
***文件描述：。
*****************************************/

Sys.App.WorkLog.ProjectTreeEdit = function (isadd, wlogprojecttreeData, currentrows) {
    var wlogprojecttree = Sys.DB.WLOGProjectTree;
    var handerurl = Sys.App.WorkLog.ProjectTreeCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            wlogprojecttreetopwindow.close();

        },
        buttonsave: function () {
            var editform = wlogprojecttreeeditform.getForm();
            if (!editform.isValid())
                return;
            editform.submit({
                url: handerurl,
                method: 'post',
                success: function (frm, action) {
                    var result = action.result;
                    if (result.success == 'true') {
                        Sys.App.MsgSuccess('保存成功！');
                        wlogprojecttreeData.reload();
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
            wlogprojecttreetopwindow.close();
        }
    };
    var wlogprojecttreeeditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 120,
            anchor: '95%',
            labelAlign: 'right',
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '父项目节点', name: 'parentId_new', xtype: 'textfield' },
			{ fieldLabel: '当前项目节点编号', name: wlogprojecttree.currentId, hidden:true, xtype: 'textfield' },
			{ fieldLabel: '维护人', name: wlogprojecttree.writeUser, xtype: 'textfield' },
			{ fieldLabel: '项目节点描述', name: wlogprojecttree.dirName,maxLength:200, xtype: 'textfield' },
			{ fieldLabel: '录入人IP地址', name: wlogprojecttree.writeIp, maxLength: 30, hidden: true, xtype: 'textfield' },
            {
                fieldLabel: '是否可用',
                name: wlogprojecttree.usable,
                store: Sys.App.Common.storeUsable,
                hiddenName: wlogprojecttree.usable,   //很关键的配置
                allowBlank: false,
                editable: false,
                queryMode: 'local',
                displayField: 'describe',
                valueField: wlogprojecttree.usable,
                xtype: 'combo'
            }
        ]
    });
    var wlogprojecttreetopwindow = Ext.create('Sys.App.TopWindow', {
        title: '项目架构信息维护界面',    //窗口名称
        width: 450, //界面初始化时宽、高
        height: 200,    //
        minWidth: 450,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 200, //
        iconCls: Sys.App.Icon.addrecord,
        items: wlogprojecttreeeditform,
        buttons: [
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = wlogprojecttreeeditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    var parentid = (currentrows.length == 0) ? '0' : currentrows[0].data.currentId;
                    editform.setValues({
                        currentId: '1',
                        parentId_new: parentid
                    });
                }
            }
        }
    });
    wlogprojecttreetopwindow.show();
}

Sys.App.WorkLog.ProjectTreeMain = function (mainPanel, node) {
    var wlogprojecttree = Sys.DB.WLOGProjectTree;
    var handerurl = Sys.App.WorkLog.ProjectTreeCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.WorkLog.ProjectTreeEdit(true, wlogprojecttreedata, wlogprojecttreegrid.getSelectionModel().getSelection());
        },
        updaterecord: function () {
            Sys.App.WorkLog.ProjectTreeEdit(false, wlogprojecttreedata, wlogprojecttreegrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = wlogprojecttreegrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { currentId: currentselectrows[0].data.currentId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                wlogprojecttreedata.reload();
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
            //Sys.App.Manage.MenuQuery(menugrid);
        },
        refreshrecord: function () {
            wlogprojecttreedata.reload();
            wlogprojecttreegrid.down('#editBtn').setDisabled(true);
            wlogprojecttreegrid.down('#removeBtn').setDisabled(true);

        }
    };
    Ext.define('WLOGProjectTreeModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: 'parentId_new', type: 'int' },
			{ name: wlogprojecttree.currentId, type: 'int' },
			{ name: wlogprojecttree.writeUser, type: 'int' },
			{ name: wlogprojecttree.dirName, type: 'string' },
			{ name: wlogprojecttree.usable, type: 'bool' },
			{ name: wlogprojecttree.writeIp, type: 'string' },
			{ name: wlogprojecttree.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat }
        ]
    });
    var wlogprojecttreedata = Ext.create('Ext.data.TreeStore', {
        model: 'WLOGProjectTreeModel',
        proxy: {
            type: 'ajax',
            url: handerurl + 'listtree',
            actionMethods: { read: 'POST' }
        },
        folderSort: true
    });
    var wlogprojecttreegrid = Ext.create('Ext.tree.Panel', {
        useArrows: true,
        rootVisible: false,
        store: wlogprojecttreedata,
        rowLines: true,
        columnLines: true,
        tbar: [
			{ text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
            { text: '删除', tooltip: '删除所选', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord },
            '->', { text: '新增子目录', tooltip: '新增子目录/如未选择则新增根项节点', iconCls: Sys.App.Icon.addrecord, handler: tbarhandler.addrecord }, '-',
			{ text: '编辑所选', tooltip: '编辑所选', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }
        ],
        columns: [
            { xtype: 'treecolumn', text: '项目架构目录', flex: true, sortable: true, dataIndex: wlogprojecttree.dirName },
            { text: "当前目录编号", hidden:true, dataIndex: wlogprojecttree.currentId },
            { text: "父目录编号", hidden: true, dataIndex: 'parentId_new' },
            { text: "是否可用", dataIndex: wlogprojecttree.usable, renderer: Sys.App.Common.getUsableName }
        ]
    });
    //注册侦听选择单行时按钮可用的事件
    wlogprojecttreegrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    wlogprojecttreegrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    wlogprojecttreegrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    var wlogprojecttreetopwindow = Ext.create('Sys.App.TopWindow', {
        title: '项目架构信息维护界面',    //窗口名称
        width: 800, //界面初始化时宽、高
        height: 500,    //
        minWidth: 800,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 500, //
        border: false,
        iconCls: Sys.App.Icon.configuration,
        items: wlogprojecttreegrid
    });

    wlogprojecttreetopwindow.show();
}
