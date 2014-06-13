Ext.define("Sys.App.DocPanel", {
    extend: 'Ext.panel.Panel',
    initComponent: function (config) {
        var me = this;
        Ext.apply(me, config);
        me.closable = true;
        me.autoScroll = true;
        me.layout = 'fit';
        me.title = me.cclass;

        me.callParent(arguments);
    },
    directLink: function () {
        var link = String.format(
            "<a href=\"{0}\" target=\"_blank\">{0}</a>",
            document.location.href + '?class=' + this.cclass
        );
        Ext.Msg.alert('Direct Link to ' + this.cclass, link);
    },

    scrollToMember: function (member) {
        var el = Ext.fly(this.cclass + '-' + member);
        if (el) {
            var top = (el.getOffsetsTo(this.body)[1]) + this.body.dom.scrollTop;
            this.body.scrollTo('top', top - 25, { duration: 0.75, callback: this.hlMember.createDelegate(this, [member]) });
        }
    },

    scrollToSection: function (id) {
        var el = Ext.getDom(id);
        if (el) {
            var top = (Ext.fly(el).getOffsetsTo(this.body)[1]) + this.body.dom.scrollTop;
            this.body.scrollTo('top', top - 25, { duration: 0.5, callback: function () {
                Ext.fly(el).next('h2').pause(0.2).highlight('#8DB2E3', { attr: 'color' });
            }
            });
        }
    },

    hlMember: function (member) {
        var el = Ext.fly(this.cclass + '-' + member);
        if (el) {
            if (tr = el.up('tr')) {
                tr.highlight('#cadaf9');
            }
        }
    }
});