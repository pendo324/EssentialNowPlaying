using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NativeMessagingInterface
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class IPCServer : ITestContract
    {
        public string getSongName()
        {
            SongInfo si = Program._getSongName();
            return JsonConvert.SerializeObject(si);
        }

    }

}
