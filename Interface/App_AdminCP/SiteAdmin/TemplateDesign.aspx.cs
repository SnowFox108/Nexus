using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;
using Nexus.Core.Templates;

public partial class App_AdminCP_SiteAdmin_TemplateDesign : System.Web.UI.Page
{

    MasterPage_Lock myMasterPage_Lock;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page_Controls();
        }
    }

    private void Page_Controls()
    {
        // Check _pageindexid
        string _masterpageindexid = Request["MasterPageIndexID"];

        if (DataEval.IsEmptyQuery(_masterpageindexid))
        {
            // URLrewrite
            _masterpageindexid = "1";
        }

        btn_Cancel.CommandArgument = _masterpageindexid;
        btn_Publish.CommandArgument = _masterpageindexid;

        iframe_PageEditor_Design.Attributes["src"] = string.Format("Templates/Design.aspx?MasterPageIndexID={0}", _masterpageindexid);

        // Load Pages Template
        MasterPageEditorMgr myMasterPageEditorMgr = new MasterPageEditorMgr();
        myMasterPage_Lock = myMasterPageEditorMgr.Get_MasterPage_Lock(_masterpageindexid);

    }

    protected void btn_Cancel_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {
            string _masterpageindexid = e.CommandArgument.ToString();

            // Release PageLock
            MasterPageEditorMgr myMasterPageEditorMgr = new MasterPageEditorMgr();
            myMasterPageEditorMgr.Release_MasterPageLock(_masterpageindexid);

            Session.Remove("CurrentDockStatesDesignMode");

            Response.Redirect(string.Format("Templates.aspx?PageIndexID={0}", _masterpageindexid));
        }
    }

    protected void btn_Publish_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {

            string _masterpageindexid = e.CommandArgument.ToString();

            MasterPageEditorMgr myMasterPageEditorMgr = new MasterPageEditorMgr();

            // Replicate Buffer to Live Page
            myMasterPageEditorMgr.Publish_MasterPageLock(_masterpageindexid);

            // Release PageLock
            myMasterPageEditorMgr.Release_MasterPageLock(_masterpageindexid);

            Session.Remove("CurrentDockStatesDesignMode");

            Response.Redirect(string.Format("Templates.aspx?PageIndexID={0}", _masterpageindexid));

        }
    }

}