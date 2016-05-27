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
        private string path,suffix;
        private bool noSong;
        private bool isVLCUp;
        private bool bStop;
        private TextBox preview;
        private string oldName = null;

        public MPCHandler(string p, TextBox preview,string suffixT)
        {
            path = p;
            bStop = false;
            this.preview = preview;
            suffix = suffixT;
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
                    isVLCUp = false;
                    return null;
                }
            }
            foreach (Process process in processlist)
            {
                if (process.ProcessName == "mpc-hc64" || process.ProcessName == "mpc-hc")
                {
                    MPCHCProc = process;
                    isVLCUp = true;
                }
                else
                {
                    isVLCUp = false;
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
                    if (!isVLCUp)
                    {
                        updateText(path, "MPC-HC not open " , suffix);
                    }
                    else if (noSong)
                    {
                        updateText(path, "Paused " , suffix);
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
                                updateText(path, songName , suffix);
                                oldName = songName;
                            }
                        }
                        else
                        {
                            // first run
                            updateText(path, songName , suffix);
                            oldName = songName;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    updateText(path, "MPC-HC not open " , suffix);

                }

                await Task.Delay(1000);
            }
            Debug.WriteLine("MPC-HC Task done.");
        }

        public override void stop()
        {
            bStop = true;
        }

        private void updateText(string pathStr, string textStr, string suffixText)
        {
            writeToPath(pathStr, textStr + suffixText);
            preview.Text = textStr + suffixText;
        }
    }
}