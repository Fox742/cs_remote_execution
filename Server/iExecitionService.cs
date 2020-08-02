using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server
{
    [ServiceContract]
    public interface iExecitionService
    {
            [OperationContract]
            string Compile(string programm);
    }
}
