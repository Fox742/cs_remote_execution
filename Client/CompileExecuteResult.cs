using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Client
{
    class CompileExecuteResult
    {

        public readonly string CompilationOutput;
        public readonly bool CompilationPassed;
        public readonly bool ExecutionPassed;
        public readonly int ReturnCode;
        public readonly string RuntimeOutput;
        public readonly string SessionKey;
        public readonly System.Exception exception;


        public CompileExecuteResult( string address, string port, string programm)
        {
            ExecutionService.ExecutionResults results = new ExecutionService.iExecitionServiceClient(new WSHttpBinding(), new EndpointAddress("http://"+ address +":"+ port +"/ExecutionService")).CompileExecute(programm);

            CompilationOutput = results.CompilationOutput;
            CompilationPassed = results.CompilationPassed;
            ExecutionPassed = results.ExecutionPassed;
            ReturnCode = results.ReturnCode;
            RuntimeOutput = results.RuntimeOutput;
            SessionKey = results.SessionKey;
            exception = results.exception;
        }
        
    }
}
