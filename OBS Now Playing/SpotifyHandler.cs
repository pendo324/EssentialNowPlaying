using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace OBS_Now_Playing
{
    class SpotifyHandler : SourceHandler//, IDisposable
    {
        Process[] processlist;
        private string path;
        private bool noSong;
        private bool bStop = false;

        public SpotifyHandler(string p)
        {
            path = p;
            bStop = false;
        }

        private Process findSpotify()
        {
            Process spotify = null;
            processlist = Process.GetProcessesByName("Spotify");

            foreach (Process process in processlist)
            {
                if (process.ProcessName == "Spotify")
                {
                    if (process.MainWindowTitle != "")
                    {
                        spotify = process;
                        //Debug.WriteLine("{0} + {1}", "DEBUG", spotify.MainWindowTitle);
                        noSong = false;
                        if (process.MainWindowTitle == "Spotify")
                        {
                            noSong = true;
                        }
                    }
                }
                else
                {
                    throw new Exception("Spotify Process Not Found");
                }
            }

            return spotify;
        }

        async public override Task pollForSongChanges()
        {
            while (!bStop)
            {
                // get the Spotify process (if it exists)
                Process s = findSpotify();

                System.IO.StreamWriter writer = new System.IO.StreamWriter(path);

                string songName = s.MainWindowTitle;
                //Debug.WriteLine("{0} + {1}", "DEBUG", s.MainWindowTitle);
                
                if (noSong)
                {
                    writer.WriteLine("Paused");
                }
                else
                {
                    writer.WriteLine(s.MainWindowTitle);
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
