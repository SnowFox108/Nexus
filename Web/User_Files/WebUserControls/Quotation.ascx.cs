﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Files_WebUserControls_Quotation : System.Web.UI.UserControl
{

    private bool _submited = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            _submited = Convert.ToBoolean(ViewState["Submited"]);
        }
        else
        {
            ViewState["Submited"] = _submited;
        }

        Control_Init();
    }

    private void Control_Init()
    {
        if (_submited)
            MultiView_EnquiryForm.SetActiveView(View_Submit);
        else
            MultiView_EnquiryForm.SetActiveView(View_Form);
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string Email_Content = string.Format(Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("e2Tech_EnquiryForm_Email"),
                rbtn_ProjectType.SelectedValue,
                rbtn_Budget.SelectedValue,
                tbx_Subject.Text,
                tbx_Enquiry.Text,
                tbx_SimilarWebsite.Text,
                tbx_FirstName.Text,
                tbx_LastName.Text,
                tbx_Email.Text,
                tbx_Telephone.Text,
                DateTime.Now.ToString()
                );

            Nexus.Core.Email.EmailMgr.SendMail(tbx_Email.Text,
                "service@e2tech.co.uk",
                "winsource6@hotmail.com",
                Email_Content,
                "Enquiry Service From e2Tech"
                );

            _submited = true;
            ViewState["Submited"] = _submited;

            MultiView_EnquiryForm.SetActiveView(View_Submit);

        }
    }
}