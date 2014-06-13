/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***创建时间：2013-08-16 17:09:42
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：2013-08-16 17:09:42
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Book.BookBelongToCommon = {
    handlerUrl: 'book/handler/BookBelongTo.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="bookbelongtoData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Book.BookBelongToEdit = function (isadd, bookbelongtoData, currentrows) {
    var bookbelongto = Sys.DB.BookBelongTo;
    var handerurl = Sys.App.Book.BookBelongToCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            bookbelongtotopwindow.close();
        },
        buttonsave: function () {
            var editform = bookbelongtoeditform.getForm();
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
                        bookbelongtoData.reload();
                        bookbelongtotopwindow.close();
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
    var bookbelongtoeditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '书籍所属人的编号', name: bookbelongto.belongtoId, xtype: 'textfield' },
			{ fieldLabel: '所属人全称', name: bookbelongto.fullname, maxLength: 200, xtype: 'textfield' },
			{
			    fieldLabel: '是否可用',
			    name: bookbelongto.usable,
			    store: Sys.App.Book.Common.storeUsable,
			    hiddenName: 'usable',   //很关键的配置
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    displayField: 'describe',
			    valueField: 'usable',
			    xtype: 'combo'
			},
			{ fieldLabel: '排序号', name: bookbelongto.sort, xtype: 'textfield' }
        ]
    });
    var bookbelongtotopwindow = Ext.create('Sys.App.TopWindow', {
        title: '书籍所属（人或单位）信息维护',    //窗口名称
        width: 400, //界面初始化时宽、高
        height: 220,    //
        minWidth: 300,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 190, //
        iconCls: Sys.App.Icon.addrecord,
        items: bookbelongtoeditform,
        buttons: [
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = bookbelongtoeditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({  });
                }
            }
        }
    });
    bookbelongtotopwindow.show();
}
/// 查询条件界面的定义
/// <param name="bookbelongtogrid">引用了列表框对象</param>
Sys.App.Book.BookBelongToQuery = function (bookbelongtogrid) {
    var bookbelongto = Sys.DB.BookBelongTo;
    var queryhandler = {
        buttonclose: function () {
            bookbelongtotopwindow.close();
        },
        buttonquery: function () {
            var queryform = bookbelongtoqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(bookbelongtogrid.store.proxy.extraParams, {
                belongtoId: getvalue(bookbelongto.belongtoId),
                fullname: getvalue(bookbelongto.fullname),
                usable: getvalue(bookbelongto.usable),
                sort: getvalue(bookbelongto.sort)
            });
            bookbelongtogrid.down('#pagingToolbar').moveFirst();
            bookbelongtotopwindow.close();
        }
    }
    var bookbelongtoqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '书籍所属人的编号', name: bookbelongto.belongtoId, xtype: 'textfield' },
			{ fieldLabel: '所属人全称', name: bookbelongto.fullname, maxLength: 200, xtype: 'textfield' },
			{
			    fieldLabel: '是否可用',
			    name: bookbelongto.usable,
			    store: Sys.App.Book.Common.storeUsable,
			    hiddenName: 'usable',   //很关键的配置
			    editable: false,
			    queryMode: 'local',
			    displayField: 'describe',
			    valueField: 'usable',
			    xtype: 'combo'
			},
			{ fieldLabel: '排序号', name: bookbelongto.sort, xtype: 'textfield' }
        ]
    });
    var bookbelongtotopwindow = Ext.create('Sys.App.TopWindow', {
        title: '查询书籍所属（人或单位）信息',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 220,    //
        minWidth: 300,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 190, //
        items: bookbelongtoqueryform,
        buttons: [
             { minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
             { minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    bookbelongtotopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Book.BookBelongToMain = function (mainPanel, node) {
    var bookbelongto = Sys.DB.BookBelongTo;
    var handerurl = Sys.App.Book.BookBelongToCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Book.BookBelongToEdit(true, bookbelongtodata);
        },
        updaterecord: function () {
            Sys.App.Book.BookBelongToEdit(false, bookbelongtodata, bookbelongtogrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = bookbelongtogrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { belongtoId: currentselectrows[0].data.belongtoId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                bookbelongtodata.reload();
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
            Sys.App.Book.BookBelongToQuery(bookbelongtogrid);
        },
        refreshrecord: function () {
            bookbelongtodata.reload();
        }
    };
    Ext.define('BookBelongToModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: bookbelongto.belongtoId, type: 'int' },
			{ name: bookbelongto.fullname, type: 'string' },
			{ name: bookbelongto.usable, type: 'bool' },
			{ name: bookbelongto.sort, type: 'int' }
        ]
    });
    var bookbelongtodata = Ext.create('Ext.data.Store', {
        model: 'BookBelongToModel',
        defaultPageSize: Sys.App.Book.BookBelongToCommon.listPagesize,
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
    var bookbelongtogrid = Ext.create('Sys.App.TabInnerGrid', {
        store: bookbelongtodata,
        columns: [
			{ xtype: 'rownumberer', width: 35 },
			{ text: "书籍所属人的编号", flex: true, dataIndex: bookbelongto.belongtoId, sortable: true },
			{ text: "所属人全称",flex: true, dataIndex: bookbelongto.fullname, sortable: true },
			{ text: "是否可用", flex: true, dataIndex: bookbelongto.usable, renderer: Sys.App.Book.Common.getUsableName, sortable: true },
			{ text: "排序号", flex: true, dataIndex: bookbelongto.sort, sortable: true }
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
            store: bookbelongtodata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    bookbelongtogrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    bookbelongtogrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    bookbelongtogrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, bookbelongtogrid);
}
