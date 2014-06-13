/****************************************
***生成器版本：V1.0.1.32805
***创建人：bhlfy
***创建时间：2013-02-07 09:29:18
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：2013-02-07 09:29:18
***文件描述：。
*****************************************/

/// 注：界面中有“//”形式注释的属性，在研发过程中要更改为相应业务性的表述。

/// 本业务模块的各项共有参数定义
Sys.App.Manage.ApplicationUserCommon = {
    handlerUrl: 'handler/manage/ApplicationUser.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
Sys.App.Manage.ApplicationUserReLogon = function () {
    var eventhandler = {
        login: function () {
            var loginbasicform = frmLogin.getForm();
            if (!loginbasicform.isValid())
                return;
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
                        relogonwindows.close();
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

    var frmLogin = Ext.create('Ext.form.Panel', {
        bodyPadding: '25 0 0 0',
        border: false,
        baseCls: 'x-plain',

        fieldDefaults: {
            labelAlign: 'right',
            labelWidth: 140,
            anchor: '80%',
            msgTarget: 'side'
        },
        items: [
            {
                xtype: 'textfield',
                name: 'userName',
                fieldLabel: '用户名',
                allowBlank: false,
                readOnly: true,
                minLength: 6,
                maxLength: 20,
                regex: /^[0-9a-zA-Z]*$/,
                regexText: "只能输入数字和字母"
            },
            {
                xtype: 'textfield',
                name: 'password',
                fieldLabel: '密&nbsp;&nbsp;&nbsp;码',
                inputType: 'password',
                allowBlank: false,
                minLength: 6,
                maxLength: 20,
                regex: /^[0-9a-zA-Z]*$/,
                regexText: "只能输入数字和字母"
            }
        ]
    });

    var relogonwindows = Ext.create('Ext.window.Window', {
        title: '您已离开好久导致系统会话丢失，请输入密码重新登录',
        height: 160,
        width: 450,
        plain: true,
        modal: true,
        closable: false,
        resizable: false,
        items: frmLogin,
        buttons: [
            {
                text: '确认',
                handler: eventhandler.login
            },
            {
                text: '注销',
                handler: function () {
                    window.location.href = 'logon.html';
                }
            }
        ],
        listeners: {
            'show': function () {
                var loginbasicform = frmLogin.getForm();

                loginbasicform.setValues({ userName: Sys.Paramters.username });
                loginbasicform.findField('password').focus(false, 100);
            }
        }
    });
    relogonwindows.show();
}

Sys.App.Manage.ApplicationUserUpdate = function () {
    var applicationuser = Sys.DB.ApplicationUser;
    var handerurl = Sys.App.Manage.ApplicationUserCommon.handlerUrl;
    handerurl += 'update';
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
                    if (result.success == 'true') {
                        Sys.App.MsgSuccess('保存成功！', function () {
                            applicationusertopwindow.close();
                        });
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
    var applicationusereditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [{
            xtype: 'fieldset',
            title: '基本信息',
            defaultType: 'textfield',
            layout: 'anchor',
            defaults: {
                anchor: '100%'
            },
            items: [{
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [
                    { fieldLabel: '用户编号', name: applicationuser.userid, hidden: true, xtype: 'textfield' }/*,
			        { fieldLabel: '用户名', name: applicationuser.Username, flex:1, readOnly: true, maxLength: 100, xtype: 'textfield' },
                    {
                        fieldLabel: '所属角色',
                        name: applicationuser.roleId,
                        store: Sys.App.Common.storeRole,
                        hiddenName: applicationuser.roleId,
                        allowBlank: false,
                        editable: false,
                        flex: 1,
                        readOnly: true,
                        queryMode: 'local',
                        displayField: Sys.DB.SystemRole.roleName,
                        valueField: Sys.DB.SystemRole.roleId,
                        xtype: 'combo'
                    }*/]
            }, {
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [
                { fieldLabel: '姓名', name: applicationuser.fullName, flex: 1, maxLength: 20, xtype: 'textfield' },
                {
                    fieldLabel: '电子邮箱地址',
                    name: applicationuser.email,
                    flex: 1,
                    maxLength: 100,
                    xtype: 'textfield',
                    regex: /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/,
                    regexText: "邮箱格式不正确，示例xxx@yyy.zzz"
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [
                    {
                        fieldLabel: '婚否',
                        name: applicationuser.isMarry,
                        store: Sys.App.Common.storeUsable,
                        hiddenName: applicationuser.isMarry,
                        allowBlank: false,
                        editable: false,
                        flex: 1,
                        queryMode: 'local',
                        displayField: 'describe',
                        valueField: 'usable',
                        xtype: 'combo'
                    },
                    { fieldLabel: '生日', name: applicationuser.birthday, flex: 1, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [
                    {
                        fieldLabel: '最高学历',
                        name: applicationuser.maxEducation,
                        store: Sys.App.Common.storeMaxEducation,
                        hiddenName: applicationuser.maxEducation,
                        allowBlank: false,
                        editable: false,
                        flex: 1,
                        queryMode: 'local',
                        displayField: 'describe',
                        valueField: applicationuser.maxEducation,
                        xtype: 'combo'
                    },
                    { fieldLabel: '学校名称', name: applicationuser.maxEduCollege, flex: 1, maxLength: 100, xtype: 'textfield' }
                ]
            }, {
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [
                    { fieldLabel: '毕业时间', name: applicationuser.maxEduLeaveTime, flex: 1, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
                    { fieldLabel: '入职时间', name: applicationuser.intoCompanyDate, flex: 1, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' }
                ]
            }, {
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [
                    { fieldLabel: '电话号码', name: applicationuser.telephone, flex: 1, maxLength: 50, xtype: 'textfield' },
                    { fieldLabel: '工作年限', name: applicationuser.workTotalYear, flex: 1, xtype: 'textfield' }
                ]
            }, {
                xtype: 'container',
                layout: 'hbox',
                style: 'margin-bottom:5px',
                items: [
                    { fieldLabel: '户口所在地', name: applicationuser.household, flex: 1, maxLength: 100, xtype: 'textfield' },
                    { fieldLabel: '家乡', name: applicationuser.oldHome, flex: 1, maxLength: 100, xtype: 'textfield' }
                ]
            },
			    { fieldLabel: '现居住地', name: applicationuser.nowLiveHome, maxLength: 100, xtype: 'textfield' },
			    { fieldLabel: '个人照片', name: applicationuser.photoUrl, hidden: true, maxLength: 100, xtype: 'textfield' }
            ]
        }, {
            xtype: 'fieldset',
            title: '其他信息',
            defaultType: 'textfield',
            layout: 'anchor',
            defaults: {
                anchor: '100%'
            },
            items: [
			    { fieldLabel: '专业技能', name: applicationuser.still, maxLength: 200, height: 50, xtype: 'textareafield' },
			    { fieldLabel: '工作经验', name: applicationuser.workExperiences, maxLength: 300, height: 50, xtype: 'textareafield' },
			    { fieldLabel: '学习经验', name: applicationuser.studyExperiences, maxLength: 300, height: 50, xtype: 'textareafield' }
            ]
        }]
    });
    var applicationusertopwindow = Ext.create('Sys.App.TopWindow', {
        title: '用户信息维护界面',    //窗口名称
        width: 720, //界面初始化时宽、高
        height: 530,    //
        minWidth: 720,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 530, //
        iconCls: Sys.App.Icon.editrecord,
        items: applicationusereditform,
        buttons: [
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = applicationusereditform.getForm();

                Ext.Ajax.request({
                    url: Sys.App.Manage.ApplicationUserCommon.handlerUrl + 'list',
                    params: { userid: Sys.Paramters.userid, limit: 15, page: 1 }, //传值方式有待改善
                    success: function (response, opts) {
                        var obj = Ext.decode(response.responseText);
                        if (obj.success == 'true')
                            editform.setValues(obj.topics[0]);
                    },
                    failure: function (response, opts) {
                        Sys.App.Error(response);
                    }
                });
            }
        }
    });
    applicationusertopwindow.show();
}
/// 维护界面（新增和编辑）的定义
/// <param name="isadd">是否为新增（true为新增）</param>
/// <param name="applicationuserData">列表框中所引用的store</param>
/// <param name="currentrows">针对列表框中选择的当前行（可为多行，所以加's'）</param>
Sys.App.Manage.ApplicationUserEdit = function (isadd, applicationuserData, currentrows) {
    var applicationuser = Sys.DB.ApplicationUser;
    var firstuserid;
    var handerurl = Sys.App.Manage.ApplicationUserCommon.handlerUrl;
    handerurl += (isadd) ? 'add' : 'update';
    var edithandler = {
        buttonclose: function () {
            applicationusertopwindow.close();
        },
        buttonsave: function () {
            var editform = applicationusereditform.getForm();
            if (!isadd)
                editform.setValues({ roleId: firstuserid });
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
                        applicationuserData.reload();
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
    var applicationusereditform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '用户编号', name: applicationuser.userid, hidden: true, xtype: 'textfield' },
			{ fieldLabel: '用户名', name: applicationuser.Username, maxLength: 100, xtype: 'textfield' },
            {
                fieldLabel: '所属角色',
                name: Sys.DB.SystemRole.roleId,
                itemId: Sys.DB.SystemRole.roleId,
                store: Sys.App.Common.storeRole,
                hiddenName: Sys.DB.SystemRole.roleId,
                allowBlank: false,
                editable: false,
                queryMode: 'local',
                displayField: Sys.DB.SystemRole.roleName,
                valueField: Sys.DB.SystemRole.roleId,
                xtype: 'combo',
                listeners: {
                    'select': function (combo, record, index) {
                        if (!isadd) {
                            applicationusereditform.getForm().setValues({ roleId: combo.getValue() });
                            firstuserid = combo.getValue();
                        }
                    }
                }
            },
			{ fieldLabel: '全名', name: applicationuser.fullName, maxLength: 20, xtype: 'textfield' },
			{ fieldLabel: '电子邮箱地址', name: applicationuser.email, maxLength: 100, xtype: 'textfield' },
			{ fieldLabel: '电话号码', name: applicationuser.telephone, maxLength: 50, xtype: 'textfield' },
            {
                fieldLabel: '是否统计工作量',
                name: applicationuser.isTotal,
                store: Sys.App.Common.storeUsable,
                hiddenName: applicationuser.usable,
                allowBlank: false,
                editable: false,
                queryMode: 'local',
                displayField: 'describe',
                valueField: applicationuser.usable,
                xtype: 'combo'
            },
            {
                fieldLabel: '可用性',
                name: applicationuser.usable,
                store: Sys.App.Common.storeUsable,
                hiddenName: applicationuser.usable,
                allowBlank: false,
                editable: false,
                queryMode: 'local',
                displayField: 'describe',
                valueField: applicationuser.usable,
                xtype: 'combo'
            },
			{ fieldLabel: '登录次数', name: applicationuser.loginTimes, readOnly: true, xtype: 'textfield' },
			{ fieldLabel: '上次登录时刻', name: applicationuser.lastLoginTime, readOnly: true, format: Sys.App.Config.datetimeFormat, xtype: 'datefield' },
			{ fieldLabel: '录入时刻', name: applicationuser.writeTime, readOnly: true, format: Sys.App.Config.dateFormat, xtype: 'datefield' }
        ]
    });
    var applicationusertopwindow = Ext.create('Sys.App.TopWindow', {
        title: '用户信息维护界面',    //窗口名称
        width: 400, //界面初始化时宽、高
        height: 350,    //
        minWidth: 400,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 350, //
        iconCls: Sys.App.Icon.addrecord,
        items: applicationusereditform,
        buttons: [
			{ minWidth: 80, text: '保存', handler: edithandler.buttonsave },
			{ minWidth: 80, text: '关闭', handler: edithandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = applicationusereditform.getForm();
                if (!isadd) {
                    editform.setValues(currentrows[0].data);
                    this.setIconCls(Sys.App.Icon.editrecord);
                    editform.setValues({ roleId: currentrows[0].data.roleName });
                    firstuserid = currentrows[0].data.roleId;
                }
                else {
                    editform.setValues({
                        userid: '1',
                        usable: true
                    });
                }
            }
        }
    });
    applicationusertopwindow.show();
}
/// 查询条件界面的定义
/// <param name="applicationusergrid">引用了列表框对象</param>
Sys.App.Manage.ApplicationUserQuery = function (applicationusergrid) {
    var applicationuser = Sys.DB.ApplicationUser;
    var queryhandler = {
        buttonclose: function () {
            applicationusertopwindow.close();
        },
        buttonquery: function () {
            var queryform = applicationuserqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            Ext.apply(applicationusergrid.store.proxy.extraParams, {
                userid: getvalue(applicationuser.userid),
                Username: getvalue(applicationuser.Username),
                organizationId: getvalue(applicationuser.organizationId),
                fullName: getvalue(applicationuser.fullName),
                passWord: getvalue(applicationuser.passWord),
                email: getvalue(applicationuser.email),
                loginTimes: getvalue(applicationuser.loginTimes),
                lastLoginTime: getvalue(applicationuser.lastLoginTime),
                writeTime: getvalue(applicationuser.writeTime),
                writeUser: getvalue(applicationuser.writeUser),
                writeIp: getvalue(applicationuser.writeIp)
            });
            applicationusergrid.down('#pagingToolbar').moveFirst();
            applicationusertopwindow.close();
        }
    }
    var applicationuserqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '用户编号', name: applicationuser.userid, hidden: true, xtype: 'textfield' },
			{ fieldLabel: '用户名', name: applicationuser.Username, maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '组织机构编号', name: applicationuser.organizationId, hidden: true, xtype: 'textfield' },
			{ fieldLabel: '全名', name: applicationuser.fullName, maxLength: 40, xtype: 'textfield' },
			{ fieldLabel: '密码（MD5）', name: applicationuser.passWord, maxLength: 200, hidden: true, xtype: 'textfield' },
			{ fieldLabel: '电子邮箱地址', name: applicationuser.email, maxLength: 200, xtype: 'textfield' },
			{ fieldLabel: '登录次数', name: applicationuser.loginTimes, hidden: true, xtype: 'textfield' },
			{ fieldLabel: '上次登录时刻', name: applicationuser.lastLoginTime, format: Sys.App.Config.dateFormat, hidden: true, xtype: 'datefield' },
			{ fieldLabel: '录入时刻', name: applicationuser.writeTime, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '录入人', name: applicationuser.writeUser, hidden: true, xtype: 'textfield' },
			{ fieldLabel: 'ip地址', name: applicationuser.writeIp, maxLength: 30, hidden: true, xtype: 'textfield' }
        ]
    });
    var applicationusertopwindow = Ext.create('Sys.App.TopWindow', {
        title: '用户信息查询界面',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 205,    //
        resizable: false,
        items: applicationuserqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ]
    });
    applicationusertopwindow.show();
}
/// 查询界面的定义
/// <param name="mainPanel">父容器（本业务界面所在的容器）</param>
/// <param name="node">所关联的左边树形节点</param>
Sys.App.Manage.ApplicationUserMain = function (mainPanel, node) {
    var applicationuser = Sys.DB.ApplicationUser;
    var handerurl = Sys.App.Manage.ApplicationUserCommon.handlerUrl;
    var tbarhandler = {
        addrecord: function () {
            Sys.App.Manage.ApplicationUserEdit(true, applicationuserdata);
        },
        updaterecord: function () {
            Sys.App.Manage.ApplicationUserEdit(false, applicationuserdata, applicationusergrid.getSelectionModel().getSelection());
        },
        deleterecord: function () {
            Sys.App.Confirm("您确认要删除该记录吗？？", function (btn) {
                if (btn == 'yes') {
                    var currentselectrows = applicationusergrid.getSelectionModel().getSelection();
                    Ext.Ajax.request({
                        url: handerurl + 'delete',
                        params: { userid: currentselectrows[0].data.userid },
                        success: function (response) {
                            var result = Ext.decode(response.responseText);
                            if (result.success == 'true') {
                                Sys.App.MsgSuccess('删除成功！');
                                applicationuserdata.reload();
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
            Sys.App.Manage.ApplicationUserQuery(applicationusergrid);
        },
        refreshrecord: function () {
            applicationuserdata.reload();
        },
        outputexcel: function () {
            Sys.App.ExportExcel(applicationusergrid, handerurl + 'outputexcel');
        }
    };
    Ext.define('ApplicationUserModel', {
        extend: 'Ext.data.Model',
        fields: [
            { name: applicationuser.userid, type: 'int' },
			{ name: applicationuser.Username, type: 'string' },
			{ name: applicationuser.roleId, type: 'int' },
            { name: 'roleName', type: 'string' },
			{ name: applicationuser.fullName, type: 'string' },
            { name: applicationuser.email, type: 'string' },
			{ name: applicationuser.telephone, type: 'string' },
			{ name: applicationuser.loginTimes, type: 'int' },
            { name: applicationuser.isMarry, type: 'bool' },
            { name: applicationuser.birthday, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
            { name: 'age', type: 'int' },
            { name: applicationuser.maxEducation, type: 'int' },
			{ name: applicationuser.maxEduCollege, type: 'string' },
            { name: applicationuser.intoCompanyDate, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
            { name: applicationuser.workTotalYear, type: 'int' },
            { name: 'totalYear', type: 'int' },
            { name: applicationuser.household, type: 'string' },
            { name: applicationuser.oldHome, type: 'string' },
            { name: applicationuser.nowLiveHome, type: 'string' },
            { name: applicationuser.workExperiences, type: 'string' },
            { name: applicationuser.isTotal, type: 'bool' },
            { name: applicationuser.usable, type: 'bool' },
			{ name: applicationuser.lastLoginTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat },
			{ name: applicationuser.writeTime, type: 'date', dateFormat: Sys.App.Config.datetimeFormat }
        ]
    });
    var applicationuserdata = Ext.create('Ext.data.Store', {
        model: 'ApplicationUserModel',
        defaultPageSize: Sys.App.Manage.ApplicationUserCommon.listPagesize,
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
    var applicationusergrid = Ext.create('Sys.App.TabInnerGrid', {
        store: applicationuserdata,
        columns: [
			{ xtype: 'rownumberer', width: 35 },
			{ text: "用户名", dataIndex: applicationuser.Username, flex: 1, sortable: true },
			{ text: "所属角色类型", dataIndex: applicationuser.roleId, renderer: Sys.App.Common.getRoleName, sortable: true },
			{ text: "姓名", dataIndex: applicationuser.fullName, sortable: true },
			{ text: "电子邮箱地址", dataIndex: applicationuser.email, flex: 2, sortable: true },
			{ text: "电话号码", dataIndex: applicationuser.telephone, flex: 1, sortable: true },
            { text: "登录次数", dataIndex: applicationuser.loginTimes, sortable: true },
            { text: "婚否", dataIndex: applicationuser.isMarry, renderer: Sys.App.BusinessCommon.getIsMarryName, hidden: true, sortable: true },
            { text: "生日", dataIndex: applicationuser.birthday, hidden: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), hidden: true, sortable: true },
            { text: "年龄", dataIndex: 'age', hidden: true, sortable: true },
            { text: "学历", dataIndex: applicationuser.maxEducation, renderer: Sys.App.BusinessCommon.getMaxEducationName, hidden: true, sortable: true },
            { text: "毕业院校", dataIndex: applicationuser.maxEduCollege, hidden: true, sortable: true },
            { text: "入职时间", dataIndex: applicationuser.intoCompanyDate, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), hidden: true, sortable: true },
            { text: "公司在岗工龄", dataIndex: 'totalYear', hidden: true, sortable: true },
            { text: "工作总年限", dataIndex: applicationuser.workTotalYear, hidden: true, sortable: true },
            { text: "户口所在地", dataIndex: applicationuser.household, hidden: true, sortable: true },
            { text: "家乡", dataIndex: applicationuser.oldHome, hidden: true, sortable: true },
            { text: "现居住地", dataIndex: applicationuser.nowLiveHome, hidden: true, sortable: true },
            { text: "工作经验", dataIndex: applicationuser.workExperiences, hidden: true, sortable: true },
            { text: "是否统计工作量", dataIndex: applicationuser.isTotal, renderer: Sys.App.Common.getUsableName, flex: 1, sortable: true },
			{ text: "可用性", dataIndex: applicationuser.usable, renderer: Sys.App.Common.getUsableName, sortable: true },
			{ text: "录入时刻", dataIndex: applicationuser.writeTime, hidden: true, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true },
			{ text: "上次登录时刻", dataIndex: applicationuser.lastLoginTime, flex: 2, renderer: Ext.util.Format.dateRenderer(Sys.App.Config.datetimeFormat), sortable: true }
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
            store: applicationuserdata,
            displayInfo: true,
            displayMsg: '显示记录从 {0} - {1} 条  共 {2} 条记录。',
            emptyMsg: '没有内容可显示',
            plugins: [new Sys.App.PageSizePlugin()]
        })
    });
    //注册侦听选择单行时按钮可用的事件
    applicationusergrid.getSelectionModel().on('selectionchange',
		function (sm) {
		    applicationusergrid.down('#editBtn').setDisabled(sm.getCount() != 1);
		    //可删多行
		    applicationusergrid.down('#removeBtn').setDisabled(sm.getCount() < 1);
		}
	);
    mainPanel.viewContent(node, applicationusergrid);
}
