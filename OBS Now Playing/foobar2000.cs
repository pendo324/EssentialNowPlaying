using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace OBS_Now_Playing
{
    class FoobarHandler : SourceHandler
    {
        private Process[] processlist;
        private string path;
        private bool noSong;
        private bool bStop;
        private bool isFoobarUp;
        private TextBox preview;
        private string oldName = null;

        public FoobarHandler(string p, TextBox preview)
        {
            path = p;
            bStop = false;
            isFoobarUp = true;
            this.preview = preview;
        }

        private Process findFoobar()
        {
            Process foobar2000 = null;
            processlist = Process.GetProcessesByName("foobar2000");

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
                    if (process.ProcessName == "foobar2000")
                    {
                        if (process.MainWindowTitle != "")
                        {
                            foobar2000 = process;
                            //Debug.WriteLine("{0} + {1}", "DEBUG", spotify.MainWindowTitle);
                            noSong = false;
                            isFoobarUp = true;
                            if (process.MainWindowTitle == "foobar2000")
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
                System.IO.StreamWriter writer = new System.IO.StreamWriter(path);

                try
                {
                    Process s = findFoobar();

                    string songName = s.MainWindowTitle;
                    //Debug.WriteLine("{0} + {1}", "DEBUG", s.MainWindowTitle);
                    if (!isFoobarUp)
                    {
                        writer.WriteLine("foobar2000 not open");
                        preview.Text = "foobar2000 not open";
                    }
                    else if (noSong)
                    {
                        writer.WriteLine("Paused");
                        preview.Text = "Paused";
                    }
                    else
                    {
                        // only update the song if the song changes
                        // strip some extra information from the string, like the theme and the program name
                        songName = songName.Substring(0, songName.IndexOf("▪"));
                        if (oldName != null)
                        {
                            if (oldName != songName)
                            {
                                preview.Text = songName;
                                writer.WriteLine(songName);
                                oldName = songName;
                            }
                        }
                        else
                        {
                            // first run
                            preview.Text = songName;
                            writer.WriteLine(songName);
                            oldName = songName;
                        }
                    }

                    writer.Close();

                }
                catch (NullReferenceException)
                {
                    writer.WriteLine("foobar2000 not open");
                    preview.Text = "foobar2000 not open";
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
