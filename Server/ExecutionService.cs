using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ExecutionService:iExecitionService
    {
        public ExecutionResults Compile(string programm)
        {
            ExecutionResults result = new ExecutionResults();

            string compilationOutput = "";
            bool compilationPassed = false;
            bool executionPassed = false;
            int returnCode=-1;
            string executionOutput = "";
            string sessionKey = "";

            ServiceEngine.Compile(programm, ref compilationOutput, ref compilationPassed, ref executionPassed, ref returnCode, ref executionOutput, ref sessionKey);

            result.CompilationOutput = compilationOutput;
            result.CompilationPassed = compilationPassed;
            result.ExecutionPassed = executionPassed;
            result.ReturnCode = returnCode;
            result.RuntimeOutput = executionOutput;
            result.SessionKey = sessionKey;

            return result;
        }
    }
}
