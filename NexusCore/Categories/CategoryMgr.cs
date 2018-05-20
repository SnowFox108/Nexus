using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Nexus.Core.Categories
{
    [DataObject(true)]
    public class CategoryMgr
    {

        public CategoryMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region Get and Chk

        public Category Get_Category(string CategoryID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Category(myDP.Get_Category(CategoryID));
        }

        public List<Category> Get_Categories(string Parent_CategoryID)            
        {
            return Get_Categories(Parent_CategoryID, "Category_Name");
        }

        public List<Category> Get_Categories(string CategoryID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Categories(CategoryID, SortOrder);

            List<Category> list = new List<Category>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Category(myDR));
            }

            return list;

        }

        public List<Category_Full> Get_ComponentInCategory_Full_ByCategoryID(string CategoryID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_ComponentInCategory_Full_ByCategoryID(CategoryID, SortOrder);

            List<Category_Full> list = new List<Category_Full>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Category_Full(myDR));
            }

            return list;

        }

        public ComponentInCategory Get_ComponentInCategory(string CategoryID, string Module_ItemID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new ComponentInCategory(myDP.Get_ComponentInCategory(CategoryID, Module_ItemID));
        }


        public int Count_Child_Category(string CategoryID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Count_Child_Category(CategoryID);

        }

        public int Sum_CategoryItems(string CategoryID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Sum_CategoryItems(CategoryID);

        }

        public int Sum_CategoryItems(string CategoryID, string Module_ItemID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Sum_CategoryItems(CategoryID, Module_ItemID);

        }


        #endregion

        #region Add

        public void Add_Category(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Category(UpdateData);
        }

        public void Add_ComponentInCategory(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_ComponentInCategory(UpdateData);
        }

        #endregion

        #region Edit

        public void Edit_Category(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Category(UpdateData);

        }

        public void Edit_ComponentInCategory(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_ComponentInCategory(UpdateData);

        }

        #endregion

        #region Remove

        public void Remove_Category(string CategoryID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Category(CategoryID);
        }

        public void Remove_ComponentInCategory_ByCategoryID(string CategoryID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_ComponentInCategory_ByCategoryID(CategoryID);
        }

        public void Remove_ComponentInCategory_ByCategoryID(string CategoryID, string Module_ItemID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_ComponentInCategory_ByCategoryID(CategoryID, Module_ItemID);
        }

        public void Remove_ComponentInCategory_ByComponentID(string Module_ItemID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_ComponentInCategory_ByComponentID(Module_ItemID);
        }

        public void Remove_ComponentInCategory_ByModuelID(string ModuleID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_ComponentInCategory_ByModuleID(ModuleID);
        }


        #endregion

        #region Functions

        public void Add_ComponentInCategory_Item(string CategoryID, string Module_ItemID)
        {
            int Item_Count = Sum_CategoryItems(CategoryID, Module_ItemID);

            Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();

            Modules.Module_Item myModule_Item = myModuleMgr.Get_Module_Item(Module_ItemID);

            if (myModule_Item != null)
            {

                if (Item_Count < 1)
                {
                    e2Data[] UpdateData = {
                                              new e2Data("Module_ItemID", Module_ItemID),
                                              new e2Data("ModuleID", myModule_Item.ModuleID),
                                              new e2Data("CategoryID", CategoryID),
                                              new e2Data("Item_Count", "1")
                                          };

                    Add_ComponentInCategory(UpdateData);

                }
                else
                {

                    Item_Count++;

                    ComponentInCategory myComponentInCategory = Get_ComponentInCategory(CategoryID, Module_ItemID);

                    e2Data[] UpdateData = {
                                              new e2Data("RelationID", myComponentInCategory.RelationID),
                                              new e2Data("Item_Count", Item_Count.ToString())
                                          };

                    Edit_ComponentInCategory(UpdateData);

                }
            }
        }

        public void Delete_ComponentInCategory_Item(string CategoryID, string Module_ItemID)
        {
            int Item_Count = Sum_CategoryItems(CategoryID, Module_ItemID);

            Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();

            Modules.Module_Item myModule_Item = myModuleMgr.Get_Module_Item(Module_ItemID);

            if (myModule_Item != null)
            {
                Item_Count--;

                if (Item_Count < 1)
                {
                    Remove_ComponentInCategory_ByCategoryID(CategoryID, Module_ItemID);

                }
                else
                {

                    ComponentInCategory myComponentInCategory = Get_ComponentInCategory(CategoryID, Module_ItemID);

                    e2Data[] UpdateData = {
                                              new e2Data("RelationID", myComponentInCategory.RelationID),
                                              new e2Data("Item_Count", Item_Count.ToString())
                                          };

                    Edit_ComponentInCategory(UpdateData);

                }
            }

        }

        public void Move_ComponentInCategory_Item(string Source_CategoryID, string Dest_CategoryID, string Module_ItemID)
        {
            if (Source_CategoryID != Dest_CategoryID)
            {
                // Remove from Source Category
                Delete_ComponentInCategory_Item(Source_CategoryID, Module_ItemID);

                // Add to New Source Category
                Add_ComponentInCategory_Item(Dest_CategoryID, Module_ItemID);
            }
        }
        #endregion

    }
}
