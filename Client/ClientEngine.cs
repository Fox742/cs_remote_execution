using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Основной класс программы
    /// </summary>
    class ClientEngine
    {
        private BaseUIWrapper _interfaceWrapper;
        private string outputDelimiter = "--------------------------\n";

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="interfaceWrapper">Ссылка на базовый класс-обёртку интерфейса</param>
        public ClientEngine(BaseUIWrapper interfaceWrapper)
        {
            _interfaceWrapper = interfaceWrapper;
        }

        /// <summary>
        /// Метод обращается к службе WCF, получает данные от неё и выводит их в интерфейс через обёртку, полученную в конструкторе
        /// </summary>
        /// <param name="serviceAddress">Адрес службы (без префикса)</param>
        /// <param name="servicePort">Порт службы</param>
        /// <param name="programm">Текст программы, которую нужно скомпилировать и запустить</param>
        public async void CompileExeciteService(string serviceAddress, string servicePort, string programm)
        {
            _interfaceWrapper.clearOutput();
            try
            {
                // Обращаемся через обёртку к службе
                CompileExecuteResult cer = await Task.Run(()=> new CompileExecuteResult(serviceAddress, servicePort, programm));

                // Печатаем идентификатор удалённого вызова. По этому идентификатору на сервере можно найти директорию, в которой хранится текст программы, её exe и результаты
                _interfaceWrapper.printToOutput(string.Format("Идентификатор удалённого вызова: {0}\n",cer.SessionKey));

                // Если есть вывод от компилятора - выводим его в интерфейс
                if (!string.IsNullOrEmpty(cer.CompilationOutput))
                {
                    _interfaceWrapper.printToOutput(outputDelimiter);
                    _interfaceWrapper.printToOutput("Логи удалённой сборки: \n");
                    _interfaceWrapper.printToOutput(cer.CompilationOutput);
                }
                // Если программа не была скомпилирована - нет смысла выводить результаты её исполнения
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
                // Если на стороне сервера произошло исключение, то печатаем его
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
                // А тут мы перехватываем исключение, если оно произошло уже на нашей стороне при недоступности сервера
                _interfaceWrapper.printToOutput(string.Format(
                    "Произошло исключение при вызове сервиса. Проверьте доступность сервиса и его работоспособность, а также правильность написание адреса и порта.\nОписание исключения {0}\nСтек вызовов:{1}",
                    e.Message,
                    e.StackTrace)
                    );
            }

        }

    }
}
