Sys.App.Chart.CreateLogsTimesStore = function () {
    Ext.define('LogsTimesModel', {
        extend: 'Ext.data.Model',
        fields: [
			{ name: 'fullName', type: 'string' },
			{ name: '满足时效日志数', type: 'int' }
        ]
    });

    var logstimesdata = Ext.create('Ext.data.Store', {
        model: 'LogsTimesModel',
        proxy: {
            type: 'ajax',
            url: Sys.App.WorkLog.WLOGPersonLogCommon.handlerUrl + 'logstimes', //地址需变
            reader: { type: 'json', root: 'topics', totalProperty: 'total' }
        }
    });
    return logstimesdata;
}

Sys.App.Chart.CreateLogsTimesChart = function (logstimesdata) {
    var chart = Ext.create('Ext.chart.Chart', {
        xtype: 'chart',
        style: 'background:#fff',
        animate: true,
        shadow: true,
        store: logstimesdata,
        axes: [{
            type: 'Numeric',
            position: 'bottom',
            fields: ['满足时效日志数'],
            title: '工作日志提交时效性统计',
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
                field: ['满足时效日志数'],
                renderer: Ext.util.Format.numberRenderer('0'),
                orientation: 'horizontal',
                color: '#333',
                'text-anchor': 'middle',
                contrast: true
            },
            highlight: true,
            yField: ['满足时效日志数'],
            xField: 'fullName',
            renderer: function (sprite, record, attr, index, store) {
                var fieldValue = Math.random() * 20 + 10;
                var value = (record.get('满足时效日志数') >> 0) % 5;
                var color = ['rgb(213, 70, 121)',
                             'rgb(44, 153, 201)',
                             'rgb(146, 6, 157)',
                             'rgb(49, 149, 0)',
                             'rgb(249, 153, 0)'][value];
                return Ext.apply(attr, {
                    fill: color
                });
            }
        }]
    });
    return chart;
}

Sys.App.Chart.LogsTimesQuery = function (logstimesdata, cookieprovider) {
    var wlogweeksummary = Sys.DB.WLOGWeekSummary;
    var applicationuser = Sys.DB.ApplicationUser;
    var wlogmission = Sys.DB.WLOGMission;
    var queryhandler = {
        buttonclose: function () {
            logstimestopwindow.close();
        },
        buttonquery: function () {
            var queryform = logstimesqueryform.getForm();
            var getvalue = function (fieldName) {
                return queryform.findField(fieldName).getValue();
            }
            if (cookieprovider) {
                cookieprovider.set('chartworktotaluserids', getvalue(wlogweeksummary.writeUser));
                cookieprovider.set('chartworktotalfullnames', getvalue(applicationuser.fullName));
            }
            logstimesdata.load({
                params: {
                    writeUser: getvalue(wlogweeksummary.writeUser),
                    startDate: getvalue(wlogweeksummary.startDate),
                    endDate: getvalue(wlogweeksummary.endDate)
                }
            });
            logstimestopwindow.close();
        }
    }
    var logstimesqueryform = Ext.create('Sys.App.TopForm', {
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
			            Sys.App.Chart.WorkPersonCheck(logstimesqueryform, cookieprovider);
			        }
			    }
			},
			{ fieldLabel: '开始日期', name: wlogweeksummary.startDate, format: Sys.App.Config.dateFormat, xtype: 'datefield' },
			{ fieldLabel: '结束日期', name: wlogweeksummary.endDate, format: Sys.App.Config.dateFormat, xtype: 'datefield' }
        ]
    });
    var logstimestopwindow = Ext.create('Sys.App.TopWindow', {
        title: '工作日志时效性查询界面',    //窗口名称
        iconCls: Sys.App.Icon.queryrecord,
        width: 400, //界面初始化时宽、高
        height: 170,    //
        minWidth: 400,  //界面最小宽高，每个弹出页面必须设置
        minHeight: 170, //
        items: logstimesqueryform,
        buttons: [
			{ minWidth: 80, text: '开始查询', handler: queryhandler.buttonquery },
			{ minWidth: 80, text: '关闭', handler: queryhandler.buttonclose }
        ],
        listeners: {
            'show': function () {
                var editform = logstimesqueryform.getForm();
                if (cookieprovider) {
                    editform.setValues({
                        writeUser: cookieprovider.get('chartworktotaluserids', ''),
                        fullName: cookieprovider.get('chartworktotalfullnames', '')
                    });
                }
            }
        }
    });
    logstimestopwindow.show();
}

Sys.App.Chart.AddLogsTimesToMainPanel = function () {
    var cookieprovider = new Ext.state.CookieProvider();
    Ext.state.Manager.setProvider(cookieprovider);

    var store = Sys.App.Chart.CreateLogsTimesStore();
    var chart = Sys.App.Chart.CreateLogsTimesChart(store);

    store.load({
        params: {
            writeUser: cookieprovider.get('chartworktotaluserids', '')
        }
    });
    var chartpanel = Ext.create('widget.panel', {
        tbar: [ {
            text: '查询条件',
            iconCls: Sys.App.Icon.queryrecord,
            handler: function () {
                Sys.App.Chart.LogsTimesQuery(store, cookieprovider);
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

Sys.App.Chart.LogsTimesMain = function () {

    var store = Sys.App.Chart.CreateLogsTimesStore();

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
        title: '工作日志提交时效性统计图',
        layout: 'fit',
        tbar: [{
            text: '查询条件',
            iconCls: Sys.App.Icon.queryrecord,
            handler: function () {
                Sys.App.Chart.LogsTimesQuery(store);
            }
        }, {
            text: '重新载入',
            style: 'margin-left:348px;',
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
        items: Sys.App.Chart.CreateLogsTimesChart(store)
    });
    win.show();
    store.load();
}
