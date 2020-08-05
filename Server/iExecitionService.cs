using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Runtime.Serialization;

namespace Server
{
    [ServiceContract]
    public interface iExecitionService
    {
            [OperationContract]
            ExecutionResults CompileExecute(string programm);
    }

    [DataContract]
    public class ExecutionResults
    {
        [DataMember]
        public string CompilationOutput;

        [DataMember]
        public bool CompilationPassed;

        [DataMember]
        public bool ExecutionPassed;

        [DataMember]
        public int ReturnCode;

        [DataMember]
        public string RuntimeOutput;

        [DataMember]
        public string SessionKey;

        [DataMember]
        public System.Exception exception;

    }

}
