using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Nexus.Core.Tools
{
    public class AppItemTemplates
    {
        private string _itemtemplatepath;
        private string _alttemplatepath;
        private string _separator;
        private string _dataempty;

        public string ItemTemplatePath {
            set
            {
                _itemtemplatepath = value;
                Set_AltPath(_itemtemplatepath);
            }
            get { return _itemtemplatepath; } }

        public string AltPath { get { return _alttemplatepath; } }
        public string Separator { get { return _separator; } }
        public string DataEmpty { get { return _dataempty; } }

        public AppItemTemplates()
        {

        }

        public void Set_AltPath(string altpath)
        {
            _alttemplatepath = Get_ItemTemplatePath(_itemtemplatepath, altpath, "_Alt");
        }

        public void Set_Separator(string separator)
        {
            _separator = Get_ItemTemplatePath(_itemtemplatepath, separator, "_Separator");
        }

        public void Set_DataEmpty(string dataempty)
        {
            _dataempty = Get_ItemTemplatePath(_itemtemplatepath, dataempty, "_Empty");
        }

        private string Get_ItemTemplatePath(string _path, string _returnpath, string _appex)
        {
            if (_path.Length > 5)
            {
                string _filename = Path.GetFileNameWithoutExtension(_path);
                string _filepath = _path.Substring(0, _path.LastIndexOf("/"));
                string _altpath = _filepath + "/" + _filename + _appex + ".ascx";

                if (File.Exists(_altpath))
                {
                    return _altpath;
                }
                else
                {
                    return _returnpath;
                }
            }
            else
            {
                return _returnpath;
            }
        }

    }
}
