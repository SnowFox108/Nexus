using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Reflection;
using Nexus.Core.Templates;
using Nexus.Core.Pages;

namespace Nexus.Core.Controls
{
    public class ControlMgr
    {
        public ControlMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region Update Page Control Properties

        public void Add_Page_Control_Properties_AdvanceMode(Control_Property[] Update_Properties)
        {
            foreach (Control_Property Update_Property in Update_Properties)
            {
                e2Data[] UpdateData = {
                                           new e2Data("Page_ControlID", Update_Property.Page_ControlID),
                                           new e2Data("Property_Name", Update_Property.Property_Name),
                                           new e2Data("Property_Value", Update_Property.Property_Value)
                                       };

                Pages.PageMgr myPageMgr = new Pages.PageMgr();

                myPageMgr.Add_Page_Property(UpdateData);

            }
        }

        public void Add_Page_Control_Properties_DesignMode(Control_Property[] Update_Properties)
        {
            foreach (Control_Property Update_Property in Update_Properties)
            {
                e2Data[] UpdateData = {
                                           new e2Data("Page_ControlID", Update_Property.Page_ControlID),
                                           new e2Data("Property_Name", Update_Property.Property_Name),
                                           new e2Data("Property_Value", Update_Property.Property_Value)
                                       };

                Pages.PageEditorMgr myPageEditor = new Pages.PageEditorMgr();

                myPageEditor.Add_Page_Lock_Property(UpdateData);

            }
        }

        public void Edit_Page_Control_Properties_AdvanceMode(string Page_ControlID, Control_Property[] Update_Properties)
        {

            Pages.PageMgr myPageMgr = new Pages.PageMgr();

            myPageMgr.Remove_Page_Control_Properties(Page_ControlID);

            foreach (Control_Property Update_Property in Update_Properties)
            {
                e2Data[] UpdateData = {
                                           new e2Data("Page_ControlID", Update_Property.Page_ControlID),
                                           new e2Data("Property_Name", Update_Property.Property_Name),
                                           new e2Data("Property_Value", Update_Property.Property_Value)
                                       };


                myPageMgr.Add_Page_Property(UpdateData);

            }
        }

        public void Edit_Page_Control_Properties_AdvanceMode(string Page_ControlID, Control_Property[] Update_Properties, string Current_UserID)
        {

            Pages.PageMgr myPageMgr = new Pages.PageMgr();

            myPageMgr.Remove_Page_Control_Properties(Page_ControlID);

            foreach (Control_Property Update_Property in Update_Properties)
            {
                e2Data[] UpdateData = {
                                           new e2Data("Page_ControlID", Update_Property.Page_ControlID),
                                           new e2Data("Property_Name", Update_Property.Property_Name),
                                           new e2Data("Property_Value", Update_Property.Property_Value)
                                       };


                myPageMgr.Add_Page_Property(UpdateData);

            }

            // Update Page Version
            Page_Control myPage_Control = myPageMgr.Get_Page_Control(Page_ControlID);

            e2Data[] UpdateData_PageVersion = {
                                                  new e2Data("PageID", myPage_Control.PageID),
                                                  new e2Data("LastUpdate_Date", DateTime.Now.ToString()),
                                                  new e2Data("LastUpdate_UserID", Current_UserID)
                                               };

            myPageMgr.Edit_Page(UpdateData_PageVersion);


        }

        public void Edit_Page_Control_Properties_DesignMode(string Page_ControlID, Control_Property[] Update_Properties)
        {
            Pages.PageEditorMgr myPageEditor = new Pages.PageEditorMgr();

            myPageEditor.Remove_Page_Lock_Control_Properties(Page_ControlID);

            foreach (Control_Property Update_Property in Update_Properties)
            {
                e2Data[] UpdateData = {
                                           new e2Data("Page_ControlID", Update_Property.Page_ControlID),
                                           new e2Data("Property_Name", Update_Property.Property_Name),
                                           new e2Data("Property_Value", Update_Property.Property_Value)
                                       };


                myPageEditor.Add_Page_Lock_Property(UpdateData);

            }
        }

        #endregion

        #region Update MasterPage Control Properties

        public void Add_MasterPage_Control_Properties_AdvanceMode(Control_Property[] Update_Properties)
        {
            foreach (Control_Property Update_Property in Update_Properties)
            {
                e2Data[] UpdateData = {
                                           new e2Data("Page_ControlID", Update_Property.Page_ControlID),
                                           new e2Data("Property_Name", Update_Property.Property_Name),
                                           new e2Data("Property_Value", Update_Property.Property_Value)
                                       };

                Templates.MasterPageMgr myMasterPageMgr = new Templates.MasterPageMgr();

                myMasterPageMgr.Add_MasterPage_Property(UpdateData);

            }
        }

        public void Add_MasterPage_Control_Properties_DesignMode(Control_Property[] Update_Properties)
        {
            foreach (Control_Property Update_Property in Update_Properties)
            {
                e2Data[] UpdateData = {
                                           new e2Data("Page_ControlID", Update_Property.Page_ControlID),
                                           new e2Data("Property_Name", Update_Property.Property_Name),
                                           new e2Data("Property_Value", Update_Property.Property_Value)
                                       };

                Templates.MasterPageEditorMgr myMasterPageEditor = new Templates.MasterPageEditorMgr();

                myMasterPageEditor.Add_MasterPage_Lock_Property(UpdateData);

            }
        }

        public void Edit_MasterPage_Control_Properties_AdvanceMode(string Page_ControlID, Control_Property[] Update_Properties)
        {

            Templates.MasterPageMgr myMasterPageMgr = new Templates.MasterPageMgr();

            myMasterPageMgr.Remove_MasterPage_Control_Properties(Page_ControlID);

            foreach (Control_Property Update_Property in Update_Properties)
            {
                e2Data[] UpdateData = {
                                           new e2Data("Page_ControlID", Update_Property.Page_ControlID),
                                           new e2Data("Property_Name", Update_Property.Property_Name),
                                           new e2Data("Property_Value", Update_Property.Property_Value)
                                       };


                myMasterPageMgr.Add_MasterPage_Property(UpdateData);

            }

        }

        public void Edit_MasterPage_Control_Properties_AdvanceMode(string Page_ControlID, Control_Property[] Update_Properties, string Current_UserID)
        {

            Templates.MasterPageMgr myMasterPageMgr = new Templates.MasterPageMgr();

            myMasterPageMgr.Remove_MasterPage_Control_Properties(Page_ControlID);

            foreach (Control_Property Update_Property in Update_Properties)
            {
                e2Data[] UpdateData = {
                                           new e2Data("Page_ControlID", Update_Property.Page_ControlID),
                                           new e2Data("Property_Name", Update_Property.Property_Name),
                                           new e2Data("Property_Value", Update_Property.Property_Value)
                                       };


                myMasterPageMgr.Add_MasterPage_Property(UpdateData);

            }

            // Update MasterPage Version
            MasterPage_Control myMasterPage_Control = myMasterPageMgr.Get_MasterPage_Control(Page_ControlID);

            e2Data[] UpdateData_PageVersion = {
                                                  new e2Data("MasterPageID", myMasterPage_Control.MasterPageID),
                                                  new e2Data("LastUpdate_Date", DateTime.Now.ToString()),
                                                  new e2Data("LastUpdate_UserID", Current_UserID)
                                               };

            myMasterPageMgr.Edit_MasterPage(UpdateData_PageVersion);
        }

        public void Edit_MasterPage_Control_Properties_DesignMode(string Page_ControlID, Control_Property[] Update_Properties)
        {
            Templates.MasterPageEditorMgr myMasterPageEditor = new Templates.MasterPageEditorMgr();

            myMasterPageEditor.Remove_MasterPage_Lock_Control_Properties(Page_ControlID);

            foreach (Control_Property Update_Property in Update_Properties)
            {
                e2Data[] UpdateData = {
                                           new e2Data("Page_ControlID", Update_Property.Page_ControlID),
                                           new e2Data("Property_Name", Update_Property.Property_Name),
                                           new e2Data("Property_Value", Update_Property.Property_Value)
                                       };


                myMasterPageEditor.Add_MasterPage_Lock_Property(UpdateData);

            }
        }

        #endregion

        #region Update Customer Control Properties

        public void Update_Control_Properties(string EditMode, string ControlID, string Page_ControlID, Control_Property[] Update_Properties)
        {
            switch (EditMode)
            {
                case "PageAdvancedMode":
                    if (DataEval.IsEmptyQuery(ControlID))
                    {
                        // Create Lock Page_Control Property
                        Add_Page_Control_Properties_AdvanceMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        Edit_Page_Control_Properties_AdvanceMode(Page_ControlID, Update_Properties);
                    }
                    break;

                case "PageDesignMode":
                    if (DataEval.IsEmptyQuery(ControlID))
                    {
                        // Create Lock Page_Control Property
                        Add_Page_Control_Properties_DesignMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        Edit_Page_Control_Properties_DesignMode(Page_ControlID, Update_Properties);

                    }
                    break;

                case "TemplateAdvancedMode":
                    if (DataEval.IsEmptyQuery(ControlID))
                    {
                        // Create Lock Page_Control Property
                        Add_MasterPage_Control_Properties_AdvanceMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        Edit_MasterPage_Control_Properties_AdvanceMode(Page_ControlID, Update_Properties);
                    }
                    break;

                case "TemplateDesignMode":
                    if (DataEval.IsEmptyQuery(ControlID))
                    {
                        // Create Lock Page_Control Property
                        Add_MasterPage_Control_Properties_DesignMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        Edit_MasterPage_Control_Properties_DesignMode(Page_ControlID, Update_Properties);
                    }
                    break;
            }

        }

        public void Update_Control_Properties(string EditMode, string ControlID, string Page_ControlID, Control_Property[] Update_Properties, string Current_UserID)
        {
            switch (EditMode)
            {
                case "PageAdvancedMode":
                    if (DataEval.IsEmptyQuery(ControlID))
                    {
                        // Create Lock Page_Control Property
                        Add_Page_Control_Properties_AdvanceMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        Edit_Page_Control_Properties_AdvanceMode(Page_ControlID, Update_Properties, Current_UserID);
                    }
                    break;

                case "PageDesignMode":
                    if (DataEval.IsEmptyQuery(ControlID))
                    {
                        // Create Lock Page_Control Property
                        Add_Page_Control_Properties_DesignMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        Edit_Page_Control_Properties_DesignMode(Page_ControlID, Update_Properties);

                    }
                    break;

                case "TemplateAdvancedMode":
                    if (DataEval.IsEmptyQuery(ControlID))
                    {
                        // Create Lock Page_Control Property
                        Add_MasterPage_Control_Properties_AdvanceMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        Edit_MasterPage_Control_Properties_AdvanceMode(Page_ControlID, Update_Properties, Current_UserID);
                    }
                    break;

                case "TemplateDesignMode":
                    if (DataEval.IsEmptyQuery(ControlID))
                    {
                        // Create Lock Page_Control Property
                        Add_MasterPage_Control_Properties_DesignMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        Edit_MasterPage_Control_Properties_DesignMode(Page_ControlID, Update_Properties);
                    }
                    break;
            }

        }

        #endregion
    }

    public class ControlCPMgr
    {
        public ControlCPMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public void Load_ControlEditor_PageAdvancedMode(System.Web.UI.Page myPage, string Page_ControlID)
        {
            PageMgr myPageMgr = new PageMgr();
            Page_Control myPage_Control = myPageMgr.Get_Page_Control(Page_ControlID);

            Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();
            Modules.Component myComponent = myModuleMgr.Get_Component(myPage_Control.ComponentID);
            Modules.Component_Control myControl = myModuleMgr.Get_Control(myPage_Control.ComponentID, Modules.Control_Type.Editor);

            if (myControl.Assembly_Name != null)
            {
                Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                Type _control_type = assembly.GetType(myControl.Class_Name);
                Control _control = myPage.LoadControl(_control_type, null);

                List<Page_Control_Property> Control_Properties = myPageMgr.Get_Page_Control_Properties(myPage_Control.Page_ControlID);

                // Load Exist Control
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

                // Place PageControlID and EditMode
                PropertyInfo Page_ControlID_Property = _control_type.GetProperty("Page_ControlID");
                Page_ControlID_Property.SetValue(_control, Page_ControlID, null);

                PropertyInfo EditMode_Property = _control_type.GetProperty("EditMode");
                EditMode_Property.SetValue(_control, "PageAdvancedMode", null);

                // Create Events Failed
                //EventInfo _Control_Event = _control_type.GetEvent("FinishUpdate");
                //_Control_Event.

                // Create Editor
                PlaceHolder myPlaceHolder = (PlaceHolder)myPage.FindControl("PlaceHolder_Editor");
                myPlaceHolder.Controls.Add(_control);

            }
            else
            {
                throw new Exception(string.Format("Invalid PageControl Editor.Design Mode ComponentID: {0}", myPage_Control.ComponentID));
            }

        }

        public void Load_ControlEditor_PageDesignMode(System.Web.UI.Page myPage, string Page_ControlID)
        {
            PageEditorMgr myPageEditor = new PageEditorMgr();
            Page_Lock_Control myPage_Control = myPageEditor.Get_Page_Lock_Control(Page_ControlID);

            Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();
            Modules.Component myComponent = myModuleMgr.Get_Component(myPage_Control.ComponentID);
            Modules.Component_Control myControl = myModuleMgr.Get_Control(myPage_Control.ComponentID, Modules.Control_Type.Editor);

            if (myControl.Assembly_Name != null)
            {
                Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                Type _control_type = assembly.GetType(myControl.Class_Name);
                Control _control = myPage.LoadControl(_control_type, null);

                List<Page_Lock_Control_Property> Control_Properties = myPageEditor.Get_Page_Lock_Control_Properties(myPage_Control.Page_ControlID);

                // Load Exist Control
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
                        // do nothing
                    }

                }

                // Place PageControlID and EditMode
                PropertyInfo Page_ControlID_Property = _control_type.GetProperty("Page_ControlID");
                Page_ControlID_Property.SetValue(_control, Page_ControlID, null);

                PropertyInfo EditMode_Property = _control_type.GetProperty("EditMode");
                EditMode_Property.SetValue(_control, "PageDesignMode", null);

                // Create Events Failed
                //EventInfo _Control_Event = _control_type.GetEvent("FinishUpdate");
                //_Control_Event.

                // Create Editor
                PlaceHolder myPlaceHolder = (PlaceHolder)myPage.FindControl("PlaceHolder_Editor");
                myPlaceHolder.Controls.Add(_control);

            }
            else
            {
                throw new Exception(string.Format("Invalid PageControl Editor.Design Mode ComponentID: {0}", myPage_Control.ComponentID));
            }

        }

        public void Load_ControlEditor_TemplateAdvancedMode(System.Web.UI.Page myPage, string Page_ControlID)
        {
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();
            MasterPage_Control myMasterPage_Control = myMasterPageMgr.Get_MasterPage_Control(Page_ControlID);

            Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();
            Modules.Component myComponent = myModuleMgr.Get_Component(myMasterPage_Control.ComponentID);
            Modules.Component_Control myControl = myModuleMgr.Get_Control(myMasterPage_Control.ComponentID, Modules.Control_Type.Editor);

            if (myControl.Assembly_Name != null)
            {
                Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                Type _control_type = assembly.GetType(myControl.Class_Name);
                Control _control = myPage.LoadControl(_control_type, null);

                List<MasterPage_Control_Property> Control_Properties = myMasterPageMgr.Get_MasterPage_Control_Properties(myMasterPage_Control.Page_ControlID);

                // Load Exist Control
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

                // Place PageControlID and EditMode
                PropertyInfo Page_ControlID_Property = _control_type.GetProperty("Page_ControlID");
                Page_ControlID_Property.SetValue(_control, Page_ControlID, null);

                PropertyInfo EditMode_Property = _control_type.GetProperty("EditMode");
                EditMode_Property.SetValue(_control, "TemplateAdvancedMode", null);

                // Create Editor
                PlaceHolder myPlaceHolder = (PlaceHolder)myPage.FindControl("PlaceHolder_Editor");
                myPlaceHolder.Controls.Add(_control);

            }
            else
            {
                throw new Exception(string.Format("Invalid PageControl Editor.Design Mode ComponentID: {0}", myMasterPage_Control.ComponentID));
            }

        }

        public void Load_ControlEditor_TemplateDesignMode(System.Web.UI.Page myPage, string Page_ControlID)
        {
            Templates.MasterPageEditorMgr myMasterPageEditor = new Templates.MasterPageEditorMgr();
            MasterPage_Lock_Control myMasterPage_Control = myMasterPageEditor.Get_MasterPage_Lock_Control(Page_ControlID);

            Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();
            Modules.Component myComponent = myModuleMgr.Get_Component(myMasterPage_Control.ComponentID);
            Modules.Component_Control myControl = myModuleMgr.Get_Control(myMasterPage_Control.ComponentID, Modules.Control_Type.Editor);

            if (myControl.Assembly_Name != null)
            {
                Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                Type _control_type = assembly.GetType(myControl.Class_Name);
                Control _control = myPage.LoadControl(_control_type, null);

                List<MasterPage_Lock_Control_Property> Control_Properties = myMasterPageEditor.Get_MasterPage_Lock_Control_Properties(myMasterPage_Control.Page_ControlID);

                // Load Exist Control
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

                // Place PageControlID and EditMode
                PropertyInfo Page_ControlID_Property = _control_type.GetProperty("Page_ControlID");
                Page_ControlID_Property.SetValue(_control, Page_ControlID, null);

                PropertyInfo EditMode_Property = _control_type.GetProperty("EditMode");
                EditMode_Property.SetValue(_control, "TemplateDesignMode", null);

                // Create Editor
                PlaceHolder myPlaceHolder = (PlaceHolder)myPage.FindControl("PlaceHolder_Editor");
                myPlaceHolder.Controls.Add(_control);

            }
            else
            {
                throw new Exception(string.Format("Invalid PageControl Editor.Design Mode ComponentID: {0}", myMasterPage_Control.ComponentID));
            }

        }

        public void Load_ControlPanel(System.Web.UI.Page myPage, PlaceHolder myPlaceHolder, string ControlID)
        {
            Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();

            Modules.Component_Control myControl = myModuleMgr.Get_Control(ControlID);

            if (myControl.Assembly_Name != null)
            {
                Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                Type _control_type = assembly.GetType(myControl.Class_Name);
                Control _control = myPage.LoadControl(_control_type, null);

                // Create Control
                //PlaceHolder myPlaceHolder = (PlaceHolder)myPage.FindControl(PlaceHolder_ID);
                myPlaceHolder.Controls.Add(_control);

            }
        }


        public void Load_ControlPanel(System.Web.UI.Page myPage, string PlaceHolder_ID, string ControlID, e2Data[] MyProperties)
        {
            Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();

            Modules.Component_Control myControl = myModuleMgr.Get_Control(ControlID);

            if (myControl.Assembly_Name != null)
            {
                Assembly assembly = Assembly.Load(new AssemblyName(myControl.Assembly_Name));

                Type _control_type = assembly.GetType(myControl.Class_Name);
                Control _control = myPage.LoadControl(_control_type, null);

                // Load Exist Control
                foreach (e2Data myProperty in MyProperties)
                {
                    PropertyInfo _Control_Property = _control_type.GetProperty(myProperty.FieldName);

                    switch (_Control_Property.PropertyType.FullName)
                    {
                        case "System.String":
                            _Control_Property.SetValue(_control, myProperty.FieldValue, null);
                            break;
                        case "System.Int32":
                            _Control_Property.SetValue(_control, Convert.ToInt32(myProperty.FieldValue), null);
                            break;
                        case "System.Boolean":
                            _Control_Property.SetValue(_control, Convert.ToBoolean(myProperty.FieldValue), null);
                            break;
                        default:
                            _Control_Property.SetValue(_control, myProperty.FieldValue, null);
                            break;
                    }

                }

                // Create Control
                PlaceHolder myPlaceHolder = (PlaceHolder)myPage.FindControl(PlaceHolder_ID);
                myPlaceHolder.Controls.Add(_control);

            }
        }

    }

}
