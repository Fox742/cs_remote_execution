using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Server
{
    /// <summary>
    /// Класс, обеспечивающий предоставление настроек и констант работает с ConfigurationManager-ом
    /// </summary>
    class Settings
    {
        public static string delimiter
        {
            get { return ConfigurationManager.AppSettings["delimiter"]; }
        }

        public static string host
        {
            get
            {
                return ConfigurationManager.AppSettings["host"];
            }
        }

        public static string port
        {
            get
            {
                return ConfigurationManager.AppSettings["port"];
            }
        }
        
        public static string prefix
        {
            get
            {
                return ConfigurationManager.AppSettings["prefix"];
            }
        }

        public static string rootPath
        {
            get
            {
                return "."+ delimiter + ConfigurationManager.AppSettings["rootFolder"];
            }
        }

        public static string executionPath
        {
            get
            {
                return rootPath+  delimiter +ConfigurationManager.AppSettings["executionFolder"];
            }
        }

        public static string compilerPath
        {
            get
            {
                return ConfigurationManager.AppSettings["compilerPath"];
            }
        }
    }
}
