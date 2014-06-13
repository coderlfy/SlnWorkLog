/// <reference path="../../../ext/ext-all.js" />
/// <reference path="../base/Namespace.js" />

Sys.App.UsbKey = {
    keyPID: 'F737F785',
    keyPIN: 'FFFFFFFFFFFFFFFF',
    information: {
        notFindKey: '没有找到密钥，请确认密钥是否连接成功！',
        openFail: '打开密钥失败，请确认密钥是否连接成功！',
        verifyFail: '密钥验证失败，请联系管理员！',
        readSuccess: '成功获取信息！',
        readFormatError: '密钥内容格式有误，请联系管理员重新发布！',
        readFail: '密钥读取有误，请确认连接密钥正确之后再试！',
        writeSuccess: '写入成功！',
        writeFail: '写入失败，请确认连接密钥正确之后再试！'
    },
    openKey: function (valueobject) {
        try {
            var pid = Sys.App.UsbKey.keyPID;
            var token_count = 0;

            token_count = ET299.FindToken(pid).toString();
        }
        catch (err) {
            if (valueobject!=null)
                valueobject.msg = Sys.App.UsbKey.information.notFindKey;
            return false;
        }
        try {
            ET299.OpenToken(pid, 1);
        }
        catch (err) {
            if (valueobject != null)
                valueobject.msg = Sys.App.UsbKey.information.openFail;
            return false;
        }
        try {
            var pin = Sys.App.UsbKey.keyPIN;
            ET299.VerifyPIN(1, pin)
        }
        catch (err) {
            if (valueobject != null)
                valueobject.msg = Sys.App.UsbKey.information.verifyFail;
            return false;
        }
        return true;
    },
    getValue: function (keyName) {
        var valueobject = {
            success: false,  //成功与否
            value: '', //返回值
            msg: '' //提示信息
        };
        if (!Sys.App.UsbKey.openKey(valueobject))
            return valueobject;
        else {
            try {
                //读密钥内指定信息（当前默认不提供keyName的解决方案，为以后扩展提供该参数。）
                var content = ET299.Read(0, 0, 100);
                var indexend = content.indexOf(';');
                if (indexend >= 0) {
                    var insidevalue = content.substring(0, indexend);
                    valueobject.value = insidevalue;
                    valueobject.success = true;
                    valueobject.msg = Sys.App.UsbKey.information.readSuccess;
                }
                else {
                    valueobject.msg = Sys.App.UsbKey.information.readFormatError;
                }
                ET299.CloseToken();
                return valueobject;
            }
            catch (err) {
                valueobject.msg = Sys.App.UsbKey.information.readFail;
                ET299.CloseToken();
                return valueobject;
            }
        }

    },
    setValue: function (value) {
        var valueobject = {
            success: false,
            msg: ''
        };
        if (!Sys.App.UsbKey.openKey(valueobject))
            return valueobject;
        else {
            try {
                ET299.Write(0, 0, value.length + 1, value + ';');
                valueobject.msg = Sys.App.UsbKey.information.writeSuccess;
                valueobject.success = true;
                ET299.CloseToken();
                return valueobject;
            }
            catch (err) {
                valueobject.msg = Sys.App.UsbKey.information.writeFail;
                ET299.CloseToken();
                return valueobject;
            }
        }
    }
};