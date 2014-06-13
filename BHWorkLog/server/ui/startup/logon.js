/****************************************
***创建人：bhlfy
***创建时间：2013-03-08 08:06:44
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：2013-03-08 08:06:44
***文件描述：。
*****************************************/
Sys.App.UserLogin = function () {
    var cookieprovider = new Ext.state.CookieProvider();
    Ext.state.Manager.setProvider(cookieprovider);

    var eventhandler = {
        findusbkey: function (obj, arr) {
            for (var i in arr)
                if (arr[i] == obj)
                    return i;
            return -1;
        },
        login: function () {
            var loginbasicform = frmLogin.getForm();
            if (!loginbasicform.isValid())
                return;
            Ext.MessageBox.wait('系统登录中……');
            //此处只要form提交，会默认传输到服务端界面上元素的值。
            loginbasicform.submit({
                url: 'handler/Logon.ashx?action=logon',
                async: true,
                method: 'post',
                success: function (frm, action) {
                    var result = action.result;
                    var username = frmLogin.form.findField('userName').getValue();
                    var password = frmLogin.form.findField('password').getValue();
                    if (result.success == 'true') {
                        /*
                        if (result.roleId != '3') {
                            var usbkeyobject = Sys.App.UsbKey.getValue();
                            if (!usbkeyobject.success) {
                                Sys.App.MsgFailure(usbkeyobject.msg);
                                return;
                            }
                            else {
                                var usbkeyvalue = usbkeyobject.value.split(',');
                                if (username != usbkeyvalue[0]) {
                                    Sys.App.MsgFailure('发布的密钥和用户不对应，请联系管理员！');
                                    return;
                                }
                                var findusbkeyindex = eventhandler.findusbkey(usbkeyvalue[1], result.allkeyid);
                                if (findusbkeyindex == -1) {
                                    Sys.App.MsgFailure('密钥非正常发布，请联系管理员！'); //发布的keyid不在服务器中
                                    return;
                                }
                                else {
                                    if (!result.allkeystatus[findusbkeyindex]) {
                                        Sys.App.MsgFailure('密钥被系统管理员锁定，请联系管理员解锁！');
                                        return;
                                    }
                                    cookieprovider.set('usbkeyid', usbkeyvalue[1]);
                                }
                            }
                        }
                        */
                        cookieprovider.set('username', username);
                        cookieprovider.set('refreshtimes', '0');
                        if (username == password) {
                            Sys.App.MsgSuccess('您的用户名和密码一致，为了您的信息安全，请及时更改密码!', function () {
                                window.location.href = 'index.html';
                            });
                        }
                        window.location.href = 'index.html';
                    }
                    else {
                        if (result.msg != null) {
                            Sys.App.MsgFailure(result.msg);
                            frmLogin.form.findField('password').reset();
                        }
                    }
                },
                failure: function (frm, action) {
                    Sys.App.Error(action);
                }
            });
        }
    };
    Ext.apply(Ext.form.VTypes, {
        checkcode: function (val, field) {
            var checkcode = frmLogin.down('#checkcode').hiddenValue.toString().substring(2, 8);
            if (field.value == checkcode)
                return true;
        },
        checkcodeText: '验证码输入有误，请重新输入！'
    });

    var checkcode = Ext.create('Sys.App.CheckCode', {
        fieldLabel: '验证码',
        name: 'checkcode',
        itemId: 'checkcode',
        allowBlank: false,
        isLoader: true,
        blankText: '验证码不能为空',
        vtype: 'checkcode',
        codeUrl: 'handler/CheckCode.ashx',
        width: 300
    });
    var frmLogin = Ext.create('Ext.form.Panel', {
        bodyPadding: '50 0 0 0',
        border: false,
        baseCls: 'x-plain',

        fieldDefaults: {
            labelAlign: 'right',
            labelWidth: 140,
            anchor: '80%',
            msgTarget: 'side'
        },
        items: [
            { xtype: 'textfield', name: 'userName', fieldLabel: '用户名', allowBlank: false, minLength: 6, maxLength: 20, regex: /^[0-9a-zA-Z]*$/, regexText: "只能输入数字和字母" },
            { xtype: 'textfield', name: 'password', fieldLabel: '密&nbsp;&nbsp;&nbsp;码', inputType: 'password', allowBlank: false, minLength: 6, maxLength: 20, regex: /^[0-9a-zA-Z]*$/, regexText: "只能输入数字和字母" },
            checkcode
        ]
    });

    Ext.create('Ext.window.Window', {
        title: 'ICat Studio网上办公协作管理平台',
        iconCls: 'icon-register',
        height: 270,
        width: 500,
        plain: true,
        closable: false,
        resizable: false,
        items: frmLogin,
        buttons: [
            { text: '登录', handler: eventhandler.login },
            { text: '注册', handler: Sys.App.Manage.ApplicationUserRegister },
            {
                text: '切换旧版本', handler: function () {
                    window.location.href = 'http://192.163.20.5:8888/v1.0';
                }
            }
        ],
        listeners: {
            'show': function () {
                var cookieusername = cookieprovider.get('username', '');
                var loginbasicform = frmLogin.getForm();
                if (cookieusername == '')
                    loginbasicform.findField('userName').focus(false, 100); //置焦点时最好加延时
                else {
                    loginbasicform.setValues({ userName: cookieusername });
                    loginbasicform.findField('password').focus(false, 100);
                }
            }
        }
    }).show();
    var map = new Ext.KeyMap(Ext.get(document), [{
        key: Ext.EventObject.ENTER, //键盘值
        fn: eventhandler.login
    }]);

};

Sys.App.Manage.ApplicationUserCommon = {
    handlerUrl: 'handler/manage/ApplicationUser.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
Sys.App.Manage.ApplicationUserRegister = function () {
    var cookieprovider = new Ext.state.CookieProvider();
    Ext.state.Manager.setProvider(cookieprovider);

    var applicationuser = Sys.DB.ApplicationUser;
    var handerurl = Sys.App.Manage.ApplicationUserCommon.handlerUrl + 'register';
    var edithandler = {
        buttonclose: function () {
            applicationusertopwindow.close();
        },
        buttonsave: function () {
            var editform = applicationusereditform.getForm();
            if (!editform.isValid())
                return;
            //此处只要form提交，会默认传输到服务端界面上元素的值。            
            editform.submit({
                url: handerurl,
                method: 'post',
                success: function (frm, action) {
                    var result = action.result;
                    var username = applicationusereditform.getForm().findField(applicationuser.Username).getValue();
                    if (result.success == 'true') {
                        Sys.App.MsgSuccess('注册成功，即将登入系统！');
                        cookieprovider.set('username', username);
                        cookieprovider.set('refreshtimes', '0');
                        window.location.href = 'index.html';
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

            //applicationusertopwindow.close();
        }
    };

    Ext.apply(Ext.form.VTypes, {
        password: function (val, field) {
            if (field.initialPassField) {
                var password = applicationusereditform.getForm().findField(applicationuser.passWord).getValue();
                return (val == password);
            }
            return true;
        },
        passwordText: '两次输入的密码不一致!'
    });

    var applicationusereditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '用户编号', name: applicationuser.userid, hidden: true, xtype: 'textfield' },
            { fieldLabel: '角色编号', name: applicationuser.roleId, hidden: true, xtype: 'textfield' },
            { fieldLabel: '是否可用', name: applicationuser.usable, hidden: true, xtype: 'textfield' },
            { fieldLabel: '是否统计数据', name: applicationuser.isTotal, hidden: true, xtype: 'textfield' },
			{
			    fieldLabel: '用户名',
			    name: applicationuser.Username,
			    xtype: 'textfield',
			    allowBlank: false,
			    minLength: 6,
			    maxLength: 20,
			    regex: /^[0-9a-zA-Z]*$/,
			    regexText: "只能输入数字和字母",
			    listeners: {
			        'blur': function (field) {
			            var username = applicationusereditform.getForm().findField(applicationuser.Username).getValue();
			            if (username.length >= 6) {
			                Ext.Ajax.request({
			                    url: Sys.App.Manage.ApplicationUserCommon.handlerUrl + 'registercheck',
			                    params: { username: username },
			                    success: function (response, opts) {
			                        var obj = Ext.decode(response.responseText);
			                        if (obj.success == 'true') {
			                            field.clearInvalid();
			                        } else {
			                            field.markInvalid('用户名已经存在!');
			                            field.focus(true, 100);
			                            return;
			                        }
			                    },
			                    failure: function (response, opts) {
			                        Sys.App.Error(response);
			                    }
			                });
			            }
			        }
			    }
			},
			{
			    fieldLabel: '密码',
			    name: applicationuser.passWord,
			    xtype: 'textfield',
			    inputType: 'password',
			    allowBlank: false,
			    minLength: 6,
			    maxLength: 20,
			    regex: /^[0-9a-zA-Z]*$/,
			    regexText: "只能输入数字和字母"
			},
            {
                fieldLabel: '确认密码',
                name: 'confirmPassword',
                vtype: 'password',
                initialPassField: applicationuser.passWord,
                allowBlank: false,
                minLength: 6,
                maxLength: 20,
                inputType: 'password',
                xtype: 'textfield'
            },
			{
			    fieldLabel: '真实姓名',
			    name: applicationuser.fullName,
			    xtype: 'textfield',
			    allowBlank: false,
			    minLength: 2,
			    maxLength: 20,
			    regex: /^[A-Za-z0-9\u4e00-\u9fa5]*$/,
			    regexText: "只能输入数字、字母和汉字"
			},
			{
			    fieldLabel: '电子邮箱',
			    name: applicationuser.email,
			    xtype: 'textfield',
			    allowBlank: true,
			    minLength: 6,
			    maxLength: 20,
			    allowBlank: false,
			    regex: /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/,
			    regexText: "邮箱格式不正确"
			},
            { fieldLabel: '电话号码', name: applicationuser.telephone, minLength: 7, allowBlank: false, maxLength: 50, xtype: 'textfield' },

        ]
    });
    var applicationusertopwindow = Ext.create('Sys.App.TopWindow', {
        title: '新用户注册',
        width: 400,
        height: 245,
        minWidth: 400,
        minHeight: 245,
        iconCls: Sys.App.Icon.userregister,
        items: applicationusereditform,
        buttons: [
			{ minWidth: 80, text: '确认注册', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '取消', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = applicationusereditform.getForm();
                editform.setValues({
                    userid: '1',
                    roleId: '5',
                    usable: 'true',
                    isTotal: 'true'
                });
            }
        }
    });
    applicationusertopwindow.show();

}

