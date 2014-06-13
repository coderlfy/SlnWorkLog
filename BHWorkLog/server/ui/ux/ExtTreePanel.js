Ext.define("Sys.App.MenuTree", {
    extend: 'Ext.tree.Panel',
    initComponent: function () {
        var me = this;
        this.hiddenPkgs = [];

        me.id = this.id;
        me.header = false;
        me.rootVisible = false;
        me.border = false;
        me.lines = true;
        me.autoScroll = true;
        me.animate = true;
        me.loader = new Ext.data.TreeStore({
            clearOnLoad: false
        });
        me.root = {
            expanded: true,
            children: this.data
        };
        me.collapseFirst = true;
        me.callParent(arguments);
    },
    initEvents: function () {
        this.superclass.initEvents.call(this);
        this.getSelectionModel().on('beforeselect', function (model, record) {
            return record.data.leaf;
        });
        this.on('itemclick', function (store, record, element, index, e) {
            if (record.isLeaf()) {
                e.stopEvent();
                this.mainPanel.loadClass(record.data);
            }
        });
    },
    filterTree: function (t, e) {
        var text = t.getValue();
        Ext.each(this.hiddenPkgs, function (n) {
            n.ui.show();
        });
        if (!text) {
            this.filter.clear();
            return;
        }
        this.expandAll();

        var re = new RegExp('^' + Ext.escapeRe(text), 'i');
        this.filter.filterBy(function (n) {
            return !n.attributes.isClass || re.test(n.text);
        });

        // hide empty packages that weren't filtered
        this.hiddenPkgs = [];
        var me = this;
        this.root.cascade(function (n) {
            if (!n.attributes.isClass && n.ui.ctNode.offsetHeight < 3) {
                n.ui.hide();
                me.hiddenPkgs.push(n);
            }
        });
    },
    selectClass: function (cls) {
        if (cls) {
            var parts = cls.split('.');
            var last = parts.length - 1;
            var res = [];
            var pkg = [];
            for (var i = 0; i < last; i++) { // things get nasty - static classes can have .
                var p = parts[i];
                var fc = p.charAt(0);
                var staticCls = fc.toUpperCase() == fc;
                if (p == 'Ext' || !staticCls) {
                    pkg.push(p);
                    res[i] = 'pkg-' + pkg.join('.');
                } else if (staticCls) {
                    --last;
                    res.splice(i, 1);
                }
            }
            res[last] = cls;

            this.selectPath('/root/apidocs/' + res.join('/'));
        }
    }
});
