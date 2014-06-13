/****************************************
***生成器版本：V1.2.4.21968
***创建人：bhlfy
***创建时间：2012-10-12 14:27:01
***公司：iCat Studio
***修改人：
***修改时间：2012-10-12 14:27:01
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。
Sys.App.Manage.MenuCommon = {
    handlerUrl: 'handler/manage/Menu.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="menuData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Manage.MenuEdit = function (isadd, menuData, currentrows) {
    var menu = Sys.DB.Menu;
    var handerurl = Sys.App.Manage.MenuCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            menutopwindow.close();

        },
        buttonsave: function () {
            var editform = menueditform.getForm();
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
                        menuData.reload();
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
            menutopwindow.close();
        }
    };
    var menueditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 120, //可微调，以适应不同的界面。
            anchor: '95%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '菜单编号', hidden: true, name: menu.menuId, xtype: 'textfield' },
			{ fieldLabel: '当前菜单编号', name: menu.currentId, allowBlank: false, xtype: 'textfield' },
			{ fieldLabel: '父菜单编号', name: 'parentId_new', allowBlank: false, xtype: 'textfield' },
			{ fieldLabel: '菜单名称', name: menu.menuName, allowBlank: false, maxLength: 40, xtype: 'textfield' },
			{ fieldLabel: '图标样式名', name: menu.iconCls, maxLength: 40, xtype: 'textfield' },
			{ fieldLabel: 'URL地址', name: menu.htmlurl, maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '菜单链接的事件名', name: menu.eventName, maxLength: 100, xtype: 'textfield' },
			{ fieldLabel: '排序', name: menu.sort, allowBlank: false, xtype: 'textfield' },
            {
                fieldLabel: '是否可用',
                name: menu.usable,
                store: Sys.App.Common.storeUsable,
                hiddenName: menu.usable,   //很关键的配置
                allowBlank: false,
                editable: false,
                queryMode: 'local',
                displayField: 'describe',
                valueField: menu.usable,
                xtype: 'combo'
            }
		]
    });
    var menutopwindow = Ext.create('Sys.App.TopWindow', {
        title: '菜单信息维护界面',    //窗口名称
        width: 450, //界面初始化时宽、高
        height: 300,    //
        minWidth: 450,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 300, //
        iconCls: Sys.App.Icon.addrecord,
        items: menueditform,
        buttons: [
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
		],
        listeners: {
            'show': function () {
                var editform = menueditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({ menuId: '1' });
                }
            }
        }
    });
    menutopwindow.show();
}

Sys.App.Manage.MenuMain = function (mainPanel, node) {
    var menu = Sys.DB.Menu;
    var handerurl = Sys.App.Manage.MenuCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Manage.MenuEdit(true, menudata);
        },
        updaterecord: function () {
            Sys.App.Manage.MenuEdit(false, menudata, menutree.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = menutree.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { menuId: currentselectrows[0].data.menuId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                menudata.reload();
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
            Sys.App.Manage.MenuQuery(menugrid);
        },
        refreshrecord: function () {
            menudata.reload();
            menutree.down('#editBtn').setDisabled(true);
            menutree.down('#removeBtn').setDisabled(true);

        }
    };
    Ext.define('MenuModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: menu.menuId, type: 'int' },
			{ name: menu.currentId, type: 'int' },
			{ name: 'parentId_new', type: 'int' },  //字段和Ext定义属性冲突
			{ name: menu.menuName, type: 'string' },
			{ name: menu.iconCls, type: 'string' },
			{ name: menu.htmlurl, type: 'string' },
			{ name: menu.eventName, type: 'string' },
			{ name: menu.sort, type: 'int' },
			{ name: menu.usable, type: 'bool' }
		]
    });
    var menudata = Ext.create('Ext.data.TreeStore', {
        model: 'MenuModel',
        proxy: {
            type: 'ajax',
            actionMethods: { read: 'post' },
            url: handerurl + 'listtree'
        },
        folderSort: true
    });
    var menutree = Ext.create('Ext.tree.Panel', {
        useArrows: true,
        rootVisible: false,
        store: menudata,
        rowLines: true,
        columnLines: true,
        tbar: [
			{ text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
            { text: '新增', tooltip: '新增', iconCls: Sys.App.Icon.addrecord, handler: tbarhandler.addrecord }, '-',
			{ text: '编辑', tooltip: '编辑', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',
			{ text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord }
		],
        columns: [
            { xtype: 'treecolumn', text: '菜单名称', flex: true, sortable: true, dataIndex: menu.menuName },
            { text: "链接", dataIndex: menu.eventName, flex: true },
            { text: "当前菜单编号", dataIndex: menu.currentId },
            { text: "父菜单编号", dataIndex: 'parentId_new' },
            { text: "是否可用", dataIndex: menu.usable, renderer: Sys.App.Common.getUsableName },
            { text: "排序", dataIndex: menu.sort }
        ]
    });
    //注册侦听选择单行时按钮可用的事件
    menutree.getSelectionModel().on('selectionchange',
		function (sm) {
		    menutree.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    menutree.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    var menutopwindow = Ext.create('Sys.App.TopWindow', {
        title: '菜单信息维护界面',    //窗口名称
        width: 800, //界面初始化时宽、高
        height: 500,    //
        minWidth: 800,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 500, //
        border:false,
        iconCls: Sys.App.Icon.configuration,
        items: menutree
    });
    menutopwindow.show();
}
