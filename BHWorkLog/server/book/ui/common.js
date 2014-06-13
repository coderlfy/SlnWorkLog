//出版社的界面配置
Sys.App.Book.BookPublisherCommon = {
    handlerUrl: 'book/handler/BookPublisher.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
//书籍所属人的界面配置
Sys.App.Book.BookBelongToCommon = {
    handlerUrl: 'book/handler/BookBelongTo.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
//书籍所属国家的界面配置
Sys.App.Book.BookFromCountryCommon = {
    handlerUrl: 'book/handler/BookFromCountry.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
/// 书籍所属领域的界面配置
Sys.App.Book.BookDomainTypeCommon = {
    handlerUrl: 'book/handler/BookDomainType.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};

//系统共有的属性与方法（静态成员的方式体现）
Sys.App.Book.Common = {
    //公有的转换方法
    getName: function (original, store, valueName, displayName) {
        var value = original;
        store.each(function (record) {
            if (record.raw[valueName] == original) {
                value = record.raw[displayName];
                return false;
            }
        });
        return value;
    },
    //可用非可用信息
    storeUsable: Ext.create('Ext.data.Store', {
        fields: ['usable', 'describe'],
        data: [
            { "usable": true, "describe": "是" },
            { "usable": false, "describe": "否" }
        ]
    }),
    //获取可用非可用的描述信息
    getUsableName: function (val) {
        return Sys.App.Book.Common.getName(val, Sys.App.Book.Common.storeUsable, 'usable', 'describe');
    },
    //出版社信息
    storeBookPublisher: Ext.create('Ext.data.Store', {
        fields: ['publisherId', 'publisherName'],
        proxy: {
            type: 'ajax',
            url: Sys.App.Book.BookPublisherCommon.handlerUrl + 'viewall',
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        autoLoad: true
    }),
    //根据出版社编号转换出版社名称
    getBookPublisherName: function (val) {
        return Sys.App.Book.Common.getName(val, Sys.App.Book.Common.storeBookPublisher, 'publisherId', 'publisherName');
    },
    //书籍所属信息
    storeBookBelongTo: Ext.create('Ext.data.Store', {
        fields: ['belongtoId', 'fullname'],
        proxy: {
            type: 'ajax',
            url: Sys.App.Book.BookBelongToCommon.handlerUrl + 'viewall',
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        autoLoad: true
    }),
    //根据书籍所属的编号转换书籍所属人（或单位）名称
    getBookBelongToName: function (val) {
        return Sys.App.Book.Common.getName(val, Sys.App.Book.Common.storeBookBelongTo, 'belongtoId', 'fullname');
    },
    //书籍所属国籍信息
    storeBookFromCountry: Ext.create('Ext.data.Store', {
        fields: ['countryId', 'countryName'],
        proxy: {
            type: 'ajax',
            url: Sys.App.Book.BookFromCountryCommon.handlerUrl + 'viewall',
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },/*
        listeners: {
            'load': function () {
                this.filter([{
                    filterFn: function (item) {
                        return (item.get('countryId') == '1' || item.get('countryId') == '3');
                    }
                }]);
            }
        },
        */
        autoLoad: true
    }),
    //根据书籍所属国家的编号转换书籍所属国家的名称
    getBookFromCountryName: function (val) {
        var store = Sys.App.Book.Common.storeBookFromCountry;
        store.clearFilter(true);
        return Sys.App.Book.Common.getName(val, store, 'countryId', 'countryName');
    },
    //书籍所属领域信息
    storeBookDomainType: Ext.create('Ext.data.Store', {
        fields: ['domainTypeId', 'domainName'],
        proxy: {
            type: 'ajax',
            url: Sys.App.Book.BookDomainTypeCommon.handlerUrl + 'viewall',
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        autoLoad: true
    }),
    //根据书籍所属领域的编号转换书籍所属领域的名称
    getBookDomainTypeName: function (val) {
        return Sys.App.Book.Common.getName(val, Sys.App.Book.Common.storeBookDomainType, 'domainTypeId', 'domainName');
    }
};

