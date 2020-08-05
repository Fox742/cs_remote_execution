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
                    Console.WriteLine("Сервер запущен. Нажмите клавишу Escape, чтобы его остановить");
                    Logger.whereIsLog();
                    while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                    {
                    }
                    // Вышли из цикла - хотим выйти из программы. метод Dispose у службы выполняется долго - до нескольких секунд, поэтому пишем, что нужно подождать
                    Console.WriteLine("Пожалуйста, подождите, сервер завершает свою работу...");
                }
            }
            catch(System.Exception Exc) // Перехватываем исключение о неисправности работы всей службы
            {
                Console.WriteLine("Получено исключение: " + Exc.Message);
            }
            Console.WriteLine("Работа сервера завершена. Нажмите Enter чтобы закрыть приложение");
            Console.ReadLine();
        }
    }
}
