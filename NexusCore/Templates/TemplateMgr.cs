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
using Nexus.Core.Pages;

namespace Nexus.Core.Templates
{

    [DataObject(true)]
    public class TemplateMgr
    {

        public TemplateMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public Template Get_Template(string TemplateID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Template(myDP.Get_Template(TemplateID));
        }

        public List<Template> Get_Templates(string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Templates(SortOrder);

            List<Template> list = new List<Template>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Template(myDR));
            }

            return list;

        }

        public static List<Template> sGet_Templates(string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Templates(SortOrder);

            List<Template> list = new List<Template>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Template(myDR));
            }

            return list;

        }

        public static List<Template_List> sGet_Template_List(string TemplateID, string ThemeID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Template_List(TemplateID, ThemeID, SortOrder);

            List<Template_List> list = new List<Template_List>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Template_List(myDR));
            }

            return list;

        }

        public Template_MasterPage Get_Template_MasterPage(string Template_MasterPageID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Template_MasterPage(myDP.Get_Template_MasterPage(Template_MasterPageID));
        }

        public List<Template_MasterPage> Get_Template_MasterPages (string TemplateID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Template_MasterPages(TemplateID, SortOrder);

            List<Template_MasterPage> list = new List<Template_MasterPage>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Template_MasterPage(myDR));
            }

            return list;

        }

        public static List<Template_MasterPage> sGet_Template_MasterPages(string TemplateID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Template_MasterPages(TemplateID, SortOrder);

            List<Template_MasterPage> list = new List<Template_MasterPage>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Template_MasterPage(myDR));
            }

            return list;

        }

        public Template_MasterPage_Control Get_Template_MasterPage_Control(string ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Template_MasterPage_Control(myDP.Get_Template_MasterPage_Control(ControlID));
        }

        public List<Template_MasterPage_Control> Get_Template_MasterPage_Controls(string Template_MasterPageID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Template_MasterPage_Controls(Template_MasterPageID, SortOrder);

            List<Template_MasterPage_Control> list = new List<Template_MasterPage_Control>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Template_MasterPage_Control(myDR));
            }

            return list;

        }

    }

    [DataObject(true)]
    public class MasterPageMgr
    {

        public MasterPageMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region MetaTags

        public List<MetaTag> Get_MasterPage_MetaTags(string MasterPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_MasterPage_MetaTags(MasterPageIndexID);

            List<MetaTag> list = new List<MetaTag>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new MetaTag(myDR));
            }

            return list;

        }

        public List<MetaTag> Get_MasterPage_MetaTags(string MasterPageIndexID, Meta_Type myMeta_Type)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_MasterPage_MetaTags(MasterPageIndexID, StringEnum.GetStringValue(myMeta_Type));

            List<MetaTag> list = new List<MetaTag>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new MetaTag(myDR));
            }

            return list;

        }

        public MetaTag Get_MasterPage_MetaTag(string MetaTagID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new MetaTag(myDP.Get_MasterPage_MetaTag(MetaTagID));
        }

        public void Add_MasterPage_MetaTag(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_MasterPage_MetaTag(UpdateData);
        }

        public void Edit_MasterPage_MetaTag(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_MasterPage_MetaTag(UpdateData);

        }

        public void Remove_MasterPage_MetaTag(string MetaTagID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_MasterPage_MetaTag(MetaTagID);
        }

        #endregion

        #region Get and Check

        public static List<Template_MasterPage_List> sGet_Template_MasterPage_DropList(string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Template_MasterPage_DropList(SortOrder);

            List<Template_MasterPage_List> list = new List<Template_MasterPage_List>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Template_MasterPage_List(myDR, 0));
            }

            return list;

        }

        public List<Template_MasterPage_List> Get_Template_MasterPage_DropList(string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Template_MasterPage_DropList(SortOrder);

            List<Template_MasterPage_List> list = new List<Template_MasterPage_List>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Template_MasterPage_List(myDR, 0));
            }

            return list;

        }


        public static List<Template_MasterPage_List> sGet_Template_MasterPage_List(string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Template_MasterPage_List(SortOrder);

            List<Template_MasterPage_List> list = new List<Template_MasterPage_List>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Template_MasterPage_List(myDR));
            }

            return list;

        }

        public MasterPageIndex Get_MasterPageIndex(string MasterPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new MasterPageIndex(myDP.Get_MasterPageIndex(MasterPageIndexID));
        }

        public List<NexusCore_MasterPage> Get_MasterPages(string MasterPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_MasterPages(MasterPageIndexID);

            List<NexusCore_MasterPage> list = new List<NexusCore_MasterPage>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new NexusCore_MasterPage(myDR));
            }

            return list;
        }

        public NexusCore_MasterPage Get_MasterPage(string MasterPageID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new NexusCore_MasterPage(myDP.Get_MasterPage(MasterPageID));
        }

        public NexusCore_MasterPage Get_MasterPage_ActiveID(string MasterPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new NexusCore_MasterPage(myDP.Get_MasterPage_ActiveID(MasterPageIndexID));
        }

        public MasterPage_Control Get_MasterPage_Control(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new MasterPage_Control(myDP.Get_MasterPage_Control(Page_ControlID));
        }

        public List<MasterPage_Control> Get_MasterPage_Controls(string MasterPageID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_MasterPage_Controls(MasterPageID);

            List<MasterPage_Control> list = new List<MasterPage_Control>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new MasterPage_Control(myDR));
            }

            return list;

        }

        public List<MasterPage_Control> Get_MasterPage_Controls(string MasterPageID, string PlaceHolderID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_MasterPage_Controls(MasterPageID, PlaceHolderID);

            List<MasterPage_Control> list = new List<MasterPage_Control>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new MasterPage_Control(myDR));
            }

            return list;

        }

        public List<MasterPage_Control_Property> Get_MasterPage_Control_Properties(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_MasterPage_Control_Properties(Page_ControlID);

            List<MasterPage_Control_Property> list = new List<MasterPage_Control_Property>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new MasterPage_Control_Property(myDR));
            }

            return list;

        }

        public int Count_MasterPage_Version(string MasterPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Count_MasterPage_Version(MasterPageIndexID);

        }


        #endregion

        #region OnPage realtime loading controls

        public void Load_MasterPageControls_WebView(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info)
        {

            //MasterPageIndex myMasterPageIndex = Get_MasterPageIndex(MasterPageIndexID);

            TemplateMgr myTemplateMgr = new TemplateMgr();

            List<Templates.Template_MasterPage_Control> myTemplate_MasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myPage_Loading_Info.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myTemplate_MasterPage_Control in myTemplate_MasterPage_Controls)
            {

                List<MasterPage_Control> MasterPage_Controls = Get_MasterPage_Controls(myPage_Loading_Info.MasterPageID, myTemplate_MasterPage_Control.PlaceHolderID);

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myTemplate_MasterPage_Control.PlaceHolderID);

                foreach (MasterPage_Control MasterPage_Control in MasterPage_Controls)
                {

                    if (myContentPlaceHolder != null)
                    {

                        Nexus.Core.Modules.ModuleMgr myModuleMgr = new Nexus.Core.Modules.ModuleMgr();
                        Modules.Component myComponent = myModuleMgr.Get_Component(MasterPage_Control.ComponentID);
                        Modules.Component_Control myControl = myModuleMgr.Get_Control(MasterPage_Control.ComponentID, Modules.Control_Type.WebView);

                        if (myControl != null)
                        {
                            Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                            Type _control_type = assembly.GetType(myControl.Class_Name);
                            Control _control = myPage.LoadControl(_control_type, null);

                            List<MasterPage_Control_Property> Control_Properties = Get_MasterPage_Control_Properties(MasterPage_Control.Page_ControlID);

                            foreach (MasterPage_Control_Property Control_Property in Control_Properties)
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

                            myContentPlaceHolder.Controls.Add(_control);

                        }
                        else
                        {
                            throw new Exception(string.Format("Invalid MasterPageControl.Webview ComponentID: {0}", MasterPage_Control.ComponentID));
                        }
                    }
                }

            }
        }

        public void Load_MasterPageControls_WebView(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info, bool IsEditMode)
        {

            //MasterPageIndex myMasterPageIndex = Get_MasterPageIndex(myPage_Loading_Info.MasterPageIndexID);

            TemplateMgr myTemplateMgr = new TemplateMgr();

            List<Templates.Template_MasterPage_Control> myTemplate_MasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myPage_Loading_Info.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myTemplate_MasterPage_Control in myTemplate_MasterPage_Controls)
            {

                List<MasterPage_Control> MasterPage_Controls = Get_MasterPage_Controls(myPage_Loading_Info.MasterPageID, myTemplate_MasterPage_Control.PlaceHolderID);

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myTemplate_MasterPage_Control.PlaceHolderID);

                foreach (MasterPage_Control MasterPage_Control in MasterPage_Controls)
                {

                    if (myContentPlaceHolder != null)
                    {

                        Nexus.Core.Modules.ModuleMgr myModuleMgr = new Nexus.Core.Modules.ModuleMgr();
                        Modules.Component myComponent = myModuleMgr.Get_Component(MasterPage_Control.ComponentID);
                        Modules.Component_Control myControl = myModuleMgr.Get_Control(MasterPage_Control.ComponentID, Modules.Control_Type.WebView);

                        if (myControl != null)
                        {
                            Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                            Type _control_type = assembly.GetType(myControl.Class_Name);
                            Control _control = myPage.LoadControl(_control_type, null);

                            List<MasterPage_Control_Property> Control_Properties = Get_MasterPage_Control_Properties(MasterPage_Control.Page_ControlID);

                            foreach (MasterPage_Control_Property Control_Property in Control_Properties)
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

                            if (IsEditMode)
                            {
                                // Add Edit button to page
                                myContentPlaceHolder.Controls.Add(Core.ServerControls.ToolBars.LivePage_ToolBar(
                                    myComponent.Component_Icon,
                                    myComponent.Component_Name,
                                     MasterPage_Control.Page_ControlID,
                                    "TemplateAdvancedMode"));
                            }


                            myContentPlaceHolder.Controls.Add(_control);

                        }
                        else
                        {
                            throw new Exception(string.Format("Invalid MasterPageControl.Webview ComponentID: {0}", MasterPage_Control.ComponentID));
                        }
                    }
                }

            }
        }

        public void Load_MasterPageControls_Advanced(System.Web.UI.Page myPage, Pages.Page_Loading_Info myPage_Loading_Info)
        {

            //MasterPageIndex myMasterPageIndex = Get_MasterPageIndex(MasterPageIndexID);

            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myTemplate_MasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myPage_Loading_Info.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myTemplate_MasterPage_Control in myTemplate_MasterPage_Controls)
            {
                List<MasterPage_Control> MasterPage_Controls = Get_MasterPage_Controls(myPage_Loading_Info.MasterPageID, myTemplate_MasterPage_Control.PlaceHolderID);

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myTemplate_MasterPage_Control.PlaceHolderID);

                // Create DockLayOut
                RadDockLayout myDockLayout = new RadDockLayout();
                myDockLayout.ID = "MasterDockLayout_" + myTemplate_MasterPage_Control.PlaceHolderID;


                // Create DockZone
                RadDockZone myDockZone = new RadDockZone();
                myDockZone.ID = "MasterDockZone_" + myTemplate_MasterPage_Control.PlaceHolderID;
                myDockZone.ToolTip = myTemplate_MasterPage_Control.PlaceHolderID;
                myDockZone.BorderStyle = BorderStyle.Dotted;

                if (myTemplate_MasterPage_Control.MinWidth < 250)
                {
                    myDockZone.MinWidth = 250;
                }
                else
                {
                    myDockZone.MinWidth = myTemplate_MasterPage_Control.MinWidth;
                }

                myDockZone.MinHeight = myTemplate_MasterPage_Control.MinHeight;

                if (myTemplate_MasterPage_Control.Orientation == Nexus.Core.Templates.DockZone_Orientation.Vertical)
                {
                    myDockZone.Orientation = Orientation.Vertical;
                }
                else
                {
                    myDockZone.Orientation = Orientation.Horizontal;
                }

                myDockLayout.Controls.Add(myDockZone);

                // Create Controls
                foreach (MasterPage_Control MasterPage_Control in MasterPage_Controls)
                {

                    if (myContentPlaceHolder != null)
                    {

                        Nexus.Core.Modules.ModuleMgr myModuleMgr = new Nexus.Core.Modules.ModuleMgr();
                        Modules.Component myComponent = myModuleMgr.Get_Component(MasterPage_Control.ComponentID);
                        Modules.Component_Control myControl = myModuleMgr.Get_Control(MasterPage_Control.ComponentID, Modules.Control_Type.Advanced);

                        if (myControl != null)
                        {
                            Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                            Type _control_type = assembly.GetType(myControl.Class_Name);
                            Control _control = myPage.LoadControl(_control_type, null);

                            List<MasterPage_Control_Property> Control_Properties = Get_MasterPage_Control_Properties(MasterPage_Control.Page_ControlID);

                            foreach (MasterPage_Control_Property Control_Property in Control_Properties)
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

                            // Create Dock
                            RadDock myDock = new RadDock();
                            myDock.Title = myComponent.Component_Name;
                            myDock.DefaultCommands = Telerik.Web.UI.Dock.DefaultCommands.None;
                            myDock.ID = string.Format("MasterDock_{0}", Tools.IDGenerator.Get_New_GUID().Replace('-', 'a'));
                            myDock.EnableDrag = false;
                            myDock.DockMode = DockMode.Docked;
                            myDock.ContentContainer.CssClass = "nexusCore_Editor_Content";

                            // Dock Command
                            // Create Link Buttons
                            HyperLink HLinkbtn_Edit = new HyperLink();
                            HLinkbtn_Edit.ID = "Hlinkbtn_Edit";
                            HLinkbtn_Edit.Attributes["href"] = "#";
                            HLinkbtn_Edit.Attributes["onclick"] = string.Format("return Show_ControlManager('../PoP_ControlManager.aspx?Page_ControlID={0}&EditMode={1}');", MasterPage_Control.Page_ControlID, "TemplateAdvancedMode");
                            HLinkbtn_Edit.Text = "Edit";

                            Nexus.Core.ServerControls.NC_LinkButton[] myLinkButtons = {
                                                new Nexus.Core.ServerControls.NC_LinkButton("/App_Control_Style/NexusCore/Images/Edit.png", HLinkbtn_Edit, typeof(HyperLink))
                                            };


                            myDock.TitlebarTemplate = new Nexus.Core.PageEditor.RadDockTemplate(myComponent.Component_Icon, myDock.Title, myLinkButtons);

                            // Create Control Inner Div
                            HtmlGenericControl myDock_Div = new HtmlGenericControl("Div");
                            myDock_Div.Attributes.Add("class", "inner");

                            myDock_Div.Controls.Add(_control);
                            myDock.ContentContainer.Controls.Add(myDock_Div);
                            
                            myDockZone.Controls.Add(myDock);


                        }
                        else
                        {
                            throw new Exception(string.Format("Invalid MasterPageControl.Webview ComponentID: {0}", MasterPage_Control.ComponentID));
                        }
                    }
                }

                // Place All controls
                myContentPlaceHolder.Controls.Add(myDockLayout);
            }
        }

        #endregion

        #region Duplicate Masterpage

        public void Duplicate_MasterPageIndex(string Original_MasterPageIndexID, string UserID)
        {

            MasterPageMgr myMasterPageMgr = new MasterPageMgr();
            MasterPageIndex Original_MasterPageIndex = Get_MasterPageIndex(Original_MasterPageIndexID);

            string MasterPage_Name = "Copy of " + Original_MasterPageIndex.MasterPage_Name;

            // Create New Master Page

            // Master Index
            string MasterPageIndexID = Tools.IDGenerator.Get_New_GUID_PlainText();

            // MasterPage Index
            e2Data[] UpdateData = {
                                          new e2Data("MasterPageIndexID", MasterPageIndexID),
                                          new e2Data("MasterPage_Name", MasterPage_Name),
                                          new e2Data("TemplateID", Original_MasterPageIndex.TemplateID),
                                          new e2Data("Template_MasterPageID", Original_MasterPageIndex.Template_MasterPageID),
                                          new e2Data("ThemeID", Original_MasterPageIndex.ThemeID),
                                          new e2Data("MasterPage_Description", Original_MasterPageIndex.MasterPage_Description)
                                      };

            myMasterPageMgr.Add_MasterPageIndex(UpdateData);

            // MasterPage MetaTags
            List<MetaTag> myMetaTags = myMasterPageMgr.Get_MasterPage_MetaTags(Original_MasterPageIndexID);

            foreach (MetaTag myMetaTag in myMetaTags)
            {
                e2Data[] UpdateData_MetaTag = {
                                                  new e2Data("MasterPageIndexID", MasterPageIndexID),
                                                  new e2Data("Meta_Type", StringEnum.GetStringValue(myMetaTag.Meta_Type)),
                                                  new e2Data("Meta_Src", myMetaTag.Meta_Src)
                                                  };

                myMasterPageMgr.Add_MasterPage_MetaTag(UpdateData_MetaTag);

            }

            // MasterPage Version
            string MasterPageID = Tools.IDGenerator.Get_New_GUID_PlainText();
            string NowDate = DateTime.Now.ToString();

            e2Data[] UpdateData_MasterPage = {
                                                     new e2Data("MasterPageID", MasterPageID),
                                                     new e2Data("MasterPageIndexID", MasterPageIndexID),
                                                     new e2Data("MasterPage_Version", "1"),
                                                     new e2Data("Create_Date", NowDate),
                                                     new e2Data("LastUpdate_Date", NowDate),
                                                     new e2Data("LastUpdate_UserID", UserID),
                                                     new e2Data("IsActive", "1"),
                                                     new e2Data("IsDelete", "0")
                                                  };

            myMasterPageMgr.Add_MasterPage(UpdateData_MasterPage);

            Duplicate_Controls(Original_MasterPageIndexID, MasterPageID);

        }

        private void Duplicate_Controls(string Original_MasterPageIndexID, string MasterPageID)
        {

            // Copy Controls and properties
            NexusCore_MasterPage myMasterPage = Get_MasterPage_ActiveID(Original_MasterPageIndexID);

            List<MasterPage_Control> myMasterPage_Controls = Get_MasterPage_Controls(myMasterPage.MasterPageID);

            foreach (MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {

                e2Data[] UpdateData_MasterPage_Control = {
                                                       new e2Data("MasterPageID", MasterPageID),
                                                       new e2Data("PlaceHolderID", myMasterPage_Control.PlaceHolderID),
                                                       new e2Data("ComponentID", myMasterPage_Control.ComponentID),
                                                       new e2Data("SortOrder", myMasterPage_Control.SortOrder.ToString())
                                                   };

                string MasterPage_ControlID = Add_MasterPage_Control(UpdateData_MasterPage_Control);

                System.Threading.Thread.Sleep(100);

                List<MasterPage_Control_Property> myMasterPage_Control_Properties = Get_MasterPage_Control_Properties(myMasterPage_Control.Page_ControlID);

                foreach (MasterPage_Control_Property myMasterPage_Control_Property in myMasterPage_Control_Properties)
                {

                    e2Data[] UpdateData_MasterPage_Property = {
                                                             new e2Data("Page_ControlID", MasterPage_ControlID),
                                                             new e2Data("Property_Name", myMasterPage_Control_Property.Property_Name),
                                                             new e2Data("Property_Value", myMasterPage_Control_Property.Property_Value),
                                                         };

                    Add_MasterPage_Property(UpdateData_MasterPage_Property);

                    System.Threading.Thread.Sleep(100);

                }

            }

        }

        #endregion

        #region Delete Masterpage

        #endregion

        #region Add

        public void Add_MasterPageIndex(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_MasterPageIndex(UpdateData);
        }

        public void Add_MasterPage(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_MasterPage(UpdateData);
        }

        public string Add_MasterPage_Control(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Add_MasterPage_Control(UpdateData);
        }

        public void Add_MasterPage_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_MasterPage_Control_Property(UpdateData);
        }

        #endregion

        #region Update

        public void Edit_MasterPageIndex(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_MasterPageIndex(UpdateData);

        }

        public void Edit_MasterPage(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_MasterPage(UpdateData);

        }

        public void Reset_MasterPage_Active(string MasterPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Reset_MasterPage_Active(MasterPageIndexID);

        }

        public void Edit_MasterPage_Control(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_MasterPage_Control(UpdateData);
        }

        public void Edit_MasterPage_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_MasterPage_Control_Property(UpdateData);
        }


        #endregion

        #region Delete

        public void Remove_MasterPageIndex(string MasterPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_MasterPageIndex(MasterPageIndexID);
        }

        public void Remove_MasterPage(string MasterPageID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_MasterPage(MasterPageID);
        }

        public void Remove_MasterPages(string MasterPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_MasterPages(MasterPageIndexID);
        }

        public void Remove_MasterPage_Controls(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_MasterPage_Controls(PageIndexID);
        }

        public void Remove_MasterPage_Control_Properties(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_MasterPage_Control_Properties(Page_ControlID);
        }


        #endregion

    }

    public class MasterPageEditorMgr
    {

        public MasterPageEditorMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public MasterPage_Lock Get_MasterPage_Lock(string MasterPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new MasterPage_Lock(myDP.Get_MasterPage_Lock(MasterPageIndexID));
        }

        public bool Chk_MasterPage_Lock(string MasterPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_MasterPage_Lock(MasterPageIndexID);
        }

        public MasterPage_Lock_Control Get_MasterPage_Lock_Control(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new MasterPage_Lock_Control(myDP.Get_MasterPage_Lock_Control(Page_ControlID));
        }

        public List<MasterPage_Lock_Control> Get_MasterPage_Lock_Controls(string MasterPage_LockID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_MasterPage_Lock_Controls(MasterPage_LockID);

            List<MasterPage_Lock_Control> list = new List<MasterPage_Lock_Control>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new MasterPage_Lock_Control(myDR));
            }

            return list;

        }

        public List<MasterPage_Lock_Control> Get_MasterPage_Lock_Controls(string MasterPage_LockID, string PlaceHolderID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_MasterPage_Lock_Controls(MasterPage_LockID, PlaceHolderID);

            List<MasterPage_Lock_Control> list = new List<MasterPage_Lock_Control>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new MasterPage_Lock_Control(myDR));
            }

            return list;

        }

        public List<MasterPage_Lock_Control_Property> Get_MasterPage_Lock_Control_Properties(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_MasterPage_Lock_Control_Properties(Page_ControlID);

            List<MasterPage_Lock_Control_Property> list = new List<MasterPage_Lock_Control_Property>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new MasterPage_Lock_Control_Property(myDR));
            }

            return list;

        }

        #region On Page realtime loading controls

        // Load Page Layout
        public void Load_MasterPageDocks_Design(System.Web.UI.Page myPage, MasterPage_Lock myMasterPage_Lock)
        {

            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myMasterPage_Lock.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myMasterPage_Control.PlaceHolderID);

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
                myContentPlaceHolder.Controls.Add(myDockZone);

            }

        }

        // Read Layout data to DockState
        public List<DockState> Load_MasterPageControls_StateList(System.Web.UI.Page myPage, MasterPage_Lock myMasterPage_Lock, RadDockLayout myDockLayout)
        {

            List<DockState> myDockStates = new List<DockState>();

            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myMasterPage_Lock.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {

                List<MasterPage_Lock_Control> myPage_Controls = Get_MasterPage_Lock_Controls(myMasterPage_Lock.MasterPage_LockID, myMasterPage_Control.PlaceHolderID);

                ContentPlaceHolder myContentPlaceHolder = (ContentPlaceHolder)myPage.Master.FindControl(myMasterPage_Control.PlaceHolderID);

                // Look for droping DockZone
                RadDockZone myDockZone = (RadDockZone)myContentPlaceHolder.FindControl("DockZone_" + myMasterPage_Control.PlaceHolderID);

                // Create Controls
                foreach (MasterPage_Lock_Control myPage_Control in myPage_Controls)
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
        public RadDock Load_MasterPageControls_FromState(System.Web.UI.Page myPage, MasterPage_Lock myMasterPage_Lock, DockState state)
        {
            if (state.Tag != null)
            {
                MasterPage_Lock_Control myPage_Control = Get_MasterPage_Lock_Control(state.Tag);

                Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();
                Modules.Component myComponent = myModuleMgr.Get_Component(myPage_Control.ComponentID);
                Modules.Component_Control myControl = myModuleMgr.Get_Control(myPage_Control.ComponentID, Modules.Control_Type.Advanced);

                if (myControl != null)
                {
                    Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                    Type _control_type = assembly.GetType(myControl.Class_Name);
                    Control _control = myPage.LoadControl(_control_type, null);
                    _control.ID = state.UniqueName;

                    List<MasterPage_Lock_Control_Property> Control_Properties = Get_MasterPage_Lock_Control_Properties(myPage_Control.Page_ControlID);

                    foreach (MasterPage_Lock_Control_Property Control_Property in Control_Properties)
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

                    // Dock Command
                    // Create Link Buttons
                    HyperLink HLinkbtn_Edit = new HyperLink();
                    HLinkbtn_Edit.ID = "Hlinkbtn_Edit";
                    HLinkbtn_Edit.Attributes["href"] = "#";
                    HLinkbtn_Edit.Attributes["onclick"] = string.Format("return Show_ControlManager('../PoP_ControlManager.aspx?Page_ControlID={0}&EditMode={1}');", myPage_Control.Page_ControlID, "TemplateDesignMode");
                    HLinkbtn_Edit.Text = "Edit";

                    LinkButton Linkbtn_Delete = new LinkButton();
                    Linkbtn_Delete.ID = "Linkbtn_Delete";
                    Linkbtn_Delete.CommandName = "Delete";
                    Linkbtn_Delete.CommandArgument = myDock.ID;
                    Linkbtn_Delete.Text = "Delete";

                    Nexus.Core.ServerControls.NC_LinkButton[] myLinkButtons = {
                                                new Nexus.Core.ServerControls.NC_LinkButton("/App_Control_Style/NexusCore/Images/Edit.png", HLinkbtn_Edit, typeof(HyperLink)),
                                                new Nexus.Core.ServerControls.NC_LinkButton("/App_Control_Style/NexusCore/Images/Delete.png", Linkbtn_Delete, typeof(LinkButton))
                                            };


                    myDock.TitlebarTemplate = new Nexus.Core.PageEditor.RadDockTemplate(myComponent.Component_Icon, myDock.Title, myLinkButtons);

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

        // Drag new Control from Toolbox to Design Mode
        public RadDock Add_DesignMode_NewControl(System.Web.UI.Page myPage, MasterPage_Lock myMasterPage_Lock, RadTreeNode sourceNode, string dropHtmlElementID, int dockCurrentPos)
        {

            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myMasterPage_Lock.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {
                List<MasterPage_Lock_Control> Page_Controls = Get_MasterPage_Lock_Controls(myMasterPage_Lock.MasterPage_LockID, myMasterPage_Control.PlaceHolderID);

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

                            // Save New Control to Database
                            e2Data[] UpdateData = {
                                                      new e2Data("MasterPage_LockID", myMasterPage_Lock.MasterPage_LockID),
                                                      new e2Data("PlaceHolderID", myMasterPage_Control.PlaceHolderID),
                                                      new e2Data("ComponentID", myComponent.ComponentID),
                                                      new e2Data("SortOrder", dockCurrentPos.ToString())
                                                  };

                            string Page_ControlID = Add_MasterPage_Lock_Control(UpdateData);

                            myDock.Tag = Page_ControlID;
                            myDock.Title = myComponent.Component_Name + " " + Page_ControlID;

                            // Create Link Buttons
                            HyperLink HLinkbtn_Edit = new HyperLink();
                            HLinkbtn_Edit.ID = "Hlinkbtn_Edit";
                            HLinkbtn_Edit.Attributes["href"] = "#";
                            HLinkbtn_Edit.Attributes["onclick"] = string.Format("return Show_ControlManager('../PoP_ControlManager.aspx?Page_ControlID={0}&EditMode={1}');", Page_ControlID, "TemplateDesignMode");
                            HLinkbtn_Edit.Text = "Edit";

                            LinkButton Linkbtn_Delete = new LinkButton();
                            Linkbtn_Delete.ID = "Linkbtn_Delete";
                            Linkbtn_Delete.CommandName = "Delete";
                            Linkbtn_Delete.CommandArgument = Page_ControlID;
                            Linkbtn_Delete.Text = "Delete";

                            Nexus.Core.ServerControls.NC_LinkButton[] myLinkButtons = {
                                                new Nexus.Core.ServerControls.NC_LinkButton("/App_Control_Style/NexusCore/Images/Edit.png", HLinkbtn_Edit, typeof(HyperLink)),
                                                new Nexus.Core.ServerControls.NC_LinkButton("/App_Control_Style/NexusCore/Images/Delete.png", Linkbtn_Delete, typeof(LinkButton))
                                            };


                            myDock.TitlebarTemplate = new Nexus.Core.PageEditor.RadDockTemplate(myComponent.Component_Icon, myDock.Title, myLinkButtons);

                            // Complete Control Load and add into dock
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

        // Update Controls Dock Position on Page
        public void Edit_DesignMode_Control_Position(System.Web.UI.Page myPage, MasterPage_Lock myMasterPage_Lock, List<DockState> CurrentDockStates)
        {
            Templates.TemplateMgr myTemplateMgr = new Nexus.Core.Templates.TemplateMgr();

            List<Templates.Template_MasterPage_Control> myMasterPage_Controls = myTemplateMgr.Get_Template_MasterPage_Controls(myMasterPage_Lock.Template_MasterPageID, null);

            foreach (Templates.Template_MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {

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

                                Edit_MasterPage_Lock_Control(UpdateData);

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
            Remove_MasterPage_Lock_Control_Properties(Page_ControlID);
            Remove_MasterPage_Lock_Control(Page_ControlID);
        }


        #endregion

        #region Add

        public string Add_MasterPage_Lock(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Add_MasterPage_Lock(UpdateData);
        }

        public string Add_MasterPage_Lock_Control(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Add_MasterPage_Lock_Control(UpdateData);
        }

        public void Add_MasterPage_Lock_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_MasterPage_Lock_Control_Property(UpdateData);
        }

        #endregion

        #region Update

        public void Edit_MasterPage_Lock(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_MasterPage_Lock(UpdateData);

        }

        public void Edit_MasterPage_Lock_Control(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_MasterPage_Lock_Control(UpdateData);
        }

        public void Edit_MasterPage_Lock_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_MasterPage_Lock_Control_Property(UpdateData);
        }


        #endregion

        #region Delete

        public void Remove_MasterPage_Lock(string MasterPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_MasterPage_Lock(MasterPageIndexID);
        }

        public void Remove_MasterPage_Lock_Control(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_MasterPage_Lock_Control(Page_ControlID);
        }

        public void Remove_MasterPage_Lock_Controls(string MasterPage_LockID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_MasterPage_Lock_Controls(MasterPage_LockID);
        }

        public void Remove_MasterPage_Lock_Control_Properties(string Page_ControlID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_MasterPage_Lock_Control_Properties(Page_ControlID);
        }


        #endregion

        #region Page design actions

        public void Set_MasterPageLock(Page myPage, string _masterpageindexid)
        {
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();
            Page_Loading_Info myPage_Loading_Info = myPropertyMgr.Get_MasterPage_Loading_Info(_masterpageindexid);

            // Lock the MasterPage
            MasterPageIndex myMasterPageIndex = myMasterPageMgr.Get_MasterPageIndex(_masterpageindexid);

            e2Data[] UpdateData_MasterPage_Lock = {
                                                new e2Data("MasterPageIndexID", myMasterPageIndex.MasterPageIndexID),
                                                new e2Data("MasterPage_Name", myMasterPageIndex.MasterPage_Name),
                                                new e2Data("MasterPageID", myPage_Loading_Info.MasterPageID),
                                                new e2Data("TemplateID", myMasterPageIndex.TemplateID),
                                                new e2Data("Template_MasterPageID", myMasterPageIndex.Template_MasterPageID),
                                                new e2Data("ThemeID", myMasterPageIndex.ThemeID),
                                                new e2Data("MasterPage_Description", myMasterPageIndex.MasterPage_Description),
                                                new e2Data("UserID", Security.Users.UserStatus.Current_UserID(myPage)),
                                                new e2Data("LockDate", DateTime.Now.ToString()),
                                            };

            string MasterPage_LockID = Add_MasterPage_Lock(UpdateData_MasterPage_Lock);

            System.Threading.Thread.Sleep(100);

            // Copy Controls and properties
            List<MasterPage_Control> myMasterPage_Controls = myMasterPageMgr.Get_MasterPage_Controls(myPage_Loading_Info.MasterPageID);

            foreach (MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {

                e2Data[] UpdateData_MasterPage_Lock_Control = {
                                                             new e2Data("MasterPage_LockID", MasterPage_LockID),
                                                             new e2Data("PlaceHolderID", myMasterPage_Control.PlaceHolderID),
                                                             new e2Data("ComponentID", myMasterPage_Control.ComponentID),
                                                             new e2Data("SortOrder", myMasterPage_Control.SortOrder.ToString())
                                                         };

                string Page_ControlID = Add_MasterPage_Lock_Control(UpdateData_MasterPage_Lock_Control);

                System.Threading.Thread.Sleep(100);

                List<MasterPage_Control_Property> myMasterPage_Control_Properties = myMasterPageMgr.Get_MasterPage_Control_Properties(myMasterPage_Control.Page_ControlID);

                foreach (MasterPage_Control_Property myMasterPage_Control_Property in myMasterPage_Control_Properties)
                {

                    e2Data[] UpdateData_MasterPage_Lock_Property = {
                                                             new e2Data("Page_ControlID", Page_ControlID),
                                                             new e2Data("Property_Name", myMasterPage_Control_Property.Property_Name),
                                                             new e2Data("Property_Value", myMasterPage_Control_Property.Property_Value),
                                                         };

                    Add_MasterPage_Lock_Property(UpdateData_MasterPage_Lock_Property);

                    System.Threading.Thread.Sleep(100);

                }

            }

        }

        // Publish the lock masterpage to live site
        public void Publish_MasterPageLock(string MasterPageIndexID, bool IsMasterPageActive)
        {

            MasterPage_Lock myMasterPage_Lock = Get_MasterPage_Lock(MasterPageIndexID);

            List<MasterPage_Lock_Control> myMasterPage_Lock_Controls = Get_MasterPage_Lock_Controls(myMasterPage_Lock.MasterPage_LockID);

            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            // remove old controls from live page.
            //Release_MasterPage(MasterPageIndexID);

            // Create New Page Version
            string MasterPageID = Tools.IDGenerator.Get_New_GUID_PlainText();
            string NowDate = DateTime.Now.ToString();

            int MasterPage_Version = myMasterPageMgr.Count_MasterPage_Version(MasterPageIndexID) + 1;

            e2Data[] UpdateData_MasterPage = {
                                           new e2Data("MasterPageID", MasterPageID),
                                           new e2Data("MasterPageIndexID", MasterPageIndexID),
                                           new e2Data("MasterPage_Version", MasterPage_Version.ToString()),
                                           new e2Data("Create_Date", NowDate),
                                           new e2Data("LastUpdate_Date", NowDate),
                                           new e2Data("LastUpdate_UserID", myMasterPage_Lock.UserID),
                                           new e2Data("IsActive", IsMasterPageActive.ToString()),
                                           new e2Data("IsDelete", "0")
                                       };

            if (IsMasterPageActive)
                myMasterPageMgr.Reset_MasterPage_Active(MasterPageIndexID);

            myMasterPageMgr.Add_MasterPage(UpdateData_MasterPage);


            // Publish Controls
            foreach (MasterPage_Lock_Control myMasterPage_Lock_Control in myMasterPage_Lock_Controls)
            {
                e2Data[] UpdateData_Control = {
                                                  new e2Data("MasterPageID", MasterPageID),
                                                  new e2Data("PlaceHolderID", myMasterPage_Lock_Control.PlaceHolderID),
                                                  new e2Data("ComponentID", myMasterPage_Lock_Control.ComponentID),
                                                  new e2Data("SortOrder", myMasterPage_Lock_Control.SortOrder.ToString())
                                              };

                string Page_ControlID = myMasterPageMgr.Add_MasterPage_Control(UpdateData_Control);

                Thread.Sleep(100);

                List<MasterPage_Lock_Control_Property> myMasterPage_Lock_Control_Properties = Get_MasterPage_Lock_Control_Properties(myMasterPage_Lock_Control.Page_ControlID);

                foreach (MasterPage_Lock_Control_Property myMasterPage_Lock_Control_Property in myMasterPage_Lock_Control_Properties)
                {
                    e2Data[] UpdateData_Property = {
                                                       new e2Data("Page_ControlID", Page_ControlID),
                                                       new e2Data("Property_Name", myMasterPage_Lock_Control_Property.Property_Name),
                                                       new e2Data("Property_Value", myMasterPage_Lock_Control_Property.Property_Value)
                                                   };

                    myMasterPageMgr.Add_MasterPage_Property(UpdateData_Property);

                    Thread.Sleep(100);
                }
            }
        }

        // Cancel Lock masterpage back to site
        public void Release_MasterPage(string MasterPageID)
        {
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            //MasterPageIndex myMasterPageIndex = myMasterPageMgr.Get_MasterPageIndex(MasterPageIndexID);

            List<MasterPage_Control> myMasterPage_Controls = myMasterPageMgr.Get_MasterPage_Controls(MasterPageID);

            foreach (MasterPage_Control myMasterPage_Control in myMasterPage_Controls)
            {
                myMasterPageMgr.Remove_MasterPage_Control_Properties(myMasterPage_Control.Page_ControlID);
            }

            myMasterPageMgr.Remove_MasterPage_Controls(MasterPageID);

        }

        public void Release_MasterPageLock(string MasterPageIndexID)
        {

            MasterPage_Lock myMasterPage_Lock = Get_MasterPage_Lock(MasterPageIndexID);

            List<MasterPage_Lock_Control> myMasterPage_Lock_Controls = Get_MasterPage_Lock_Controls(myMasterPage_Lock.MasterPage_LockID);

            foreach (MasterPage_Lock_Control myMasterPage_Lock_Control in myMasterPage_Lock_Controls)
            {
                Remove_MasterPage_Lock_Control_Properties(myMasterPage_Lock_Control.Page_ControlID);
            }

            Remove_MasterPage_Lock_Controls(myMasterPage_Lock.MasterPage_LockID);
            Remove_MasterPage_Lock(MasterPageIndexID);

        }

        #endregion

    }

    [DataObject(true)]
    public class ThemeMgr
    {

        public ThemeMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public Theme Get_Theme (string ThemeID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Theme(myDP.Get_Theme(ThemeID));
        }

        public List<Theme> Get_Themes(string TemplateID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Themes(TemplateID, SortOrder);

            List<Theme> list = new List<Theme>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Theme(myDR));
            }

            return list;

        }

        public static List<Theme> sGet_Themes(string TemplateID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Themes(TemplateID, SortOrder);

            List<Theme> list = new List<Theme>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Theme(myDR));
            }

            return list;

        }

    }

}
