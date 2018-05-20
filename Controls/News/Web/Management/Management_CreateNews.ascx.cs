using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;

namespace Nexus.Controls.News.Management
{

    public partial class CreateNews : System.Web.UI.UserControl
    {

        bool _iscreated = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init_Form();
                Reset_Form();
            }

            Control_Init();
        }

        private void Control_Init()
        {
            if (_iscreated)
            {
                MultiView_CreateNews.SetActiveView(View_Created_News);
            }
            else
            {
                MultiView_CreateNews.SetActiveView(View_Add_News);
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
            if (TextEditor_NewsContent.Text.Length > (int)RadNumericTbx_NumWords.Value)
                TextEditor_ContentBrief.Content = TextEditor_NewsContent.Text.Substring(0, (int)RadNumericTbx_NumWords.Value) + "...";
            else
                TextEditor_ContentBrief.Content = TextEditor_NewsContent.Text + "...";

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
                                               new e2Data("CategoryID", CategoryTree_Menu.Selected_CategoryID),
                                               new e2Data("UserID", Security.Users.UserStatus.Current_UserID(this.Page)),
                                               new e2Data("UserName", Security.Users.UserStatus.Current_UserName(this.Page)),
                                               new e2Data("News_Date", News_Date),
                                               new e2Data("News_ModifyDate", News_Date),
                                               new e2Data("News_Title", tbx_Title.Text),
                                               new e2Data("News_Brief", TextEditor_ContentBrief.Content),
                                               new e2Data("News_Content", TextEditor_NewsContent.Content),
                                               new e2Data("News_Status", droplist_NewsStatus.SelectedValue),
                                               new e2Data("News_Password", tbx_Password.Text),
                                               new e2Data("Author", tbx_Author.Text),
                                               new e2Data("Source_Name", tbx_SourceName.Text),
                                               new e2Data("Source_URL", tbx_SourceURL.Text)
                                           };

                myNewsMgr.Add_News_Post(UpdateData);

                // Add Item to Category
                CategoryMgr myCategoryMgr = new CategoryMgr();
                myCategoryMgr.Add_ComponentInCategory_Item(CategoryTree_Menu.Selected_CategoryID, "3A79BF21-D0DF-4825-BFB2-7F6738C12BA7");

                _iscreated = true;

                Control_Init();

            }
        }

        protected void lbtn_CreateOtherNews_Click(object sender, EventArgs e)
        {
            Reset_Form();
            _iscreated = false;
            Control_Init();
        }
    }
}