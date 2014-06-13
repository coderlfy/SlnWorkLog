/****************************************
***创建人：bhlfy
***创建时间：2013-03-30 08:06:44
***公司：山西博华科技有限公司
***修改人：
***修改时间：2013-03-08 08:06:44
***文件描述：因为从原始的store里是无法获取全部数据的，
***所以需要做个“地下活动”来达到预期效果。
*****************************************/
Sys.App.ExportExcel = function (gridPanel, handlerUrl) {
    //构造一个全新的store查询参数Ext.clone
    var newStoreParams = Ext.clone(gridPanel.store.proxy.extraParams);

    //从grid获取当前需要导出的列信息
    var viewcolumnnames = '';
    var hiddens = '';
    var columnstitle = '';
    Ext.each(gridPanel.columns, function (str, index) {
        var hiddenproperty = (str.hidden) ? '1' : '0';
        if (index == 0) {
            viewcolumnnames = str.dataIndex;
            hiddens = hiddenproperty;
            if(str.text == '&#160')
                columnstitle = '序号';
        }
        else {
            viewcolumnnames += ',' + str.dataIndex;
            hiddens += ',' + hiddenproperty;
            columnstitle += ',' + str.text;
        }
    });

    //将参数绑定到新的查询参数对象中
    Ext.apply(newStoreParams, {
        viewcolumnnames: viewcolumnnames,
        hiddens: hiddens,
        columnstitle: columnstitle,
        limit: 65535
    });

    //执行导出Excel的操作
    if (!Ext.fly('frmDummy')) {
        var frm = document.createElement('form');
        frm.id = 'frmDummy';
        frm.name = 'frmDummy';
        frm.className = 'x-hidden';
        document.body.appendChild(frm);
    }
    Ext.Ajax.request({
        url: handlerUrl,
        method: 'post',
        contentType: 'charset=gb2312',
        form: Ext.fly('frmDummy'),
        isUpload: true,
        params: newStoreParams
    });
};

Sys.App.ExportSummaryExcel = function (data, handlerUrl) {
    //构造一个全新的store查询参数Ext.clone

    //执行导出Excel的操作
    if (!Ext.fly('frmDummy')) {
        var frm = document.createElement('form');
        frm.id = 'frmDummy';
        frm.name = 'frmDummy';
        frm.className = 'x-hidden';
        document.body.appendChild(frm);
    }
    Ext.Ajax.request
    ({
        url: handlerUrl,
        method: 'post',
        contentType: 'charset=gb2312',
        form: Ext.fly('frmDummy'),
        isUpload: true,
        params: {
            summaryId: data.summaryId,
            summaryFullName: Sys.App.Common.getUserfullName(data.writeUser)
        }
    });
};

Sys.App.ExportAddressBook = function (handlerUrl) {
    //构造一个全新的store查询参数Ext.clone

    //执行导出Excel的操作
    if (!Ext.fly('frmDummy')) {
        var frm = document.createElement('form');
        frm.id = 'frmDummy';
        frm.name = 'frmDummy';
        frm.className = 'x-hidden';
        document.body.appendChild(frm);
    }

    Ext.Ajax.request
    ({
        url: handlerUrl,
        method: 'post',
        contentType: 'charset=gb2312',
        form: Ext.fly('frmDummy'),
        isUpload: true
    });
};