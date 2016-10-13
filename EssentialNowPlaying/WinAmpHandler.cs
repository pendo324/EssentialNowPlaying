using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Essential_Now_Playing
{
    class WinAmpHandler : SourceHandler
    {
        private Process[] processlist;
        private string path;
        private bool noSong;
        private bool bStop;
        private bool isFoobarUp;
        private TextBox preview;
        private string oldName = null;

        public WinAmpHandler(string p, TextBox preview)
        {
            path = p;
            bStop = false;
            isFoobarUp = true;
            this.preview = preview;
        }

        private Process findFoobar()
        {
            Process foobar2000 = null;
            processlist = Process.GetProcessesByName("winamp");

            if (processlist.Length == 0)
            {
                isFoobarUp = false;
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
                            foobar2000 = process;
                            //Debug.WriteLine("{0} + {1}", "DEBUG", spotify.MainWindowTitle);
                            noSong = false;
                            isFoobarUp = true;
                            if (process.MainWindowTitle == "winamp")
                            {
                                noSong = true;
                            }
                        }
                    }
                    else
                    {
                        isFoobarUp = false;
                    }
                }
            }

            return foobar2000;
        }

        async public override Task pollForSongChanges()
        {
            while (!bStop)
            {
                // get the foobar process (if it exists)


                try
                {
                    Process s = findFoobar();

                    string songName = s.MainWindowTitle;
                    //Debug.WriteLine("{0} + {1}", "DEBUG", s.MainWindowTitle);
                    if (!isFoobarUp)
                    {
                        writeToPath(path, "foobar2000 not open", true);
                        //preview.Text = "foobar2000 not open";
                    }
                    else if (noSong)
                    {
                        writeToPath(path, "Paused", true);
                        //preview.Text = "Paused";
                        oldName = null;
                    }
                    else
                    {
                        // only update the song if the song changes
                        // strip some extra information from the string, like the theme and the program name
                        songName = s.MainWindowTitle.Substring(0, songName.LastIndexOf("-")) + " ";
                        if (oldName != null)
                        {
                            if (oldName != songName)
                            {
                                //preview.Text = songName;
                                writeToPath(path, songName, true);
                                oldName = songName;
                            }
                        }
                        else
                        {
                            // first run
                            //preview.Text = songName;
                            writeToPath(path, songName, true);
                            oldName = songName;
                        }
                    }



                }
                catch (NullReferenceException)
                {
                    writeToPath(path, "foobar2000 not open", true);
                    //preview.Text = "foobar2000 not open";

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
