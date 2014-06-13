Sys.App.Chart.WorkPersonCheck = function (worktotalqueryform, cookieprovider) {
    var applicationuser = Sys.DB.ApplicationUser;
    var tbarhandler = {
        addrecord: function () {

            var editform = worktotalqueryform.getForm();

            var selects = applicationusergrid.getSelectionModel().getSelection();
            var userids = '';
            var fullnames = '';
            for (var i = 0; i < selects.length; i++) {
                var tempuserid = selects[i].data.userid;
                var tempfullname = selects[i].data.fullName;
                if (i != selects.length - 1) {
                    tempuserid += ',';
                    tempfullname += ',';
                }
                userids += tempuserid;
                fullnames += tempfullname;
            }
            editform.setValues({
                writeUser: userids,
                fullName: fullnames
            });
            applicationuserwindow.close();
        },
        refreshrecord: function () {
            Sys.App.Common.storeUser.reload();
        }

    };

    var applicationusergrid = Ext.create('Sys.App.TabInnerGrid', {
        store: Sys.App.Common.storeUser,
        selModel: Ext.create('Ext.selection.CheckboxModel'),
        columns: [
			{ xtype: 'rownumberer', width: 20 },
            { text: "用户编号", dataIndex: applicationuser.userid, hidden: true, sortable: true },
            { text: "姓名", dataIndex: applicationuser.fullName, flex: 1, sortable: true }
        ]
    });

    var applicationuserwindow = Ext.create('Sys.App.TopWindow', {
        title: '选择要统计的人员',    //窗口名称
        width: 200, //界面初始化时宽、高
        height: 350,    //
        minWidth: 200,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 350, //
        border: false,
        iconCls: Sys.App.Icon.addrecord,
        items: applicationusergrid,
        buttons: [
			{ minWidth: 80, text: '确认选择', handler: tbarhandler.addrecord },
			{ minWidth: 80, text: '关闭', handler: function () { applicationuserwindow.close(); } }
        ]
    });
    Sys.App.Common.storeUser.load({
        callback: function (records, operation, success) {

            applicationuserwindow.show();
            if (cookieprovider) {
                var oldmissionsid = cookieprovider.get('chartworktotaluserids', '').split(',');

                var selMod = applicationusergrid.getSelectionModel();
                for (var m = 0; m < Sys.App.Common.storeUser.getCount() ; m++) {
                    for (var n = 0 ; n < oldmissionsid.length; n++) {
                        var current = Sys.App.Common.storeUser.getAt(m)
                        if (current.data.userid == oldmissionsid[n]) {
                            selMod.select(current.index, true, false);
                        }
                    }
                }
            }
        }
    });

}

Sys.App.Chart.AddToMainPanel = function () {
    var viewtotal = [1,6,7];
    
    if (viewtotal.indexOf((new Date()).getDay()) != -1)
        return Sys.App.Chart.AddWorkTotalToMainPanel();
    else
        return Sys.App.Chart.AddLogsTimesToMainPanel();

}