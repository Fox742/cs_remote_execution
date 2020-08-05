using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class WinFormsUIWrapper:BaseUIWrapper
    {
        public WinFormsUIWrapper(Form1 winFormsInterface):base(winFormsInterface)
        {

        }
        
        public override void printToOutput(string whatToPrint)
        {
            ((Form1)_interface).addTextToOutput(whatToPrint);
        }

        public override void clearOutput()
        {
            ((Form1)_interface).clearOutput();
        }
    }


}
