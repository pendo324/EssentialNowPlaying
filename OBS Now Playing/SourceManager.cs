using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS_Now_Playing
{
    class SourceManager
    {
        public string source = null;
        private string path = null;
        SourceHandler sh;

        public SourceManager(string s, string p)
        {
            source = s;
            path = p;
        }

        public void newSourceHandler()
        {
            switch (source) {
                case "Spotify":
                    sh = new SpotifyHandler(path);
                    Task t = sh.pollForSongChanges();
                    break;
               default:
                    break;
            }
        }

        public void stop()
        {
            sh.stop();
        }
    }
}
