using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    class FileSystemInspector
    {
        private static string rootPath = string.Empty;

        private static void touchPath(string path)
        {
            Directory.CreateDirectory(path);
        }

        static FileSystemInspector()
        {
            rootPath = Settings.rootPath;
            touchPath(rootPath);
        }

        public static string getSessionPath(string sessionKey)
        {
            string result = Settings.executionPath + Settings.delimiter+sessionKey;
            touchPath(result);
            return result;
        }

        public static string getFullPathDirectory(string relativePath)
        {
            string result;

            DirectoryInfo di = new DirectoryInfo(relativePath);

            return di.FullName;
        }

    }
}
