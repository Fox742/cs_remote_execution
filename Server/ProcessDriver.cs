using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Server
{
    class ProcessDriver:IDisposable
    {
        private string _standardOutput = "";
        private int _returnCode = -1;

        public int returnCode
        {
            get
            {
                return _returnCode;
            }
        }


        public string standardOutput
        {
            get
            {
                return _standardOutput;
            }

        }

        private Process _process = null;

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
