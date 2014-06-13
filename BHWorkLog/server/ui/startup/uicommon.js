/// <reference path="../../ext/ext-all.js" />
/// <reference path="base/Namespace.js" />
/// <reference path="base/UIObjects.js" />
/// <reference path="ux/Usbkey.js" />

/****************************************
***创建人：bhlfy
***创建时间：2013-03-08 08:06:44
***公司：山西博华科技有限公司
***修改人：
***修改时间：2013-03-08 08:06:44
***文件描述：。
*****************************************/
Sys.App.Common.Address = {
    handlerUrl: 'handler/Address.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
Sys.App.Manage.ApplicationUserCommon = {
    handlerUrl: 'handler/manage/ApplicationUser.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
Sys.App.Manage.SystemRoleCommon = {
    handlerUrl: 'handler/manage/SystemRole.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};

//系统日志事件类型枚举（提交数据库时，传参对象名，严禁出现实际值！）
Sys.App.EnumEventType = {
    UserLoginSuccess: '1', //用户登录成功
    UserLoginFailure: '2', //用户登录失败超过最大次数（默认5次），锁定该用户。
    RegisterUser: '3',  //注册用户
    LockedUser: '4',    //锁定用户
    UnlockedUser: '5',  //解锁用户
    LockedUsbkey: '6',  //锁定密钥
    UnlockedUsbkey: '7',  //解锁密钥
    ReleaseUsbkey: '8', //发布密钥
    ModifyPassword: '9'    //修改密码
};
Sys.App.EnumRoleType = {
    SystemManageLevel: '1',
    DepartmentManageLevel: '2',
    SecretaryLevel: '3',
    PMLevel: '4',
    CoderLevel: '5'
};
//上传文件最大值的定义
Sys.App.UpLoadFileSize = {//单位是字节
    WordFile: '2097152', //单位是字节
    PictureFile: '512000', //单位是字节
    PictureWidth: '2048', //单位是像素
    PictureHight: '1536'//单位是像素
};
//系统共有的属性与方法（静态成员的方式体现）
Sys.App.Common = {
    //公有的转换方法
    getName: function (original, store, valueName, displayName, defaultValue) {
        var value = original;
        store.clearFilter(true);
        store.each(function (record) {
            if (record.raw[valueName] == original) {
                value = record.raw[displayName];
                return false;
            }
        });
        if (defaultValue != null && value == original)
            value = defaultValue;
        return value;
    },
    //系统事件类型（静态构造数据）
    storeSystemEventType: Ext.create('Ext.data.Store', {
        fields: ['eventtype', 'describe'],
        data: [
            { eventtype: Sys.App.EnumEventType.UserLoginSuccess, describe: "用户登录成功" },
            { eventtype: Sys.App.EnumEventType.UserLoginFailure, describe: "用户登录失败超过最大次数" },
            { eventtype: Sys.App.EnumEventType.RegisterUser, describe: "注册用户" },
            { eventtype: Sys.App.EnumEventType.LockedUser, describe: "锁定用户" },
            { eventtype: Sys.App.EnumEventType.UnlockedUser, describe: "解锁用户" },
            { eventtype: Sys.App.EnumEventType.LockedUsbkey, describe: "锁定密钥" },
            { eventtype: Sys.App.EnumEventType.UnlockedUsbkey, describe: "解锁密钥" },
            { eventtype: Sys.App.EnumEventType.ReleaseUsbkey, describe: "发布密钥" },
            { eventtype: Sys.App.EnumEventType.ModifyPassword, describe: "修改密码" }
        ]
    }),
    //获取系统事件类型的描述信息
    getSystemEventTypeName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeSystemEventType, 'eventtype', 'describe');
    },
    //可用非可用信息（静态构造数据）
    storeUsable: Ext.create('Ext.data.Store', {
        fields: ['usable', 'describe'],
        data: [
            { "usable": true, "describe": "是" },
            { "usable": false, "describe": "否" }
        ]
    }),
    storeIpUseStatus: Ext.create('Ext.data.Store', {
        fields: ['ipUseStatus', 'ipUseStatusName'],
        data: [
            { "ipUseStatus": 1, "ipUseStatusName": "使用中" },
            { "ipUseStatus": 2, "ipUseStatusName": "未使用" }
        ]
    }),
    getIpUseStatusName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeIpUseStatus, 'ipUseStatus', 'ipUseStatusName');
    },
    storeWorkStatus: Ext.create('Ext.data.Store', {
        fields: ['workStatus', 'workStatusName'],
        data: [
            { "workStatus": 1, "workStatusName": "在职" },
            { "workStatus": 2, "workStatusName": "离职" }
        ]
    }),
    getWorkStatusName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeWorkStatus, 'workStatus', 'workStatusName');
    },
    storeComputerType: Ext.create('Ext.data.Store', {
        fields: ['computerType', 'computerTypename'],
        data: [
            { "computerType": 1, "computerTypename": "台式" },
            { "computerType": 2, "computerTypename": "笔记本" }
        ]
    }),
    getComputerTypeName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeComputerType, 'computerType', 'computerTypename');
    },
    storeReleaseType: Ext.create('Ext.data.Store', {
        fields: ['releaseType', 'releaseTypeName'],
        data: [
            { "releaseType": 1, "releaseTypeName": "对内发布" },
            { "releaseType": 2, "releaseTypeName": "对生产部发布" },
            { "releaseType": 3, "releaseTypeName": "对工程部发布" }
        ]
    }),
    getReleaseTypeName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeReleaseType, 'releaseType', 'releaseTypeName');
    },
    //获取频道信息
    getUsableName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeUsable, 'usable', 'describe');
    },
    //省信息
    storeProvince: Ext.create('Ext.data.Store', {
        fields: ['addrId', 'addrName'],
        data: [
            { "addrId": "23", "addrName": "山西省" }
        ]
    }),
    //根据省编号转换名称
    getProvinceName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeProvince, 'addrId', 'addrName');
    },
    //地级市信息（动态获取数据）
    storeCity: Ext.create('Ext.data.Store', {
        fields: ['addrId', 'addrName'],
        proxy: {
            type: 'ajax',
            url: Sys.App.Common.Address.handlerUrl + 'viewcity',
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        sorters: [{
            property: 'addrId',
            direction: 'DESC'
        }],
        autoLoad: true
    }),
    //根据地级市编号转换地级市名称
    getCityName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeCity, 'addrId', 'addrName');
    },
    //县信息
    storeCounty: Ext.create('Ext.data.Store', {
        fields: ['addrId', 'addrName', 'parentId'],
        proxy: {
            type: 'ajax',
            url: Sys.App.Common.Address.handlerUrl + 'viewcounty',
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        sorters: [{
            property: 'addrId',
            direction: 'DESC'
        }],
        autoLoad: true
    }),
    //根据县的编号转换县名称
    getCountyName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeCounty, 'addrId', 'addrName');
    },
    provinceBeforeRender: function (provinceControl) {
        provinceControl.setValue('23');
    },
    cityBeforeRender: function (cityControl, countyControl, withoutCascade) {
        cityControl.setValue('3429');
        if (!withoutCascade) {
            var countystore = Sys.App.Common.storeCounty;
            countystore.clearFilter(true);
            countystore.filter([{
                filterFn: function (item) {
                    var contryidvalue = item.get('parentId');
                    return (contryidvalue == '3429');
                }
            }]);
            countyControl.setValue('3832');
        }
    },
    citySelectChange: function (cityCombo, countyControl) {
        var countystore = Sys.App.Common.storeCounty;
        var firstindex = '';
        countystore.clearFilter(true);
        countystore.filter([{
            filterFn: function (item) {
                var contryidvalue = item.get('parentId');
                if (contryidvalue == cityCombo.value) {
                    if (item.get('addrName') == '请选择')
                        firstindex = item.get('addrId');
                    return true;
                }
            }
        }]);
        countyControl.setValue(firstindex);
    },
    storeMaxEducation: Ext.create('Ext.data.Store', {
        fields: ['maxEducation', 'describe'],
        data: [
            { "maxEducation": '1', "describe": "高中" },
            { "maxEducation": '2', "describe": "中专" },
            { "maxEducation": '3', "describe": "大专" },
            { "maxEducation": '4', "describe": "本科" },
            { "maxEducation": '5', "describe": "硕士" }
        ]
    }),
    getMaxEducationName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeMaxEducation, 'maxEducation', 'describe');
    },

    //用户信息
    storeUser: Ext.create('Ext.data.Store', {
        fields: ['userid', 'fullName'],
        proxy: {
            type: 'ajax',
            url: Sys.App.Manage.ApplicationUserCommon.handlerUrl + 'viewall',
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        autoLoad: true
    }),
    //根据用户编号转换全名
    getUserfullName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeUser, 'userid', 'fullName');
    },
    
    storeRole: Ext.create('Ext.data.Store', {
        fields: [Sys.DB.SystemRole.roleId, Sys.DB.SystemRole.roleName],
        proxy: {
            type: 'ajax',
            url: Sys.App.Manage.SystemRoleCommon.handlerUrl + 'viewall',
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        autoLoad: true
    }),
    //根据角色编号转换角色名称
    getRoleName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeRole, Sys.DB.SystemRole.roleId, Sys.DB.SystemRole.roleName);
    },
    manageRoleRelation: [
        { parentId: '1', roleId: ['1', '2', '3', '4', '5', '6', '7'] },
        { parentId: '2', roleId: ['3', '5', '6', '7'] },
        { parentId: '3', roleId: [] },
        { parentId: '4', roleId: ['2', '3', '5', '6', '7'] },
        { parentId: '5', roleId: [] },
        { parentId: '6', roleId: [] },
        { parentId: '7', roleId: ['6'] }
    ],
    RoleInit: function (roleId) {
        for (var i in Sys.App.Common.manageRoleRelation) {
            var singlerelation = Sys.App.Common.manageRoleRelation[i];
            if (singlerelation.parentId == roleId) {
                Sys.App.Common.storeRole.filter([{
                    filterFn: function (item) {
                        var roleid = item.get(Sys.DB.SystemRole.roleId);
                        for (var m in singlerelation.roleId) {
                            if (singlerelation.roleId[m] == roleid)
                                return true;
                        }
                    }
                }]);
                return singlerelation.roleId[0];
            }
        }
    },
    CheckUsbkeyValid: function (systemUsbkeyId) {
        var usbkeyobject = Sys.App.UsbKey.getValue();
        var uktotalvalue;
        var ukbusinessvalid = false;
        if (usbkeyobject.success) {
            uktotalvalue = usbkeyobject.value.split(',');
            if (uktotalvalue.length != 3) {
                ukbusinessvalid = false;
                Sys.App.MsgFailure('密钥发布有问题，请联系管理员！');
            }
            else {
                if (uktotalvalue[2] != '1') {
                    ukbusinessvalid = false;
                    Sys.App.MsgFailure('密钥发布有问题，请联系管理员！');
                }
                else {
                    if (uktotalvalue[1] != systemUsbkeyId) {
                        ukbusinessvalid = false;
                        Sys.App.MsgFailure('密钥用户和当前登录系统的用户不匹配，请确认！');
                    }
                    else {
                        ukbusinessvalid = true;
                    }
                }
            }
        }
        else {
            ukbusinessvalid = false;
            Sys.App.MsgFailure(usbkeyobject.msg);
        }
        return ukbusinessvalid;
    }
}
Sys.App.Common.getCookie = function (name, defaultValue) {
    var cookieprovider = new Ext.state.CookieProvider();
    Ext.state.Manager.setProvider(cookieprovider);
    var value = (defaultValue) ? cookieprovider.get(name, defaultValue) : cookieprovider.get(name, '15');
    return value;
}