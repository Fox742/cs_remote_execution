using System;

namespace Server
{
    class BaseServiceEngine
    {
        public virtual void CompileExecute(
            string _program,
            ref string _compilationOutput,
            ref bool _compilationPassed,
            ref bool _executionPassed,
            ref int _returnCode,
            ref string _executionOutput,
            ref string _sessionKey,
            ref Exception ServiceException
        )
        {

        }
    }

    class InstanceServiceEngine:BaseServiceEngine
    {
        public override void CompileExecute(
            string _program,
            ref string _compilationOutput,
            ref bool _compilationPassed,
            ref bool _executionPassed,
            ref int _returnCode,
            ref string _executionOutput,
            ref string _sessionKey,
            ref Exception ServiceException
    )
        {
            // Генерация GUID-а
            _sessionKey = Guid.NewGuid().ToString();
            Logger.WriteLine(DateTime.Now.ToString()+" "+_sessionKey+" << income");
            try
            {
                string sessionPath = FileSystemInspector.getSessionPath(_sessionKey);

                // Запускаем компиляцию
                Compiler _compiler = new Compiler(sessionPath, _program);
                // Компиляция присланной программы выполняется в конструкторе класса Compiler, поэтому в этой точке мы уже можем получить информацию о том как прошла компиляция и вывод компилятора
                _compilationOutput = _compiler.Output;
                if (_compiler.Success)
                {
                    Logger.WriteLine(DateTime.Now.ToString() + " " + _sessionKey + " compilation passed successfully" );
                    _compilationPassed = true;

                    // Исполнение
                    Executor _executor = new Executor(sessionPath, _compiler.name);
                    // Выполнение программы также происходит в конструкторе класса Executor, 
                    //    поэтому после отработки его конструктора мы уже можем получить информацию о том как прошло выполнение программы
                    _executionOutput = _executor.Output;
                    _returnCode = _executor.returnCode;
                    if (_executor.Success)
                    {
                        Logger.WriteLine(DateTime.Now.ToString() + " " + _sessionKey + " execution passed successfully");
                        _executionPassed = true;
                    }
                    else
                    {
                        Logger.WriteLine(DateTime.Now.ToString() + " " + _sessionKey + " execution failed");
                    }
                }
                else
                {
                    Logger.WriteLine(DateTime.Now.ToString() + " " + _sessionKey + " compilation failed");
                }

            }
            catch (System.Exception e)
            {
                // Произошло исключение - мы должны записать его чтобы вернуть клиенту
                Logger.WriteLine(DateTime.Now.ToString() + " " + _sessionKey + " Exception: "+e.ToString());
                ServiceException = e;
                return;
            }
            Logger.WriteLine(DateTime.Now.ToString() + " " + _sessionKey + " >> completed");
        }
    }

    /// <summary>
    /// Класс, реализующий логику сервиса
    /// </summary>
    class ServiceEngine
    {
        private static BaseServiceEngine _instance = null;
        static ServiceEngine()
        {
            _instance = new InstanceServiceEngine();
        }

        public static void CompileExecute(
            string _program, 
            ref string _compilationOutput, 
            ref bool _compilationPassed, 
            ref bool _executionPassed, 
            ref int _returnCode, 
            ref string _executionOutput, 
            ref string _sessionKey,
            ref Exception ServiceException
        )
        {
            _instance.CompileExecute(_program, ref _compilationOutput, ref _compilationPassed, ref _executionPassed, ref _returnCode, ref _executionOutput, ref _sessionKey, ref ServiceException);
        }
    }
}