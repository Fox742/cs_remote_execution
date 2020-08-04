using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Operator
    {
        protected bool _operationCompleted = false;
        protected string _output = string.Empty;

        public bool Success
        {
            get
            {
                return _operationCompleted;
            }
        }

        public string Output
        {
            get
            {
                return _output;
            }
        }

    }
}
