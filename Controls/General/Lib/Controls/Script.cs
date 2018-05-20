using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using Nexus.Core;
using System.ComponentModel;

namespace  Nexus.Controls.General.Lib
{
    // Script Enum
    public enum Script_Type
    {
        [StringValue("text/javascript")]
        Javascript,
        [StringValue("text/jscript")]
        Jscript,
        [StringValue("text/vbscript")]
        VBscript
    }

    // Script base class
    public class Script
    {
        private string _scriptid;
        private string _categoryid;
        private string _display_name;
        private Script_Type _script_type;
        private string _script_content;
        private string _create_date;
        private string _lastupdate_date;
        private string _lastupdate_userid;

        public string ScriptID { get { return _scriptid; } }
        public string CategoryID { get { return _categoryid; } }
        public string Display_Name { get { return _display_name; } }
        public Script_Type Script_Type { get { return _script_type; } }
        public string Script_Content { get { return _script_content; } }
        public string Create_Date { get { return _create_date; } }
        public string LastUpdate_Date { get { return _lastupdate_date; } }
        public string LastUpdate_UserID { get { return _lastupdate_userid; } }

        public Script(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _scriptid = myDR["ScriptID"].ToString();
                _categoryid = myDR["CategoryID"].ToString();
                _display_name = myDR["Display_Name"].ToString();
                _script_type = (Script_Type)StringEnum.Parse(typeof(Script_Type), myDR["Script_Type"].ToString(), true);
                _script_content = myDR["Script_Content"].ToString();
                _create_date = myDR["Create_Date"].ToString();
                _lastupdate_date = myDR["LastUpdate_Date"].ToString();
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();
            }

        }

    }

    public class ScriptMgr
    {
        public ScriptMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }

        public Script Get_Script_Content(string ScriptID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Script(myDP.Get_Script_Content(ScriptID));
        }

        public List<Script> Get_Scripts(string CategoryID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Scripts(CategoryID, SortOrder);

            List<Script> list = new List<Script>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Script(myDR));
            }

            return list;
        }

        public void Add_Script_Content(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Script_Content(UpdateData);
        }

        public void Edit_Script_Content(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Script_Content(UpdateData);

        }

        public void Remove_Script_Content(string ScriptID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Script_Content(ScriptID);
        }
    }

}
