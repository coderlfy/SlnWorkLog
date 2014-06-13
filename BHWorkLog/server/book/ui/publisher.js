/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***创建时间：2013-08-20 09:08:51
***公司：山西博华科技有限公司
***修改人：
***修改时间：2013-08-20 09:08:51
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Book.BookPublisherCommon = {
    handlerUrl: 'book/handler/BookzPublisher.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="bookpublisherData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Book.BookPublisherEdit = function (isadd, bookpublisherData, currentrows) {
    var bookpublisher = Sys.DB.BookPublisher;
    var handerurl = Sys.App.Book.BookPublisherCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            bookpublishertopwindow.close();
        },
        buttonsave: function () {
            var editform = bookpublishereditform.getForm();
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
                        bookpublisherData.reload();
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
            bookpublishertopwindow.close();
        }
    };
    var bookpublishereditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '出版社的编号', name: bookpublisher.publisherId, xtype: 'textfield' },
			{ fieldLabel: '出版社名称', name: bookpublisher.publisherName, maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '地址', name: bookpublisher.address, maxLength: 400, xtype: 'textfield' },
			{ fieldLabel: '是否可用', name: bookpublisher.usable, xtype: 'textfield' },
			{ fieldLabel: '排序号', name: bookpublisher.sort, xtype: 'textfield' }
        ]
    });
    var bookpublishertopwindow = Ext.create('Sys.App.TopWindow', {
        title: '出版社信息维护',    //窗口名称
        width: 400, //界面初始化时宽、高
        height: 220,    //
        minWidth: 300,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 190, //
        iconCls: Sys.App.Icon.addrecord,
        items: bookpublishereditform,
        buttons: [
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = bookpublishereditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({});
                }
            }
        }
    });
    bookpublishertopwindow.show();
}
/// 查询条件界面的定义
/// <param name="bookpublishergrid">引用了列表框对象</param>
Sys.App.Book.BookPublisherQuery = function (bookpublishergrid) {
    var bookpublisher = Sys.DB.BookPublisher;
    var queryhandler = {
        buttonclose: function () {
            bookpublishertopwindow.close();
        },
        buttonquery: function () {
            var queryform = bookpublisherqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(bookpublishergrid.store.proxy.extraParams, {
                publisherId: getvalue(bookpublisher.publisherId),
                publisherName: getvalue(bookpublisher.publisherName),
                address: getvalue(bookpublisher.address),
                usable: getvalue(bookpublisher.usable),
                sort: getvalue(bookpublisher.sort)
            });
            bookpublishergrid.down('#pagingToolbar').moveFirst();
            bookpublishertopwindow.close();
        }
    }
    var bookpublisherqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '出版社的编号', name: bookpublisher.publisherId, xtype: 'textfield' },
			{ fieldLabel: '出版社名称', name: bookpublisher.publisherName, maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '地址', name: bookpublisher.address, maxLength: 400, xtype: 'textfield' },
			{ fieldLabel: '是否可用', name: bookpublisher.usable, xtype: 'textfield' },
			{ fieldLabel: '排序号', name: bookpublisher.sort, xtype: 'textfield' }
        ]
    });
    var bookpublishertopwindow = Ext.create('Sys.App.TopWindow', {
        title: '查询出版社信息',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 220,    //
        minWidth: 300,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 190, //
        items: bookpublisherqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    bookpublishertopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Book.BookPublisherMain = function (mainPanel, node) {
    var bookpublisher = Sys.DB.BookPublisher;
    var handerurl = Sys.App.Book.BookPublisherCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Book.BookPublisherEdit(true, bookpublisherdata);
        },
        updaterecord: function () {
            Sys.App.Book.BookPublisherEdit(false, bookpublisherdata, bookpublishergrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = bookpublishergrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: {},
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                bookpublisherdata.reload();
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
            Sys.App.Book.BookPublisherQuery(bookpublishergrid);
        },
        refreshrecord: function () {
            bookpublisherdata.reload();
        }
    };
    Ext.define('BookPublisherModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: bookpublisher.publisherId, type: 'int' },
			{ name: bookpublisher.publisherName, type: 'string' },
			{ name: bookpublisher.address, type: 'string' },
			{ name: bookpublisher.usable, type: 'bool' },
			{ name: bookpublisher.sort, type: 'int' }
        ]
    });
    var bookpublisherdata = Ext.create('Ext.data.Store', {
        model: 'BookPublisherModel',
        defaultPageSize: Sys.App.Book.BookPublisherCommon.listPagesize,
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
    var bookpublishergrid = Ext.create('Sys.App.TabInnerGrid', {
        store: bookpublisherdata,
        columns: [
			{ xtype: 'rownumberer', width: 35 },
			{ text: "出版社的编号",  flex: true, dataIndex: bookpublisher.publisherId, sortable: true },
			{ text: "出版社名称",  flex: true, dataIndex: bookpublisher.publisherName, sortable: true },
			{ text: "地址",  flex: true, dataIndex: bookpublisher.address, sortable: true },
			{ text: "是否可用",flex: true, dataIndex: bookpublisher.usable, sortable: true },
			{ text: "排序号", dataIndex: bookpublisher.sort, sortable: true }
        ],
        tbar: [
			{ text: '查询条件', tooltip: '查询条件', iconCls: Sys.App.Icon.queryrecord, handler: tbarhandler.queryrecord }, '-',
			{ text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
            { text: '新增', tooltip: '新增', iconCls: Sys.App.Icon.addrecord, handler: tbarhandler.addrecord }, '-',
			{ text: '编辑', tooltip: '编辑', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',
			{ text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord }
        ],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: bookpublisherdata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    bookpublishergrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    bookpublishergrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    bookpublishergrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, bookpublishergrid);
}
