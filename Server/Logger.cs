using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private static LoggerBase _loggerInstance = null;

        static Logger()
        {
            _loggerInstance = new ConsoleLogger();
        }

        public static void Clear()
        {
            _loggerInstance.Clear();
        }

        public static void WriteLine(string whatToPrint)
        {
            _loggerInstance.WriteLine(whatToPrint);
        }

    }
}
