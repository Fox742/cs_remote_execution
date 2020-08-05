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
    /// <summary>
    /// Интерфейс службы. Точка входа для клиентов службы
    /// </summary>
    [ServiceContract]
    public interface iExecitionService
    {
            /// <summary>
            /// Скомпилировать и запустить код в параметре programm
            /// </summary>
            /// <param name="programm"></param>
            /// <returns>Объект ExecutionResults, содержащий информацию о том, как прошла компиляция, исполнение программы и вывод компилятора и вывод программы</returns>
            [OperationContract]
            ExecutionResults CompileExecute(string programm);
    }

    [DataContract]
    public class ExecutionResults
    {
        /// <summary>
        /// Вывод компилятора
        /// </summary>
        [DataMember]
        public string CompilationOutput;

        /// <summary>
        /// Выполнилась ли компилция до конца? (Значение true этого поля означает, что был создан файл *.exe)
        /// </summary>
        [DataMember]
        public bool CompilationPassed;

        /// <summary>
        /// Была ли скомпилированная программа запущена?
        /// </summary>
        [DataMember]
        public bool ExecutionPassed;

        /// <summary>
        /// Код возврата, полученный после выполнения скомпилированной программы
        /// </summary>
        [DataMember]
        public int ReturnCode;

        /// <summary>
        /// Стандартный вывод программы при её исполнении
        /// </summary>
        [DataMember]
        public string RuntimeOutput;

        /// <summary>
        /// GUID-ключ вызова. Используется для хранения данных о конкретном вызове
        /// </summary>
        [DataMember]
        public string SessionKey;

        /// <summary>
        /// Исключение на стороне сервера, если оно произошло
        /// </summary>
        [DataMember]
        public System.Exception exception;

    }

}
