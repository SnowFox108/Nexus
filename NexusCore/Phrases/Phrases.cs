using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Nexus.Core.Phrases
{
    public class Phrase
    {

        private string _phraseid;
        private string _language;
        private string _varname;
        private string _fieldname;
        private string _phrasename;
        private string _phrasevalue;
        private int _sortorder;
        private string _moduleid;

        public string PhraseID { get { return _phraseid; } }
        public string Language { get { return _language; } }
        public string VarName { get { return _varname; } }
        public string FieldName { get { return _fieldname; } }
        public string PhraseName { get { return _phrasename; } }
        public string PhraseValue { get { return _phrasevalue; } }
        public int SortOrder { get { return _sortorder; } }
        public string ModuleID { get { return _moduleid; } }

        public Phrase(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _phraseid = myDR["PhraseID"].ToString();
                _language = myDR["Language"].ToString();
                _varname = myDR["VarName"].ToString();
                _fieldname = myDR["FieldName"].ToString();
                _phrasename = myDR["PhraseName"].ToString();
                _phrasevalue = myDR["PhraseValue"].ToString();
                _sortorder = Convert.ToInt32(myDR["SortOrder"]);
                _moduleid = myDR["ModuleID"].ToString();

            }

        }

    }
}
