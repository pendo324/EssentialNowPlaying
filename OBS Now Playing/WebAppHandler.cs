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
        private TextBox preview;
        HttpListener listener;

        delegate void SetPreviewCallback(string text);

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
            path = p;
            bStop = false;
            isPluginOpen = true;
            this.preview = preview;
            this.webPlayer = webPlayer;
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:13337/");
        }

        public void start()
        {
            pr = new Thread(new ThreadStart(pollForSongChanges));
            pr.Start();
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            context.Response.AppendHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

            StreamWriter writer = new System.IO.StreamWriter(path);

            // Get the data from the HTTP stream
            var body = new StreamReader(context.Request.InputStream).ReadToEnd();

            Console.WriteLine("\n DEBUG: " + body);

            if (body.Length > 0)
            {
                Dictionary<string, string> postParams = new Dictionary<string, string>();
                string[] rawParams = body.Split('&');
                foreach (string param in rawParams)
                {
                    string[] kvPair = param.Split('=');
                    string key = kvPair[0];
                    string value = System.Web.HttpUtility.UrlDecode(kvPair[1]);
                    postParams.Add(key, value);
                }

                string wp = postParams["player"];
                string songName = postParams["song"];

                string[] songs;

                songs = songName.Split(new string[] { (" - ") }, StringSplitOptions.None);

                if (wp == webPlayer)
                {
                    writer.WriteLine(songName);
                    SetPreview(songName);
                }
                else
                {
                    writer.WriteLine("{0} not open.", wp);
                    SetPreview(string.Format("{0} not open.", wp));
                }
            }

            context.Response.Close();
            writer.Close();
        }

        public void pollForSongChanges()
        {
            try
            {
                listener.Start();
            }
            catch (HttpListenerException)
            {
                return;
            }
            while (listener.IsListening)
            {
                var context = listener.GetContext();
                ProcessRequest(context);
            }
            listener.Close();
        }

        public void stop()
        {
            listener.Close();
            pr.Abort();
        }

    }
}
