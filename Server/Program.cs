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
            // Инициализируем службу, указываем адрес, по которому она будет доступна
            ServiceHost host = new ServiceHost(typeof(ExecutionService), new Uri("http://localhost:8000/ExecutionService"));
            try
            {
                // Включаем публикацию метадаты для нашей службы
                // Check to see if the service host already has a ServiceMetadataBehavior
                ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                // If not, add one
                if (smb == null)
                    smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);
                // Add MEX endpoint
                host.AddServiceEndpoint(
                  ServiceMetadataBehavior.MexContractName,
                  MetadataExchangeBindings.CreateMexHttpBinding(),
                  "mex"
                );

                // Добавляем конечную точку службы с заданным интерфейсом, привязкой (создаём новую) и адресом конечной точки
                host.AddServiceEndpoint(typeof(iExecitionService), new WSHttpBinding(), "");
                // Запускаем службу
                host.Open();
                Console.WriteLine("Сервер запущен");
                Console.ReadLine();
                // Закрываем службу
                host.Close();
            }
            catch(System.Exception Exc)
            {
                Console.WriteLine("Получено исключение:" + Exc.Message);
            }
        }
    }
}
