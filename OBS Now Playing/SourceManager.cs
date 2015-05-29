using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS_Now_Playing
{
    class SourceManager
    {
        public string source;
        private string path;
        private TextBox preview;
        private SourceHandler sh;

        public SourceManager(string s, string p, TextBox preview)
        {
            source = s;
            path = p;
            this.preview = preview;
        }

        public void newSourceHandler()
        {
            switch (source) {
                case "Spotify":
                    sh = new SpotifyHandler(path, preview);
                    Task spotify = sh.pollForSongChanges();
                    break;
                case "iTunes":
                    sh = new iTunesHandler(path, preview);
                    Task itunes = sh.pollForSongChanges();
                    break;
                case "MPC-HC":
                    sh = new MPCHandler(path, preview);
                    Task mpc = sh.pollForSongChanges();
                    break;
                case "VLC":
                    sh = new VLCHandler(path, preview);
                    Task vlc = sh.pollForSongChanges();
                    break;
                case "WinAmp":
                    sh = new WinAmpHandler(path, preview);
                    Task winamp = sh.pollForSongChanges();
                    break;
                case "YouTube":
                    Task youtube = sh.pollForSongChanges();
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
