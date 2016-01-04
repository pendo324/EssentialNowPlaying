using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace NativeMessagingInterface
{
    public class Program
    {
        static SongInfo si;
        static void Main(string[] args)
        {
            // setup IPC to the main app
            string address = "net.pipe://localhost/flyinglawnmower/obsnp";

            ServiceHost serviceHost = new ServiceHost(typeof(IPCServer));
            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            serviceHost.AddServiceEndpoint(typeof(ITestContract), binding, address);
            serviceHost.Open();

            while (Read() != null || Read() != "")
            {
                si = JsonConvert.DeserializeObject<SongInfo>(Read());
            }
        }

        public static SongInfo _getSongName()
        {
            //MessageBox.Show(string.Format("player: {0}, song: {1}", si.player, si.song));
            return si;
        }

        private static string Read()
        {
            //// We need to read first 4 bytes for length information
            Stream stdin = Console.OpenStandardInput();
            int length = 0;
            byte[] bytes = new byte[4];
            stdin.Read(bytes, 0, 4);
            length = System.BitConverter.ToInt32(bytes, 0);

            string input = "";
            for (int i = 0; i < length; i++)
            {
                input += (char)stdin.ReadByte();
            }

            //MessageBox.Show("got " + input + " from Chrome");
            return input;
        }

        private static void Write(string stringData)
        {
            //// We need to send the 4 btyes of length information

            Dictionary<string, string> msg = new Dictionary<string, string>
            {
                {"text", stringData }
            };

            string msgdata = JsonConvert.SerializeObject(msg);

            int DataLength = msgdata.Length;
            Stream stdout = Console.OpenStandardOutput();
            stdout.WriteByte((byte)((DataLength >> 0) & 0xFF));
            stdout.WriteByte((byte)((DataLength >> 8) & 0xFF));
            stdout.WriteByte((byte)((DataLength >> 16) & 0xFF));
            stdout.WriteByte((byte)((DataLength >> 24) & 0xFF));
            //Available total length : 4,294,967,295 ( FF FF FF FF )

            //MessageBox.Show("sending " + msgdata + " to Chrome");
            Console.Write(msgdata);
        }

        private static void WriteSong(string player, string song)
        {
            //// We need to send the 4 btyes of length information

            Dictionary<string, string> msg = new Dictionary<string, string>
            {
                {"player", player},
                {"song", song}
            };

            string msgdata = JsonConvert.SerializeObject(msg);

            int DataLength = msgdata.Length;
            Stream stdout = Console.OpenStandardOutput();
            stdout.WriteByte((byte)((DataLength >> 0) & 0xFF));
            stdout.WriteByte((byte)((DataLength >> 8) & 0xFF));
            stdout.WriteByte((byte)((DataLength >> 16) & 0xFF));
            stdout.WriteByte((byte)((DataLength >> 24) & 0xFF));
            //Available total length : 4,294,967,295 ( FF FF FF FF )

            //MessageBox.Show("sending " + msgdata + " to Chrome");
            Console.Write(msgdata);
        }
    }
}

