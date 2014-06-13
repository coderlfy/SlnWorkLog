
Sys.App.Manage.ApplicationUserPasswordEdit = function () {
    var applicationuser = Sys.DB.ApplicationUser;
    var handerurl = 'handler/manage/ModifyPassword.ashx?action=update';

    var edithandler = {
        buttonreset: function () {
            applicationusereditform.getForm().reset();
            var editform = applicationusereditform.getForm();
            editform.setValues({ username: Sys.Paramters.username }); 
        },
        buttonsave: function () {
            var editform = applicationusereditform.getForm();
            if (!editform.isValid())
                return;
            //此处只要form提交，会默认传输到服务端界面上元素的值。
            editform.submit({
                url: handerurl,
                method: 'post',
                params: { clientip: Sys.Paramters.clientIp },
                success: function (frm, action) {
                    var result = action.result;
                    if (result.success == 'true') {
                        Sys.App.MsgSuccess('修改成功！');
                        applicationusertopwindow.close();
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
    Ext.apply(Ext.form.VTypes, {
        password: function (val, field) {
            if (field.initialPassField) {
                var roleid = applicationusereditform.getForm().findField("newpwd").getValue();
                return (val == roleid);
            }
            return true;
        },
        passwordText: '两次输入的密码不一致!'
    });
    var applicationusereditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 120, //可微调，以适应不同的界面。
            anchor: '95%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items:
        [
            {
                fieldLabel: '用户名',
                name: "username",
                allowBlank: false,
                readOnly: true,
                xtype: 'textfield'
            },
            {
                fieldLabel: '用户编号',
                name: "userid",
                allowBlank: false,
                hidden: true,
                xtype: 'textfield'
            },
            {
                fieldLabel: '原密码',
                name: "oldpwd",
                allowBlank: false,
                inputType: 'password',
                blankText: "原密码不允许为空",
                minLength: 6,
                maxLength: 20,
                regex: /^[0-9a-zA-Z]*$/,
                regexText: "只能输入数字字母",
                xtype: 'textfield'
            },

            {
                fieldLabel: '修改密码为',
                name: 'newpwd',
                allowBlank: false,
                inputType: 'password',
                blankText: "修改密码不允许为空",
                minLength: 6,
                maxLength: 20,
                regex: /^[0-9a-zA-Z]*$/,
                regexText: "只能输入数字字母",
                xtype: 'textfield'
            },
            {
                fieldLabel: '确认密码',
                name: 'comfirmpassword',
                allowBlank: false,
                inputType: 'password',
                initialPassField: 'newpwd',
                vtype: 'password',
                blankText: "确认密码不允许为空",
                minLength: 6,
                maxLength: 20,
                regex: /^[0-9a-zA-Z]*$/,
                regexText: "只能输入数字字母",
                xtype: 'textfield'
            }
        ]
    });

    var applicationusertopwindow = Ext.create('Sys.App.TopWindow', {
        title: '修改密码',    //窗口名称
        width: 400, //界面初始化时宽、高
        height: 190,    //
        minWidth: 400,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 190, //
        items: applicationusereditform,
        buttons: [
			{ minWidth: 80, text: '确认修改', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '重置', handler: edithandler.buttonreset }
		],
        listeners: {
            'show': function () {
                var editform = applicationusereditform.getForm();
                editform.setValues({ username: Sys.Paramters.username, userid: Sys.Paramters.userid });
            }
        }
    });
    applicationusertopwindow.show();
}
