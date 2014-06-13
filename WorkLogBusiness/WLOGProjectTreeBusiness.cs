/****************************************
***创建人：bhlfy
***创建时间：2013-04-24 18:43:49
***公司：山西博华科技有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using System;
using System.Data;

using WorkLogDataLibrary;
using WorkLogSqlLibrary;
using ExportExcelLib;
using BusinessBase;
using Fundation.Core;

namespace WorkLogBusiness
{
    public class WLOGProjectTreeBusiness : GeneralBusinesser
    {
        WLOGProjectTreeClass _wlogprojecttreeclass = new WLOGProjectTreeClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-24 18:43:49
        ***公司：山西博华科技有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        
        /// <summary>
        /// 根据条件筛选所有WLOGProjectTree指定页码的数据（分页型）
        /// </summary>
        /// <param name="wlogprojecttree">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityWLOGProjectTree wlogprojecttree, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            WLOGProjectTreeClass wlogprojecttreeclass = new WLOGProjectTreeClass();
            pageparams.PageSorts.Add(new PageSort(WLOGProjectTreeData.writeTime, EnumSQLOrderBY.DESC));
            DataSet wlogprojecttreedata = this.GetData(wlogprojecttree, pageparams, out totalCount);
            return base.GetJson(wlogprojecttreedata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存wlogprojecttreedata数据集数据
        /// </summary>
        /// <param name="wlogprojecttreedata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveWLOGProjectTree(WLOGProjectTreeData wlogprojecttreedata)
        {
            #region
            WLOGProjectTreeClass wlogprojecttreeclass = new WLOGProjectTreeClass();
            return base.Save(wlogprojecttreedata, wlogprojecttreeclass);
            #endregion
        }
                
        /// <summary>
        /// 添加WLOGProjectTree表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="wlogprojecttreedata">数据集对象</param>
        /// <param name="wlogprojecttree">实体对象</param>
        public void AddRow(ref WLOGProjectTreeData wlogprojecttreedata, EntityWLOGProjectTree wlogprojecttree)
        {
            #region
            DataRow dr = wlogprojecttreedata.Tables[0].NewRow();
            wlogprojecttree.currentId = this._wlogprojecttreeclass.GetMaxAddOne(wlogprojecttreedata).ToString();
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.parentId, wlogprojecttree.parentId);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.currentId, wlogprojecttree.currentId);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.writeUser, wlogprojecttree.writeUser);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.dirName, wlogprojecttree.dirName);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.usable, wlogprojecttree.usable);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.writeIp, wlogprojecttree.writeIp);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.writeTime, wlogprojecttree.writeTime);
            wlogprojecttreedata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑wlogprojecttreedata数据集中指定的行数据
        /// </summary>
        /// <param name="wlogprojecttreedata">数据集对象</param>
        /// <param name="wlogprojecttree">实体对象</param>
        public void EditRow(ref WLOGProjectTreeData wlogprojecttreedata, EntityWLOGProjectTree wlogprojecttree)
        {
            #region
            if (wlogprojecttreedata.Tables[0].Rows.Count <= 0)
                wlogprojecttreedata = this.getData(wlogprojecttree.currentId);
            DataRow dr = wlogprojecttreedata.Tables[0].Rows.Find(new object[1] {wlogprojecttree.currentId});
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.parentId, wlogprojecttree.parentId);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.currentId, wlogprojecttree.currentId);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.writeUser, wlogprojecttree.writeUser);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.dirName, wlogprojecttree.dirName);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.usable, wlogprojecttree.usable);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.writeIp, wlogprojecttree.writeIp);
            wlogprojecttreedata.Assign(dr, WLOGProjectTreeData.writeTime, wlogprojecttree.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除wlogprojecttreedata数据集中指定的行数据
        /// </summary>
        /// <param name="wlogprojecttreedata">数据集对象</param>
        /// <param name="currentId">主键-当前项目节点编号</param>
        public void DeleteRow(ref WLOGProjectTreeData wlogprojecttreedata,string currentId)
        {
            #region
            if (wlogprojecttreedata.Tables[0].Rows.Count <= 0)
                wlogprojecttreedata = this.getData(currentId);
            DataRow dr = wlogprojecttreedata.Tables[0].Rows.Find(new object[1] { currentId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取WLOGProjectTree数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            WLOGProjectTreeData wlogprojecttreedata = this.getData(null);
            totalCount = wlogprojecttreedata.Tables[0].Rows.Count;
            return base.GetJson(wlogprojecttreedata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityWLOGProjectTree wlogprojecttree)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(wlogprojecttree, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="currentId">主键-当前项目节点编号</param>
        /// <returns></returns>
        private WLOGProjectTreeData getData(string currentId)
        {
            #region
            WLOGProjectTreeData wlogprojecttreedata = new WLOGProjectTreeData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(WLOGProjectTreeData.currentId, EnumSqlType.sqlint, EnumCondition.Equal, currentId);
            this._wlogprojecttreeclass.GetSingleTAllWithoutCount(wlogprojecttreedata, querybusinessparams);
            return wlogprojecttreedata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有WLOGProjectTree指定页码的数据（分页型）
        /// </summary>
        /// <param name="wlogprojecttree">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityWLOGProjectTree wlogprojecttree, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(WLOGProjectTreeData.parentId, EnumSqlType.sqlint, 
                EnumCondition.Equal, wlogprojecttree.parentId);
            querybusinessparams.Add(WLOGProjectTreeData.currentId, EnumSqlType.sqlint, 
                EnumCondition.Equal, wlogprojecttree.currentId);
            querybusinessparams.Add(WLOGProjectTreeData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, wlogprojecttree.writeUser);
            querybusinessparams.Add(WLOGProjectTreeData.dirName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, wlogprojecttree.dirName);
            querybusinessparams.Add(WLOGProjectTreeData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, wlogprojecttree.usable);
            querybusinessparams.Add(WLOGProjectTreeData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, wlogprojecttree.writeIp);
            querybusinessparams.Add(WLOGProjectTreeData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, wlogprojecttree.writeTime);
            WLOGProjectTreeData wlogprojecttreedata = new WLOGProjectTreeData();
            totalCount = this._wlogprojecttreeclass.GetSingleT(wlogprojecttreedata, querybusinessparams);
            return wlogprojecttreedata;
            #endregion
        }
        #endregion

        #endregion

        /// <summary
        /// 菜单维护时获取项目架构数据
        /// </summary>
        /// <returns></returns>
        public string GetProjectTree()
        {
            #region
            string menulistjson = "";
            PageParams qParams = new PageParams();
            WLOGProjectTreeClass wlogprojecttreeclass = new WLOGProjectTreeClass();

            DataSet wlogprojecttreedata = wlogprojecttreeclass.SelectWLOGProjectTreeByPage(qParams, null);
            menulistjson += "{ \"text\":\".\",\"children\": [";

            string treejson = "";

            this.iteratorTree(wlogprojecttreedata, "0", ref treejson);
            if (treejson.Length > 0)
                treejson = treejson.Remove(treejson.Length - 1, 1);

            menulistjson += treejson + "]}";
            return menulistjson;
            #endregion
        }
        /// <summary>
        /// 递归获取各项目下的树形列表
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="parentId"></param>
        /// <param name="json"></param>
        private void iteratorTree(DataSet ds, string parentId, ref String json)
        {
            #region
            DataRow[] drArr = ds.Tables[0].Select(WLOGProjectTreeData.parentId + "=" + parentId.ToString()); //可取记录数到最后条数时卡符号
            DataRow[] drparent;
            int i = 0;
            foreach (DataRow dr in drArr)
            {
                drparent = ds.Tables[0].Select(WLOGProjectTreeData.parentId + "=" + dr[WLOGProjectTreeData.currentId].ToString());
                json += "{";

                json += WLOGProjectTreeData.currentId + ":'" + dr[WLOGProjectTreeData.currentId].ToString() + "',";
                json += "parentId_new:'" + dr[WLOGProjectTreeData.parentId].ToString() + "',";
                json += WLOGProjectTreeData.dirName + ":'" + dr[WLOGProjectTreeData.dirName].ToString() + "',";
                json += "'text':'" + dr[WLOGProjectTreeData.dirName].ToString() + "',";
                json += "'id':'" + dr[WLOGProjectTreeData.currentId].ToString() + "',";
                json += WLOGProjectTreeData.writeIp + ":'" + dr[WLOGProjectTreeData.writeIp].ToString() + "',";
                json += WLOGProjectTreeData.writeUser + ":'" + dr[WLOGProjectTreeData.writeUser].ToString() + "',";
                json += WLOGProjectTreeData.writeTime + ":'" + dr[WLOGProjectTreeData.writeTime].ToString() + "',";
                json += WLOGProjectTreeData.usable + ":" + dr[WLOGProjectTreeData.usable].ToString().ToLower() + ",";
                json += "expanded:true,";

                if (drparent.Length > 0)
                    json += "children:[";
                else
                    json += "children:[]";

                i++;
                iteratorTree(ds, dr[WLOGProjectTreeData.currentId].ToString(), ref json);
                json += "},";
                if (i == drArr.Length)
                {
                    json = json.Remove(json.Length - 1);
                    json += "]";
                }
            }
            #endregion
        }

        /// <summary>
        /// 菜单维护时获取项目架构数据
        /// </summary>
        /// <returns></returns>
        public string GetAllocProjectTree()
        {
            #region
            string menulistjson = "";
            PageParams qParams = new PageParams();
            WLOGProjectTreeClass wlogprojecttreeclass = new WLOGProjectTreeClass();

            DataSet wlogprojecttreedata = wlogprojecttreeclass.SelectWLOGProjectTreeByPage(qParams, null);
            menulistjson += "{ \"text\":\".\",\"children\": [";

            string treejson = "";

            this.iteratorProjectTree(wlogprojecttreedata, "0", ref treejson);
            if (treejson.Length > 0)
                treejson = treejson.Remove(treejson.Length - 1, 1);

            menulistjson += treejson + "]}";
            return menulistjson;
            #endregion
        }
        /// <summary>
        /// 递归获取各项目下的树形列表
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="parentId"></param>
        /// <param name="json"></param>
        private void iteratorProjectTree(DataSet ds, string parentId, ref String json)
        {
            #region
            DataRow[] drArr = ds.Tables[0].Select(WLOGProjectTreeData.parentId + "=" + parentId.ToString()); //可取记录数到最后条数时卡符号
            DataRow[] drparent;
            int i = 0;
            foreach (DataRow dr in drArr)
            {
                drparent = ds.Tables[0].Select(WLOGProjectTreeData.parentId + "=" + dr[WLOGProjectTreeData.currentId].ToString());
                json += "{";

                //json += "class:'1',";
                json += "text:'" + dr[WLOGProjectTreeData.dirName].ToString() + "',";
                json += "id:" + dr[WLOGProjectTreeData.currentId].ToString() + ",";
                json += "expanded:true,";

                if (drparent.Length > 0)
                    json += "children:[";
                else
                    json += "leaf:true";

                i++;
                iteratorProjectTree(ds, dr[WLOGProjectTreeData.currentId].ToString(), ref json);
                json += "},";
                if (i == drArr.Length)
                {
                    json = json.Remove(json.Length - 1);
                    json += "]";
                }
            }
            #endregion
        }

    }
}


