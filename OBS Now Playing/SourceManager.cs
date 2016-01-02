using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS_Now_Playing
{
    class SourceManager
    {
        public bool isWebPlayer;
        public string source;
        private string path;
        private TextBox preview;
        private SourceHandler sh;
        private WebAppHandler wah;

        public SourceManager(string s, string p, TextBox preview)
        {
            isWebPlayer = false;
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
                case "foobar2000":
                    sh = new FoobarHandler(path, preview);
                    Task foobar = sh.pollForSongChanges();
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
                    isWebPlayer = true;
                    wah = new WebAppHandler(path, preview, "YouTube");
                    wah.start();
                    break;
                case "Soundcloud":
                    isWebPlayer = true;
                    wah = new WebAppHandler(path, preview, "Soundcloud");
                    wah.start();
                    break;
                case "Pandora":
                    isWebPlayer = true;
                    wah = new WebAppHandler(path, preview, "Pandora");
                    wah.start();
                    break;
                case "Spotify (web)":
                    isWebPlayer = true;
                    wah = new WebAppHandler(path, preview, "Spotify");
                    wah.start();
                    break;
                default:
                    break;
            }
        }

        public void stop()
        {
            if (!isWebPlayer)
                sh.stop();
            else
            {
                wah.stop();
            }

        }
    }
}
