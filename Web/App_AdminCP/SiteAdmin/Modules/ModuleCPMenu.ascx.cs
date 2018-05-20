using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Modules;
using Telerik.Web.UI;

namespace Nexus.Core
{
    public partial class App_AdminCP_SiteAdmin_Modules_ModuleCPMenu : System.Web.UI.UserControl
    {

        #region Properties

        private string _selected_componentid;
        private string _selected_componenttext;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Selected_ComponentID
        {
            get
            {
                return _selected_componentid;
            }
            set
            {
                _selected_componentid = value;
                ViewState["Selected_ComponentID"] = _selected_componentid;
            }
        }

        [DefaultValue("")]
        public string Selected_ComponentText
        {
            get
            {
                return _selected_componenttext;
            }
        }

        #endregion

        #region Events

        // Control Panel Menu Click Event
        private static readonly object EventSelected = new object();

        [Category("Action")]
        [Description("Raised Control Panel Menu Clicked event")]
        public event RadPanelBarEventHandler CategorySelected
        {
            add
            {
                Events.AddHandler(EventSelected, value);
            }
            remove
            {
                Events.RemoveHandler(EventSelected, value);
            }
        }

        protected void OnSelected(object sender, RadPanelBarEventArgs e)
        {
            RadPanelBarEventHandler SelectedHandler = (RadPanelBarEventHandler)Events[EventSelected];

            if (SelectedHandler != null)
                SelectedHandler(sender, e);

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _selected_componentid = ViewState["Selected_ComponentID"].ToString();
                    _selected_componenttext = ViewState["Selected_ComponentText"].ToString();
                }
                catch
                {
                }
            }
            else
            {
                LoadComponentRoot();
            }

        }

        public void LoadComponentRoot()
        {

            // Remove all Item before add new one
            RadPanelBar_ControlPanel.Items.Clear();

            ModuleMgr myModuleMgr = new ModuleMgr();
            List<Module> myModules = myModuleMgr.Get_Modules("Module_Name");

            foreach (Module myModule in myModules)
            {
                List<Modules.Component> myComponents = myModuleMgr.Get_Components(myModule.ModuleID, "-1", Component_Type.ControlPanel, "Component_Name");

                foreach (Modules.Component myComponent in myComponents)
                {
                    RadPanelItem item = new RadPanelItem();
                    item.Text = myComponent.Component_Name;
                    item.ImageUrl = myComponent.Component_Icon;

                    LoadComponentItem(item, myComponent.ComponentID);

                    RadPanelBar_ControlPanel.Items.Add(item);
                }

            }
        }

        private void LoadComponentItem(RadPanelItem MyItem, string ComponentID)
        {
            ModuleMgr myModuleMgr = new ModuleMgr();

            List<Component_Control> myControls = myModuleMgr.Get_Controls(ComponentID, Control_Type.Management, "Control_Name");

            foreach (Component_Control myControl in myControls)
            {
                RadPanelItem item = new RadPanelItem();
                item.Text = myControl.Control_Name;
                item.Value = myControl.ControlID;

                MyItem.Items.Add(item);

            }

        }
        protected void RadPanelBar_ControlPanel_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            if (e.Item.Value != null)
            {
                _selected_componentid = e.Item.Value;
                ViewState["Selected_ComponentID"] = _selected_componentid;

                _selected_componenttext = e.Item.Text;
                ViewState["Selected_ComponentText"] = _selected_componenttext;

                OnSelected(sender, e);
            }
        }
}
}