using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Reflection;

namespace Nexus.Core.Phrases
{
    public class PhraseMgr
    {
        public PhraseMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public static List<Phrase> Get_Phrases(string FieldName, string SortOrder, string ModuleID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Phrases(FieldName, SortOrder, ModuleID);

            List<Phrase> list = new List<Phrase>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Phrase(myDR));
            }

            return list;

        }

        public static List<Phrase> Get_Phrases(string FieldName, string Language, string SortOrder, string ModuleID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Phrases(FieldName, Language, SortOrder, ModuleID);

            List<Phrase> list = new List<Phrase>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Phrase(myDR));
            }

            return list;

        }

        public static Phrase Get_Phrase(string VarName)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Phrase(myDP.Get_Phrase(VarName));
        }

        public static Phrase Get_Phrase(string VarName, string Language)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Phrase(myDP.Get_Phrase(VarName, Language));
        }

        public static string Get_Phrase_Value(string VarName)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            Phrase myPhrase = new Phrase(myDP.Get_Phrase(VarName));

            return myPhrase.PhraseValue;

        }

        public static string Get_Phrase_Value(string VarName, string Language)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            Phrase myPhrase = new Phrase(myDP.Get_Phrase(VarName, Language));

            return myPhrase.PhraseValue;

        }

        public void Add_Phrase(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Phrase(UpdateData);
        }

        public void Edit_Phrase(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Phrase(UpdateData);

        }

        /// <summary>
        /// Update set of phrase value
        /// </summary>
        /// <param name="UpdateData">Update Phrase</param>
        public void Edit_Phrases(e2Data[] UpdateData)
        {
            foreach (e2Data myData in UpdateData)
            {
                Phrase myPhrase = Get_Phrase(myData.FieldName);

                e2Data[] _updatedata = {
                                           new e2Data("PhraseID", myPhrase.PhraseID),
                                           new e2Data("PhraseValue", myData.FieldValue)
                                       };

                Edit_Phrase(_updatedata);
            }
        }

        public void Remove_Phrase(string PhraseID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Phrase(PhraseID);
        }


    }
}
