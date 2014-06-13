/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***创建时间：2013-08-16 17:20:32
***公司：山西博华科技有限公司
***修改人：
***修改时间：2013-08-16 17:20:32
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Book.BookInformationCommon = {
    handlerUrl: 'book/handler/BookInformation.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="bookinformationData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Book.BookInformationEdit = function (isadd, bookinformationData, currentrows) {
    var bookinformation = Sys.DB.BookInformation;
    var handerurl = Sys.App.Book.BookInformationCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            bookinformationtopwindow.close();
        },
        buttonsave: function () {
            var editform = bookinformationeditform.getForm();
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
                        bookinformationData.reload();
                        bookinformationtopwindow.close();
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
    var bookinformationeditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '书籍编号', hidden: true, name: bookinformation.bookId, xtype: 'textfield' },
            { fieldLabel: '书名', name: bookinformation.bookTitle, xtype: 'textfield' },
			{ fieldLabel: '作者', name: bookinformation.author, xtype: 'textfield' },
			{ fieldLabel: '译者', name: bookinformation.translator, xtype: 'textfield' },
			{
			    fieldLabel: '所属领域',
			    name: bookinformation.domainTypeId,
			    store: Sys.App.Book.Common.storeBookDomainType,
			    hiddenName: 'domainTypeId',   //很关键的配置
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    displayField: 'domainName',
			    valueField: 'domainTypeId',
			    xtype: 'combo'
			},
			{
			    fieldLabel: '出版社',
			    name: bookinformation.publisherId,
			    store: Sys.App.Book.Common.storeBookPublisher,
			    hiddenName: 'publisherId',   //很关键的配置
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    displayField: 'publisherName',
			    valueField: 'publisherId',
			    xtype: 'combo'
			},
			{
			    fieldLabel: '书籍所属',
			    name: bookinformation.belongtoId,
			    store: Sys.App.Book.Common.storeBookBelongTo,
			    hiddenName: 'belongtoId',   //很关键的配置
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    displayField: 'fullname',
			    valueField: 'belongtoId',
			    xtype: 'combo'
			},
			{
			    fieldLabel: '所属国家',
			    name: bookinformation.countryId,
			    itemId: bookinformation.countryId,
			    store: Sys.App.Book.Common.storeBookFromCountry,
			    hiddenName: 'countryId',   //很关键的配置
			    allowBlank: false,
			    editable: false,
			    queryMode: 'local',
			    displayField: 'countryName',
			    valueField: 'countryId',
			    xtype: 'combo'
			},
			{ fieldLabel: '用户编号', hidden: true, name: bookinformation.userId, xtype: 'textfield' },
			{ fieldLabel: '网址', name: bookinformation.bookurl, xtype: 'textfield' },
			{ fieldLabel: '出版日期', name: bookinformation.publishDate, xtype: 'datefield', format: 'Y-m-d' },
			{ fieldLabel: '书籍唯一编号', name: bookinformation.isbn, xtype: 'textfield' },
			{ fieldLabel: '购买时间', name: bookinformation.buyTime, xtype: 'datefield', format: 'Y-m-d' },
			{ fieldLabel: '购买价格', name: bookinformation.paymoney, xtype: 'textfield' },
            { fieldLabel: '录入时间', name: bookinformation.writeTime, xtype: 'datefield', format: 'Y-m-d' }
        ]
    });
    var bookinformationtopwindow = Ext.create('Sys.App.TopWindow', {
        title: '图书信息维护界面',    //窗口名称
        width: 400, //界面初始化时宽、高
        height: 420,    //
        minWidth: 400,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 420, //
        iconCls: Sys.App.Icon.addrecord,
        items: bookinformationeditform,
        buttons: [
             { minWidth: 80, text: '保存', handler: edithandler.buttonsave },
             { minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = bookinformationeditform.getForm();
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
    bookinformationtopwindow.show();
}
/// 查询条件界面的定义
/// <param name="bookinformationgrid">引用了列表框对象</param>
Sys.App.Book.BookInformationQuery = function (bookinformationgrid) {
    var bookinformation = Sys.DB.BookInformation;
    var queryhandler = {
        buttonclose: function () {
            bookinformationtopwindow.close();
        },
        buttonquery: function () {
            var queryform = bookinformationqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(bookinformationgrid.store.proxy.extraParams, {
                bookId: getvalue(bookinformation.bookId),
                domainTypeId: getvalue(bookinformation.domainTypeId),
                publisherId: getvalue(bookinformation.publisherId),
                belongtoId: getvalue(bookinformation.belongtoId),
                countryId: getvalue(bookinformation.countryId),
                userId: getvalue(bookinformation.userId),
                bookTitle: getvalue(bookinformation.bookTitle),
                author: getvalue(bookinformation.author),
                translator: getvalue(bookinformation.translator),
                bookurl: getvalue(bookinformation.bookurl),
                publishDate: getvalue(bookinformation.publishDate),
                isbn: getvalue(bookinformation.isbn),
                buyTime: getvalue(bookinformation.buyTime),
                paymoney: getvalue(bookinformation.paymoney),
                writeTime: getvalue(bookinformation.writeTime)
            });
            bookinformationgrid.down('#pagingToolbar').moveFirst();
            bookinformationtopwindow.close();
        }
    }
    var bookinformationqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right' //标签内容靠左\右
            ///msgTarget: 'side'
        },
        items: [
                   { fieldLabel: '书籍编号', hidden: true, name: bookinformation.bookId, xtype: 'textfield' },
                   { fieldLabel: '书名', name: bookinformation.bookTitle, xtype: 'textfield' },
			       { fieldLabel: '作者', name: bookinformation.author, xtype: 'textfield' },
            	   { fieldLabel: '译者', name: bookinformation.translator, xtype: 'textfield' },
                   {
                       fieldLabel: '所属领域',
                       name: bookinformation.domainTypeId,
                       store: Sys.App.Book.Common.storeBookDomainType,
                       hiddenName: 'domainTypeId',   //很关键的配置
                       editable: false,
                       queryMode: 'local',
                       displayField: 'domainName',
                       valueField: 'domainTypeId',
                       xtype: 'combo'
                    },
                    {
                        fieldLabel: '出版社',
                        name: bookinformation.publisherId,
                        store: Sys.App.Book.Common.storeBookPublisher,
                        hiddenName: 'publisherId',   //很关键的配置
                        editable: false,
                        queryMode: 'local',
                        displayField: 'publisherName',
                        valueField: 'publisherId',
                        xtype: 'combo'
                    },
                    {
                        fieldLabel: '书籍所属',
                        name: bookinformation.belongtoId,
                        store: Sys.App.Book.Common.storeBookBelongTo,
                        hiddenName: 'belongtoId',   //很关键的配置
                        editable: false,
                        queryMode: 'local',
                        displayField: 'fullname',
                        valueField: 'belongtoId',
                        xtype: 'combo'
                    },
                    {
                        fieldLabel: '所属国家',
                        name: bookinformation.countryId,
                        itemId: bookinformation.countryId,
                        store: Sys.App.Book.Common.storeBookFromCountry,
                        hiddenName: 'countryId',   //很关键的配置
                        editable: false,
                        queryMode: 'local',
                        displayField: 'countryName',
                        valueField: 'countryId',
                        xtype: 'combo'
                    },
                    { fieldLabel: '用户编号', hidden: true, name: bookinformation.userId, xtype: 'textfield' },
			{ fieldLabel: '网址', name: bookinformation.bookurl, xtype: 'textfield' },
			{ fieldLabel: '出版日期', name: bookinformation.publishDate, xtype: 'datefield', format: 'Y-m-d' },
			{ fieldLabel: '书籍唯一编号', name: bookinformation.isbn, xtype: 'textfield' },
			{ fieldLabel: '购买时间', name: bookinformation.buyTime, xtype: 'datefield', format: 'Y-m-d' },
			{ fieldLabel: '购买价格', name: bookinformation.paymoney, xtype: 'textfield' },
            { fieldLabel: '录入时间 ', name: bookinformation.writeTime, xtype: 'datefield', format: 'Y-m-d' }
        ]
    });
    var bookinformationtopwindow = Ext.create('Sys.App.TopWindow', {
        title: '图书信息查询界面',    //窗口名称
        iconCls: 'icon-queryRecord',
        width: 400, //界面初始化时宽、高
        height: 420,    //
        minWidth: 400,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 420, //
        items: bookinformationqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    bookinformationtopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Book.BookInformationMain = function (mainPanel, node) {
    var bookinformation = Sys.DB.BookInformation;
    var handerurl = Sys.App.Book.BookInformationCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Book.BookInformationEdit(true, bookinformationdata);
        },
        updaterecord: function () {
            Sys.App.Book.BookInformationEdit(false, bookinformationdata, bookinformationgrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = bookinformationgrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { bookId: currentselectrows[0].data.bookId },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                bookinformationdata.reload();
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
            Sys.App.Book.BookInformationQuery(bookinformationgrid);
        },
        refreshrecord: function () {
            bookinformationdata.reload();
        },
        outputexcel: function () {
            Sys.App.ExportExcel(bookinformationgrid, handerurl + 'outputexcel');
        }
    };
    Ext.define('BookInformationModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: bookinformation.bookId, type: 'int' },
			{ name: bookinformation.domainTypeId, type: 'int' },
			{ name: bookinformation.publisherId, type: 'int' },
			{ name: bookinformation.belongtoId, type: 'int' },
			{ name: bookinformation.countryId, type: 'int' },
			{ name: bookinformation.userId, type: 'string' },
			{ name: bookinformation.bookTitle, type: 'string' },
			{ name: bookinformation.author, type: 'string' },
			{ name: bookinformation.translator, type: 'string' },
			{ name: bookinformation.bookurl, type: 'string' },
			{ name: bookinformation.publishDate, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: bookinformation.isbn, type: 'string' },
			{ name: bookinformation.buyTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: bookinformation.paymoney, type: 'auto' },
			{ name: bookinformation.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat }
        ]
    });
    var bookinformationdata = Ext.create('Ext.data.Store', {
        model: 'BookInformationModel',
        defaultPageSize: Sys.App.Book.BookInformationCommon.listPagesize,
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
    var bookinformationgrid = Ext.create('Sys.App.TabInnerGrid', {
        store: bookinformationdata,
        columns: [
           { xtype: 'rownumberer' },
           { text: "书籍编号", hidden: true, dataIndex: bookinformation.bookId, sortable: true },
           { text: "书名", flex: true, dataIndex: bookinformation.bookTitle, sortable: true },
           { text: "所属领域", hidden: true, flex: true, dataIndex: bookinformation.domainTypeId, renderer: Sys.App.Book.Common.getBookDomainTypeName, sortable: true },
           { text: "书籍所属", hidden: true, flex: true, dataIndex: bookinformation.belongtoId, renderer: Sys.App.Book.Common.getBookBelongToName, sortable: true },
           { text: "国家", hidden: true, flex: true, dataIndex: bookinformation.countryId, renderer: Sys.App.Book.Common.getBookFromCountryName, sortable: true },
           { text: "用户编号", hidden: true, dataIndex: bookinformation.userId, sortable: true },
           { text: "作者", flex: true, dataIndex: bookinformation.author, sortable: true },
           { text: "译者", flex: true, dataIndex: bookinformation.translator, sortable: true },
           { text: "购买价格", dataIndex: bookinformation.paymoney, sortable: true },
           { text: "网址", hidden: true, dataIndex: bookinformation.bookurl, sortable: true },
		   { text: "出版日期", flex: true, dataIndex: bookinformation.publishDate, sortable: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat) },
           { text: "书籍唯一编号", hidden: true, dataIndex: bookinformation.isbn, sortable: true },
           { text: "购买时间",  flex: true, dataIndex: bookinformation.buyTime, sortable: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat) },
           { text: "出版社", hidden: true, flex: true, dataIndex: bookinformation.publisherId, renderer: Sys.App.Book.Common.getBookPublisherName, sortable: true },
           { text: "录入时间", flex: true, dataIndex: bookinformation.writeTime, sortable: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.dateFormat) }
        ],
        tbar: [
			{ text: '查询条件', tooltip: '查询条件', iconCls: Sys.App.Icon.queryrecord, handler: tbarhandler.queryrecord }, '-',
            { text: '刷新', tooltip: '在上次查询条件基础上，重新从服务器获取数据', iconCls: Sys.App.Icon.refreshrecord, handler: tbarhandler.refreshrecord }, '-',
            { text: '新增', tooltip: '新增', iconCls: Sys.App.Icon.addrecord, handler: tbarhandler.addrecord }, '-',
			{ text: '编辑', tooltip: '编辑', iconCls: Sys.App.Icon.editrecord, itemId: 'editBtn', disabled: true, handler: tbarhandler.updaterecord }, '-',
			{ text: '删除', tooltip: '删除', iconCls: Sys.App.Icon.deleterecord, itemId: 'removeBtn', disabled: true, handler: tbarhandler.deleterecord },
            '->', { text: '导出表格', tooltip: '导出表格', iconCls: Sys.App.Icon.excelexport, handler: tbarhandler.outputexcel }
        ],
        bbar: Ext.create('Ext.PagingToolbar', {
            itemId: 'pagingToolbar',
            store: bookinformationdata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    bookinformationgrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    bookinformationgrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    bookinformationgrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, bookinformationgrid);
}
