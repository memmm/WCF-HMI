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
    public class WPFProxy : IHMIService, IHMIserviceCallback
    {

        ChannelFactory<IHMIService> HMIServiceChannel = null;
        IHMIService service;

        public WPFProxy(FormMain fm)
        {
            try
            {
                var context = new InstanceContext(this);
                var binding = new NetTcpBinding();
                var endpoint = new EndpointAddress("net.tcp://localhost:8002/HmiService");
                HMIServiceChannel = new DuplexChannelFactory<IHMIService>(context, binding, endpoint);
                service = HMIServiceChannel.CreateChannel();
            }
            catch (InvalidOperationException ie)
            {
                Console.WriteLine(ie.Message);
            }
        }

        public void Connect()
        {
            service.Connect();

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

        public void NewClientConnected(int no)
        {
            Console.WriteLine("There are " + no + " client(s) connected to the service");
        }

        public void DataChanged(DeviceBase d)
        {

        }

    }
}
