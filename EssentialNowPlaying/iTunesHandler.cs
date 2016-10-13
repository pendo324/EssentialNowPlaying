using System.Threading.Tasks;
using iTunesLib;
using System.Windows.Forms;
using System.Diagnostics;

namespace Essential_Now_Playing
{
    class iTunesHandler : SourceHandler
    {
        private Process[] processlist;
        private string path;
        private bool isItunesUp;
        private bool bStop;
        private TextBox preview;
        private string oldName = null;

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
                
                string songName;
                string artist;
                string fullName;
                IITTrack ITrack;

                if (!findItunes())
                {
                    writeToPath(path, "iTunes not open", true);
                    //preview.Text = "iTunes not open";
                    oldName = null;
                }
                else
                {
                    iTunesApp iTunes = new iTunesApp();
                    ITrack = iTunes.CurrentTrack;
                    if (oldName != null)
                    {
                        if (ITrack != null)
                        {
                            songName = ITrack.Name;
                            artist = ITrack.Artist;
                            fullName = artist + " - " + songName + " ";
                            if (fullName != oldName)
                            {
                                writeToPath(path, fullName, true);
                                //preview.Text = fullName;
                                oldName = fullName;
                            }
                        }
                        else
                        {
                            writeToPath(path, "Paused", true);
                            //preview.Text = "Paused";
                            oldName = null;
                        }
                    }
                    else
                    {
                        // First run
                        if (ITrack != null)
                        {
                            songName = ITrack.Name;
                            artist = ITrack.Artist;
                            fullName = artist + " - " + songName + " ";
                            writeToPath(path, fullName, true);
                            //preview.Text = fullName;
                            oldName = fullName;
                        }
                        else
                        {
                            writeToPath(path, "Paused", true);
                            //preview.Text = "Paused";
                            oldName = null;
                        }
                    }
                }

                

                await Task.Delay(500);
            }
        }

        public override void stop()
        {
            bStop = true;
        }
    }
}
