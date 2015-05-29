using System;
using System.Windows.Forms;

namespace OBS_Now_Playing
{
    public partial class Form1 : Form
    {
        bool isStarted;
        SourceManager sm;
        string settingFileLocation = @".\settings.json";
        //string settingFileLocation = @"D:\Documents\Visual Studio 2015\Projects\Spotify Now-Playing\Spotify Now-Playing\bin\Debug";

        public Form1()
        {
            InitializeComponent();
            this.mediaPlayerBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.defaultMediaBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SaveManager.loadSettings(settingFileLocation, defaultMediaBox, mediaPlayerBox, saveLocation, defaultSaveLocation);
        }

        private void selectLocation_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = ".";
            savefile.FileName = "nowplaying.txt";
            savefile.Filter = "Text File*|.txt";
            savefile.Title = "Choose a location for Now Playing";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                saveLocation.Text = savefile.FileName;
            }

            else
            {
                throw new Exception("Unable to save file");
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (mediaPlayerBox.Enabled == true)
            {
                mediaPlayerBox.Enabled = false;
                isStarted = true;
                startButton.Text = "Stop!";
            }
            else if (isStarted == true)
            {
                mediaPlayerBox.Enabled = true;
                isStarted = false;
                startButton.Text = "Start!";
            }

            if (isStarted)
            {
                sm = new SourceManager(mediaPlayerBox.Text, saveLocation.Text, previewBox);
                sm.newSourceHandler();
            }
            else
            {
                sm.stop();
            }
        }

        private void settingsLocation_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = ".";
            savefile.FileName = "nowplaying.txt";
            savefile.Filter = "Text File*|.txt";
            savefile.Title = "Choose a location for Now Playing";
            savefile.OverwritePrompt = false;

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                defaultSaveLocation.Text = savefile.FileName;
            }

            else
            {
                throw new Exception("Unable to save file");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveManager.saveSettings(settingFileLocation, defaultSaveLocation, defaultMediaBox);
        }
    }
}
