Sys.App.Chart.CreateWorkTotalStore = function () {
    Ext.define('WorkTotalModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: 'fullName', type: 'string' },
			{ name: '计划内工作量', type: 'int' },
			{ name: '计划外工作量', type: 'int' },
			{ name: '所有工作量', type: 'int' }
        ]
    });

    var worktotaldata = Ext.create('Ext.data.Store', {
        model: 'WorkTotalModel',
        proxy: {
            type: 'ajax',
            url: Sys.App.WorkLog.WLOGMissionCommon.handlerUrl + 'report',
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        }
    });
    return worktotaldata;
}

Sys.App.Chart.CreateWorkTotalChart = function (worktotaldata) {
    var chart = Ext.create('Ext.chart.Chart', {
        xtype: 'chart',
        style: 'background:#fff',
        animate: true,
        shadow: true,
        store: worktotaldata,
        legend: {
            position: 'right'
        },
        axes: [{
            type: 'Numeric',
            position: 'bottom',
            fields: ['计划内工作量', '计划外工作量', '所有工作量'],
            title: '员工工作量统计数据',
            minimum: 0,
            label: {
                renderer: Ext.util.Format.numberRenderer('0,0')
            },
            grid: true
        }, {
            type: 'Category',
            position: 'left',
            fields: ['fullName'],
            title: '合计'
        }],
        series: [{
            type: 'bar',
            axis: 'bottom',
            label: {
                display: 'insideEnd',
                field: ['计划内工作量', '计划外工作量', '所有工作量'],
                renderer: Ext.util.Format.numberRenderer('0'),
                orientation: 'horizontal',
                color: '#333',
                'text-anchor': 'middle',
                contrast: true
            },
            highlight: true,
            yField: ['计划内工作量', '计划外工作量', '所有工作量'],
            xField: 'fullName'
        }]
    });
    return chart;
}

Sys.App.Chart.WorkTotalMain = function () {
    
    var store = Sys.App.Chart.CreateWorkTotalStore();

    var win = Ext.create('Ext.Window', {
        width: 640,
        height: 480,
        minWidth: 640,
        minHeight: 480,
        hidden: false,
        maximizable: true,
        animCollapse: true,
        collapsible: true,
        iconCls: Sys.App.Icon.chartpie,
        title: '员工工作量统计图',
        layout: 'fit',
        tbar: [{
            text: '查询条件',
            iconCls: Sys.App.Icon.queryrecord,
            handler: function () {
                Sys.App.Chart.WorkTotalQuery(store);
            }
        }, '->', {
            text: '重新载入',
            iconCls: Sys.App.Icon.refreshrecord,
            handler: function () {
                store.reload();
            }
        }, '-', {
            enableToggle: true,
            pressed: true,
            text: '启用动画',
            toggleHandler: function (btn, pressed) {
                chart.animate = pressed ? { easing: 'ease', duration: 500 } : false;
            }
        }],
        items: Sys.App.Chart.CreateWorkTotalChart(store)
    });
    win.show();
    store.load();
}

Sys.App.Chart.WorkTotalQuery = function (worktotaldata, cookieprovider) {
    var wlogweeksummary = Sys.DB.WLOGWeekSummary;
    var applicationuser = Sys.DB.ApplicationUser;
    var wlogmission = Sys.DB.WLOGMission;
    var queryhandler = {
        buttonclose: function () {
            wlogweeksummarytopwindow.close();
        },
        buttonquery: function () {
            var queryform = worktotalqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            if (cookieprovider) {
                cookieprovider.set('chartworktotaluserids', getvalue(wlogweeksummary.writeUser));
                cookieprovider.set('chartworktotalfullnames', getvalue(applicationuser.fullName));
            }
            /*
            Ext.apply(worktotaldata.proxy.extraParams, {
                writeUser: getvalue(wlogweeksummary.writeUser),
                startDate: getvalue(wlogweeksummary.startDate),
                endDate: getvalue(wlogweeksummary.endDate),
                missionState: getvalue(wlogmission.missionState),
                reviewState: getvalue(wlogmission.reviewState)
            });
            */
            worktotaldata.load({
                params: {
                    writeUser: getvalue(wlogweeksummary.writeUser),
                    startDate: getvalue(wlogweeksummary.startDate),
                    endDate: getvalue(wlogweeksummary.endDate),
                    missionState: getvalue(wlogmission.missionState),
                    reviewState: getvalue(wlogmission.reviewState)
                }
            });
            wlogweeksummarytopwindow.close();
        }
    }
    var worktotalqueryform = Ext.create('Sys.App.TopForm', {
        fieldDefaults: {
            labelWidth: 100, //可微调，以适应不同的界面。
            anchor: '90%',  //控件所占宽度比例，可微调。
            labelAlign: 'right', //标签内容靠左\右
            msgTarget: 'side'
        },
        items: [
			{ fieldLabel: '用户编号', name: wlogweeksummary.writeUser, hidden: true, xtype: 'textfield' },
			{
			    fieldLabel: '所统计人员',
			    name: applicationuser.fullName,
			    readOnly: true,
			    xtype: 'textfield',
			    listeners: {
			        'focus': function (a, b) {
			            Sys.App.Chart.WorkPersonCheck(worktotalqueryform, cookieprovider);
			        }
			    }
			},
			{ fieldLabel: '开始日期', name: wlogweeksummary.startDate, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '结束日期', name: wlogweeksummary.endDate, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{
			    fieldLabel: '任务状态',
			    name: wlogmission.missionState,
			    store: Sys.App.BusinessCommon.storeWorkState,
			    hiddenName: 'workState',
			    editable: false,
			    queryMode: 'local',
			    flex: 1,
			    displayField: 'describe',
			    valueField: 'workState',
			    xtype: 'combo'
			},
            {
                fieldLabel: '审核状态',
                name: wlogmission.reviewState,
                store: Sys.App.BusinessCommon.storeReviewState,
                hiddenName: wlogmission.reviewState,
                editable: false,
                queryMode: 'local',
                flex: 1,
                displayField: 'describe',
                valueField: wlogmission.reviewState,
                xtype: 'combo'
            }
        ]
    });
    var wlogweeksummarytopwindow = Ext.create('Sys.App.TopWindow', {
        title: '员工工作量统计查询界面',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 220,    //
        minWidth: 400,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 220, //
        items: worktotalqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = worktotalqueryform.getForm();
                if (cookieprovider) {
                    editform.setValues({
                        writeUser: cookieprovider.get('chartworktotaluserids', ''),
                        fullName: cookieprovider.get('chartworktotalfullnames', '')
                    });
                }
            }
        }
    });
    wlogweeksummarytopwindow.show();
}

Sys.App.Chart.AddWorkTotalToMainPanel = function () {
    var cookieprovider = new Ext.state.CookieProvider();
    Ext.state.Manager.setProvider(cookieprovider);

    var store = Sys.App.Chart.CreateWorkTotalStore();
    var chart = Sys.App.Chart.CreateWorkTotalChart(store);

    store.load({
        params : {
            writeUser: cookieprovider.get('chartworktotaluserids', '')
        }
    });
    var chartpanel = Ext.create('widget.panel', {
        tbar: [{
            text: '查询条件',
            iconCls: Sys.App.Icon.queryrecord,
            handler: function () {
                Sys.App.Chart.WorkTotalQuery(store, cookieprovider);
            }
        }, '->', {
            text: '重新载入',
            iconCls: Sys.App.Icon.refreshrecord,
            handler: function () {
                store.reload();
            }
        }, '-', {
            enableToggle: true,
            pressed: true,
            text: '启用动画',
            toggleHandler: function (btn, pressed) {
                chart.animate = pressed ? { easing: 'ease', duration: 500 } : false;
            }
        }],
        layout: 'fit',
        items: [chart]
    });
    
    return chartpanel;
}
