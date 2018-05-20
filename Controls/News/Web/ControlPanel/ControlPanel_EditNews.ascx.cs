using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;

namespace Nexus.Controls.News.ControlPanel
{

    public partial class EditNews : System.Web.UI.UserControl
    {

        private string _newsid;
        private string _source_categoryid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _newsid = ViewState["NewsID"].ToString();
                    _source_categoryid = ViewState["Source_CategoryID"].ToString();
                }
                catch
                {
                    // nothing to do
                }
            }
            else
            {
                Init_Form();
                Reset_Form();
                Control_Init();
            }

        }

        private void Control_Init()
        {
            if (!DataEval.IsEmptyQuery(Request["NexusNewsPostID"]))
            {
                Lib.NewsMgr myNewsMgr = new Lib.NewsMgr();
                Lib.News_Post myNews_Post = myNewsMgr.Get_News_Post(Request["NexusNewsPostID"]);

                tbx_Title.Text = myNews_Post.News_Title;
                TextEditor_NewsContent.Content = myNews_Post.News_Content;
                CategoryTree_Menu.Selected_CategoryID = myNews_Post.CategoryID;
                droplist_NewsStatus.SelectedValue = myNews_Post.News_Status.ToString();
                tbx_Password.Text = myNews_Post.News_Password;
                RadDateTimePicker_NewsDate.SelectedDate = Convert.ToDateTime(myNews_Post.News_Date);
                TextEditor_ContentBrief.Content = myNews_Post.News_Brief;
                tbx_Author.Text = myNews_Post.Author;
                tbx_SourceName.Text = myNews_Post.Source_Name;
                tbx_SourceURL.Text = myNews_Post.Source_URL;

                _newsid = myNews_Post.NewsID;
                ViewState["NewsID"] = _newsid;
                _source_categoryid = myNews_Post.CategoryID;
                ViewState["Source_CategoryID"] = _source_categoryid;

            }
            else
            {
                btn_Update.Enabled = false;
            }
        }

        private void Init_Form()
        {

        }

        private void Reset_Form()
        {
            #region Bind Data to droplist
            // Enable user edit mode

            //Gets your enum names and adds it to a string array
            Array enumNames = Enum.GetValues(typeof(Lib.News_Status));

            //Creates an ArrayList
            ArrayList myNews_Statuses = new ArrayList();

            //Loop through your string array and poppulates the ArrayList
            foreach (Lib.News_Status myNews_Status in enumNames)
            {
                myNews_Statuses.Add(new { Value = StringEnum.GetStringValue(myNews_Status), Name = myNews_Status.ToString() });
            }


            //Bind the ArrayList to your DropDownList             
            droplist_NewsStatus.DataSource = myNews_Statuses;
            droplist_NewsStatus.DataTextField = "Name";
            droplist_NewsStatus.DataValueField = "Value";
            droplist_NewsStatus.DataBind();
            #endregion

            // Default Setting
            tbx_Title.Text = "";
            TextEditor_NewsContent.Content = "";
            CategoryTree_Menu.UnSelectItems();
            CategoryTree_Menu.LoadCategoryRoot();
            droplist_NewsStatus.SelectedIndex = 0;
            tbx_Password.Text = "";
            RadDateTimePicker_NewsDate.SelectedDate = null;
            TextEditor_ContentBrief.Content = "";

            // News Source
            tbx_Author.Text = "";
            tbx_SourceName.Text = "";
            tbx_SourceURL.Text = "";


        }

        protected void CustomValidator_Category_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DataEval.IsEmptyQuery(CategoryTree_Menu.Selected_CategoryID))
                args.IsValid = false;
        }

        protected void lbtn_CopyBrief_Click(object sender, EventArgs e)
        {
            TextEditor_ContentBrief.Content = TextEditor_NewsContent.Text.Substring(0, (int)RadNumericTbx_NumWords.Value) + "...";
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Lib.NewsMgr myNewsMgr = new Lib.NewsMgr();

                string News_Date;
                if (RadDateTimePicker_NewsDate.SelectedDate != null)
                {
                    News_Date = RadDateTimePicker_NewsDate.SelectedDate.ToString();
                }
                else
                {
                    News_Date = DateTime.Now.ToString();
                }

                e2Data[] UpdateData = {
                                               new e2Data("NewsID", _newsid),
                                               new e2Data("CategoryID", CategoryTree_Menu.Selected_CategoryID),
                                               new e2Data("UserID", Security.Users.UserStatus.Current_UserID(this.Page)),
                                               new e2Data("UserName", Security.Users.UserStatus.Current_UserName(this.Page)),
                                               new e2Data("News_Date", News_Date),
                                               new e2Data("News_ModifyDate", DateTime.Now.ToString()),
                                               new e2Data("News_Title", tbx_Title.Text),
                                               new e2Data("News_Brief", TextEditor_ContentBrief.Content),
                                               new e2Data("News_Content", TextEditor_NewsContent.Content),
                                               new e2Data("News_Status", droplist_NewsStatus.SelectedValue),
                                               new e2Data("News_Password", tbx_Password.Text),
                                               new e2Data("Author", tbx_Author.Text),
                                               new e2Data("Source_Name", tbx_SourceName.Text),
                                               new e2Data("Source_URL", tbx_SourceURL.Text)
                                      };

                myNewsMgr.Edit_News_Post(UpdateData);

                // Switch Category
                CategoryMgr myCategoryMgr = new CategoryMgr();
                myCategoryMgr.Move_ComponentInCategory_Item(_source_categoryid, CategoryTree_Menu.Selected_CategoryID, "3A79BF21-D0DF-4825-BFB2-7F6738C12BA7");

                // Finish Update Close Window
                string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText("Module_ControlPanel"));
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

            }
        }
    }
}