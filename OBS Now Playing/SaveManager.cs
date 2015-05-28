using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS_Now_Playing
{
    class SaveManager
    {
        static public void loadSettings(string settingFileLocation, ComboBox mediaPlayerBox, ComboBox defaultMediaBox, TextBox saveLocation, TextBox defaultSaveLocation)
        {
            string defaultLocation = "";
            string defaultPlayer = "";

            try
            {
                using (StreamReader file = File.OpenText(settingFileLocation))
                {
                    string jstring = file.ReadToEnd();

                    dynamic data = JsonConvert.DeserializeObject(jstring);

                    defaultPlayer = data[0].player;
                    defaultLocation = data[0].path;
                }

                defaultMediaBox.SelectedIndex = mediaPlayerBox.SelectedIndex = mediaPlayerBox.FindString(defaultPlayer);
                saveLocation.Text = defaultSaveLocation.Text = defaultLocation;
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException || ex is Newtonsoft.Json.JsonReaderException)
                {
                    saveSettings(settingFileLocation, defaultSaveLocation, defaultMediaBox);
                }
                else
                {
                    throw ex;
                }
            }
        }

        static public void saveSettings(string settingFileLocation, TextBox textBox2, ComboBox comboBox1)
        {
            List<settings> data = new List<settings>();
            data.Add(new settings()
            {
                path = textBox2.Text,
                player = comboBox1.Text
            });

            string json = JsonConvert.SerializeObject(data.ToArray());
            File.WriteAllText(settingFileLocation, json);
        }

        public class settings
        {
            public string path;
            public string player;
        }

    }
}
