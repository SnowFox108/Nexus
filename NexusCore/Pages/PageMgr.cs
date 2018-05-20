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
using Nexus.Core;

namespace Nexus.Core.Pages
{

    [DataObject(true)]
    public class SiteMenu
    {
        public SiteMenu()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public Menu_Nodes Get_Menu_Node(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Menu_Nodes(myDP.Get_Menu_Node(PageIndexID));
        }

        public static List<Menu_Nodes> sGet_Menu_Nodes(string Parent_PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Menu_Nodes(Parent_PageIndexID, "1,2");

            List<Menu_Nodes> list = new List<Menu_Nodes>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Menu_Nodes(myDR));
            }

            return list;

        }

        public int Get_Root_Menu_Count()
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Get_Root_Menu_Count();
        }

        public static void sEdit_Menu_Nodes(string srcNode, string destNode)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            e2Data[] UpdateData = {
                                   new e2Data("PageIndexID", srcNode),
                                   new e2Data("Parent_PageIndexID", destNode)
                                      };
            myDP.Edit_Menu_Nodes(UpdateData);

        }

        public static void sEdit_Menu_Nodes(RadTreeNode srcNode, RadTreeNode destNode)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            int i = 1;
            foreach (RadTreeNode node in destNode.Nodes)
            {
                e2Data[] UpdateData = {
                                   new e2Data("PageIndexID", node.Value),
                                   new e2Data("SortOrder", i.ToString())
                                      };
                myDP.Edit_Menu_Nodes(UpdateData);
                Thread.Sleep(100);
                i++;
            }

            if (srcNode.Value != destNode.Value)
            {
                i = 1;
                foreach (RadTreeNode node in srcNode.Nodes)
                {
                    e2Data[] UpdateData = {
                                   new e2Data("PageIndexID", node.Value),
                                   new e2Data("SortOrder", i.ToString())
                                      };
                    myDP.Edit_Menu_Nodes(UpdateData);
                    Thread.Sleep(100);
                    i++;
                }
            }
        }

        public void Reset_Menu_RootOrder()
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            List<Menu_Nodes> myMenu_Nodes = sGet_Menu_Nodes("-1");

            int i = 1;

            foreach (Menu_Nodes myMenu_Node in myMenu_Nodes)
            {
                e2Data[] UpdateData = {
                                          new e2Data("PageIndexID", myMenu_Node.PageIndexID),
                                          new e2Data("SortOrder", i.ToString())
                                      };
                myDP.Edit_Menu_Nodes(UpdateData);
                Thread.Sleep(100);
                i++;

            }

        }

    }

    [DataObject(true)]
    public class PageMgr
    {
        public PageMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region MetaTags

        public List<MetaTag> Get_Page_MetaTags(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Page_MetaTags(PageIndexID);

            List<MetaTag> list = new List<MetaTag>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new MetaTag(myDR));
            }

            return list;

        }


        public List<MetaTag> Get_Page_MetaTags(string PageIndexID, Meta_Type myMeta_Type)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Page_MetaTags(PageIndexID, StringEnum.GetStringValue(myMeta_Type));

            List<MetaTag> list = new List<MetaTag>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new MetaTag(myDR));
            }

            return list;

        }

        public MetaTag Get_Page_MetaTag(string MetaTagID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new MetaTag(myDP.Get_Page_MetaTag(MetaTagID));
        }

        public void Add_Page_MetaTag(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_MetaTag(UpdateData);
        }

        public void Edit_Page_MetaTag(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_MetaTag(UpdateData);

        }

        public void Remove_Page_MetaTag(string MetaTagID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_MetaTag(MetaTagID);
        }

        #endregion

        #region Get and Check

        public string Get_Homepage_PageIndexID()
        {
            return Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_HomepageID");
        }

        public List<Page_Category> Get_Page_Categories()
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Page_Categories();

            List<Page_Category> list = new List<Page_Category>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Page_Category(myDR));
            }

            return list;


        }

        public List<PageIndex> Get_PageIndex_ByName(string Page_Name)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_PagesIndex_ByName(Page_Name);

            List<PageIndex> list = new List<PageIndex>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new PageIndex(myDR));
            }

            return list;

        }

        public List<PageIndex> Get_PageIndex_ByName(string Page_Name, string CategoryIDs)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_PagesIndex_ByName(Page_Name, CategoryIDs);

            List<PageIndex> list = new List<PageIndex>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new PageIndex(myDR));
            }

            return list;

        }

        public PageIndex Get_PageIndex(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new PageIndex(myDP.Get_PageIndex(PageIndexID));
        }

        public static List<PageIndex_Full> sGet_PageIndex_FullList(string Parent_PageIndexID, string CategoryIDs, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_PageIndex_List(Parent_PageIndexID, CategoryIDs, SortOrder);

            List<PageIndex_Full> list = new List<PageIndex_Full>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new PageIndex_Full(myDR));
            }

            return list;

        }

        public PageIndex Get_Child_PageIndex(string PageIndexID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new PageIndex(myDP.Get_Child_PageIndex(PageIndexID, SortOrder));

        }

        public List<NexusCore_Page> Get_Pages(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Pages(PageIndexID);

            List<NexusCore_Page> list = new List<NexusCore_Page>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new NexusCore_Page(myDR));
            }

            return list;
        }

        public NexusCore_Page Get_Page(string PageID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new NexusCore_Page(myDP.Get_Page(PageID));
        }

        public NexusCore_Page Get_Page_ActiveID(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new NexusCore_Page(myDP.Get_Page_ActiveID(PageIndexID));
        }

        public Page_Control Get_Page_Control(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Control(myDP.Get_Page_Control(Page_ControlID));
        }

        public List<Page_Control> Get_Page_Controls(string PageID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Page_Controls(PageID);

            List<Page_Control> list = new List<Page_Control>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Page_Control(myDR));
            }

            return list;

        }

        public List<Page_Control> Get_Page_Controls(string PageID, string PlaceHolderID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Page_Controls(PageID, PlaceHolderID);

            List<Page_Control> list = new List<Page_Control>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Page_Control(myDR));
            }

            return list;

        }

        public List<Page_Control_Property> Get_Page_Control_Properties(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Page_Control_Properties(Page_ControlID);

            List<Page_Control_Property> list = new List<Page_Control_Property>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Page_Control_Property(myDR));
            }

            return list;

        }

        public bool Chk_PageIndexID(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_PageIndexID(PageIndexID);
        }

        /// <summary>
        /// Check if Page Name existed
        /// </summary>
        /// <param name="Page_Name">PageName from PageIndex</param>
        /// <returns>check result</returns>
        public bool Chk_PageName(string Page_Name)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_PageName(Page_Name);
        }

        public bool Chk_PageName_Live(string Page_Name)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_PageName_Live(Page_Name);
        }

        public int Count_Child_PageIndex(string PageIndexID, string CategoryIDs)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Count_Child_PageIndex(PageIndexID, CategoryIDs);

        }

        public int Count_Page_Version(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Count_Page_Version(PageIndexID);

        }

        #endregion

        #region OnPage realtime loading controls

        public void Load_PageControls_WebView(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info)
        {

            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myPage_Loading_Info.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {
                List<Page_Control> Page_Controls = Get_Page_Controls(myPage_Loading_Info.PageID, myMasterPage_Control.PlaceHolderID);

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myMasterPage_Control.PlaceHolderID);

                foreach (Page_Control Page_Control in Page_Controls)
                {

                    if (myContentPlaceHolder != null)
                    {

                        Nexus.Core.Modules.ModuleMgr myModuleMgr = new Nexus.Core.Modules.ModuleMgr();
                        Modules.Component myComponent = myModuleMgr.Get_Component(Page_Control.ComponentID);
                        Modules.Component_Control myControl = myModuleMgr.Get_Control(Page_Control.ComponentID, Modules.Control_Type.WebView);

                        if (myControl != null)
                        {
                            Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                            Type _control_type = assembly.GetType(myControl.Class_Name);
                            Control _control = myPage.LoadControl(_control_type, null);

                            List<Page_Control_Property> Control_Properties = Get_Page_Control_Properties(Page_Control.Page_ControlID);

                            foreach (Page_Control_Property Control_Property in Control_Properties)
                            {

                                try
                                {

                                    PropertyInfo _Control_Property = _control_type.GetProperty(Control_Property.Property_Name);

                                    switch (_Control_Property.PropertyType.FullName)
                                    {
                                        case "System.String":
                                            _Control_Property.SetValue(_control, Control_Property.Property_Value, null);
                                            break;
                                        case "System.Int32":
                                            _Control_Property.SetValue(_control, Convert.ToInt32(Control_Property.Property_Value), null);
                                            break;
                                        case "System.Boolean":
                                            _Control_Property.SetValue(_control, Convert.ToBoolean(Control_Property.Property_Value), null);
                                            break;
                                        default:
                                            _Control_Property.SetValue(_control, Control_Property.Property_Value, null);
                                            break;
                                    }
                                }
                                catch
                                {
                                    // Do nothing but recorder control errors
                                }
                            }

                            myContentPlaceHolder.Controls.Add(_control);

                        }
                        else
                        {
                            throw new Exception(string.Format("Invalid PageControl.Webview ComponentID: {0}", Page_Control.ComponentID));
                        }
                    }
                }

            }
        }

        public void Load_PageControls_WebView(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info, bool IsEditMode)
        {

            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myPage_Loading_Info.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {
                List<Page_Control> Page_Controls = Get_Page_Controls(myPage_Loading_Info.PageID, myMasterPage_Control.PlaceHolderID);

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myMasterPage_Control.PlaceHolderID);

                foreach (Page_Control Page_Control in Page_Controls)
                {

                    if (myContentPlaceHolder != null)
                    {

                        Nexus.Core.Modules.ModuleMgr myModuleMgr = new Nexus.Core.Modules.ModuleMgr();
                        Modules.Component myComponent = myModuleMgr.Get_Component(Page_Control.ComponentID);
                        Modules.Component_Control myControl = myModuleMgr.Get_Control(Page_Control.ComponentID, Modules.Control_Type.WebView);

                        if (myControl != null)
                        {
                            Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                            Type _control_type = assembly.GetType(myControl.Class_Name);
                            Control _control = myPage.LoadControl(_control_type, null);

                            List<Page_Control_Property> Control_Properties = Get_Page_Control_Properties(Page_Control.Page_ControlID);

                            foreach (Page_Control_Property Control_Property in Control_Properties)
                            {
                                PropertyInfo _Control_Property = _control_type.GetProperty(Control_Property.Property_Name);

                                switch (_Control_Property.PropertyType.FullName)
                                {
                                    case "System.String":
                                        _Control_Property.SetValue(_control, Control_Property.Property_Value, null);
                                        break;
                                    case "System.Int32":
                                        _Control_Property.SetValue(_control, Convert.ToInt32(Control_Property.Property_Value), null);
                                        break;
                                    case "System.Boolean":
                                        _Control_Property.SetValue(_control, Convert.ToBoolean(Control_Property.Property_Value), null);
                                        break;
                                    default:
                                        _Control_Property.SetValue(_control, Control_Property.Property_Value, null);
                                        break;
                                }
                            }

                            #region Create Edit button on live page
                            if (IsEditMode)
                            {
                                // Add Edit button to page
                                myContentPlaceHolder.Controls.Add(Core.ServerControls.ToolBars.LivePage_ToolBar(
                                    myComponent.Component_Icon,
                                    myComponent.Component_Name,
                                    Page_Control.Page_ControlID,
                                    "PageAdvancedMode"));

                            }
                            #endregion

                            myContentPlaceHolder.Controls.Add(_control);

                        }
                        else
                        {
                            throw new Exception(string.Format("Invalid PageControl.Webview ComponentID: {0}", Page_Control.ComponentID));
                        }
                    }
                }

            }
        }

        public void Load_PageControls_Advanced(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info)
        {

            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myPage_Loading_Info.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {
                List<Page_Control> Page_Controls = Get_Page_Controls(myPage_Loading_Info.PageID, myMasterPage_Control.PlaceHolderID);

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myMasterPage_Control.PlaceHolderID);

                // Create DockLayOut
                RadDockLayout myDockLayout = new RadDockLayout();
                myDockLayout.ID = "DockLayout_" + myMasterPage_Control.PlaceHolderID;


                // Create DockZone
                RadDockZone myDockZone = new RadDockZone();
                myDockZone.ID = "DockZone_" + myMasterPage_Control.PlaceHolderID;
                myDockZone.ToolTip = myMasterPage_Control.PlaceHolderID;
                myDockZone.BorderStyle = BorderStyle.Dotted;

                if (myMasterPage_Control.MinWidth < 250)
                {
                    myDockZone.MinWidth = 250;
                }
                else
                {
                    myDockZone.MinWidth = myMasterPage_Control.MinWidth;
                }

                myDockZone.MinHeight = myMasterPage_Control.MinHeight;

                if (myMasterPage_Control.Orientation == Nexus.Core.Templates.DockZone_Orientation.Vertical)
                {
                    myDockZone.Orientation = Orientation.Vertical;
                }
                else
                {
                    myDockZone.Orientation = Orientation.Horizontal;
                }

                myDockLayout.Controls.Add(myDockZone);

                // Create Controls
                foreach (Page_Control Page_Control in Page_Controls)
                {

                    if (myContentPlaceHolder != null)
                    {

                        Nexus.Core.Modules.ModuleMgr myModuleMgr = new Nexus.Core.Modules.ModuleMgr();
                        Modules.Component myComponent = myModuleMgr.Get_Component(Page_Control.ComponentID);
                        Modules.Component_Control myControl = myModuleMgr.Get_Control(Page_Control.ComponentID, Modules.Control_Type.Advanced);

                        if (myControl != null)
                        {
                            Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                            Type _control_type = assembly.GetType(myControl.Class_Name);
                            Control _control = myPage.LoadControl(_control_type, null);

                            List<Page_Control_Property> Control_Properties = Get_Page_Control_Properties(Page_Control.Page_ControlID);

                            foreach (Page_Control_Property Control_Property in Control_Properties)
                            {
                                try
                                {
                                    PropertyInfo _Control_Property = _control_type.GetProperty(Control_Property.Property_Name);

                                    switch (_Control_Property.PropertyType.FullName)
                                    {
                                        case "System.String":
                                            _Control_Property.SetValue(_control, Control_Property.Property_Value, null);
                                            break;
                                        case "System.Int32":
                                            _Control_Property.SetValue(_control, Convert.ToInt32(Control_Property.Property_Value), null);
                                            break;
                                        case "System.Boolean":
                                            _Control_Property.SetValue(_control, Convert.ToBoolean(Control_Property.Property_Value), null);
                                            break;
                                        default:
                                            _Control_Property.SetValue(_control, Control_Property.Property_Value, null);
                                            break;
                                    }
                                }
                                catch
                                {
                                    // Do nothing but record control error
                                }

                            }

                            // Create Dock
                            RadDock myDock = new RadDock();
                            myDock.Title = myComponent.Component_Name;
                            myDock.DefaultCommands = Telerik.Web.UI.Dock.DefaultCommands.None;
                            myDock.ID = string.Format("PageDock_{0}", Tools.IDGenerator.Get_New_GUID().Replace('-', 'a'));
                            myDock.EnableDrag = false;
                            myDock.DockMode = DockMode.Docked;
                            myDock.ContentContainer.CssClass = "nexusCore_Editor_Content";

                            // Dock Command
                            // Create Link Buttons
                            HyperLink HLinkbtn_Edit = new HyperLink();
                            HLinkbtn_Edit.ID = "Hlinkbtn_Edit";
                            HLinkbtn_Edit.Attributes["href"] = "#";
                            HLinkbtn_Edit.Attributes["onclick"] = string.Format("return Show_ControlManager('../PoP_ControlManager.aspx?Page_ControlID={0}&EditMode={1}');", Page_Control.Page_ControlID, "PageAdvancedMode");
                            HLinkbtn_Edit.Text = "Edit";

                            Nexus.Core.ServerControls.NC_LinkButton[] myLinkButtons = {
                                                new Nexus.Core.ServerControls.NC_LinkButton("/App_Control_Style/NexusCore/Images/Edit.png", HLinkbtn_Edit, typeof(HyperLink))
                                            };


                            myDock.TitlebarTemplate = new Nexus.Core.PageEditor.RadDockTemplate(myComponent.Component_Icon, myDock.Title, myLinkButtons);

                             //Create Control Inner Div
                            HtmlGenericControl myDock_Div = new HtmlGenericControl("Div");
                            myDock_Div.Attributes.Add("class", "inner");

                            myDock_Div.Controls.Add(_control);
                            myDock.ContentContainer.Controls.Add(myDock_Div);

                            myDockZone.Controls.Add(myDock);


                        }
                        else
                        {
                            throw new Exception(string.Format("Invalid PageControl.Webview ComponentID: {0}", Page_Control.ComponentID));
                        }
                    }
                }

                // Place All controls
                myContentPlaceHolder.Controls.Add(myDockLayout);
            }

        }

        #endregion

        #region Duplicate Page

        public void Duplicate_PageIndex(string Original_PageIndexID, string UserID)
        {
            PageIndex Original_PageIndex = Get_PageIndex(Original_PageIndexID);

            string Menu_Title = "Copy of " + Original_PageIndex.Menu_Title;
            string Page_Name = "Copy-of-" + Original_PageIndex.Page_Name;
            int Child_Count = Count_Child_PageIndex(Original_PageIndex.Parent_PageIndexID, "1,2") + 1;

            // Create New Page

            // Page Index
            string PageIndexID = Tools.IDGenerator.Get_New_GUID_PlainText();

            e2Data[] UpdateData_PageIndex = {
                                                    new e2Data("PageIndexID", PageIndexID),
                                                    new e2Data("Parent_PageIndexID", Original_PageIndex.Parent_PageIndexID),
                                                    new e2Data("Page_CategoryID", Original_PageIndex.Page_CategoryID ),
                                                    new e2Data("Menu_Title", Menu_Title ),
                                                    new e2Data("Page_Name", Page_Name ),
                                                    new e2Data("Page_Type", StringEnum.GetStringValue(Original_PageIndex.Page_Type) ),
                                                    new e2Data("SortOrder", Child_Count.ToString())
                                                    };

            Add_PageIndex(UpdateData_PageIndex);

            // Page Properties

            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            Page_Property Original_Page_Property = myPropertyMgr.Get_Page_Property(Original_PageIndexID);

            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("IsOnMenu", Original_Page_Property.IsOnMenu.ToString()),
                                      new e2Data("IsOnNavigator", Original_Page_Property.IsOnNavigator.ToString()),
                                      new e2Data("IsPrivacy_Inherited", Original_Page_Property.IsPrivacy_Inherited.ToString()),
                                      new e2Data("IsAttribute_Inherited", Original_Page_Property.IsAttribute_Inherited.ToString()),
                                      new e2Data("IsTemplate_Inherited", Original_Page_Property.IsTemplate_Inherited.ToString()),
                                      new e2Data("IsSSL", Original_Page_Property.IsSSL.ToString())
                                  };

            myPropertyMgr.Add_Page_Property(UpdateData);

            //URL rewrite
            string URLrewrite = Page_Name.Replace(" ", "");

            //
            switch (Original_PageIndex.Page_Type)
            {
                // Duplicate Normal Page
                case Page_Type.Normal_Page:

                    // Page MetaTags
                    PageMgr myPageMgr = new PageMgr();

                    List<MetaTag> myMetaTags = myPageMgr.Get_Page_MetaTags(Original_PageIndexID);

                    foreach (MetaTag myMetaTag in myMetaTags)
                    {
                        e2Data[] UpdateData_MetaTag = {
                                                          new e2Data("PageIndexID", PageIndexID),
                                                          new e2Data("Meta_Type", StringEnum.GetStringValue(myMetaTag.Meta_Type)),
                                                          new e2Data("Meta_Src", myMetaTag.Meta_Src)
                                                      };

                        myPageMgr.Add_Page_MetaTag(UpdateData_MetaTag);

                    }

                    // Page Version
                    string PageID = Tools.IDGenerator.Get_New_GUID_PlainText();
                    string NowDate = DateTime.Now.ToString();

                    e2Data[] UpdateData_Page = {
                                           new e2Data("PageID", PageID),
                                           new e2Data("PageIndexID", PageIndexID),
                                           new e2Data("Page_Version", "1"),
                                           new e2Data("Create_Date", NowDate),
                                           new e2Data("LastUpdate_Date", NowDate),
                                           new e2Data("LastUpdate_UserID", UserID),
                                           new e2Data("IsActive", "1"),
                                           new e2Data("IsDelete", "0")
                                       };

                    Add_Page(UpdateData_Page);


                    if (!Original_Page_Property.IsTemplate_Inherited)
                        Duplicate_Template(Original_PageIndexID, PageIndexID);

                    if (!Original_Page_Property.IsAttribute_Inherited)
                        Duplicate_Attribute(Original_PageIndexID, PageIndexID);

                    Duplicate_Controls(Original_PageIndexID, PageID);

                    break;

                // Create Category
                case Page_Type.Category:
                    if (!Original_Page_Property.IsTemplate_Inherited)
                        Duplicate_Template(Original_PageIndexID, PageIndexID);

                    if (!Original_Page_Property.IsAttribute_Inherited)
                        Duplicate_Attribute(Original_PageIndexID, PageIndexID);

                    break;

                case Page_Type.Internal_Page_Pointer:
                    Duplicate_IntLink(Original_PageIndexID, PageIndexID);
                    break;

                case Page_Type.External_Link:
                    Duplicate_ExtLink(Original_PageIndexID, PageIndexID);
                    break;


            }

        }

        private void Duplicate_Template(string Original_PageIndexID, string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            Page_Template Original_Page_Template = myPropertyMgr.Get_Page_Template(Original_PageIndexID);

            // Page Index
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("MasterPageIndexID", Original_Page_Template.MasterPageIndexID)
                                  };

            myPropertyMgr.Add_Page_Template(UpdateData);
        }

        private void Duplicate_ExtLink(string Original_PageIndexID, string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            Page_ExtLink Original_Page_ExtLink = myPropertyMgr.Get_Page_ExtLink(Original_PageIndexID);

            // Page Index
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("Page_URL", Original_Page_ExtLink.Page_URL),
                                      new e2Data("Page_Target", Original_Page_ExtLink.Page_Target)
                                  };

            myPropertyMgr.Add_Page_ExtLink(UpdateData);
        }

        private void Duplicate_IntLink(string Original_PageIndexID, string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            Page_IntLink Original_Page_IntLink = myPropertyMgr.Get_Page_IntLink(Original_PageIndexID);

            // Page Index
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("PagePointerID", Original_Page_IntLink.PagePointerID),
                                      new e2Data("Page_Target", Original_Page_IntLink.Page_Target)
                                  };

            myPropertyMgr.Add_Page_IntLink(UpdateData);
        }

        private void Duplicate_Attribute(string Original_PageIndexID, string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            Page_Attribute Original_Page_Attribute = myPropertyMgr.Get_Page_Attribute(Original_PageIndexID);

            // Page Index
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("Page_Title", Original_Page_Attribute.Page_Title),
                                      new e2Data("Page_Keyword", Original_Page_Attribute.Page_Keyword),
                                      new e2Data("Page_Description", Original_Page_Attribute.Page_Description)
                                  };

            myPropertyMgr.Add_Page_Attribute(UpdateData);
        }

        private void Duplicate_Controls(string Original_PageIndexID, string PageID)
        {

            // Copy Controls and properties
            NexusCore_Page myPage = Get_Page_ActiveID(Original_PageIndexID);

            List<Page_Control> myPage_Controls = Get_Page_Controls(myPage.PageID);

            foreach (Page_Control myPage_Control in myPage_Controls)
            {

                e2Data[] UpdateData_Page_Control = {
                                                       new e2Data("PageID", PageID),
                                                       new e2Data("PlaceHolderID", myPage_Control.PlaceHolderID),
                                                       new e2Data("ComponentID", myPage_Control.ComponentID),
                                                       new e2Data("SortOrder", myPage_Control.SortOrder.ToString())
                                                   };

                string Page_ControlID = Add_Page_Control(UpdateData_Page_Control);

                System.Threading.Thread.Sleep(100);

                List<Page_Control_Property> myPage_Control_Properties = Get_Page_Control_Properties(myPage_Control.Page_ControlID);

                foreach (Page_Control_Property myPage_Control_Property in myPage_Control_Properties)
                {

                    e2Data[] UpdateData_Page_Property = {
                                                             new e2Data("Page_ControlID", Page_ControlID),
                                                             new e2Data("Property_Name", myPage_Control_Property.Property_Name),
                                                             new e2Data("Property_Value", myPage_Control_Property.Property_Value),
                                                         };

                    Add_Page_Property(UpdateData_Page_Property);

                    System.Threading.Thread.Sleep(100);

                }

            }

        }

        #endregion

        #region Delete Page

        public void Delete_PageIndex(string PageIndexID)
        {
            // Remove all Page Controls
            Delete_Pages(PageIndexID);

            Page_PropertyMgr myPage_PropertyMgr = new Page_PropertyMgr();
            Page_Property myPage_Property = myPage_PropertyMgr.Get_Page_Property(PageIndexID);

            if (!myPage_Property.IsPrivacy_Inherited)
            {
                Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();
                myPrivacyMgr.Remove_Page_PrivacyURL(PageIndexID);
                myPrivacyMgr.Remove_Page_Privacy(PageIndexID);
            }

            if (!myPage_Property.IsAttribute_Inherited)
                myPage_PropertyMgr.Remove_Page_Attribute(PageIndexID);

            if (!myPage_Property.IsTemplate_Inherited)
                myPage_PropertyMgr.Remove_Page_Template(PageIndexID);

            myPage_PropertyMgr.Remove_Page_Property(PageIndexID);
            Remove_PageIndex(PageIndexID);

        }

        public void Delete_Pages(string PageIndexID)
        {
            PageEditorMgr myPageEditorMgr = new PageEditorMgr();

            List<NexusCore_Page> myPages = Get_Pages(PageIndexID);

            foreach (NexusCore_Page myPage in myPages)
            {

                List<Page_Control> myPage_Controls = Get_Page_Controls(myPage.PageID);

                foreach (Page_Control myPage_Control in myPage_Controls)
                {
                    Remove_Page_Control_Properties(myPage_Control.Page_ControlID);
                }

                Remove_Page_Controls(myPage.PageID);
            }

            Remove_Pages(PageIndexID);

        }

        #endregion

        #region Add

        public void Add_PageIndex(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_PageIndex(UpdateData);
        }

        public void Add_Page(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page(UpdateData);
        }

        public string Add_Page_Control(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Add_Page_Control(UpdateData);
        }

        public void Add_Page_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_Control_Property(UpdateData);
        }

        #endregion

        #region Update

        public void Edit_PageIndex(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_PageIndex(UpdateData);

        }

        public void Edit_Page(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page(UpdateData);

        }

        public void Reset_Page_Active(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Reset_Page_Active(PageIndexID);

        }

        public void Edit_Page_Control(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_Control(UpdateData);
        }

        public void Edit_Page_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_Control_Property(UpdateData);
        }


        #endregion

        #region Delete

        public void Remove_PageIndex(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_PageIndex(PageIndexID);
        }

        public void Remove_Page(string PageID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page(PageID);
        }

        public void Remove_Pages(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Pages(PageIndexID);
        }

        public void Remove_Page_Controls(string PageID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Controls(PageID);
        }

        public void Remove_Page_Control_Properties(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Control_Properties(Page_ControlID);
        }


        #endregion

    }

    public class PageEditorMgr : System.Web.UI.UserControl
    {

        #region Events

        //private static readonly object EventDockPositionChanged = new object();

        //[Category("Action")]
        //[Description("Raised RadDock Position Changing event")]
        //public event DockPositionChangedEventHandler DockPositionChanged
        //{
        //    add
        //    {
        //        Events.AddHandler(EventDockPositionChanged, value);
        //    }
        //    remove
        //    {
        //        Events.RemoveHandler(EventDockPositionChanged, value);
        //    }
        //}

        //protected void OnDockPositionChanged(object sender, DockPositionChangedEventArgs e)
        //{
        //    DockPositionChangedEventHandler DockPositionChangedHandler = (DockPositionChangedEventHandler)Events[EventDockPositionChanged];

        //    if (DockPositionChangedHandler != null)
        //        DockPositionChangedHandler(sender, e);

        //}

        //// LinkButton Click Event
        //private static readonly object EventCommand = new object();

        //[Category("Action")]
        //[Description("LinkButton Command Clicked event")]
        //public event CommandEventHandler CommandEvent
        //{
        //    add
        //    {
        //        Events.AddHandler(EventCommand, value);
        //    }
        //    remove
        //    {
        //        Events.RemoveHandler(EventCommand, value);
        //    }
        //}

        //protected void OnCommand(object sender, CommandEventArgs e)
        //{
        //    CommandEventHandler CommandHandler = (CommandEventHandler)Events[EventCommand];

        //    if (CommandHandler != null)
        //        CommandHandler(sender, e);

        //}

        //// LinkButton Load Event
        //private static readonly object EventLoad = new object();

        //[Category("Action")]
        //[Description("LinkButton Load event")]
        //public event EventHandler LoadEvent
        //{
        //    add
        //    {
        //        Events.AddHandler(EventLoad, value);
        //    }
        //    remove
        //    {
        //        Events.RemoveHandler(EventLoad, value);
        //    }
        //}

        //protected void OnLoad(object sender, EventArgs e)
        //{
        //    EventHandler LoadHandler = (EventHandler)Events[EventLoad];

        //    if (LoadHandler != null)
        //        LoadHandler(sender, e);

        //}

        #endregion

        public PageEditorMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public Page_Lock Get_Page_Lock(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Lock(myDP.Get_Page_Lock(PageIndexID));
        }

        public bool Chk_Page_Lock(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Page_Lock(PageIndexID);
        }

        public Page_Lock_Template Get_Page_Lock_Template(string Page_LockID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Lock_Template(myDP.Get_Page_Lock_Template(Page_LockID));
        }

        public Page_Lock_Attribute Get_Page_Lock_Attribute(string Page_LockID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Lock_Attribute(myDP.Get_Page_Lock_Attribute(Page_LockID));
        }

        public Page_Lock_Control Get_Page_Lock_Control(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Lock_Control(myDP.Get_Page_Lock_Control(Page_ControlID));
        }

        public List<Page_Lock_Control> Get_Page_Lock_Controls(string Page_LockID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Page_Lock_Controls(Page_LockID);

            List<Page_Lock_Control> list = new List<Page_Lock_Control>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Page_Lock_Control(myDR));
            }

            return list;

        }

        public List<Page_Lock_Control> Get_Page_Lock_Controls(string Page_LockID, string PlaceHolderID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Page_Lock_Controls(Page_LockID, PlaceHolderID);

            List<Page_Lock_Control> list = new List<Page_Lock_Control>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Page_Lock_Control(myDR));
            }

            return list;

        }

        public List<Page_Lock_Control_Property> Get_Page_Lock_Control_Properties(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Page_Lock_Control_Properties(Page_ControlID);

            List<Page_Lock_Control_Property> list = new List<Page_Lock_Control_Property>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Page_Lock_Control_Property(myDR));
            }

            return list;

        }

        #region On Page realtime loading controls

        #region unused code
        //public void Load_PageControls_Design(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info)
        //{

        //    Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

        //    List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myPage_Loading_Info.MasterPageID, null);

        //    foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
        //    {

        //        List<Page_Lock_Control> myPage_Controls = Get_Page_Lock_Controls(myPage_Loading_Info.Page_LockID, myMasterPage_Control.PlaceHolderID);

        //        ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myMasterPage_Control.PlaceHolderID);

        //        // Create UpdatePanel
        //        UpdatePanel myUpdatePanel = new UpdatePanel();
        //        myUpdatePanel.ID = "UpdatePanel_" + myMasterPage_Control.PlaceHolderID;

        //        // Create DockZone
        //        RadDockZone myDockZone = new RadDockZone();
        //        myDockZone.ID = "DockZone_" + myMasterPage_Control.PlaceHolderID;
        //        myDockZone.ToolTip = myMasterPage_Control.PlaceHolderID;
        //        myDockZone.BorderStyle = BorderStyle.Dotted;

        //        myDockZone.MinWidth = myMasterPage_Control.MinWidth;
        //        myDockZone.MinHeight = myMasterPage_Control.MinHeight;

        //        if (myMasterPage_Control.Orientation == Nexus.Core.Templates.DockZone_Orientation.Vertical)
        //        {
        //            myDockZone.Orientation = Orientation.Vertical;
        //        }
        //        else
        //        {
        //            myDockZone.Orientation = Orientation.Horizontal;
        //        }

        //        // Create Controls
        //        foreach (Page_Lock_Control myPage_Control in myPage_Controls)
        //        {

        //            if (myContentPlaceHolder != null)
        //            {

        //                Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();
        //                Modules.Component myComponent = myModuleMgr.Get_Component(myPage_Control.ComponentID);
        //                Modules.Component_Control myControl = myModuleMgr.Get_Control(myPage_Control.ComponentID, Modules.Control_Type.Advanced);

        //                if (myControl != null)
        //                {
        //                    Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

        //                    Type _control_type = assembly.GetType(myControl.Class_Name);
        //                    Control _control = myPage.LoadControl(_control_type, null);
        //                    _control.ID = "PageControl_"
        //                        + myMasterPage_Control.PlaceHolderID
        //                        + "_"
        //                        + myComponent.ComponentID
        //                        + "_"
        //                        + (myDockZone.Docks.Count + 1).ToString();

        //                    List<Page_Lock_Control_Property> Control_Properties = Get_Page_Lock_Control_Properties(myPage_Control.Page_ControlID);

        //                    foreach (Page_Lock_Control_Property Control_Property in Control_Properties)
        //                    {
        //                        PropertyInfo _Control_Property = _control_type.GetProperty(Control_Property.Property_Name);

        //                        switch (_Control_Property.PropertyType.FullName)
        //                        {
        //                            case "System.String":
        //                                _Control_Property.SetValue(_control, Control_Property.Property_Value, null);
        //                                break;
        //                            case "System.Int32":
        //                                _Control_Property.SetValue(_control, Convert.ToInt32(Control_Property.Property_Value), null);
        //                                break;
        //                            case "System.Boolean":
        //                                _Control_Property.SetValue(_control, Convert.ToBoolean(Control_Property.Property_Value), null);
        //                                break;
        //                            default:
        //                                _Control_Property.SetValue(_control, Control_Property.Property_Value, null);
        //                                break;
        //                        }

        //                    }

        //                    // Create Dock
        //                    RadDock myDock = new RadDock();
        //                    myDock.Title = myComponent.Component_Name + " " + myPage_Control.Page_ControlID;
        //                    myDock.DefaultCommands = Telerik.Web.UI.Dock.DefaultCommands.None;
        //                    myDock.ID = "PageDock_"
        //                        + myMasterPage_Control.PlaceHolderID
        //                        + "_"
        //                        + (myDockZone.Docks.Count + 1).ToString(); // + NewID

        //                    myDock.Tag = myPage_Control.Page_ControlID;
        //                    myDock.EnableDrag = true;
        //                    myDock.AutoPostBack = true;
        //                    myDock.CommandsAutoPostBack = true;
        //                    myDock.DockMode = DockMode.Docked;

        //                    // Add Dock Event
        //                    //myDock.DockPositionChanged += new DockPositionChangedEventHandler(RadDock_DesignMode_DockPositionChanged);

        //                    DockCommand _edit = new DockCommand();
        //                    _edit.Name = "Edit";
        //                    _edit.Text = "Edit";
        //                    _edit.AutoPostBack = true;

        //                    DockCommand _delete = new DockCommand();
        //                    _delete.Name = "Delete";
        //                    _delete.Text = "Delete";
        //                    _delete.AutoPostBack = true;

        //                    myDock.Commands.Add(_delete);
        //                    myDock.Commands.Add(_edit);

        //                    myDock.ContentContainer.Controls.Add(_control);
        //                    myDockZone.Controls.Add(myDock);

        //                    // Add UpdatePanel Trigger
        //                    //AsyncPostBackTrigger saveStateTrigger = new AsyncPostBackTrigger();
        //                    //saveStateTrigger.ControlID = myDock.ID;
        //                    //saveStateTrigger.EventName = "DockPositionChanged";
        //                    //myUpdatePanel.Triggers.Add(saveStateTrigger);

        //                    //saveStateTrigger = new AsyncPostBackTrigger();
        //                    //saveStateTrigger.ControlID = myDock.ID;
        //                    //saveStateTrigger.EventName = "Command";
        //                    //myUpdatePanel.Triggers.Add(saveStateTrigger);

        //                }
        //                else
        //                {
        //                    throw new Exception(string.Format("Invalid PageControl.Design Mode ComponentID: {0}", myPage_Control.ComponentID));
        //                }
        //            }
        //        }

        //        // Place All controls
        //        myContentPlaceHolder.Controls.Add(myUpdatePanel);
        //        myContentPlaceHolder.Controls.Add(myDockZone);

        //    }

        //}
        #endregion

        public void Load_PageDocks_Design(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info)
        {

            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myPage_Loading_Info.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {

                //List<Page_Lock_Control> Page_Controls = Get_Page_Lock_Controls(myPage_Loading_Info.Page_LockID, myMasterPage_Control.PlaceHolderID);

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myMasterPage_Control.PlaceHolderID);

                // Create UpdatePanel
                //UpdatePanel myUpdatePanel = new UpdatePanel();
                //myUpdatePanel.ID = "UpdatePanel_" + myMasterPage_Control.PlaceHolderID;

                // Create DockZone
                RadDockZone myDockZone = new RadDockZone();
                myDockZone.ID = "DockZone_" + myMasterPage_Control.PlaceHolderID;
                myDockZone.ToolTip = myMasterPage_Control.PlaceHolderID;
                myDockZone.BorderStyle = BorderStyle.Dotted;

                if (myMasterPage_Control.MinWidth < 300)
                {
                    myDockZone.MinWidth = 300;
                }
                else
                {
                    myDockZone.MinWidth = myMasterPage_Control.MinWidth;
                }

                myDockZone.MinHeight = myMasterPage_Control.MinHeight;

                if (myMasterPage_Control.Orientation == Nexus.Core.Templates.DockZone_Orientation.Vertical)
                {
                    myDockZone.Orientation = Orientation.Vertical;
                }
                else
                {
                    myDockZone.Orientation = Orientation.Horizontal;
                }

                // Place All controls
                //myContentPlaceHolder.Controls.Add(myUpdatePanel);
                myContentPlaceHolder.Controls.Add(myDockZone);

            }

        }

        public List<DockState> Load_PageControls_StateList(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info, RadDockLayout myDockLayout)
        {

            List<DockState> myDockStates = new List<DockState>();

            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myPage_Loading_Info.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {

                List<Page_Lock_Control> myPage_Controls = Get_Page_Lock_Controls(myPage_Loading_Info.Page_LockID, myMasterPage_Control.PlaceHolderID);

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myMasterPage_Control.PlaceHolderID);

                // Look for droping DockZone
                RadDockZone myDockZone = (RadDockZone)myContentPlaceHolder.FindControl("DockZone_" + myMasterPage_Control.PlaceHolderID);

                // Create Controls
                foreach (Page_Lock_Control myPage_Control in myPage_Controls)
                {

                    if (myContentPlaceHolder != null)
                    {

                        Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();
                        Modules.Component myComponent = myModuleMgr.Get_Component(myPage_Control.ComponentID);
                        Modules.Component_Control myControl = myModuleMgr.Get_Control(myPage_Control.ComponentID, Modules.Control_Type.Advanced);

                        if (myControl != null)
                        {

                            DockState myDockState = new DockState();

                            myDockState.Closed = false;

                            //string prefix = "ctl00_" + myMasterPage_Control.PlaceHolderID + "_";
                            myDockState.DockZoneID = myDockZone.ClientID;
                            myDockState.Index = myPage_Control.SortOrder - 1;
                            myDockState.Tag = myPage_Control.Page_ControlID;
                            myDockState.Title = myComponent.Component_Name + " " + myPage_Control.Page_ControlID;
                            myDockState.UniqueName = string.Format("PageDock_{0}", Tools.IDGenerator.Get_New_GUID().Replace('-', 'a'));

                            myDockStates.Add(myDockState);

                        }
                        else
                        {
                            throw new Exception(string.Format("Invalid PageControl.Design Mode ComponentID: {0}", myPage_Control.ComponentID));
                        }
                    }
                }

            }

            return myDockStates;

        }

        // Load Controls for Design Mode
        public RadDock Load_PageControls_FromState(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info, DockState state)
        {
            if (state.Tag != null)
            {
                Page_Lock_Control myPage_Control = Get_Page_Lock_Control(state.Tag);

                Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();
                Modules.Component myComponent = myModuleMgr.Get_Component(myPage_Control.ComponentID);
                Modules.Component_Control myControl = myModuleMgr.Get_Control(myPage_Control.ComponentID, Modules.Control_Type.Advanced);

                if (myControl != null)
                {
                    Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                    Type _control_type = assembly.GetType(myControl.Class_Name);
                    Control _control = myPage.LoadControl(_control_type, null);
                    _control.ID = state.UniqueName;

                    List<Page_Lock_Control_Property> Control_Properties = Get_Page_Lock_Control_Properties(myPage_Control.Page_ControlID);

                    foreach (Page_Lock_Control_Property Control_Property in Control_Properties)
                    {
                        try
                        {
                            PropertyInfo _Control_Property = _control_type.GetProperty(Control_Property.Property_Name);

                            switch (_Control_Property.PropertyType.FullName)
                            {
                                case "System.String":
                                    _Control_Property.SetValue(_control, Control_Property.Property_Value, null);
                                    break;
                                case "System.Int32":
                                    _Control_Property.SetValue(_control, Convert.ToInt32(Control_Property.Property_Value), null);
                                    break;
                                case "System.Boolean":
                                    _Control_Property.SetValue(_control, Convert.ToBoolean(Control_Property.Property_Value), null);
                                    break;
                                default:
                                    _Control_Property.SetValue(_control, Control_Property.Property_Value, null);
                                    break;
                            }
                        }
                        catch
                        {
                            // Do nothing but recorder control error
                        }

                    }

                    // Create Dock
                    RadDock myDock = new RadDock();
                    myDock.Title = myComponent.Component_Name + " " + myPage_Control.Page_ControlID;
                    myDock.DefaultCommands = Telerik.Web.UI.Dock.DefaultCommands.None;
                    myDock.ID = state.UniqueName;

                    myDock.Tag = myPage_Control.Page_ControlID;
                    myDock.EnableDrag = true;
                    myDock.AutoPostBack = true;
                    myDock.CommandsAutoPostBack = true;
                    myDock.DockMode = DockMode.Docked;
                    myDock.ApplyState(state);

                    myDock.ContentContainer.CssClass = "nexusCore_Editor_Content";

                    // Add Dock Event
                    //myDock.DockPositionChanged += new DockPositionChangedEventHandler(RadDock_DesignMode_DockPositionChanged);

                    // Dock Command

                    // Create Link Buttons
                    HyperLink HLinkbtn_Edit = new HyperLink();
                    HLinkbtn_Edit.ID = "Hlinkbtn_Edit";
                    HLinkbtn_Edit.Attributes["href"] = "#";
                    HLinkbtn_Edit.Attributes["onclick"] = string.Format("return Show_ControlManager('../PoP_ControlManager.aspx?Page_ControlID={0}&EditMode={1}');", myPage_Control.Page_ControlID, "PageDesignMode");
                    HLinkbtn_Edit.Text = "Edit";

                    LinkButton Linkbtn_Delete = new LinkButton();
                    Linkbtn_Delete.ID = "Linkbtn_Delete";
                    Linkbtn_Delete.CommandName = "Delete";
                    Linkbtn_Delete.CommandArgument = myDock.ID;
                    //Linkbtn_Delete.Command += new CommandEventHandler(Linkbtn_Edit_Command);
                    Linkbtn_Delete.Text = "Delete";

                    Nexus.Core.ServerControls.NC_LinkButton[] myLinkButtons = {
                                                new Nexus.Core.ServerControls.NC_LinkButton("/App_Control_Style/NexusCore/Images/Edit.png", HLinkbtn_Edit, typeof(HyperLink)),
                                                new Nexus.Core.ServerControls.NC_LinkButton("/App_Control_Style/NexusCore/Images/Delete.png", Linkbtn_Delete, typeof(LinkButton))
                                            };


                    myDock.TitlebarTemplate = new Nexus.Core.PageEditor.RadDockTemplate(myComponent.Component_Icon, myDock.Title, myLinkButtons);

                    //DockCommand _edit = new DockCommand();
                    //_edit.Name = "Edit";
                    //_edit.Text = "Edit";
                    //_edit.AutoPostBack = true;

                    //DockCommand _delete = new DockCommand();
                    //_delete.Name = "Delete";
                    //_delete.Text = "Delete";
                    //_delete.AutoPostBack = true;

                    //myDock.Commands.Add(_delete);
                    //myDock.Commands.Add(_edit);
                    
                    // Create Control Inner Div
                    HtmlGenericControl myDock_Div = new HtmlGenericControl("Div");
                    myDock_Div.Attributes.Add("class", "inner");

                    myDock_Div.Controls.Add(_control);
                    myDock.ContentContainer.Controls.Add(myDock_Div);

                    return myDock;

                }
                else
                {
                    throw new Exception(string.Format("Invalid PageControl.Design Mode ComponentID: {0}", myPage_Control.ComponentID));
                }

            }

            return null;

        }

        //protected void Linkbtn_Edit_Command(object sender, CommandEventArgs e)
        //{
        //    OnCommand(sender, e);
        //}

        //protected void Linkbtn_Edit_Load(object sender, EventArgs e)
        //{
        //    OnLoad(sender, e);
        //}

        // Drag new Control from Toolbox to Design Mode
        public RadDock Add_DesignMode_NewControl(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info, RadTreeNode sourceNode, string dropHtmlElementID, int dockCurrentPos)
        {

            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myPage_Loading_Info.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {
                List<Page_Lock_Control> Page_Controls = Get_Page_Lock_Controls(myPage_Loading_Info.Page_LockID, myMasterPage_Control.PlaceHolderID);

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myMasterPage_Control.PlaceHolderID);

                // Look for droping DockZone
                RadDockZone myDockZone = (RadDockZone)myContentPlaceHolder.FindControl("DockZone_" + myMasterPage_Control.PlaceHolderID);

                if (myDockZone != null)
                {
                    if (dropHtmlElementID == myDockZone.ClientID)
                    {
                        // Drop Controls
                        Nexus.Core.Modules.ModuleMgr myModuleMgr = new Nexus.Core.Modules.ModuleMgr();
                        Modules.Component myComponent = myModuleMgr.Get_Component(sourceNode.Value);
                        Modules.Component_Control myControl = myModuleMgr.Get_Control(sourceNode.Value, Modules.Control_Type.Advanced);

                        if (myControl != null)
                        {
                            Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                            Type _control_type = assembly.GetType(myControl.Class_Name);
                            Control _control = myPage.LoadControl(_control_type, null);

                            // Create Dock State
                            DockState myDockState = new DockState();

                            myDockState.Closed = false;

                            myDockState.DockZoneID = myDockZone.ClientID;
                            myDockState.Index = myDockZone.Docks.Count;

                            // Create Dock
                            RadDock myDock = new RadDock();
                            myDock.DefaultCommands = Telerik.Web.UI.Dock.DefaultCommands.None;
                            myDock.ID = string.Format("PageDock_{0}", Tools.IDGenerator.Get_New_GUID().Replace('-', 'a'));
                            myDock.ApplyState(myDockState);

                            myDock.EnableDrag = true;
                            myDock.AutoPostBack = true;
                            myDock.CommandsAutoPostBack = true;
                            myDock.DockMode = DockMode.Docked;
                            myDock.ContentContainer.CssClass = "nexusCore_Editor_Content";

                            // Add Dock Event
                            //myDock.DockPositionChanged += new DockPositionChangedEventHandler(RadDock_DesignMode_DockPositionChanged);

                            // Save New Control to Database
                            e2Data[] UpdateData = {
                                                      new e2Data("Page_LockID", myPage_Loading_Info.Page_LockID),
                                                      new e2Data("PlaceHolderID", myMasterPage_Control.PlaceHolderID),
                                                      new e2Data("ComponentID", myComponent.ComponentID),
                                                      new e2Data("SortOrder", dockCurrentPos.ToString())
                                                  };

                            string Page_ControlID = Add_Page_Lock_Control(UpdateData);

                            myDock.Tag = Page_ControlID;
                            myDock.Title = myComponent.Component_Name + " " + Page_ControlID;

                            // Create Link Buttons
                            HyperLink HLinkbtn_Edit = new HyperLink();
                            HLinkbtn_Edit.ID = "Hlinkbtn_Edit";
                            HLinkbtn_Edit.Attributes["href"] = "#";
                            HLinkbtn_Edit.Attributes["onclick"] = string.Format("return Show_ControlManager('../PoP_ControlManager.aspx?Page_ControlID={0}&EditMode={1}');", Page_ControlID, "PageDesignMode");
                            HLinkbtn_Edit.Text = "Edit";

                            LinkButton Linkbtn_Delete = new LinkButton();
                            Linkbtn_Delete.ID = "Linkbtn_Delete";
                            Linkbtn_Delete.CommandName = "Delete";
                            Linkbtn_Delete.CommandArgument = Page_ControlID;
                            //Linkbtn_Delete.Command += new CommandEventHandler(Linkbtn_Edit_Command);
                            Linkbtn_Delete.Text = "Delete";

                            Nexus.Core.ServerControls.NC_LinkButton[] myLinkButtons = {
                                                new Nexus.Core.ServerControls.NC_LinkButton("/App_Control_Style/NexusCore/Images/Edit.png", HLinkbtn_Edit, typeof(HyperLink)),
                                                new Nexus.Core.ServerControls.NC_LinkButton("/App_Control_Style/NexusCore/Images/Delete.png", Linkbtn_Delete, typeof(LinkButton))
                                            };


                            myDock.TitlebarTemplate = new Nexus.Core.PageEditor.RadDockTemplate(myComponent.Component_Icon, myDock.Title, myLinkButtons);

                            // Complete Control Load and add into dock
                            // Create Control Inner Div
                            HtmlGenericControl myDock_Div = new HtmlGenericControl("Div");
                            myDock_Div.Attributes.Add("class", "inner");

                            myDock_Div.Controls.Add(_control);
                            myDock.ContentContainer.Controls.Add(myDock_Div);

                            return myDock;
                        }
                    }
                }
            }

            return null;
        }

        public void Edit_DesignMode_Control_Position(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info, List<DockState> CurrentDockStates)
        {
            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myPage_Loading_Info.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {
                //List<Page_Lock_Control> Page_Controls = Get_Page_Lock_Controls(myPage_Loading_Info.Page_LockID, myMasterPage_Control.PlaceHolderID);

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myMasterPage_Control.PlaceHolderID);

                // Look for droping DockZone
                RadDockZone myDockZone = (RadDockZone)myContentPlaceHolder.FindControl("DockZone_" + myMasterPage_Control.PlaceHolderID);

                if (myDockZone != null)
                {

                    foreach (DockState myRadDock in CurrentDockStates)
                    {
                        if (!myRadDock.Closed)
                        {
                            if (myRadDock.DockZoneID == myDockZone.ClientID)
                            {
                                e2Data[] UpdateData = {
                                                      new e2Data("Page_ControlID", myRadDock.Tag),
                                                      new e2Data("PlaceHolderID", myMasterPage_Control.PlaceHolderID),
                                                      new e2Data("SortOrder", (myRadDock.Index + 1).ToString())
                                              };

                                Edit_Page_Lock_Control(UpdateData);

                                Thread.Sleep(100);
                            }
                        }
                    }
                }
            }
        }

        // Delete Control From Page
        public void Remove_DesignMode_Control(string Page_ControlID)
        {
            // Remove from Database
            Remove_Page_Lock_Control_Properties(Page_ControlID);
            Remove_Page_Lock_Control(Page_ControlID);
        }

        #endregion

        #region Add

        public string Add_Page_Lock(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Add_Page_Lock(UpdateData);
        }

        public void Add_Page_Lock_Template(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_Lock_Template(UpdateData);
        }

        public void Add_Page_Lock_Attribute(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_Lock_Attribute(UpdateData);
        }

        public string Add_Page_Lock_Control(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Add_Page_Lock_Control(UpdateData);
        }

        public void Add_Page_Lock_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_Lock_Control_Property(UpdateData);
        }

        #endregion

        #region Update

        public void Edit_Page_Lock(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_Lock(UpdateData);

        }

        public void Edit_Page_Lock_Template(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_Lock_Template(UpdateData);
        }

        public void Edit_Page_Lock_Attribute(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_Lock_Attribute(UpdateData);
        }

        public void Edit_Page_Lock_Control(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_Lock_Control(UpdateData);
        }

        public void Edit_Page_Lock_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_Lock_Control_Property(UpdateData);
        }


        #endregion

        #region Delete

        public void Remove_Page_Lock(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Lock(PageIndexID);
        }

        public void Remove_Page_Lock_Templates(string Page_LockID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Lock_Template(Page_LockID);
        }

        public void Remove_Page_Lock_Attribute(string Page_LockID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Lock_Attribute(Page_LockID);
        }

        public void Remove_Page_Lock_Control(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Lock_Control(Page_ControlID);
        }

        public void Remove_Page_Lock_Controls(string Page_LockID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Lock_Controls(Page_LockID);
        }

        public void Remove_Page_Lock_Control_Properties(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Lock_Control_Properties(Page_ControlID);
        }


        #endregion

        #region Page design actions

        public void Set_PageLock(Page myPage, string _pageindexid)
        {
            PageMgr myPageMgr = new PageMgr();

            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            Page_Loading_Info myPage_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(_pageindexid);

            // Lock the Page
            PageIndex myPageIndex = myPageMgr.Get_PageIndex(myPage_Loading_Info.PageIndexID);

            e2Data[] UpdateData_Page_Lock = {
                                                new e2Data("PageIndexID", myPageIndex.PageIndexID),
                                                new e2Data("Parent_PageIndexID", myPageIndex.Parent_PageIndexID),
                                                new e2Data("PageID", myPage_Loading_Info.PageID),
                                                new e2Data("Page_CategoryID", myPageIndex.Page_CategoryID),
                                                new e2Data("Page_Name", myPageIndex.Page_Name),
                                                new e2Data("Page_Type", StringEnum.GetStringValue(myPageIndex.Page_Type)),
                                                new e2Data("UserID", Security.Users.UserStatus.Current_UserID(myPage)),
                                                new e2Data("LockDate", DateTime.Now.ToString()),
                                            };

            string Page_LockID = Add_Page_Lock(UpdateData_Page_Lock);

            System.Threading.Thread.Sleep(100);

            Page_Property myPage_Property = myPropertyMgr.Get_Page_Property(myPageIndex.PageIndexID);

            // Copy Template
            e2Data[] UpdateData_Page_Lock_Template = {
                                                         new e2Data("Page_LockID", Page_LockID),
                                                         new e2Data("MasterPageIndexID", myPage_Loading_Info.MasterPageIndexID),
                                                         new e2Data("IsTemplate_Inherited", DataEval.Convert_BoolToString(myPage_Property.IsTemplate_Inherited)),
                                                         new e2Data("Original_MasterPageIndexID", myPage_Loading_Info.MasterPageIndexID)
                                                     };

            Add_Page_Lock_Template(UpdateData_Page_Lock_Template);

            System.Threading.Thread.Sleep(100);

            // Copy Attribute
            Page_Attribute myPage_Attribute = myPropertyMgr.Get_Page_Attribute(myPage_Loading_Info.PageIndexID);

            e2Data[] UpdateData_Page_Lock_Attribute = {
                                                          new e2Data("Page_LockID", Page_LockID),
                                                          new e2Data("Page_Title", myPage_Attribute.Page_Title),
                                                          new e2Data("Page_Keyword", myPage_Attribute.Page_Keyword),
                                                          new e2Data("Page_Description", myPage_Attribute.Page_Description)
                                                      };
            Add_Page_Lock_Attribute(UpdateData_Page_Lock_Attribute);

            System.Threading.Thread.Sleep(100);

            // Copy Controls and properties
            List<Page_Control> myPage_Controls = myPageMgr.Get_Page_Controls(myPage_Loading_Info.PageID);

            foreach (Page_Control myPage_Control in myPage_Controls)
            {

                e2Data[] UpdateData_Page_Lock_Control = {
                                                             new e2Data("Page_LockID", Page_LockID),
                                                             new e2Data("PlaceHolderID", myPage_Control.PlaceHolderID),
                                                             new e2Data("ComponentID", myPage_Control.ComponentID),
                                                             new e2Data("SortOrder", myPage_Control.SortOrder.ToString())
                                                         };

                string Page_ControlID = Add_Page_Lock_Control(UpdateData_Page_Lock_Control);

                System.Threading.Thread.Sleep(100);

                List<Page_Control_Property> myPage_Control_Properties = myPageMgr.Get_Page_Control_Properties(myPage_Control.Page_ControlID);

                foreach (Page_Control_Property myPage_Control_Property in myPage_Control_Properties)
                {

                    e2Data[] UpdateData_Page_Lock_Property = {
                                                             new e2Data("Page_ControlID", Page_ControlID),
                                                             new e2Data("Property_Name", myPage_Control_Property.Property_Name),
                                                             new e2Data("Property_Value", myPage_Control_Property.Property_Value),
                                                         };

                    Add_Page_Lock_Property(UpdateData_Page_Lock_Property);

                    System.Threading.Thread.Sleep(100);

                }

            }

        }

        // Publish the lockpage to live site
        public void Publish_PageLock(string PageIndexID, bool IsPageActive)
        {

            Pages.Page_Lock myPage_Lock = Get_Page_Lock(PageIndexID);

            List<Page_Lock_Control> myPage_Lock_Controls = Get_Page_Lock_Controls(myPage_Lock.Page_LockID);

            PageMgr myPageMgr = new PageMgr();

            // remove old controls from live page.
            //Release_PageIndex(PageIndexID);

            // Create New Page Version
            string PageID = Tools.IDGenerator.Get_New_GUID_PlainText();
            string NowDate = DateTime.Now.ToString();

            int Page_Version = myPageMgr.Count_Page_Version(PageIndexID) + 1;

            e2Data[] UpdateData_Page = {
                                           new e2Data("PageID", PageID),
                                           new e2Data("PageIndexID", PageIndexID),
                                           new e2Data("Page_Version", Page_Version.ToString()),
                                           new e2Data("Create_Date", NowDate),
                                           new e2Data("LastUpdate_Date", NowDate),
                                           new e2Data("LastUpdate_UserID", myPage_Lock.UserID),
                                           new e2Data("IsActive", IsPageActive.ToString()),
                                           new e2Data("IsDelete", "0")
                                       };

            if (IsPageActive)
                myPageMgr.Reset_Page_Active(PageIndexID);

            myPageMgr.Add_Page(UpdateData_Page);


            // Publish Controls
            foreach (Page_Lock_Control myPage_Lock_Control in myPage_Lock_Controls)
            {
                e2Data[] UpdateData_Control = {
                                                  new e2Data("PageID", PageID),
                                                  new e2Data("PlaceHolderID", myPage_Lock_Control.PlaceHolderID),
                                                  new e2Data("ComponentID", myPage_Lock_Control.ComponentID),
                                                  new e2Data("SortOrder", myPage_Lock_Control.SortOrder.ToString())
                                              };

                string Page_ControlID = myPageMgr.Add_Page_Control(UpdateData_Control);

                Thread.Sleep(100);

                List<Page_Lock_Control_Property> myPage_Lock_Control_Properties = Get_Page_Lock_Control_Properties(myPage_Lock_Control.Page_ControlID);

                foreach (Page_Lock_Control_Property myPage_Lock_Control_Property in myPage_Lock_Control_Properties)
                {
                    e2Data[] UpdateData_Property = {
                                                       new e2Data("Page_ControlID", Page_ControlID),
                                                       new e2Data("Property_Name", myPage_Lock_Control_Property.Property_Name),
                                                       new e2Data("Property_Value", myPage_Lock_Control_Property.Property_Value)
                                                   };

                    myPageMgr.Add_Page_Property(UpdateData_Property);

                    Thread.Sleep(100);
                }
            }


            // Check Template
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();
            Page_Property myPage_Property = myPropertyMgr.Get_Page_Property(PageIndexID);

            Page_Lock_Template myPage_Lock_Template = Get_Page_Lock_Template(myPage_Lock.Page_LockID);

            if (myPage_Lock_Template.IsTemplate_Inherited)
            {
                // Switch Template to Inherited Mode
                if (myPropertyMgr.Chk_Page_Template(PageIndexID))
                {
                    myPropertyMgr.Remove_Page_Template(PageIndexID);
                }
            }
            else
            {
                // Add or Edit if Inherited is Off
                e2Data[] UpdateData_Template = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("MasterPageIndexID", myPage_Lock_Template.MasterPageIndexID) // Get from Select Template list
                                  };

                if (myPropertyMgr.Chk_Page_Template(PageIndexID))
                {
                    myPropertyMgr.Edit_Page_Template(UpdateData_Template);
                }
                else
                {
                    myPropertyMgr.Add_Page_Template(UpdateData_Template);
                }
            }

            Thread.Sleep(100);

            // Update Tempalte Inherited
            e2Data[] UpdateData_PageProps = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("IsTemplate_Inherited", DataEval.Convert_BoolToString(myPage_Lock_Template.IsTemplate_Inherited))
                                  };

            myPropertyMgr.Edit_Page_Property(UpdateData_PageProps);

        }

        // Cancel Lock page back to site
        //public void Release_PageIndex(string PageIndexID)
        //{
        //    PageMgr myPageMgr = new PageMgr();

        //    PageIndex myPageIndex = myPageMgr.Get_PageIndex(PageIndexID);

        //    List<Page_Control> myPage_Controls = myPageMgr.Get_Page_Controls(PageIndexID);

        //    foreach (Page_Control myPage_Control in myPage_Controls)
        //    {
        //        myPageMgr.Remove_Page_Control_Properties(myPage_Control.Page_ControlID);
        //    }

        //    myPageMgr.Remove_Page_Controls(PageIndexID);

        //}

        public void Release_PageLock(string PageIndexID)
        {

            Pages.Page_Lock myPage_Lock = Get_Page_Lock(PageIndexID);

            List<Page_Lock_Control> myPage_Lock_Controls = Get_Page_Lock_Controls(myPage_Lock.Page_LockID);

            foreach (Page_Lock_Control myPage_Lock_Control in myPage_Lock_Controls)
            {
                Remove_Page_Lock_Control_Properties(myPage_Lock_Control.Page_ControlID);
            }

            Remove_Page_Lock_Controls(myPage_Lock.Page_LockID);
            Remove_Page_Lock_Templates(myPage_Lock.Page_LockID);
            Remove_Page_Lock_Attribute(myPage_Lock.Page_LockID);
            Remove_Page_Lock(PageIndexID);

        }

        #endregion

    }

    public class Page_PropertyMgr
    {
        public Page_PropertyMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region Get

        public Page_Property Get_Page_Property (string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Property(myDP.Get_Page_Property(PageIndexID));
        }

        public Page_Template Get_Page_Template (string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Template(myDP.Get_Page_Template(PageIndexID));
        }

        public Page_ExtLink Get_Page_ExtLink (string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_ExtLink(myDP.Get_Page_ExtLink(PageIndexID));
        }

        public Page_IntLink Get_Page_IntLink (string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_IntLink(myDP.Get_Page_IntLink(PageIndexID));
        }

        public Page_Attribute Get_Page_Attribute (string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Attribute(myDP.Get_Page_Attribute(PageIndexID));
        }

        public bool Chk_Page_Template(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Page_Template(PageIndexID);
        }

        public bool Chk_Page_ExtLink(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Page_ExtLink(PageIndexID);
        }

        public bool Chk_Page_IntLink(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Page_IntLink(PageIndexID);
        }

        public bool Chk_Page_Attribute(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Page_Attribute(PageIndexID);
        }


        #endregion

        #region Add

        public void Add_Page_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_Property(UpdateData);
        }

        public void Add_Page_Template(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_Template(UpdateData);
        }

        public void Add_Page_ExtLink(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_ExtLink(UpdateData);
        }

        public void Add_Page_IntLink(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_IntLink(UpdateData);
        }

        public void Add_Page_Attribute(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_Attribute(UpdateData);
        }

        #endregion

        #region Update

        public void Edit_Page_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_Property(UpdateData);
        }

        public void Edit_Page_Template(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_Template(UpdateData);
        }

        public void Edit_Page_ExtLink(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_ExtLink(UpdateData);
        }

        public void Edit_Page_IntLink(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_IntLink(UpdateData);
        }

        public void Edit_Page_Attribute(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_Attribute(UpdateData);
        }

        

        #endregion

        #region Delete

        public void Remove_Page_Property(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Property(PageIndexID);
        }

        public void Remove_Page_Template(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Template(PageIndexID);
        }

        public void Remove_Page_ExtLink(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_ExtLink(PageIndexID);
        }

        public void Remove_Page_IntLink(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_IntLink(PageIndexID);
        }

        public void Remove_Page_Attribute(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Attribute(PageIndexID);
        }

        #endregion

        public Page_Loading_Info Get_Page_Loading_Info(string PageIndexID)
        {
            Page_Loading_Info myPageInfo = new Page_Loading_Info();

            // Get PageIndex
            Pages.PageMgr myPageMgr = new PageMgr();
            Pages.PageIndex myPageIndex = myPageMgr.Get_PageIndex(PageIndexID);
            myPageInfo.PageIndexID = PageIndexID;
            myPageInfo.Parent_PageIndexID = myPageIndex.Parent_PageIndexID;

            // Get PageID
            NexusCore_Page myPage = myPageMgr.Get_Page_ActiveID(PageIndexID);
            myPageInfo.PageID = myPage.PageID;

            // Get MasterPageURL and Theme
            Nexus.Core.Templates.MasterPageMgr myMasterPageMgr = new Nexus.Core.Templates.MasterPageMgr();
            Nexus.Core.Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();
            Nexus.Core.Templates.ThemeMgr myThemeMgr = new Nexus.Core.Templates.ThemeMgr();

            Templates.MasterPageIndex myMasterPageIndex = myMasterPageMgr.Get_MasterPageIndex(Get_Inherited_TemplateID(PageIndexID));
            Templates.Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(myMasterPageIndex.Template_MasterPageID);

            myPageInfo.MasterPageIndexID = myMasterPageIndex.MasterPageIndexID;
            myPageInfo.Template_MasterPageID = myMasterPageIndex.Template_MasterPageID;
            myPageInfo.MasterPage_URL = myTemplate_MasterPage.MasterPage_URL;
            myPageInfo.Theme = myThemeMgr.Get_Theme(myMasterPageIndex.ThemeID).Theme_Code;

            // Get MastPageID
            Templates.NexusCore_MasterPage myMasterPage = myMasterPageMgr.Get_MasterPage_ActiveID(myMasterPageIndex.MasterPageIndexID);
            myPageInfo.MasterPageID = myMasterPage.MasterPageID;

            // Get Page Attribute
            Page_Attribute myAttribute = Get_Page_Attribute(Get_Inherited_AttributeID(PageIndexID));

            myPageInfo.Page_Title = myAttribute.Page_Title;
            myPageInfo.Page_Keyword = myAttribute.Page_Keyword;
            myPageInfo.Page_Description = myAttribute.Page_Description;

            return myPageInfo;
        }

        public Page_Loading_Info Get_MasterPage_Loading_Info(string MasterPageIndexID)
        {
            Page_Loading_Info myPageInfo = new Page_Loading_Info();

            // Get MasterPageURL and Theme
            Nexus.Core.Templates.MasterPageMgr myMasterPageMgr = new Nexus.Core.Templates.MasterPageMgr();
            Nexus.Core.Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();
            Nexus.Core.Templates.ThemeMgr myThemeMgr = new Nexus.Core.Templates.ThemeMgr();

            Templates.MasterPageIndex myMasterPageIndex = myMasterPageMgr.Get_MasterPageIndex(MasterPageIndexID);
            Templates.Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(myMasterPageIndex.Template_MasterPageID);

            myPageInfo.MasterPageIndexID = myMasterPageIndex.MasterPageIndexID;
            myPageInfo.Template_MasterPageID = myMasterPageIndex.Template_MasterPageID;
            myPageInfo.MasterPage_URL = myTemplate_MasterPage.MasterPage_URL;
            myPageInfo.Theme = myThemeMgr.Get_Theme(myMasterPageIndex.ThemeID).Theme_Code;

            // Get MastPageID
            Templates.NexusCore_MasterPage myMasterPage = myMasterPageMgr.Get_MasterPage_ActiveID(myMasterPageIndex.MasterPageIndexID);
            myPageInfo.MasterPageID = myMasterPage.MasterPageID;

            return myPageInfo;
        }

        public Page_Loading_Info Get_Page_Lock_Loading_Info(string PageIndexID)
        {
            Page_Loading_Info myPageInfo = new Page_Loading_Info();

            myPageInfo.PageIndexID = PageIndexID;

            // Page Lock Info
            PageEditorMgr myPageEditorMgr = new PageEditorMgr();
            Page_Lock myPage_Lock = myPageEditorMgr.Get_Page_Lock(PageIndexID);

            myPageInfo.Page_LockID = myPage_Lock.Page_LockID;
            myPageInfo.Parent_PageIndexID = myPage_Lock.Parent_PageIndexID;
            myPageInfo.PageID = myPage_Lock.PageID;

            // Page Lock Template Info
            Page_Lock_Template myTemplate = myPageEditorMgr.Get_Page_Lock_Template(myPage_Lock.Page_LockID);


            // Get MasterPageURL and Theme
            Nexus.Core.Templates.MasterPageMgr myMasterPageMgr = new Nexus.Core.Templates.MasterPageMgr();
            Nexus.Core.Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();
            Nexus.Core.Templates.ThemeMgr myThemeMgr = new Nexus.Core.Templates.ThemeMgr();

            Templates.MasterPageIndex myMasterPageIndex = myMasterPageMgr.Get_MasterPageIndex(myTemplate.MasterPageIndexID);
            Templates.Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(myMasterPageIndex.Template_MasterPageID);

            myPageInfo.MasterPageIndexID = myMasterPageIndex.MasterPageIndexID;
            myPageInfo.Template_MasterPageID = myMasterPageIndex.Template_MasterPageID;
            myPageInfo.MasterPage_URL = myTemplate_MasterPage.MasterPage_URL;
            myPageInfo.Theme = myThemeMgr.Get_Theme(myMasterPageIndex.ThemeID).Theme_Code;

            // Get MastPageID
            Templates.NexusCore_MasterPage myMasterPage = myMasterPageMgr.Get_MasterPage_ActiveID(myMasterPageIndex.MasterPageIndexID);
            myPageInfo.MasterPageID = myMasterPage.MasterPageID;

            // Get Page Attribute
            Page_Lock_Attribute myPage_Lock_Attribute = myPageEditorMgr.Get_Page_Lock_Attribute(myPage_Lock.Page_LockID);

            myPageInfo.Page_Title = myPage_Lock_Attribute.Page_Title;
            myPageInfo.Page_Keyword = myPage_Lock_Attribute.Page_Keyword;
            myPageInfo.Page_Description = myPage_Lock_Attribute.Page_Description;

            return myPageInfo;
        }

        private string Get_Inherited_TemplateID(string PageIndexID)
        {
            Page_Property myProperty = Get_Page_Property(PageIndexID);

            if (myProperty.IsTemplate_Inherited)
            {
                PageMgr myPageMgr = new PageMgr();

                PageIndex myIndex = myPageMgr.Get_PageIndex(PageIndexID);

                return Get_Inherited_TemplateID(myIndex.Parent_PageIndexID);

                //if (myIndex.Parent_PageIndexID != "-1")
                //{
                //}
                //else
                //{
                //    throw new Exception(string.Format("Invalid Parent PageID for Template, {0}", myIndex.Parent_PageIndexID));
                //}
            }
            else
            {
                Page_Template myTemplate = Get_Page_Template(PageIndexID);
                return myTemplate.MasterPageIndexID;
            }
        }

        private string Get_Inherited_AttributeID(string PageIndexID)
        {
            Page_Property myProperty = Get_Page_Property(PageIndexID);

            if (myProperty.IsAttribute_Inherited)
            {
                PageMgr myPageMgr = new PageMgr();

                PageIndex myIndex = myPageMgr.Get_PageIndex(PageIndexID);

                return Get_Inherited_AttributeID(myIndex.Parent_PageIndexID);
                //if (myIndex.Parent_PageIndexID != "-1")
                //{
                //}
                //else
                //{
                //    throw new Exception(string.Format("Invalid Parent PageID for Atrribute, {0}", myIndex.Parent_PageIndexID));
                //}
            }
            else
            {
                return PageIndexID;
            }

        }

    }
}
