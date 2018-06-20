using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace contract.Devices
{

    [DataContract]
    [KnownType(typeof(Lamp))]
    [KnownType(typeof(Valve))]
    [KnownType(typeof(StackLight))]
    public class DeviceBase
    {

        public DeviceBase(string name)
        {
            Random r = new Random();
            DevID = r.Next(1000, 9000);
            DevName = name;
            
        }

        public ObservableCollection<DeviceBase> Devices { get; set; }

        int devID;
        string devName;


        [DataMember]
        public int DevID
        {
            get { return devID; }
            set { devID = value; }
        }

        [DataMember]
        public string DevName
        {
            get { return devName; }
            set { devName = value; }
        }
    }
}
