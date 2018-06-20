using contract;
using contract.Devices;
using HmiStyle.MainScreens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace clientProxy
{
    public class WPFProxy : IHMIService
    {

        ChannelFactory<IHMIService> HMIServiceChannel = null;
        IHMIService service;

        public WPFProxy(FormMain fm)
        {
            try
            {
                var binding = new NetTcpBinding();
                var endpoint = new EndpointAddress("net.tcp://localhost:8002/HmiService");
                HMIServiceChannel = new DuplexChannelFactory<IHMIService>(fm, binding, endpoint);
                service = HMIServiceChannel.CreateChannel();
            }
            catch (InvalidOperationException ie)
            {
                Console.WriteLine(ie.Message);
            }
        }
     

        public DeviceBase GetData(int devID)
        {
            return service.GetData(devID);
        }

        public ObservableCollection<DeviceBase> GetDeviceList()
        {
            return service.GetDeviceList();
        }

        public void DeviceDataChanged(DeviceBase devb)
        {
            service.DeviceDataChanged(devb);
        }

        public void Subscribe()
        {
            service.Subscribe();
        }

        public void Unsubscribe()
        {
            service.Unsubscribe();
        }

    }
}
