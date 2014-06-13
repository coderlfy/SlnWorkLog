/****************************************
***生成器版本：V1.2.3.15644
***创建人：bhshf
***创建时间：2012-10-13 08:43:35
***公司：iCat Studio
***修改人：
***修改时间：2012-10-13 08:43:35
***文件描述：分配角色权限。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Manage.RoleControlMenuCommon = {
    handlerUrl: 'handler/manage/RoleControlMenu.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};

Sys.App.Manage.RoleControlMenuMain = function (mainPanel, node) {
    var rolecontrolmenu = Sys.DB.RoleControlMenu;
    var handerurl = Sys.App.Manage.RoleControlMenuCommon.handlerUrl;
    var sethandler = {
        buttonclose: function () {
            rolecontrolmenutopwindow.close();
        },
        buttonsave: function () {
            var roleid = menutree.down('#' + Sys.DB.SystemRole.roleId).getValue();
            var records = menutree.getView().getChecked();
            menuId = [];

            Ext.Array.each(records, function (rec) {
                menuId.push(rec.get('id'));
            });
            if (roleid != null) {
                Ext.Ajax.request({
                    method: 'post',
                    params: { menuid: menuId, roleid: roleid },
                    url: handerurl + 'update',
                    success: function (action) {
                        var result = action.responseText;
                        if (result.success = 'true') {
                            Sys.App.MsgSuccess('保存成功！');
                            rolecontrolmenudata.reload();
                        }
                        else {
                            Sys.App.MsgSuccess('保存失败！');
                            rolecontrolmenudata.reload();
                        }
                    },
                    failure: function (response, opts) {
                        Sys.App.Error(response);
                    }
                });
                rolecontrolmenutopwindow.close();
            }
            else {
                Sys.App.MsgSuccess('权限角色不能为空！');
            }
        }
    };
    var tbarhandler = {
        refreshrecord: function () {
            rolecontrolmenudata.reload();
        }
    };
    var rolecontrolmenudata = Ext.create('Ext.data.TreeStore', {
        proxy: {
            type: 'ajax',
            actionMethods: { read: 'post' },
            url: Sys.App.Manage.MenuCommon.handlerUrl + 'listbyrolecontrol&roleId=' + Sys.Paramters.roleId    //定位到第一个可被控制的权限组
        }
    });

    var menutree = Ext.create('Ext.tree.Panel', {
        useArrows: true,
        rootVisible: false,
        store: rolecontrolmenudata,
        border: false,
        columnLines: true,
        buttonAlign: 'center',
        tbar: [
            {
                fieldLabel: '待分配权限的角色',
                labelWidth: 110,
                name: Sys.DB.SystemRole.roleId,
                itemId: Sys.DB.SystemRole.roleId,
                store: Sys.App.Common.storeRole,
                hiddenName: Sys.DB.SystemRole.roleId,
                allowBlank: true,
                editable: false,
                queryMode: 'local',
                displayField: Sys.DB.SystemRole.roleName,
                valueField: Sys.DB.SystemRole.roleId,
                xtype: 'combo',
                listeners: {
                    'render': function () {
                        var firstbymanage = Sys.App.Common.RoleInit(Sys.Paramters.roleId); //此处需动态设置当前用户的权限组
                        this.setValue(firstbymanage);
                    },
                    'select': function (combo, record, index) {
                        rolecontrolmenudata.proxy.url = Sys.App.Manage.MenuCommon.handlerUrl + 'listbyrolecontrol&roleId=' + this.getValue();
                        rolecontrolmenudata.reload();
                    }
                }
            }, '-',
            {
                text: '刷新',
                tooltip: '在上次查询条件基础上，重新从服务器获取数据',
                iconCls: Sys.App.Icon.refreshrecord,
                handler: tbarhandler.refreshrecord
            }
        ],
        viewConfig: {
            onCheckboxChange: function (e, t) {
                var item = e.getTarget(this.getItemSelector(), this.getTargetEl()), record;
                if (item) {
                    record = this.getRecord(item);
                    var check = !record.get('checked');
                    record.set('checked', check);
                    if (check) {
                        record.cascadeBy(function (node) {
                            node.set('checked', true);
                            while (true) {
                                node = node.parentNode;
                                if (node != null)
                                    node.set('checked', true);
                                else
                                    break;
                            }
                        });
                    } else {
                        record.cascadeBy(function (node) {
                            node.set('checked', false);
                        });
                    }
                }
            }
        },
        buttons: [
            { minWidth: 80, text: '保存', handler: sethandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: sethandler.buttonclose }
		]
    });

    var rolecontrolmenutopwindow = Ext.create('Sys.App.TopWindow', {
        title: '分配角色权限界面',    //窗口名称
        width: 350, //界面初始化时宽、高
        height: 500,    //
        minWidth: 350,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 500, //
        iconCls: Sys.App.Icon.configuration,
        items: menutree
    });

    rolecontrolmenutopwindow.show();
}
