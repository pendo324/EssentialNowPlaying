using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS_Now_Playing
{
    class MPCHandler : SourceHandler
    {
        private Process[] processlist;
        private string path;
        private bool noSong;
        private bool isVLCUp;
        private bool bStop;
        private TextBox preview;

        public MPCHandler(string p, TextBox preview)
        {
            path = p;
            bStop = false;
            this.preview = preview;
        }

        private Process findMPC()
        {
            Process spotify = null;
            processlist = Process.GetProcessesByName("MPC-HC");

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
                    if (process.ProcessName == "MPC-HC")
                    {
                        if (process.MainWindowTitle != "")
                        {
                            spotify = process;
                            //Debug.WriteLine("{0} + {1}", "DEBUG", spotify.MainWindowTitle);
                            noSong = false;
                            isVLCUp = true;
                            if (process.MainWindowTitle == "MPC-HC")
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
                    Process s = findMPC();

                    string songName = s.MainWindowTitle;
                    //Debug.WriteLine("{0} + {1}", "DEBUG", s.MainWindowTitle);
                    if (!isVLCUp)
                    {
                        writer.WriteLine("MPC-HC not open");
                        preview.Text = "MPC-HC not open";
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
                    writer.WriteLine("MPC-HC not open");
                    preview.Text = "MPC-HC not open";
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
