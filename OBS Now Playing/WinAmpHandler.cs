using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS_Now_Playing
{
    class WinAmpHandler : SourceHandler
    {
        private Process[] processlist;
        private string path;
        private bool noSong;
        private bool isVLCUp;
        private bool bStop;
        private TextBox preview;

        public WinAmpHandler(string p, TextBox preview)
        {
            path = p;
            bStop = false;
            this.preview = preview;
        }

        private Process findWinAmp()
        {
            Process spotify = null;
            processlist = Process.GetProcessesByName("winamp");

            if (processlist.Length == 0)
            {
                isVLCUp = false;
                Debug.WriteLine("\n\n\n\nDEBUG\n\n\n");
                return null;
            }
            else
            {
                foreach (Process process in processlist)
                {
                    if (process.ProcessName == "winamp")
                    {
                        if (process.MainWindowTitle != "")
                        {
                            spotify = process;
                            //Debug.WriteLine("{0} + {1}", "DEBUG", spotify.MainWindowTitle);
                            noSong = false;
                            isVLCUp = true;
                            if (process.MainWindowTitle == "winamp")
                            {
                                noSong = true;
                            }
                        }
                    }
                    else
                    {
                        isVLCUp = false;
                    }
                }
            }

            return spotify;
        }

        async public override Task pollForSongChanges()
        {
            while (!bStop)
            {
                // get the Spotify process (if it exists)
                System.IO.StreamWriter writer = new System.IO.StreamWriter(path);

                try
                {
                    Process s = findWinAmp();

                    string songName = s.MainWindowTitle;
                    //Debug.WriteLine("{0} + {1}", "DEBUG", s.MainWindowTitle);
                    if (!isVLCUp)
                    {
                        writer.WriteLine("winamp not open");
                        preview.Text = "winamp not open";
                    }
                    else if (noSong)
                    {
                        writer.WriteLine("Paused");
                        preview.Text = "Paused";
                    }
                    else
                    {
                        preview.Text = songName;
                        writer.WriteLine(songName);
                    }

                    writer.Close();

                }
                catch (NullReferenceException)
                {
                    writer.WriteLine("winamp not open");
                    preview.Text = "winamp not open";
                    writer.Close();
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
