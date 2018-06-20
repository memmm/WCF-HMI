using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace contract.Devices
{
    [DataContract]
    public class Valve : DeviceBase
    {
        public Valve(string name, bool open) : base(name)
        {           
            Opened = open;
        }

        bool opened;

        [DataMember]
        public bool Opened
        {
            get { return opened; }
            set { opened = value; }
        }


       
    }
}
