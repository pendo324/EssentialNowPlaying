using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Essential_Now_Playing
{
    class MediaMonkeyHandler : SourceHandler
    {
        private Process[] processlist;
        private string path;
        private bool noSong;
        private bool bStop;
        private bool isMMUp;
        private TextBox preview;
        private string oldName = null;

        public MediaMonkeyHandler(string p, TextBox preview)
        {
            path = p;
            bStop = false;
            this.preview = preview;
        }

        private Process findMM()
        {
            Process MediaMonkey = null;
            processlist = Process.GetProcessesByName("MediaMonkey");

            if (processlist.Length == 0)
            {
                isMMUp = false;
                Debug.WriteLine("\n\n\n\nDEBUG\n\n\n");
                return null;
            }
            else
            {
                foreach (Process process in processlist)
                {
                    if (process.ProcessName == "MediaMonkey")
                    {
                        if (process.MainWindowTitle != "")
                        {
                            MediaMonkey = process;
                            //Debug.WriteLine("{0} + {1}", "DEBUG", MediaMonkey.MainWindowTitle);
                            noSong = false;
                            isMMUp = true;
                            if (process.MainWindowTitle == "MediaMonkey")
                            {
                                noSong = true;
                            }
                        }
                    }
                    else
                    {
                        isMMUp = false;
                    }
                }
            }
                return MediaMonkey;
        }

        async public override Task pollForSongChanges()
        {
            while (!bStop)
            {

                try
                {
                    Process s = findMM();

                    string songName = s.MainWindowTitle.Replace(" - MediaMonkey", "") + " ";

                    if (!isMMUp)
                    {
                        writeToPath(path, "MediaMonkey not open", true);
                    }
                    else if (noSong)
                    {
                        writeToPath(path, "Paused", true);

                        oldName = null;
                    }
                    else
                    {

                        if (oldName != null)
                        {
                            if (string.Compare(oldName, songName) != 0)
                            {
                                writeToPath(path, songName, true);
                                oldName = songName;
                            }
                        }
                        else
                        {
                            writeToPath(path, songName, true);
                            oldName = songName;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    writeToPath(path, "MediaMonkey not open", true);
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