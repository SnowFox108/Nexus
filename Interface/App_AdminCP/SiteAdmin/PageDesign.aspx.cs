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
using Nexus.Core.Pages;

public partial class App_AdminCP_SiteAdmin_PageDesign : System.Web.UI.Page
{

    private Page_Loading_Info myPage_Loading_Info;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page_Controls();
        }
        else
        {
            // Check _pageindexid
            string _pageindexid = Request["PageIndexID"];

            // Load Pages Template
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();
            myPage_Loading_Info = myPropertyMgr.Get_Page_Lock_Loading_Info(_pageindexid);
        }


    }

    private void Page_Controls()
    {
        // Check _pageindexid
        string _pageindexid = Request["PageIndexID"];

        if (DataEval.IsEmptyQuery(_pageindexid))
        {
            // URLrewrite
            Response.Redirect("Pages.aspx");
            return;
        }

        btn_Cancel.CommandArgument = _pageindexid;
        btn_Publish.CommandArgument = _pageindexid;

        iframe_PageEditor_Design.Attributes["src"] = string.Format("Pages/Design.aspx?PageIndexID={0}&PageLink=Disable", _pageindexid);

        // Load Pages Template
        Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();
        myPage_Loading_Info = myPropertyMgr.Get_Page_Lock_Loading_Info(_pageindexid);

        // Page Template
        DataFill_Template();
    }

    private void DataFill_Template()
    {

        PageEditorMgr myPageEditorMgr = new PageEditorMgr();
        Page_Lock_Template myPage_Lock_Template = myPageEditorMgr.Get_Page_Lock_Template(myPage_Loading_Info.Page_LockID);

        // Template
        if (myPage_Lock_Template.IsTemplate_Inherited)
        {
            rbtn_IsTemplate_Inherited.SelectedValue = "1";
            Panel_Template.Enabled = false;
        }
        else
        {
            rbtn_IsTemplate_Inherited.SelectedValue = "0";
            Panel_Template.Enabled = true;
        }

        // Look for Template
        RadComboBox_Template.SelectedValue = myPage_Lock_Template.MasterPageIndexID;
    }

    protected void rbtn_IsTemplate_Inherited_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtn_IsTemplate_Inherited.SelectedValue == "0")
        {
            Panel_Template.Enabled = true;
        }
        else
        {
            Panel_Template.Enabled = false;

            // Load Pages Template
            //PageEditorMgr myPageEditorMgr = new PageEditorMgr();
            //Page_Lock_Template myPage_Lock_Template = myPageEditorMgr.Get_Page_Lock_Template(myPage_Loading_Info.Page_LockID);

            // Load Pages Template
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();
            Page_Loading_Info myParent_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(myPage_Loading_Info.Parent_PageIndexID);

            // Look for Template
            RadComboBox_Template.SelectedValue = myParent_Loading_Info.MasterPageIndexID;

            // Active New Template
            btn_SwitchTemplate_Click(sender, e);

        }

    }

    protected void btn_SwitchTemplate_Click(object sender, EventArgs e)
    {
        // Save Template
        PageEditorMgr myPageEditorMgr = new PageEditorMgr();

        // Page Index
        e2Data[] UpdateData = {
                                      new e2Data("Page_LockID", myPage_Loading_Info.Page_LockID),
                                      new e2Data("IsTemplate_Inherited", rbtn_IsTemplate_Inherited.SelectedValue),
                                      new e2Data("MasterPageIndexID", RadComboBox_Template.SelectedValue)
                                  };

        myPageEditorMgr.Edit_Page_Lock_Template(UpdateData);

        iframe_PageEditor_Design.Attributes["src"] = string.Format("Pages/Design.aspx?PageIndexID={0}&PageLink=Disable", myPage_Loading_Info.PageIndexID);

    }

    protected void btn_Cancel_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {
            string _pageindexid = e.CommandArgument.ToString();

            // Release PageLock
            PageEditorMgr myPageEditorMgr = new PageEditorMgr();
            myPageEditorMgr.Release_PageLock(_pageindexid);

            Session.Remove("CurrentDockStatesDesignMode");

            Response.Redirect(string.Format("Pages.aspx?PageIndexID={0}", _pageindexid));
        }
    }

    protected void btn_Publish_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {

            string _pageindexid = e.CommandArgument.ToString();

            PageEditorMgr myPageEditorMgr = new PageEditorMgr();

            // Replicate Buffer to Live Page
            myPageEditorMgr.Publish_PageLock(_pageindexid);

            // Release PageLock
            myPageEditorMgr.Release_PageLock(_pageindexid);

            Session.Remove("CurrentDockStatesDesignMode");

            Response.Redirect(string.Format("Pages.aspx?PageIndexID={0}", _pageindexid));

        }
    }
}
