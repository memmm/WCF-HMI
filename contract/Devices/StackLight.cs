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
    public class StackLight : DeviceBase
    {

        public StackLight(int id, string name) : base(name)
        {
            this.Devices = new ObservableCollection<DeviceBase>
            {
                FirstLamp,
                SecondLamp,
                ThirdLamp,
                FourthLamp
            };

        }

        [DataMember]
        public Lamp FirstLamp { get; set; }

        [DataMember]
        public Lamp SecondLamp { get; set; }

        [DataMember]
        public Lamp ThirdLamp { get; set; }

        [DataMember]
        public Lamp FourthLamp { get; set; }
    }
}
