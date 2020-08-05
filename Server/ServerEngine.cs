using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Server
{
    // Класс для управления сервером. Ответственный за запуск и остановку сервиса
    class ServerDriver:IDisposable
    {
        private ServiceHost serviceDriver = null;

        private void InitService()
        {
            string URL = Settings.prefix + "://" + Settings.host + ":" + Settings.port + "/ExecutionService";
            serviceDriver = new ServiceHost(typeof(ExecutionService), new Uri(URL));
            
            // Включаем публикацию метадаты для нашей службы
            ServiceMetadataBehavior smb = serviceDriver.Description.Behaviors.Find<ServiceMetadataBehavior>();
            // If not, add one
            if (smb == null)
                smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            serviceDriver.Description.Behaviors.Add(smb);
            // Add MEX endpoint
            serviceDriver.AddServiceEndpoint(
              ServiceMetadataBehavior.MexContractName,
              MetadataExchangeBindings.CreateMexHttpBinding(),
              "mex"
            );

            // Добавляем конечную точку службы с заданным интерфейсом, привязкой (создаём новую) и адресом конечной точки
            serviceDriver.AddServiceEndpoint(typeof(iExecitionService), new WSHttpBinding(), "");
            // Запускаем службу
            serviceDriver.Open();
        }

        private void DeInitService()
        {
            if (serviceDriver != null)
            {
                serviceDriver.Close();
            }
        }

        public ServerDriver()
        {
            InitService();
         }
        
        public void Dispose()
        {
            DeInitService();
        }

    }
}
