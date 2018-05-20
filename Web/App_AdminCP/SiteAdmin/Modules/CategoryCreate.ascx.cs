using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Nexus.Core.Categories;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Modules_CategoryCreate : System.Web.UI.UserControl
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
                Control_Init();
            }

        }

        public void Control_Init()
        {
            #region Form Default Setting
            tbx_Category_Name.Text = "";
            CategoryTree_Parent_CategoryID.LoadCategoryRoot();
            #endregion
        }

        protected void btn_Add_Category_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string CategoryID = Tools.IDGenerator.Get_New_GUID();
                string Parent_CategoryID;

                if (DataEval.IsEmptyQuery(CategoryTree_Parent_CategoryID.Selected_CategoryID))
                    Parent_CategoryID = "-1";
                else
                    Parent_CategoryID = CategoryTree_Parent_CategoryID.Selected_CategoryID;

                CategoryMgr myCategoryMgr = new CategoryMgr();

                e2Data[] UpdateData = {
                                          new e2Data("CategoryID", CategoryID),
                                          new e2Data("Parent_CategoryID", Parent_CategoryID),
                                          new e2Data("Category_Name", tbx_Category_Name.Text)
                                      };

                myCategoryMgr.Add_Category(UpdateData);

                _categoryid = CategoryID;
                ViewState["CategoryID"] = _categoryid;

                OnCreateCategoryClick(sender, e);
            }

        }
    }
}