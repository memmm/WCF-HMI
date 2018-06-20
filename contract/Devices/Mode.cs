using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace contract.Devices
{
    [DataContract]
    public class Mode
    {
        private string systemMode;

        [DataMember]
        public string SystemMode
        {
            get { return systemMode; }
            set { systemMode = value; }
        }

        public Mode(string m)
        {
            SystemMode = m;
        }
    }
}
