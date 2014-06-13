/****************************************
***创建人：bhlfy
***创建时间：2013-04-06 17:16:15
***公司：山西博华科技有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SystemDataLibrary;
using BusinessBase;

namespace SystemSqlLibrary
{
    public class AddressClass : GeneralAccessor
    {
        #region Create by iCat Assist Tools
        /****************************************
                ***生成器版本：V1.0.1.28380
                ***生成时间：2013-04-06 17:16:15
                ***公司：山西博华科技有限公司
                ***友情提示：以下代码为生成器自动生成，可做参照复制之用；
                ***         如需有其他业务要求，则可在region外添加新的业务关联方法；
                ***         如发现任何编译错误，请联系QQ：330669393。
                *****************************************/
        public AddressData SelectCountyByParentID(int addressId)
        {
            #region
            AddressData addressdata = new AddressData();
            string businessSql = @"SELECT * FROM [Address] where parentId in (select b.addrid from dbo.Address b where b.parentId = {0})";
            businessSql = String.Format(businessSql, addressId);

            base.GetWithoutPageBusiness(businessSql, addressdata, null);
            return addressdata;
            #endregion
        }
        #endregion
    }
}


