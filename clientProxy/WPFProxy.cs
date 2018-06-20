using contract;
using contract.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace clientProxy
{
    public class WPFProxy : IHMIService
    {

        IHMIService HMIServiceChannel = null;


        public WPFProxy()
        {
            try
            {
                IHMIService HMIServiceChannel = new ChannelFactory<IHMIService>().CreateChannel();
            }
            catch (InvalidOperationException ie)
            {
                Console.WriteLine(ie.Message);
            }
        }
     

        public DeviceBase GetData(int devID)
        {
            return HMIServiceChannel.GetData(devID);
        }

        public List<DeviceBase> GetDeviceList()
        {
            return HMIServiceChannel.GetDeviceList();
        }

        public void DeviceDataChanged(DeviceBase devb)
        {
            HMIServiceChannel.DeviceDataChanged(devb);
        }

        public void Subscribe()
        {
            HMIServiceChannel.Subscribe();
        }

        public void Unsubscribe()
        {
            HMIServiceChannel.Unsubscribe();
        }

    }
}
