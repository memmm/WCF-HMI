using contract.Devices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace contract
{
    [DataContract]
    public class SystemMode
    {
        [DataMember]
        public string Mode { get; set; }
    }

    [ServiceContract(Name="HmiService", Namespace = "service", CallbackContract = typeof(IHMIserviceCallback))]
    public interface IHMIService
    {
        [OperationContract]
        DeviceBase GetData(int devID);

        [OperationContract]
        ObservableCollection<DeviceBase> GetDeviceList();

        [OperationContract(IsOneWay = true)]
        void DeviceDataChanged(DeviceBase devb);

        [OperationContract(IsOneWay = true)]
        void Connect();

        [OperationContract]
        void Subscribe();

        [OperationContract]
        void Unsubscribe();
    }

      
    public interface IHMIserviceCallback
    {
        [OperationContract]
        void DataChanged(DeviceBase device);

        [OperationContract]
        void NewClientConnected(int nrConnectedClients);
    }
}
