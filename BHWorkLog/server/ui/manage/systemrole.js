/****************************************
***生成器版本：V1.2.3.15644
***创建人：bhshf
***创建时间：2012-10-12 15:00:21
***公司：iCat Studio
***修改人：
***修改时间：2012-10-12 15:00:21
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Manage.SystemRoleMain = function (mainPanel, node) {
    var systemrole = Sys.DB.SystemRole;
    var handerurl = Sys.App.Manage.SystemRoleCommon.handlerUrl;
    var tbarhandler = {
        refreshrecord: function () {
            systemroledata.reload();
        }
    };
    Ext.define('SystemRoleModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: systemrole.roleId, type: 'int' },
			{ name: systemrole.roleName, type: 'string' },
			{ name: systemrole.usable, type: 'bool' },
			{ name: systemrole.remark, type: 'string' },
			{ name: systemrole.sort, type: 'int' }
		]
    });
    var systemroledata = Ext.create('Ext.data.Store', {
        model: 'SystemRoleModel',
        defaultPageSize: Sys.App.Manage.SystemRoleCommon.listPagesize,
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
    var systemrolegrid = Ext.create('Sys.App.TabInnerGrid', {
        store: systemroledata,
        columns: [
			{ xtype: 'rownumberer', width: 35 },
			{ text: "权限角色编号", hidden: true, dataIndex: systemrole.roleId, sortable: true },
			{ text: "权限组名称（角色）", flex: true, width: 225, dataIndex: systemrole.roleName, sortable: true },
			{ text: "是否可用", width: 225, dataIndex: systemrole.usable, renderer: Sys.App.Common.getUsableName, sortable: true },
			{ text: "备注", flex: true, width: 223, dataIndex: systemrole.remark, sortable: true },
			{ text: "排序", dataIndex: systemrole.sort, sortable: true }
		],
        tbar: [
			{ text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }
		],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: systemroledata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    systemrolegrid.getSelectionModel().on('selectionchange',
		function (sm) {
		}
	);
    mainPanel.viewContent(node, systemrolegrid);
}
