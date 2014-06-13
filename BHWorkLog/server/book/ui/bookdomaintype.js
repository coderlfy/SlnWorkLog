/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***创建时间：2013-08-17 09:28:24
***公司：山西博华科技有限公司
***修改人：
***修改时间：2013-08-17 09:28:24
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Book.BookDomainTypeCommon = {
    handlerUrl: 'book/handler/BookDomainType.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="bookdomaintypeData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Book.BookDomainTypeEdit = function (isadd, bookdomaintypeData, currentrows) {
    var bookdomaintype = Sys.DB.BookDomainType;
    var handerurl = Sys.App.Book.BookDomainTypeCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            bookdomaintypetopwindow.close();
        },
        buttonsave: function () {
            var editform = bookdomaintypeeditform.getForm();
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
                        bookdomaintypeData.reload();
                        bookdomaintypetopwindow.close();
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
            //bookdomaintypetopwindow.close();
        }
    };
    var bookdomaintypeeditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '所属领域的编号', name: bookdomaintype.domainTypeId, hidden: true, xtype: 'textfield' },
			{ fieldLabel: '领域名称', name: bookdomaintype.domainName, maxLength: 200, xtype: 'textfield' },
			{
			    fieldLabel: '是否可用',
			    name: bookdomaintype.usable,
			    store: Sys.App.Book.Common.storeUsable,
			    hiddenName: 'usable',   //很关键的配置
			    editable: false,
			    queryMode: 'local',
			    displayField: 'describe',
			    valueField: 'usable',
			    xtype: 'combo'
			},
			{ fieldLabel: '简短描述', name: bookdomaintype.remark, maxLength: 600, xtype: 'textfield' },
			{ fieldLabel: '排序号', name: bookdomaintype.sort, xtype: 'textfield' }
        ]
    });
    var bookdomaintypetopwindow = Ext.create('Sys.App.TopWindow', {
        title: '书籍领域信息维护',    //窗口名称
        width: 400, //界面初始化时宽、高
        height: 220,    //
        minWidth: 300,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 190, //
        iconCls: Sys.App.Icon.addrecord,
        items: bookdomaintypeeditform,
        buttons: [
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = bookdomaintypeeditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.editrecord);
                }
                else {
                    editform.setValues({ domainTypeId: '1' });
                }
            }
        }
    });
    bookdomaintypetopwindow.show();
}
/// 查询条件界面的定义
/// <param name="bookdomaintypegrid">引用了列表框对象</param>
Sys.App.Book.BookDomainTypeQuery = function (bookdomaintypegrid) {
    var bookdomaintype = Sys.DB.BookDomainType;
    var queryhandler = {
        buttonclose: function () {
            bookdomaintypetopwindow.close();
        },
        buttonquery: function () {
            var queryform = bookdomaintypequeryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(bookdomaintypegrid.store.proxy.extraParams, {
                domainTypeId: getvalue(bookdomaintype.domainTypeId),
                domainName: getvalue(bookdomaintype.domainName),
                usable: getvalue(bookdomaintype.usable),
                remark: getvalue(bookdomaintype.remark),
                sort: getvalue(bookdomaintype.sort)
            });
            bookdomaintypegrid.down('#pagingToolbar').moveFirst();
            bookdomaintypetopwindow.close();
        }
    }
    var bookdomaintypequeryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '所属领域的编号', name: bookdomaintype.domainTypeId, hidden: true, xtype: 'textfield' },
			{ fieldLabel: '领域名称', name: bookdomaintype.domainName, maxLength: 200, xtype: 'textfield' },
			{
			    fieldLabel: '是否可用',
			    name: bookdomaintype.usable,
			    store: Sys.App.Book.Common.storeUsable,
			    hiddenName: 'usable',   //很关键的配置
			    editable: false,
			    queryMode: 'local',
			    displayField: 'describe',
			    valueField: 'usable',
			    xtype: 'combo'
			},
			{ fieldLabel: '简短描述', name: bookdomaintype.remark, maxLength: 600, xtype: 'textfield' },
			{ fieldLabel: '排序号', name: bookdomaintype.sort, xtype: 'textfield' }
        ]
    });
    var bookdomaintypetopwindow = Ext.create('Sys.App.TopWindow', {
        title: '查询书籍领域信息',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 220,    //
        minWidth: 300,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 190, //
        items: bookdomaintypequeryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    bookdomaintypetopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Book.BookDomainTypeMain = function (mainPanel, node) {
    var bookdomaintype = Sys.DB.BookDomainType;
    var handerurl = Sys.App.Book.BookDomainTypeCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Book.BookDomainTypeEdit(true, bookdomaintypedata);
        },
        updaterecord: function () {
            Sys.App.Book.BookDomainTypeEdit(false, bookdomaintypedata, bookdomaintypegrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = bookdomaintypegrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { domainTypeId: currentselectrows[0].data.domainTypeId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                bookdomaintypedata.reload();
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
            Sys.App.Book.BookDomainTypeQuery(bookdomaintypegrid);
        },
        refreshrecord: function () {
            bookdomaintypedata.reload();
        }
    };
    Ext.define('BookDomainTypeModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: bookdomaintype.domainTypeId, type: 'int' },
			{ name: bookdomaintype.domainName, type: 'string' },
			{ name: bookdomaintype.usable, type: 'bool' },
			{ name: bookdomaintype.remark, type: 'string' },
			{ name: bookdomaintype.sort, type: 'int' }
        ]
    });
    var bookdomaintypedata = Ext.create('Ext.data.Store', {
        model: 'BookDomainTypeModel',
        defaultPageSize: Sys.App.Book.BookDomainTypeCommon.listPagesize,
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
    var bookdomaintypegrid = Ext.create('Sys.App.TabInnerGrid', {
        store: bookdomaintypedata,
        columns: [
			{ xtype: 'rownumberer', width: 35 },
			{ text: "所属领域的编号", dataIndex: bookdomaintype.domainTypeId, hidden: true, sortable: true },
			{ text: "领域名称", flex: true, dataIndex: bookdomaintype.domainName, sortable: true },
			{ text: "是否可用", flex: true, dataIndex: bookdomaintype.usable, renderer: Sys.App.Book.Common.getUsableName, sortable: true },
			{ text: "简短描述", flex: true, dataIndex: bookdomaintype.remark, sortable: true },
			{ text: "排序号",  flex: true, dataIndex: bookdomaintype.sort, sortable: true }

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
            store: bookdomaintypedata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    bookdomaintypegrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    bookdomaintypegrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    bookdomaintypegrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, bookdomaintypegrid);
}
