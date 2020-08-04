using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {   
            try
            {
                using (ServerDriver _server = new ServerDriver())
                {
                    Console.WriteLine("Сервер запущен");
                    Console.ReadLine();
                }
            }
            catch(System.Exception Exc)
            {
                Logger.WriteLine("Получено исключение: " + Exc.Message);
            }
            Console.WriteLine("Работа сервера завершена. Нажмите Enter чтобы закрыть приложение");
            Console.ReadLine();
        }
    }
}
