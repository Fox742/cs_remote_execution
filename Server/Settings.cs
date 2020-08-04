using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Settings
    {
        public static string delimiter
        {
            get { return "/"; }
        }

        public static string host
        {
            get
            {
                return "localhost";
            }
        }

        public static string port
        {
            get
            {
                return "8000";
            }
        }
        
        public static string prefix
        {
            get
            {
                return "http";
            }
        }

        public static string rootPath
        {
            get
            {
                return "."+ delimiter +"execution_filesystem";
            }
        }

        public static string executionPath
        {
            get
            {
                return rootPath+  delimiter + "sessions";
            }
        }

        public static string compilerPath
        {
            get
            {
                return "C:\\WINDOWS\\Microsoft.NET\\Framework64\\v4.0.30319\\CSC.EXE";
            }
        }


    }
}
