Sys.App.MsgSuccess = function (msg, fn) {
    Ext.Msg.show({
        title: '系统提示',
        msg: msg,
        autoScroll: true,
        icon: Ext.Msg.INFO,
        buttons: Ext.Msg.OK,
        fn: fn
    });

};
Sys.App.MsgFailure = function (msg, fn) {
    Ext.Msg.show({
        title: '系统提示',
        msg: msg,
        autoScroll: true,
        icon: Ext.Msg.WARNING,
        buttons: Ext.Msg.OK,
        fn: fn
    });

};
Sys.App.Confirm = function (msg, fn) {
    Ext.Msg.confirm('系统提示', msg, fn);
};