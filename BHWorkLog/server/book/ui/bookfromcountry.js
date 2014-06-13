/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***创建时间：2013-08-16 14:40:45
***公司：山西博华科技有限公司
***修改人：
***修改时间：2013-08-16 14:40:45
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Book.BookFromCountryCommon = {
    handlerUrl: 'book/handler/BookFromCountry.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="bookfromcountryData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Book.BookFromCountryEdit = function (isadd, bookfromcountryData, currentrows) {
    var bookfromcountry = Sys.DB.BookFromCountry;
    var handerurl = Sys.App.Book.BookFromCountryCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            bookfromcountrytopwindow.close();
        },
        buttonsave: function () {
            var editform = bookfromcountryeditform.getForm();
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
                        bookfromcountryData.reload();
                        bookfromcountrytopwindow.close();
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
           // bookfromcountrytopwindow.close();
        }
    };
    var bookfromcountryeditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '国家的编号', name: bookfromcountry.countryId, xtype: 'textfield' },
			{ fieldLabel: '国家名称', name: bookfromcountry.countryName, maxLength: 100, xtype: 'textfield' },
			{
			    fieldLabel: '是否可用',
			    name: bookfromcountry.usable,
			    store: Sys.App.Book.Common.storeUsable,
			    hiddenName: 'usable',   //很关键的配置
			    editable: false,
			    queryMode: 'local',
			    displayField: 'describe',
			    valueField: 'usable',
			    xtype: 'combo'
			},
			{ fieldLabel: '排序号', name: bookfromcountry.sort, xtype: 'textfield' }
        ]
    });
    var bookfromcountrytopwindow = Ext.create('Sys.App.TopWindow', {
        title: '国籍信息维护',    //窗口名称
        width: 400, //界面初始化时宽、高
        height: 220,    //
        minWidth: 300,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 190, //
        iconCls: Sys.App.Icon.addrecord,
        items: bookfromcountryeditform,
        buttons: [
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = bookfromcountryeditform.getForm();
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
    bookfromcountrytopwindow.show();
}
/// 查询条件界面的定义
/// <param name="bookfromcountrygrid">引用了列表框对象</param>
Sys.App.Book.BookFromCountryQuery = function (bookfromcountrygrid) {
    var bookfromcountry = Sys.DB.BookFromCountry;
    var queryhandler = {
        buttonclose: function () {
            bookfromcountrytopwindow.close();
        },
        buttonquery: function () {
            var queryform = bookfromcountryqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(bookfromcountrygrid.store.proxy.extraParams, {
                countryId: getvalue(bookfromcountry.countryId),
                countryName: getvalue(bookfromcountry.countryName),
                usable: getvalue(bookfromcountry.usable),
                sort: getvalue(bookfromcountry.sort)
            });
            bookfromcountrygrid.down('#pagingToolbar').moveFirst();
            bookfromcountrytopwindow.close();
        }
    }
    var bookfromcountryqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '国家的编号', name: bookfromcountry.countryId, xtype: 'textfield' },
			{ fieldLabel: '国家名称', name: bookfromcountry.countryName, maxLength: 100, xtype: 'textfield' },
			{
			    fieldLabel: '是否可用',
			    name: bookfromcountry.usable,
			    store: Sys.App.Book.Common.storeUsable,
			    hiddenName: 'usable',   //很关键的配置
			    editable: false,
			    queryMode: 'local',
			    displayField: 'describe',
			    valueField: 'usable',
			    xtype: 'combo'
			},
			{ fieldLabel: '排序号', name: bookfromcountry.sort, xtype: 'textfield' }
        ]
    });
    var bookfromcountrytopwindow = Ext.create('Sys.App.TopWindow', {
        title: '查询出版社信息',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 220,    //
        minWidth: 300,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 190, //
        items: bookfromcountryqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    bookfromcountrytopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Book.BookFromCountryMain = function (mainPanel, node) {
    var bookfromcountry = Sys.DB.BookFromCountry;
    var handerurl = Sys.App.Book.BookFromCountryCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Book.BookFromCountryEdit(true, bookfromcountrydata);
        },
        updaterecord: function () {
            Sys.App.Book.BookFromCountryEdit(false, bookfromcountrydata, bookfromcountrygrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = bookfromcountrygrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { countryId: currentselectrows[0].data.countryId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                bookfromcountrydata.reload();
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
            Sys.App.Book.BookFromCountryQuery(bookfromcountrygrid);
        },
        refreshrecord: function () {
            bookfromcountrydata.reload();
        }
    };
    Ext.define('BookFromCountryModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: bookfromcountry.countryId, type: 'int' },
			{ name: bookfromcountry.countryName, type: 'string' },
			{ name: bookfromcountry.usable, type: 'bool' },
			{ name: bookfromcountry.sort, type: 'int' }
        ]
    });
    var bookfromcountrydata = Ext.create('Ext.data.Store', {
        model: 'BookFromCountryModel',
        defaultPageSize: Sys.App.Book.BookFromCountryCommon.listPagesize,
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
    var bookfromcountrygrid = Ext.create('Sys.App.TabInnerGrid', {
        store: bookfromcountrydata,
        columns: [
			{ xtype: 'rownumberer', width: 35 },
			{ text: "国家的编号", flex: true, dataIndex: bookfromcountry.countryId, sortable: true },
			{ text: "国家名称", flex: true, dataIndex: bookfromcountry.countryName, sortable: true },
			{ text: "是否可用", flex: true, dataIndex: bookfromcountry.usable, renderer: Sys.App.Book.Common.getUsableName, sortable: true },
			{ text: "排序号", flex: true, dataIndex: bookfromcountry.sort, sortable: true }
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
            store: bookfromcountrydata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    bookfromcountrygrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    bookfromcountrygrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    bookfromcountrygrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, bookfromcountrygrid);
}
