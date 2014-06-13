Sys.App.Error = function (action) {
    //如果只显示错误代码的提示部分可引用下面的过滤程序
    //var reg = /<pre>((\w|\W)*?)<\/pre>/;
    //var str = action.responseText;
    //var result = reg.exec(str);
    var errorinformation = '';
    if (action.responseText == undefined)
        errorinformation = action.response.responseText;
    else
        errorinformation = action.responseText;
    Ext.Msg.show({
        title: '错误提示',
        msg: errorinformation,
        autoScroll: true,
        buttons: Ext.Msg.OK
    });
};