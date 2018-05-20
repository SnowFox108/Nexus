using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Nexus.Core
{

    public partial class App_AdminCP_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                switch (Request["LoginMsg"])
                {
                    case "invalid":
                        lbl_ErrorText.Text = "The user does not have permission";
                        break;
                    case "logout":
                        lbl_ErrorText.Text = "You have logged out.";
                        break;
                    case "sessionexpire":
                        lbl_ErrorText.Text = "Session has been expired, please relog in.";
                        break;
                    default:
                        Control_Init();
                        break;
                }

                #region Module Login

                // Module Login
                droplist_Module.Items.Clear();

                // e2CMS
                ListItem e2CMS = new ListItem();
                e2CMS.Text = "Website Admin Panel";
                e2CMS.Value = "e2CMS";
                droplist_Module.Items.Add(e2CMS);

                // e2Shop
                Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();

                if (myModuleMgr.Chk_Module("A72F077B-FF47-4887-B9D7-71EC7DA2246D"))
                {
                    ListItem e2Shop = new ListItem();
                    e2Shop.Text = "e2Shop Admin Panel";
                    e2Shop.Value = "e2Shop";
                    droplist_Module.Items.Add(e2Shop);
                }

                #endregion
            }
        }

        private void Control_Init()
        {
            Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

            HttpCookie cookieUserInfo = myUserMgr.Get_UserCookie(this.Page);

            if (cookieUserInfo != null)
            {
                try
                {

                    if (Convert.ToBoolean(cookieUserInfo["RememberMe"]))
                    {
                        tbx_Email.Text = cookieUserInfo["Email"].ToString();
                        cookieUserInfo.Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        cookieUserInfo.Expires = DateTime.Now.AddDays(1);
                    }

                    chkbox_RememberMe.Checked = Convert.ToBoolean(cookieUserInfo["RememberMe"]);
                }
                catch
                {
                    chkbox_RememberMe.Checked = false;
                }
            }
            else
            {
                chkbox_RememberMe.Checked = false;
            }
        }

        protected void CustomValidator_Email_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

            if (!myUserMgr.Chk_Email_Exist(tbx_Email.Text))
            {
                args.IsValid = false;
            }

        }

        protected void CustomValidator_Password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

            if (!myUserMgr.Chk_User_Login(tbx_Email.Text, tbx_Password.Text))
            {
                args.IsValid = false;
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();
                //myUserMgr.Remove_UserCookie(this.Page);
                myUserMgr.Add_UserCookie(this.Page, tbx_Email.Text, tbx_Password.Text, chkbox_RememberMe.Checked);

                if (Security.Users.UserStatus.Validate_UserGroup(this.Page, Security.Users.UserGroup.Administrator))
                {
                    switch (droplist_Module.SelectedValue)
                    {
                        case "e2CMS":
                            Response.Redirect("~/App_AdminCP/SiteAdmin/Default.aspx");
                            break;
                        case "e2Shop":
                            Response.Redirect("~/App_AdminCP/ShopAdmin/Default.aspx");
                            break;
                    }

                } else
                {
                    lbl_ErrorText.Text = "The user does not have permission";
                }
            }
        }
    }
}