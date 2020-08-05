using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Server
{
    /// <summary>
    /// Класс осуществляющий выполнение скомпилированной на предыдущем шаге программы и хранящий информацию об исполнении программы
    /// </summary>
    class Executor:Operator
    {
        private static string executionLogName = "ExecutionLog.log";
        private int _returnCode = -1;

        /// <summary>
        /// Код возврата выполненной программы
        /// </summary>
        public int returnCode
        {
            get
            {
                return _returnCode;
            }
        }

        /// <summary>
        /// Выполнить программу и сохранить результаты выполнения
        /// </summary>
        /// <param name="path">Путь к директории, в которой находится exe-файл</param>
        /// <param name="exeName">Имя исполняемого файла, который нужно исполнить</param>
        public Executor(string path, string exeName)
        {
            string _fullPathDirectory = FileSystemInspector.getFullPathDirectory(path);
            string _fullPathExe = _fullPathDirectory +Settings.delimiter+exeName;

            // Исполняем exe-файл
            using (ProcessDriver pd = new ProcessDriver(_fullPathExe))
            {
                pd.execute();
                _output = pd.standardOutput;
                _returnCode = pd.returnCode;
            }

            // Записываем  вывод программы в файл
            File.WriteAllText(_fullPathDirectory + Settings.delimiter + executionLogName, _output);
            _operationCompleted = true;
        }

    }
}
