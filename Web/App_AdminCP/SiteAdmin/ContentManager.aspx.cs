using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Controls;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;

public partial class App_AdminCP_SiteAdmin_ContentManager : System.Web.UI.Page
{

    private string _selected_componentid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            try
            {
                _selected_componentid = ViewState["Selected_ComponentID"].ToString();
            }
            catch
            {
                // nothing to do
            }
        }

        Control_Init();

    }

    private void Control_Init()
    {
        //if (!DataEval.IsEmptyQuery(_selected_componentid))
        //{
        //    ControlCPMgr myControlCPMgr = new ControlCPMgr();
        //    myControlCPMgr.Load_ControlPanel(this.Page, PlaceHolder_ControlPanel, _selected_componentid);
        //}
    }

    protected void ModuleCPMenu_List_OnCategorySelected(object sender, RadPanelBarEventArgs e)
    {
        _selected_componentid = ModuleCPMenu_List.Selected_ComponentID;
        ViewState["Selected_ComponentID"] = _selected_componentid;

        if (!DataEval.IsEmptyQuery(_selected_componentid))
        {
            lbl_ControlName.Text = ModuleCPMenu_List.Selected_ComponentText;
            iframe_ControlPanel.Attributes["src"] = string.Format("Modules/ControlManager.aspx?ControlID={0}", _selected_componentid);
        }

    }

}