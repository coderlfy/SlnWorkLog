/****************************************
***创建人：bhlfy
***创建时间：2013-03-13 08:06:44
***公司：山西博华科技有限公司
***修改人：
***修改时间：2013-03-08 08:06:44
***文件描述：。
*****************************************/
Sys.App.WorkLog.ProjectTreeCommon = {
    handlerUrl: 'handler/worklog/ProjectTree.ashx?action=',
    listStartRecord: 0,
    listPagesize: 15
};
Sys.App.BusinessCommon = {
    //工作完成显示状态信息（静态构造数据）
    storeWorkState: Ext.create('Ext.data.Store', {
        fields: ['workState', 'describe'],
        data: [
            { "workState": 1, "describe": "未完成" },
            { "workState": 2, "describe": "已完成" }
        ]
    }),
    //获取工作完成状态信息
    getWorkStateName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.BusinessCommon.storeWorkState, 'workState', 'describe');
    },
    //显示婚姻状态信息（静态构造数据）
    storeIsMarry: Ext.create('Ext.data.Store', {
        fields: ['isMarry', 'describe'],
        data: [
            { "isMarry": true, "describe": "是" },
            { "isMarry": false, "describe": "否" }
        ]
    }),
    //获取婚姻状态信息
    getIsMarryName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.BusinessCommon.storeIsMarry, 'isMarry', 'describe');
    },
    //显示学历信息（静态构造数据）
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
    //获取学历信息
    getMaxEducationName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.Common.storeMaxEducation, 'maxEducation', 'describe');
    },
    //审核状态信息（静态构造数据）
    storeReviewState: Ext.create('Ext.data.Store', {
        fields: ['reviewState', 'describe'],
        data: [
            { "reviewState": true, "describe": "已审核" },
            { "reviewState": false, "describe": "未审核" }
        ]
    }),
    //获取工作完成状态信息
    getReviewStateName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.BusinessCommon.storeReviewState, 'reviewState', 'describe');
    },
    //是否提交信息（静态构造数据）
    storeSubmitedState: Ext.create('Ext.data.Store', {
        fields: ['submited', 'describe'],
        data: [
            { "submited": true, "describe": "已提交" },
            { "submited": false, "describe": "未提交" }
        ]
    }),
    //获取投诉状态
    getSubmitedStateName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.BusinessCommon.storeSubmitedState, 'submited', 'describe');
    },
    storeProject: Ext.create('Ext.data.Store', {
        fields: ['currentId', 'dirName'],
        proxy: {
            type: 'ajax',
            url: Sys.App.WorkLog.ProjectTreeCommon.handlerUrl + 'viewall',
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        },
        sorters: [{
            property: 'currentId',
            direction: 'ASC'
        }],
        autoLoad: true
    }),
    //根据频道编号转换名称
    getProjectName: function (val) {
        return Sys.App.Common.getName(val, Sys.App.BusinessCommon.storeProject, 'currentId', 'dirName');
    }

}
