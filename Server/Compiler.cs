using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Server
{
    class Compiler
    {
        private static string textOfProgrammName = "ClientProgramm.cs";
        private static string exeName = "ClientProgramm.exe";
        private static string compilationNameLog = "CompilationLog.log";


        private bool _wasCompilation = false;
        private string _path;
        private string _fullPath;
        private string _output = string.Empty;

        public bool Success
        {
            get
            {
                return _wasCompilation;
            }
        }

        public string Output
        {
            get
            {
                return _output;
            }
        }

        public Compiler(string path, string programm)
        {
            _path = path;
            _fullPath = FileSystemInspector.getFullPathDirectory(_path);

            // Записываем текст программы в файл
            File.WriteAllText(_path + Settings.delimiter + textOfProgrammName, programm);

            // Делаем компиляцию
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo( Settings.compilerPath,  textOfProgrammName);
            procStartInfo.WorkingDirectory = _fullPath;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            _output = proc.StandardOutput.ReadToEnd();

            // Записываем в compilation log логи окмпиляции
            File.WriteAllText(_path + Settings.delimiter+compilationNameLog,_output);

            if (File.Exists(_path + Settings.delimiter + exeName))
            {
                _wasCompilation = true;
            }
        }

    }
}
