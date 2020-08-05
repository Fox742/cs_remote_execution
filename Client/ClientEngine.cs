using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ClientEngine
    {
        private BaseUIWrapper _interfaceWrapper;
        private string outputDelimiter = "--------------------------\n";

        public ClientEngine(BaseUIWrapper interfaceWrapper)
        {
            _interfaceWrapper = interfaceWrapper;
        }

        public async void CompileExeciteService(string serviceAddress, string servicePort, string programm)
        {
            _interfaceWrapper.clearOutput();
            try
            {

                CompileExecuteResult cer = await Task.Run(()=> new CompileExecuteResult(serviceAddress, servicePort, programm));
                _interfaceWrapper.printToOutput(string.Format("Идентификатор удалённого вызова: {0}\n",cer.SessionKey));

                if (!string.IsNullOrEmpty(cer.CompilationOutput))
                {
                    _interfaceWrapper.printToOutput(outputDelimiter);
                    _interfaceWrapper.printToOutput("Логи удалённой сборки: \n");
                    _interfaceWrapper.printToOutput(cer.CompilationOutput);
                }
                if (cer.CompilationPassed)
                {
                    if (!string.IsNullOrEmpty(cer.RuntimeOutput))
                    {
                        _interfaceWrapper.printToOutput(outputDelimiter);
                        _interfaceWrapper.printToOutput("Логи удалённого исполнения: \n");
                        _interfaceWrapper.printToOutput(cer.RuntimeOutput);
                        _interfaceWrapper.printToOutput(string.Format("Код завершения на сервере: {0}\n", cer.ReturnCode));
                    }
                   
                }
                if (cer.exception!=null)
                {
                    _interfaceWrapper.printToOutput(outputDelimiter);
                    _interfaceWrapper.printToOutput(string.Format(
                        "Во время выполнения удалённого вызова на сервере произошло исключение\nОписание исключения: {0}\n",
                            cer.exception.Message)
                    );
                }

            }
            catch(Exception e)
            {
                _interfaceWrapper.printToOutput(string.Format(
                    "Произошло исключение при вызове сервиса. Проверьте доступность сервиса и его работоспособность, а также правильность написание адреса и порта.\nОписание исключения {0}\nСтек вызовов:{1}",
                    e.Message,
                    e.StackTrace)
                    );
            }

        }

    }
}
