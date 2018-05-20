using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web;

namespace Nexus.Security.Pages
{

    [DataObject(true)]
    public class PrivacyMgr
    {
        public PrivacyMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region Get

        public Page_PrivacyURL Get_Page_PrivacyURL(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_PrivacyURL(myDP.Get_Page_PrivacyURL(PageIndexID));
        }

        public List<Page_Privacy> Get_Page_Privacies(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Page_Privacies(PageIndexID);

            List<Page_Privacy> list = new List<Page_Privacy>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Page_Privacy(myDR));
            }

            return list;

        }

        public Page_Privacy Get_Page_Privacy(string PrivacyID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Privacy(myDP.Get_Page_Privacy(PrivacyID));
        }

        public Page_Privacy Get_Page_Privacy(string PageIndexID, string UserGroupID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Privacy(myDP.Get_Page_Privacy(PageIndexID, UserGroupID));
        }

        public List<Page_Privacy_Full> Get_Page_Privacy_FullList(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Page_Privacy_FullList(PageIndexID);

            List<Page_Privacy_Full> list = new List<Page_Privacy_Full>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Page_Privacy_Full(myDR));
            }

            return list;

        }

        public Page_Privacy_Full Get_Page_Privacy_Full(string PrivacyID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Privacy_Full(myDP.Get_Page_Privacy_Full(PrivacyID));
        }

        public bool Chk_Page_Privacy(string PageIndexID, string UserGroupID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Page_Privacy(PageIndexID, UserGroupID);
        }

        public bool Chk_Page_PrivacyURL(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Page_PrivacyURL(PageIndexID);
        }

        #endregion

        #region Add

        public void Add_Page_PrivacyURL(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_PrivacyURL(UpdateData);
        }

        public void Add_Page_Privacy(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Page_Privacy(UpdateData);
        }

        #endregion

        #region Update

        public void Edit_Page_PrivacyURL(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_PrivacyURL(UpdateData);
        }

        public void Edit_Page_Privacy(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Page_Privacy(UpdateData);
        }

        #endregion

        #region Delete

        public void Remove_Page_PrivacyURL(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_PrivacyURL(PageIndexID);
        }

        public void Remove_Page_Privacies(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Privacies(PageIndexID);
        }

        public void Remove_Page_Privacy(string PrivacyID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Page_Privacy(PrivacyID);
        }

        #endregion

        private PageIndex Get_PageIndex(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new PageIndex(myDP.Get_PageIndex(PageIndexID));
        }

        private Page_Property Get_Page_Property(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Page_Property(myDP.Get_Page_Property(PageIndexID));
        }

        public string Get_Inherited_Privacy_PageIndexID(string PageIndexID)
        {
            Page_Property myProperty = Get_Page_Property(PageIndexID);

            if (myProperty.IsPrivacy_Inherited)
            {

                PageIndex myIndex = Get_PageIndex(PageIndexID);

                return Get_Inherited_Privacy_PageIndexID(myIndex.Parent_PageIndexID);

            }
            else
            {
                return PageIndexID;
            }
        }

    }
}
