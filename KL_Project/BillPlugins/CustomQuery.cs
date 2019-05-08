using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kingdee.BOS;
using Kingdee.BOS.Core.Bill.PlugIn;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;
using Kingdee.BOS.Orm.DataEntity;
using Kingdee.BOS.Core.SqlBuilder;
using Kingdee.BOS.Core.Metadata;
using Kingdee.BOS.App.Data;
using Kingdee.BOS.ServiceHelper;
using System.ComponentModel;
using System.Data;
using Kingdee.BOS.Core.Bill.PlugIn.Args;
using Kingdee.BOS.Core.DynamicForm;
using Kingdee.BOS.Contracts;
using System.Threading;
using Kingdee.BOS.Core.DynamicForm.PlugIn;
using Kingdee.BOS.Core.List;
using KL_Project.Untity;

namespace KL_Project.BillPlugins
{
    [Description("物料自定义模糊查询")]
    public class CustomQuery : AbstractBillPlugIn
    {
        //string Path = @"D:\凯路调试.txt";
        public override void BeforeF7Select(BeforeF7SelectEventArgs e)
        {
            base.BeforeF7Select(e);
            string ActionKey = e.FieldKey.ToUpper();
            if (ActionKey == "FMATERIALID")
            {
                var a = this.View.GetFieldEditor("FMATERIALID", e.Row);
                var DataSource = this.Model.DataObject;
                //采用SQL注入来实现自定义
                e.ListFilterParameter.Filter = "FMODIFIERID = 100007 AND t0.FMATERIALID IN (100612,100614,100589))))))--";
            } 
        }

        public override void EntityRowDoubleClick(EntityRowClickEventArgs e)
        {
            base.EntityRowDoubleClick(e);
            ListShowParameter Parameter = new ListShowParameter();
            Parameter.FormId = "STK_Inventory";
            Parameter.MultiSelect = false;
            Parameter.ListFilterParameter.Filter = "FMATERIALID = 100612";
            this.View.ShowForm(Parameter);
        }
    }
}
