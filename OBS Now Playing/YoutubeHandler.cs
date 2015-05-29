using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace OBS_Now_Playing
{
    class YoutubeHandler : SourceHandler
    {
        private Process[] processlist;
        private string path;
        private bool noSong;
        private bool isItunesUp;
        private bool bStop;
        private TextBox preview;

        public YoutubeHandler(string p, TextBox preview)
        {
            path = p;
            bStop = false;
            this.preview = preview;
        }

        private void findBrowser()
        {

        }

        async public override Task pollForSongChanges()
        {
            while (!bStop)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(path);

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
