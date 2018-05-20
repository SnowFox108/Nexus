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

namespace Nexus.Core.PageTags
{
    
    [DataObject(true)]
    public class PageTagMgr
    {

        public PageTagMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region Get and Chk

        public PageTag Get_PageTag(string PageTagID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new PageTag(myDP.Get_PageTag(PageTagID));
        }

        public PageTag Get_PageTag_ByTagName(string Tag_Name)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new PageTag(myDP.Get_PageTag_ByTagName(Tag_Name.Trim()));
        }

        public List<PageTag> Get_PageTags(string SortOrder = "Tag_Name")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_PageTags(SortOrder);

            List<PageTag> list = new List<PageTag>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new PageTag(myDR));
            }

            return list;

        }

        public List<PageTag_Full> Get_ComponentInTags_Full_ByPageTagID(string PageTagID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_ComponentInTag_Full_ByPageTagID(PageTagID, SortOrder);

            List<PageTag_Full> list = new List<PageTag_Full>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new PageTag_Full(myDR));
            }

            return list;

        }

        public ComponentInTag Get_ComponentInTag(string PageTagID, string Module_ItemID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new ComponentInTag(myDP.Get_ComponentInTag(PageTagID, Module_ItemID));
        }

        public PageTag_Mapping Get_PageTag_Mapping(string PageIndexID, string PageTagID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new PageTag_Mapping(myDP.Get_PageTag_Mapping(PageIndexID, PageTagID));

        }

        public bool Chk_PageTag(string Tag_Name)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_PageTag(Tag_Name);
        }

        public int Sum_PageTagItems(string PageTagID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Sum_PageTagItems(PageTagID);

        }

        public int Sum_PageTagItems(string PageTagID, string Module_ItemID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Sum_PageTagItems(PageTagID, Module_ItemID);

        }

        #endregion

        #region Add

        public void Add_PageTag(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_PageTag(UpdateData);
        }

        public void Add_ComponentInTag(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_ComponentInTag(UpdateData);
        }

        public void Add_PageTag_Mapping(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_PageTag_Mapping(UpdateData);
        }

        #endregion

        #region Edit

        public void Edit_PageTag(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_PageTag(UpdateData);

        }

        public void Edit_ComponentInPageTag(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_ComponentInTag(UpdateData);

        }

        #endregion

        #region Remove

        public void Remove_PageTag(string PageTagID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_PageTag(PageTagID);
        }

        public void Remove_ComponentInTag_ByPageTagID(string PageTagID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_ComponentInTag_ByPageTagID(PageTagID);
        }

        public void Remove_ComponentInTag_ByPageTagID(string PageTagID, string Module_ItemID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_ComponentInTag_ByPageTagID(PageTagID, Module_ItemID);
        }

        public void Remove_ComponentInTag_ByComponentID(string Module_ItemID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_ComponentInTag_ByComponentID(Module_ItemID);
        }

        public void Remove_ComponentInTag_ByModuelID(string ModuleID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_ComponentInTag_ByModuleID(ModuleID);
        }

        public void Remove_PageTag_Mapping(string PageTag_MappingID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_PageTag_Mapping(PageTag_MappingID);
        }


        #endregion

        #region WebPage Tags

        public void Edit_WebPageTags(string PageIndexID, string NewTags, string OriginalTags)
        {

            string [] _newTags = NewTags.Replace(" ", "").Split(',');
            string [] _originalTags = OriginalTags.Replace(" ", "").Split(',');

            // Remove unused Tags
            List<PageTag> DeleteTags = new List<PageTag>();

            foreach (string OriginalTag in _originalTags)
            {
                bool found = false;
                foreach (string NewTag in _newTags)
                {
                    if (OriginalTag.Equals(NewTag, StringComparison.InvariantCultureIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    DeleteTags.Add(Get_PageTag_ByTagName(OriginalTag));
                }
            }

            foreach (PageTag DeleteTag in DeleteTags)
            {
                PageTag_Mapping myPageTag_Mapping = Get_PageTag_Mapping(PageIndexID, DeleteTag.PageTageID);
                Remove_PageTag_Mapping(myPageTag_Mapping.PageTag_MappingID);

                Delete_PageTags(DeleteTag, "07EB9C71-8751-4D42-AE97-CE4C8D213A12");
            }


            // Add new Tags
            List<string> AddTags = new List<string>();

            foreach (string NewTag in _newTags)
            {
                bool found = false;

                foreach (string OriginalTag in _originalTags)
                {
                    if (NewTag.Equals(OriginalTag, StringComparison.InvariantCultureIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    AddTags.Add(NewTag);
                }
            }

            foreach (string AddTag in AddTags)
            {

                string PageTagID = Add_PageTags(AddTag, "07EB9C71-8751-4D42-AE97-CE4C8D213A12");

                if (PageTagID != null)
                {

                    e2Data[] UpdateData = {
                                              new e2Data("PageIndexID", PageIndexID),
                                              new e2Data("PageTagID", PageTagID),
                                              new e2Data("IsFeatured", false.ToString())
                                          };

                    Add_PageTag_Mapping(UpdateData);
                }


            }

        }

        #endregion

        #region Functions

        public string Add_PageTags(string NewTag, string Module_ItemID)
        {

            Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();

            Modules.Module_Item myModule_Item = myModuleMgr.Get_Module_Item(Module_ItemID);

            if (myModule_Item != null)
            {
                //Add new Tag list to Page Tags
                if (Chk_PageTag(NewTag))
                {
                    #region Tag 已存在

                    PageTag myPageTag = Get_PageTag_ByTagName(NewTag);

                    int Item_Count = Sum_PageTagItems(myPageTag.PageTageID, Module_ItemID);

                    if (Item_Count < 1)
                    {
                        e2Data[] UpdateData = {
                                              new e2Data("Module_ItemID", Module_ItemID),
                                              new e2Data("ModuleID", myModule_Item.ModuleID),
                                              new e2Data("PageTagID", myPageTag.PageTageID),
                                              new e2Data("Item_Count", "1")
                                          };

                        Add_ComponentInTag(UpdateData);

                    }
                    else
                    {

                        Item_Count++;

                        ComponentInTag myComponentInTag = Get_ComponentInTag(myPageTag.PageTageID, Module_ItemID);

                        e2Data[] UpdateData = {
                                                      new e2Data("RelationID", myComponentInTag.RelationID),
                                                      new e2Data("Item_Count", Item_Count.ToString())
                                          };

                        Edit_ComponentInPageTag(UpdateData);

                    }

                    return myPageTag.PageTageID;

                    #endregion
                }
                else
                {
                    #region 发现新的Tag

                    string PageTagID = Tools.IDGenerator.Get_New_GUID();

                    e2Data[] UpdateData_PageTag = {
                                                      new e2Data("PageTagID", PageTagID),
                                                      new e2Data("Tag_Name", NewTag)
                                                      };

                    Add_PageTag(UpdateData_PageTag);

                    e2Data[] UpdateData_ComponentInTag = {
                                                             new e2Data("Module_ItemID", Module_ItemID),
                                                             new e2Data("ModuleID", myModule_Item.ModuleID),
                                                             new e2Data("PageTagID", PageTagID),
                                                             new e2Data("Item_Count", "1")
                                          };

                    Add_ComponentInTag(UpdateData_ComponentInTag);

                    return PageTagID;

                    #endregion
                }
            }

            return null;

        }

        public void Delete_PageTags(PageTag DeleteTag, string Module_ItemID)
        {
            Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();

            Modules.Module_Item myModule_Item = myModuleMgr.Get_Module_Item(Module_ItemID);

            if (myModule_Item != null)
            {
                //Add new Tag list to Page Tags

                int Item_Count = Sum_PageTagItems(DeleteTag.PageTageID, Module_ItemID);

                Item_Count--;

                if (Item_Count < 1)
                {
                    Remove_ComponentInTag_ByPageTagID(DeleteTag.PageTageID, Module_ItemID);

                    // Check if need remove Tag_Name
                    int Tag_Name_Count = Sum_PageTagItems(DeleteTag.PageTageID);

                    if (Tag_Name_Count < 1)
                    {
                        Remove_ComponentInTag_ByPageTagID(DeleteTag.PageTageID);
                        Remove_PageTag(DeleteTag.PageTageID);
                    }


                }
                else
                {

                    ComponentInTag myComponentInTag = Get_ComponentInTag(DeleteTag.PageTageID, Module_ItemID);

                    e2Data[] UpdateData = {
                                                      new e2Data("RelationID", myComponentInTag.RelationID),
                                                      new e2Data("Item_Count", Item_Count.ToString())
                                              };

                    Edit_ComponentInPageTag(UpdateData);

                }
            }
        }

        #endregion

    }
}
