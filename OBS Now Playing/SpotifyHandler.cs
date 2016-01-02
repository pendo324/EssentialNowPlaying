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
        private string oldName = null;

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

                try
                {
                    Process s = findSpotify();

                    string songName = s.MainWindowTitle + " ";
                    //Debug.WriteLine("{0} + {1}", "DEBUG", s.MainWindowTitle);
                    if (!isSpotifyUp)
                    {
                        writeToPath(path, "Spotify not open");

                        preview.Text = "Spotify not open";
                    }
                    else if (noSong)
                    {
                        writeToPath(path, "Paused");

                        preview.Text = "Paused";
                        oldName = null;
                    }
                    else
                    {
                        // only update the song if the song changes
                        if (oldName != null)
                        {
                            if (string.Compare(oldName, songName) != 0)
                            {
                                preview.Text = songName;
                                writeToPath(path, songName);
                                oldName = songName;
                            }
                        }
                        else
                        {
                            // first run
                            preview.Text = songName;
                            writeToPath(path, songName);
                            oldName = songName;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    writeToPath(path, "Spotify not open");
                    preview.Text = "Spotify not open";
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
