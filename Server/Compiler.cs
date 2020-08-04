using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Server
{
    class Compiler:Operator
    {
        private static string textOfProgrammName = "ClientProgramm.cs";
        private static string exeName = "ClientProgramm.exe";
        private static string compilationNameLog = "CompilationLog.log";
        
        private string _path;
        private string _fullPath;

        private string _name = string.Empty;
        
        public string name
        {
            get
            {
                return _name;
            }
        }

        public Compiler(string path, string programm)
        {
            _path = path;
            _fullPath = FileSystemInspector.getFullPathDirectory(_path);

            // Записываем текст программы в файл
            File.WriteAllText(_path + Settings.delimiter + textOfProgrammName, programm);

            // Делаем компиляцию
            using (ProcessDriver pd = new ProcessDriver(Settings.compilerPath, _fullPath, textOfProgrammName))
            {
                pd.execute();
                _output = pd.standardOutput;
            }

            // Записываем в compilation log логи компиляции
            File.WriteAllText(_path + Settings.delimiter+compilationNameLog,_output);

            if (File.Exists(_path + Settings.delimiter + exeName))
            {
                _name = exeName;
                _operationCompleted = true;
            }
        }

    }
}
