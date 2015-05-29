using System.Threading.Tasks;
using iTunesLib;
using System.Windows.Forms;
using System.Diagnostics;

namespace OBS_Now_Playing
{
    class iTunesHandler : SourceHandler
    {
        private Process[] processlist;
        private string path;
        private bool noSong;
        private bool isItunesUp;
        private bool bStop;
        private TextBox preview;

        public iTunesHandler(string p, TextBox preview)
        {
            path = p;
            bStop = false;
            this.preview = preview;
        }

        private bool findItunes()
        {
            //Process itunes = null;
            processlist = Process.GetProcessesByName("iTunes");

            foreach (Process process in processlist)
            {
                if (process.ProcessName == "iTunes")
                {
                    if (process.MainWindowTitle != "")
                    {
                        //itunes = process;
                        isItunesUp = true;
                    }
                }
                else
                {
                    isItunesUp = false;
                }
            }
            return isItunesUp;
        }

        async public override Task pollForSongChanges()
        {
            while (!bStop)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(path);
                string songName;
                string artist;
                IITTrack ITrack;

                if (!findItunes())
                {
                    writer.WriteLine("iTunes not open");
                    preview.Text = "iTunes not open";
                }
                else
                {
                    iTunesApp iTunes = new iTunesApp();
                    ITrack = iTunes.CurrentTrack;
                    if (ITrack != null)
                    {
                        songName = ITrack.Name;
                        artist = ITrack.Artist;
                        writer.WriteLine(artist + " - " + songName);
                        preview.Text = artist + " - " + songName;
                    }
                    else
                    {
                        writer.WriteLine("Paused");
                        preview.Text = "Paused";
                    }
                }

                writer.Close();

                await Task.Delay(500);
            }
        }

        public override void stop()
        {
            bStop = true;
        }
    }
}
