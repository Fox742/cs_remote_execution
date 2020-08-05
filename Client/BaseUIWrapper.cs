using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    abstract class  BaseUIWrapper
    {
        protected object _interface;

        public BaseUIWrapper(object interfaceLink)
        {
            _interface = interfaceLink;
        }

        public abstract void printToOutput(string whatToPrint);

        public abstract void clearOutput();

    }
}
