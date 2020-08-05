using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Server
{
    /// <summary>
    /// Обёртка класса Process, испольняющая заданную программу в своём конструкторе и хранящая результаты исполнения приложения
    /// </summary>
    class ProcessDriver:IDisposable
    {
        private string _standardOutput = "";
        private int _returnCode = -1;

        /// <summary>
        /// Код возврата приложения, которое было запущено
        /// </summary>
        public int returnCode
        {
            get
            {
                return _returnCode;
            }
        }

        /// <summary>
        /// Стандартный вывод приложения, которое было выполнено 
        /// </summary>
        public string standardOutput
        {
            get
            {
                return _standardOutput;
            }
        }

        private Process _process = null;

        /// <summary>
        /// Конструктор подготавливает класс Process для исполнения команды command
        /// </summary>
        /// <param name="command">Команда, которую надо выполнить (или имя экзешника)</param>
        /// <param name="workingDirectory"></param>
        /// <param name="Arguments"></param>
        public ProcessDriver(string command, string workingDirectory="", string Arguments = "")
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo(command, Arguments);

            if (workingDirectory != "")
            {
                procStartInfo.WorkingDirectory = workingDirectory;
            }
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            _process = new System.Diagnostics.Process();
            _process.StartInfo = procStartInfo;
        }
        
        /// <summary>
        /// Выполнить программу, которую мы указали в конструкторе
        /// </summary>
        public void execute()
        {
            _process.Start();
            _process.WaitForExit();
            _standardOutput = _process.StandardOutput.ReadToEnd();
            _returnCode = _process.ExitCode;
        }

        public void Dispose()
        {
            if (_process != null)
                _process.Dispose();
        }

    }
}
