using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Categories;
using Telerik.Web.UI;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Modules_CategoryCommand : System.Web.UI.UserControl
    {

        #region Properties

        private string _categoryid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CategoryID
        {
            get
            {
                return _categoryid;
            }
            set
            {
                _categoryid = value;
                ViewState["CategoryID"] = _categoryid;
            }
        }

        #endregion

        #region Events

        // Create Button Click Event
        private static readonly object CreateCategoryEventClick = new object();

        [Category("Action")]
        [Description("Raised Create Command Clicked event")]
        public event EventHandler CreateCategoryClick
        {
            add
            {
                Events.AddHandler(CreateCategoryEventClick, value);
            }
            remove
            {
                Events.RemoveHandler(CreateCategoryEventClick, value);
            }
        }

        protected void OnCreateCategoryClick(object sender, EventArgs e)
        {
            EventHandler CreateCategoryClickHandler = (EventHandler)Events[CreateCategoryEventClick];

            if (CreateCategoryClickHandler != null)
                CreateCategoryClickHandler(sender, e);

        }

        // Delete Button Click Event
        private static readonly object DeleteCategoryEventClick = new object();

        [Category("Action")]
        [Description("Raised Delete Command Clicked event")]
        public event EventHandler DeleteCategoryClick
        {
            add
            {
                Events.AddHandler(DeleteCategoryEventClick, value);
            }
            remove
            {
                Events.RemoveHandler(DeleteCategoryEventClick, value);
            }
        }

        protected void OnDeleteCategoryClick(object sender, EventArgs e)
        {
            EventHandler DeleteCategoryClickHandler = (EventHandler)Events[DeleteCategoryEventClick];

            if (DeleteCategoryClickHandler != null)
                DeleteCategoryClickHandler(sender, e);

        }

        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (ViewState["CategoryID"] != null)
                    _categoryid = ViewState["CategoryID"].ToString();
            }
            else
            {
                Category_Selected();
                Control_Init();
            }

        }

        private void Control_Init()
        {
        }

        public void Category_Selected()
        {
            if (!DataEval.IsEmptyQuery(_categoryid) && _categoryid != "-1")
            {
                CategoryMgr myCategoryMgr = new CategoryMgr();
                Category myCategory = myCategoryMgr.Get_Category(_categoryid);

                lbl_CategoryName.Text = myCategory.Category_Name;

                // Create Client Delete Confirm
               btn_Delete.OnClientClick = string.Format("return confirm('Are you sure you want to delete category \"{0}\" ?');", myCategory.Category_Name);

            }
            else
            {
                lbl_CategoryName.Text = "Unselected";
            }

        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            OnCreateCategoryClick(sender, e);
        }
        protected void btn_Delete_Click(object sender, EventArgs e)
        {

            if (!DataEval.IsEmptyQuery(_categoryid))
            {

                if (Chk_CategoryID())
                {

                    CategoryMgr myCategoryMgr = new CategoryMgr();
                    myCategoryMgr.Remove_Category(_categoryid);

                    OnDeleteCategoryClick(sender, e);
                }
            }

        }

        private bool Chk_CategoryID()
        {
            CategoryMgr myCategoryMgr = new CategoryMgr();

            if (myCategoryMgr.Count_Child_Category(_categoryid) > 0)
            {
                Tools.AlertMessage.Show_Alert(this.Page, "<h4>Selected category has child(s) category. <br/> Please move them before apply this action.</h4>", "Action failed!");
                return false;
            }

            if (myCategoryMgr.Sum_CategoryItems(_categoryid) > 0)
            {
                Tools.AlertMessage.Show_Alert(this.Page, "<h4>Selected category has item(s). <br/> Please move them before apply this action.</h4>", "Action failed!");
                return false;
            }

            if (_categoryid == "73B48270-1307-4A74-89E5-52143E82B9A9")
            {
                Tools.AlertMessage.Show_Alert(this.Page, "<h4>Selected category is created by system. <br/> Sorry you can not delete or rename system category.</h4>", "Action failed!");
                return false;
            }

            return true;
        }

    }
}