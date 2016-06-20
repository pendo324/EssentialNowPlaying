using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Essential_Now_Playing
{
    class MPCHandler : SourceHandler
    {
        private Process[] processlist;
        private string path;
        private bool noSong;
        private bool isMPCUp;
        private bool bStop;
        private TextBox preview;
        private string oldName = null;

        public MPCHandler(string p, TextBox preview)
        {
            path = p;
            bStop = false;
            this.preview = preview;
        }

        private Process findMPC()
        {
            Process MPCHCProc = null;
            processlist = Process.GetProcessesByName("mpc-hc");

            if (processlist.Length == 0)
            {
                processlist = Process.GetProcessesByName("mpc-hc64");
                if (processlist.Length == 0)
                {
                    isMPCUp = false;
                    return null;
                }
            }
            foreach (Process process in processlist)
            {
                if (process.ProcessName == "mpc-hc64" || process.ProcessName == "mpc-hc")
                {
                    MPCHCProc = process;
                    isMPCUp = true;
                }
                else
                {
                    isMPCUp = false;
                }
            }

            return MPCHCProc;
        }

        async public override Task pollForSongChanges()
        {
            Process s = findMPC();
            while (!bStop)
            {
                s.Refresh();
                if (s.HasExited)
                {
                    bStop = true;
                    break;
                }

                if (s.MainWindowTitle == "Media Player Classic Home Cinema")
                {
                    noSong = true;
                }
                else
                {
                    noSong = false;
                }
                try
                {

                    string songName = Path.GetFileNameWithoutExtension(s.MainWindowTitle) + " ";
                    if (!isMPCUp)
                    {
                        writeToPath(path, "MPC-HC not open",true);
                        //preview.Text = "MPC-HC not open";
                    }
                    else if (noSong)
                    {
                        writeToPath(path, "Paused",true);
                        //preview.Text = "Paused";
                        oldName = null;
                    }
                    else
                    {
                        // only update the song if the song changes
                        // strip some extra information from the string, like the theme and the program name
                        if (oldName != null)
                        {
                            if (oldName != songName)
                            {
                                //preview.Text = songName;
                                writeToPath(path, songName,true);
                                oldName = songName;
                            }
                        }
                        else
                        {
                            // first run
                            //preview.Text = songName;
                            writeToPath(path, songName,true);
                            oldName = songName;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    writeToPath(path, "MPC-HC not open",true);
                    //preview.Text = "MPC-HC not open";

                }

                await Task.Delay(1000);
            }
        }

        public override void stop()
        {
            bStop = true;
        }
    }
}