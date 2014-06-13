/// <reference path="../../ext/ext-all.js" />
/// <reference path="base/Namespace.js" />
/// <reference path="parameters.js" />

/****************************************
***创建人：bhlfy
***创建时间：2013-03-08 08:06:44
***公司：山西博华科技有限公司
***修改人：
***修改时间：2013-03-08 08:06:44
***文件描述：。
*****************************************/
Ext.onReady(function () {
    var cookieprovider = new Ext.state.CookieProvider();
    Ext.state.Manager.setProvider(cookieprovider);

    //本页面所显示各组件对象的申明与初始化
    var maininnerpanel = new Sys.App.MainPanel();
    var toppanel = new Ext.Component({
        region: 'north',
        cls: 'docs-header',
        border: false,
        height: 51,
        margins: '0 0 0 0',
        autoEl: {
            tag: 'div',
            html: '<div id="header_body"><table cellspacing="0" cellpadding="0" width="100%">' +
                '<tr><td><img src="businessimages/logo.png"/></td>' +
                //'<td style="color:white;" width="40%" align="right"></td>' +
                '</tr></table></div>'
        }
    });

    var leftpanel = new Ext.Panel({
        region: 'west',
        width: 200,
        minSize: 175,
        maxSize: 300,
        title: '系统菜单',
        split: true,
        //border: true,
        margins: '0 0 0 0',
        //collapseMode: 'mini',
        collapsible: true,
        animCollapse: true,
        layout: { type: 'accordion', animate: true }
    });
    var mainpanel = new Ext.Panel({
        layout: 'border',
        region: 'center',
        border: false,
        items: [maininnerpanel]
    });
    var viewport = new Ext.Viewport({
        layout: 'border',
        items: [toppanel, leftpanel, mainpanel]
    });

    //获取菜单数据
    Ext.Ajax.request({
        url: 'handler/manage/Menu.ashx?action=logon',
        success: function (response, opts) {
            var obj = Ext.decode(response.responseText);
            Sys.Paramters.roleId = obj.roleId;
            Sys.Paramters.userid = obj.userid;
            for (var i in obj.topics) {
                var systree = null;
                //获取各子系统的子菜单。
                if (obj.topics[i].children.length > 0)
                    systree = new Sys.App.MenuTree({
                        id: 'menutree-' + obj.topics[i].menuid,
                        data: obj.topics[i].children,
                        mainPanel: maininnerpanel
                    });
                //在菜单栏添加各子系统，并绑定子菜单。
                leftpanel.add({
                    id: 'Accordion-' + obj.topics[i].menuid,
                    title: obj.topics[i].menuname,
                    border: false,
                    autoScroll: false,
                    iconCls: 'icon-cmp',
                    layout: 'fit',
                    items: systree
                });
            }
        },
        failure: function (response, opts) {
            Sys.App.Error(response);
        }
    });

    Ext.Ajax.request({
        url: 'handler/logon.ashx?action=indexgetsession',
        params: { usbkeyid: cookieprovider.get('usbkeyid', ''), refreshtimes: cookieprovider.get('refreshtimes', '1') }, //传值方式有待改善
        success: function (response, opts) {
            var obj = Ext.decode(response.responseText);
            var userinformation = Ext.getCmp('userinformation');
            if (obj.Username == '') {
                Sys.App.MsgFailure('非正常登录，系统即将返回登录页！', null);
                location.href = 'logon.html';
                return;
            }
            cookieprovider.set('refreshtimes', '1');
            Sys.Paramters.username = obj.Username;
            Sys.Paramters.clientIp = obj.clientIp;
            Sys.Paramters.fullname = obj.fullname;
            Sys.Paramters.keyId = cookieprovider.get('usbkeyid', '');
            userinformation.setSource(obj);
        },
        failure: function (response, opts) {
            Sys.App.Error(response);
        }
    });

    //定时任务，当前检测usbkey的运行状态
    /*
    Ext.TaskManager.start({
        run: function () {
            var statusdiscribe = '';
            if (Sys.Paramters.roleId != '3') {
                var usbkeyobj = Sys.App.UsbKey.getValue();
                if (!usbkeyobj.success)
                    statusdiscribe = usbkeyobj.msg;
                else {
                    var valuearray = usbkeyobj.value.split(',');
                    if (valuearray.length != 3)
                        statusdiscribe = '密钥发布错误！';
                    else
                        if (valuearray[0] != Sys.Paramters.username)
                            statusdiscribe = '密钥与当前用户不匹配！';
                        else
                            statusdiscribe = '正常！';
                }
                userinformation.setProperty('usbkeystatus', statusdiscribe);
            }
        }, //执行任务时执行的函数
        interval: 5000
    });
    */
    //设置进度mask界面
    setTimeout(function () {
        Ext.get('loading').remove();
        Ext.get('loading-mask').fadeOut({ remove: true });
    }, 250);
});
