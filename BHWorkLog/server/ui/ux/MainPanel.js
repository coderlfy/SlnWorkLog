Sys.App.MainPage = function () {
    var userinformation = Ext.create('Ext.grid.property.Grid', {
        id: 'userinformation',
        border: false,
        sortableColumns: false,
        nameColumnWidth: 140,
        propertyNames: {
            contactus: '联系方式',
            developby: '系统研发单位',
            systemversion: '系统版本号',
            Username: '用户名',
            serverIp: '服务器IP地址',
            clientIp: '客户端IP地址',
            osname: '客户端操作系统',
            browser: '您的浏览器',
            logontime: '本次登录时刻',
            fullname: '用户姓名',
            browserversion: '浏览器版本'
        },
        source: {},
        listeners: {
            'beforeedit': function (e) {
                e.cancel = true;
                return false;
            }
        }
    });


    return userinformation;
};
Ext.define("Sys.App.MainPanel", {
    extend: 'Ext.tab.Panel',
    tabNamePrefix: 'docPanel-',
    initComponent: function (config) {
        var me = this;
        var currentItem;
        Ext.apply(me, config);

        me.id = 'doc-body';
        me.region = 'center';
        me.margins = '0 0 0 0'; //bhlfyoldCss 0 5 5 0
        me.cls = 'MainPanel';
        me.resizeTabs = true;
        //plugins: new Ext.ux.TabCloseMenu(),
        me.enableTabScroll = true;
        me.bodyPadding = 0; //bhlfyoldCss 5
        me.activeTab = 0;
        me.items = [{
            id: 'welcome-panel',
            title: '系统首页',
            items: [{
                title: '参考信息',
                region: 'east',
                margins: '0 0 0 0',
                cmargins: '5 5 0 0',
                width: 300,
                minSize: 300,
                maxSize: 400,
                bbar: ['->', {
                    text: '下载通讯录',
                    iconCls: Sys.App.Icon.downloadhelpdoc,
                    handler: function () {
                        Sys.App.ExportAddressBook(Sys.App.Manage.ApplicationUserCommon.handlerUrl + 'outputaddress');
                    }
                }, {
                    text: '注销用户',
                    iconCls: Sys.App.Icon.exitSystem,
                    handler: function () {
                        location.href = 'logon.html';
                    }
                }],
                items: [Sys.App.MainPage()]
            }, {
                collapsible: false,
                region: 'center',
                margins: '0 0 0 0',
                layout: 'fit',
                border: false,
                items: [Sys.App.Chart.AddToMainPanel()]
            }],
            iconCls: 'icon-docs',
            minHeight: 30,
            layout: 'border',
            defaults: {
                collapsible: true,
                split: true
            },
            autoScroll: true
        }];
        me.plugins = Ext.create('Ext.ux.TabCloseMenu', {
            closeTabText: '关闭当前选单',
            closeOthersTabsText: '关闭其他所有选单',
            closeAllTabsText: '关闭所有选单'
        });
        me.callParent(arguments);
    },
    initEvents: function () {
        this.superclass.initEvents.call(this);
        this.body.on('click', this.onClick, this);
        this.on('tabchange', this.tabChange, this);
    },
    tabChange: function (tabpanel, newcard) {
        //tab切换的时候将具体定位菜单active位置。
    },
    onClick: function (e, target) {
        if (target = e.getTarget('a:not(.exi)', 3)) {
            var cls = Ext.fly(target).getAttributeNS('ext', 'cls');
            e.stopEvent();
            if (cls) {

                var member = Ext.fly(target).getAttributeNS('ext', 'member');
                //this.loadClass(target.href, null, cls, member);
            } else if (target.className == 'inner-link') {
                this.getActiveTab().scrollToSection(target.href.split('#')[1]);
            } else {
                window.open(target.href);
            }
        } else if (target = e.getTarget('.micon', 2)) {
            e.stopEvent();
            var tr = Ext.fly(target.parentNode);
            if (tr.hasClass('expandable')) {
                tr.toggleClass('expanded');
            }
        }
    },
    loadClass: function (node) { //href, jsForm, cls, member
        var tabid = this.tabNamePrefix + node.id;
        var tab = this.getComponent(tabid);
        if (tab) {
            this.setActiveTab(tab);
            //if (node.attributes.member) {
            //    tab.scrollToMember(node.attributes.member);
            //}
        } else {
            //如设置有锚点，可直接scroll指定位置
            /*var autoLoad = { url: href };
            if (member) {
            autoLoad.callback = function () {
            Ext.getCmp(id).scrollToMember(member);
            }
            }*/
            var execEvent = eval(node.hrefTarget);
            if (execEvent != null)
                execEvent(this, node);
        }
    },
    viewContent: function (node, grid) {
        var tab = this.getComponent(this.tabNamePrefix + node.id);
        if (!tab) {
            tab = this.add(new Sys.App.DocPanel({
                id: this.tabNamePrefix + node.id,
                cclass: node.text,
                iconCls: node.iconCls,
                items: grid
            }));
        }
        this.setActiveTab(tab);
    }
});
