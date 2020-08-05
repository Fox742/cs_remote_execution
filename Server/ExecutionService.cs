using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// Класс реализации WCF-службы.
    /// </summary>
    class ExecutionService:iExecitionService
    {
        public ExecutionResults CompileExecute(string programm)
        {
            ExecutionResults result = new ExecutionResults();

            string compilationOutput = "";
            bool compilationPassed = false;
            bool executionPassed = false;
            int returnCode=-1;
            string executionOutput = "";
            string sessionKey = "";
            Exception ServiceException = null;

            ServiceEngine.CompileExecute(programm, ref compilationOutput, ref compilationPassed, ref executionPassed, ref returnCode, ref executionOutput, ref sessionKey, ref ServiceException);

            result.CompilationOutput = compilationOutput;
            result.CompilationPassed = compilationPassed;
            result.ExecutionPassed = executionPassed;
            result.ReturnCode = returnCode;
            result.RuntimeOutput = executionOutput;
            result.SessionKey = sessionKey;
            result.exception = null;
            if (ServiceException != null)
            {
                result.exception = new Exception( ServiceException.Message );
            }
            return result;
        }
    }
}
