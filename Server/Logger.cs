using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    
    class Logger
    {
        private class LoggerBase
        {
            public virtual void Clear()
            {

            }

            public virtual void WriteLine(string whatToPrint)
            {

            }

            public virtual string whereIsLog()
            {
                return "Лог не пишется";
            }
        }

        private class ConsoleLogger : LoggerBase
        {
            public override void Clear()
            {
                Console.Clear();
            }

            public override void WriteLine(string whatToPrint)
            {
                Console.WriteLine(whatToPrint);
            }

            public override string whereIsLog()
            {
                return "Лог пишется в консоль";
            }

        }

        private class FileLogger : LoggerBase
        {
            
            private string logFilename = "ServerLog.txt";
            private string fullLogfilename;

            public FileLogger()
            {
                string path = Settings.rootPath;
                fullLogfilename = FileSystemInspector.getFullPathDirectory(path) + Settings.delimiter + logFilename;

            }

            public override void WriteLine(string whatToPrint)
            {
                using (StreamWriter sw = File.AppendText(fullLogfilename))
                {
                    sw.WriteLine(whatToPrint);
                }
            }

            public override string whereIsLog()
            {
                return "Лог пишется в файл: "+fullLogfilename;
            }

        }

        private static LoggerBase _loggerInstance = null;

        static Logger()
        {
            _loggerInstance = new FileLogger();
        }

        public static void Clear()
        {
            _loggerInstance.Clear();
        }

        public static void WriteLine(string whatToPrint)
        {
            _loggerInstance.WriteLine(whatToPrint);
        }

        public static void whereIsLog()
        {
            Console.WriteLine(_loggerInstance.whereIsLog());
        }

    }
}
