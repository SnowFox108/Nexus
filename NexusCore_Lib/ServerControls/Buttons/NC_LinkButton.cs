using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Core.ServerControls
{
    public class NC_LinkButton
    {
        #region Properties

        private string _iconurl;
        private LinkButton _linkbutton;
        private HyperLink _hlinkbutton;
        private Type _btnType;

        public string IconURL
        {
            get
            {
                if (_iconurl == null)
                {
                    return "";
                }
                return _iconurl;
            }
            set
            {
                _iconurl = value;
            }
        }

        public LinkButton LinkBtn
        {
            get
            {
                return _linkbutton;
            }
            set
            {
                _linkbutton = value;
            }
        }

        public HyperLink HlinkBtn
        {
            get
            {
                return _hlinkbutton;
            }
            set
            {
                _hlinkbutton = value;
            }
        }

        public Type BtnType
        {
            get
            {
                return _btnType;
            }
        }

        #endregion

        public NC_LinkButton()
        {

        }

        public NC_LinkButton(string IconURL, LinkButton LinkBtn, Type btnType)
        {
            _iconurl = IconURL;
            _linkbutton = LinkBtn;
            _btnType = btnType;
        }

        public NC_LinkButton(string IconURL, HyperLink HlinkBtn, Type btnType)
        {
            _iconurl = IconURL;
            _hlinkbutton = HlinkBtn;
            _btnType = btnType;
        }

    }
}
