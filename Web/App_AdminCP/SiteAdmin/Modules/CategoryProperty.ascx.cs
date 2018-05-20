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
    public partial class App_AdminCP_SiteAdmin_Modules_CategoryProperty : System.Web.UI.UserControl
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
        private static readonly object CategoryEventClick = new object();

        [Category("Action")]
        [Description("Raised Create Command Clicked event")]
        public event EventHandler CategoryClick
        {
            add
            {
                Events.AddHandler(CategoryEventClick, value);
            }
            remove
            {
                Events.RemoveHandler(CategoryEventClick, value);
            }
        }

        protected void OnCategoryClick(object sender, EventArgs e)
        {
            EventHandler CategoryClickHandler = (EventHandler)Events[CategoryEventClick];

            if (CategoryClickHandler != null)
                CategoryClickHandler(sender, e);

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
            if (!DataEval.IsEmptyQuery(_categoryid))
            {
                CategoryMgr myCategoryMgr = new CategoryMgr();
                Category myCategory = myCategoryMgr.Get_Category(_categoryid);

                tbx_Category_Name.Text = myCategory.Category_Name;
                lbl_Modify.Enabled = true;

                MultiView_Modify.SetActiveView(View_Show);

            }
            else
            {
                lbl_Modify.Enabled = false;
            }
        }

        protected void lbl_Modify_Click(object sender, EventArgs e)
        {
            MultiView_Modify.SetActiveView(View_Update);
        }
        protected void lbl_Update_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                CategoryMgr myCategoryMgr = new CategoryMgr();

                e2Data[] UpdateData = {
                                          new e2Data("CategoryID", _categoryid),
                                          new e2Data("Category_Name", tbx_Category_Name.Text)
                                      };

                myCategoryMgr.Edit_Category(UpdateData);

                MultiView_Modify.SetActiveView(View_Show);

                OnCategoryClick(sender, e);
            }

        }
        protected void lbl_Cancel_Click(object sender, EventArgs e)
        {
            MultiView_Modify.SetActiveView(View_Show);
        }

        protected void CustomValidator_CategoryID_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (_categoryid == "73B48270-1307-4A74-89E5-52143E82B9A9")
            {
                args.IsValid = false;
            }
        }
    }
}