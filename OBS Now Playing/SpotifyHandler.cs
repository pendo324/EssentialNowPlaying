using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace OBS_Now_Playing
{
    class SpotifyHandler : SourceHandler
    {
        private Process[] processlist;
        private string path;
        private bool noSong;
        private bool bStop;
        private bool isSpotifyUp;
        private TextBox preview;

        public SpotifyHandler(string p, TextBox preview)
        {
            path = p;
            bStop = false;
            isSpotifyUp = true;
            this.preview = preview;
        }

        private Process findSpotify()
        {
            Process spotify = null;
            processlist = Process.GetProcessesByName("Spotify");

            if (processlist.Length == 0)
            {
                isSpotifyUp = false;
                Debug.WriteLine("\n\n\n\nDEBUG\n\n\n");
                return null;
            }
            else
            {
                foreach (Process process in processlist)
                {
                    if (process.ProcessName == "Spotify")
                    {
                        if (process.MainWindowTitle != "")
                        {
                            spotify = process;
                            //Debug.WriteLine("{0} + {1}", "DEBUG", spotify.MainWindowTitle);
                            noSong = false;
                            isSpotifyUp = true;
                            if (process.MainWindowTitle == "Spotify")
                            {
                                noSong = true;
                            }
                        }
                    }
                    else
                    {
                        isSpotifyUp = false;
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
                    Process s = findSpotify();

                    string songName = s.MainWindowTitle;
                    //Debug.WriteLine("{0} + {1}", "DEBUG", s.MainWindowTitle);
                    if (!isSpotifyUp)
                    {
                        writer.WriteLine("Spotify not open");
                        preview.Text = "Spotify not open";
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
                    writer.WriteLine("Spotify not open");
                    preview.Text = "Spotify not open";
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
