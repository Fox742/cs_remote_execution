using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ExecutionService:iExecitionService
    {
        public string Compile(string programm)
        {
            Console.WriteLine(programm);
            return new String(programm.Reverse<char>().ToArray<char>());
        }
    }
}
