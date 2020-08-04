using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Server
{
    class Executor:Operator
    {
        private static string executionLogName = "ExecutionLog.log";

        public Executor(string path, string exeName)
        {
            string _fullPathDirectory = FileSystemInspector.getFullPathDirectory(path);
            string _fullPathExe = _fullPathDirectory +Settings.delimiter+exeName;
            using (ProcessDriver pd = new ProcessDriver(_fullPathExe))
            {
                pd.execute();
                _output = pd.standardOutput;
            }
            // Записываем в compilation log логи компиляции
            File.WriteAllText(_fullPathDirectory + Settings.delimiter + executionLogName, _output);
            _operationCompleted = true;
        }

    }
}
