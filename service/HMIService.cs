using contract;
using contract.Devices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class HMIService : IHMIService
    {
        public ObservableCollection<DeviceBase> DeviceList = new ObservableCollection<DeviceBase>();
        static List<IHMIserviceCallback> clientList = new List<IHMIserviceCallback>();
        static Action<DeviceBase> m_Event1 = delegate { };

        public HMIService()
        {
            StackLight FirstStackLight = new StackLight(1, "FirstStackLight")
            {
                FirstLamp = new Lamp(1, "FirstLamp", true, false, false),
                SecondLamp = new Lamp(2, "SecondLamp", false, false, true),
                ThirdLamp = new Lamp(3, "ThirdLamp", false, true, false)
            };

            DeviceList.Add(FirstStackLight);

            DeviceList.Add(new Valve("FirstOtherDevice", true));
            DeviceList.Add(new Valve("SecondMotor", true));
            DeviceList.Add(new Valve("ThirdValve", false));            
        }

        public void Connect()
        {
            IHMIserviceCallback proxyToClient = OperationContext.Current.GetCallbackChannel<IHMIserviceCallback>();
            //Check if user already connected
            if (!clientList.Contains(proxyToClient))
            {
                clientList.Add(proxyToClient);
                 
            }

        }

        public DeviceBase GetData(int devIndex)
        {
            if (DeviceList.Contains(DeviceList[devIndex]))
            {
                DeviceBase chosenDevice = DeviceList[devIndex];
                return chosenDevice;
            }
            else return null;
        }

        public ObservableCollection<DeviceBase> GetDeviceList()
        {
            return DeviceList;
        }

        public void DeviceDataChanged(DeviceBase devb)
        {
            for (int i = 0; i < DeviceList.Count; i++)
            {
                if (DeviceList[i].DevName == devb.DevName)
                {
                    DeviceList[i] = devb;
                    m_Event1(DeviceList[i]);
                }
            }
        }

        public static void Notify(string mode)
        {
            Mode sysmode = new Mode(mode);
            Console.WriteLine(sysmode.SystemMode);
        }

        public void Subscribe()
        {
            IHMIserviceCallback subscriber = OperationContext.Current.GetCallbackChannel<IHMIserviceCallback>();
            m_Event1 += subscriber.DataChanged;

        }

        public void Unsubscribe()
        {
            IHMIserviceCallback subscriber = OperationContext.Current.GetCallbackChannel<IHMIserviceCallback>();
            m_Event1 -= subscriber.DataChanged;

        }
    }
}
