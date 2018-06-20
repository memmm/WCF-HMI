using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace contract.Devices
{
    [DataContract]
    public class Lamp : DeviceBase
        {
            public Lamp(int id, string name, bool steady, bool blslow, bool blfast) : base(name)
            {           
                SteadyOn = steady;
                BlinkingFast = blfast;
                BlinkingSlow = blslow;
                
                
            }

            bool steadyOn;
            bool blinkingSlow;
            bool blinkingFast;
            string lampColor = "#f4f4f4";

            [DataMember]
            public bool SteadyOn
            {
                get { return steadyOn; }
                set { steadyOn = value; }
            }

            [DataMember]
            public bool BlinkingFast
            {
                get { return blinkingFast; }
                set { blinkingFast = value; }
            }

            [DataMember]
            public bool BlinkingSlow
            {
                get { return blinkingSlow; }
                set { blinkingSlow = value; }
            }

            [DataMember]
            public string LampColor
            {
                get { return lampColor; }
                set { lampColor = value; }
            }

    }
}
