using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus.Core.Tools
{
    public static class URLParse
    {
        /// <summary>
        /// Get Arg from URL
        /// </summary>
        /// <param name="URL">Full Path of URL</param>
        /// <returns>Arg part of URL</returns>
        public static string Get_Arg(string URL)
        {
            // Check exisit argements
            if (URL.Contains("?"))
            {
                // URL with argments
                string[] URLs = URL.Split('?');
                return URLs[1];
            }

            return "";
        }

        public static string Combine_Arg(string URL, string Arg)
        {

            if (String.IsNullOrEmpty(Arg))
                return URL;

            string _url;

            if (URL.Contains("?"))
            {
                _url = URL + "&" + Arg;
            }
            else
            {
                _url = URL + "?" + Arg;
            }

            return _url;
                
        }

        public static string Update_Arg(string URL, string Arg, string Value)
        {
            string _url;

            // Check exisit argements
            if (URL.Contains("?"))
            {
                // URL with argments
                string[] URLs = URL.Split('?');
                _url = URLs[0] + "?";

                // Check if argment contain updated value
                if (URLs[1].Contains(Arg))
                {
                    string[] Args = URLs[1].Split('&');

                    int _cycle = 0;
                    foreach (string _arg in Args)
                    {
                        if (_cycle != 0)
                        {
                            _url += "&";
                        }

                        string[] _args = _arg.Split('=');
                        if (_args[0] == Arg)
                        {
                            _url += Arg + "=" + Value;
                        }
                        else
                        {
                            _url += _arg;
                        }

                        _cycle++;
                    }
                }
                else
                {
                    // argment does not contain updated value
                    _url += URLs[1]
                        + "&"
                        + Arg
                        + "="
                        + Value;
                }
            }
            else
            {
                // URL without argments
                _url = URL
                    + "?"
                    + Arg
                    + "="
                    + Value;
            }

            return _url;

        }

        /// <summary>
        /// Return value of require param
        /// </summary>
        /// <param name="URL">Full Path of URL</param>
        /// <param name="Arg">Param you look for</param>
        /// <returns>Value of find Param or return null</returns>
        public static string Get_ArgValue(string URL, string Arg)
        {

            // Check exisit argements
            if (URL.Contains("?"))
            {
                // URL with argments
                string[] URLs = URL.Split('?');

                // Check if argment contain updated value
                if (URLs[1].Contains(Arg))
                {
                    string[] Args = URLs[1].Split('&');

                    foreach (string _arg in Args)
                    {
                        string[] _args = _arg.Split('=');
                        if (_args[0] == Arg)
                        {
                            return _args[1];
                        }

                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Remove requre param from args
        /// </summary>
        /// <param name="URL">Full Path of URL</param>
        /// <param name="Arg">Param you need to remove</param>
        /// <returns>URL after remove param</returns>
        public static string Remove_Arg(String URL, string Arg)
        {
            string _url;

            // Check exisit argements
            if (URL.Contains("?"))
            {
                // URL with argments
                string[] URLs = URL.Split('?');
                _url = URLs[0] + "?";

                // Check if argment contain updated value
                if (URLs[1].Contains(Arg))
                {
                    string[] Args = URLs[1].Split('&');

                    int _cycle = 0;
                    foreach (string _arg in Args)
                    {

                        string[] _args = _arg.Split('=');
                        if (_args[0] != Arg)
                        {
                            if (_cycle != 0)
                            {
                                _url += "&";
                            }
                            _url += _arg;
                        }

                        _cycle++;
                    }
                }
                else
                {
                    // argment does not contain updated value
                    _url += URLs[1];
                }
            }
            else
            {
                // URL without argments
                _url = URL;
            }

            return _url;

        }
    }
}
