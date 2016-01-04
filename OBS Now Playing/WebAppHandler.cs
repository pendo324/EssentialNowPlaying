using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Newtonsoft.Json;

namespace OBS_Now_Playing
{
    // Event driven Handler for things that use the nowplaying.js script
    class WebAppHandler
    {
        Thread pr;
        private string path;
        private string webPlayer;
        private bool bStop;
        private bool isPluginOpen;
        private bool paused;
        private TextBox preview;
        ITestContract channel;

        delegate void SetPreviewCallback(string text);

        public void writeToPath(string path, string text)
        {
            System.IO.File.WriteAllText(path, text);
        }

        public void SetPreview(string text)
        {
            if (this.preview.InvokeRequired)
            {
                SetPreviewCallback d = new SetPreviewCallback(SetPreview);
                preview.Invoke(d, new object[] { text });
            }
            else
            {
                preview.Text = text;
            }
        }

        public WebAppHandler(string p, TextBox preview, string webPlayer)
        {
            string address = "net.pipe://localhost/flyinglawnmower/obsnp";

            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            EndpointAddress ep = new EndpointAddress(address);
            channel = ChannelFactory<ITestContract>.CreateChannel(binding, ep);

            path = p;
            bStop = false;
            isPluginOpen = true;
            this.preview = preview;
            this.webPlayer = webPlayer;
        }

        public void start()
        {
            pr = new Thread(new ThreadStart(pollForSongChanges));
            pr.Start();
        }

        public void pollForSongChanges()
        {
            while (true)
            {
                try
                {
                    SongInfo si = JsonConvert.DeserializeObject<SongInfo>(channel.getSongName());

                    if (si.player == webPlayer)
                    {
                        writeToPath(this.path, si.song);
                        SetPreview(si.song);
                    }
                    else
                    {
                        if (isPluginOpen)
                        {
                            writeToPath(this.path, string.Format("{0} not open.", webPlayer));
                            SetPreview(string.Format("{0} not open.", webPlayer));
                            isPluginOpen = false;
                        }
                    }

                }
                catch (Exception e)
                {
                    writeToPath(this.path, string.Format("{0} not open.", webPlayer));
                    SetPreview(string.Format("{0} not open.", webPlayer));
                }

                Thread.Sleep(500);
            }
        }

        public void stop()
        {
            pr.Abort();
        }

    }
}
