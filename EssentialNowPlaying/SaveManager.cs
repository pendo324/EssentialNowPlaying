using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Essential_Now_Playing
{
    class SaveManager
    {
        static public void loadSettings(string settingFileLocation, ComboBox mediaPlayerBox, ComboBox defaultMediaBox, TextBox saveLocation, TextBox defaultSaveLocation, TextBox suffixText)
        {
            string defaultLocation = "";
            string defaultPlayer = "";
            string defaultSuffix = "";

            try
            {
                using (StreamReader file = File.OpenText(settingFileLocation))
                {
                    string jstring = file.ReadToEnd();

                    dynamic data = JsonConvert.DeserializeObject(jstring);

                    defaultPlayer = data[0].player;
                    defaultLocation = data[0].path;
                    defaultSuffix = data[0].suffix;
                }

                defaultMediaBox.SelectedIndex = mediaPlayerBox.SelectedIndex = mediaPlayerBox.FindString(defaultPlayer);
                saveLocation.Text = defaultSaveLocation.Text = defaultLocation;
                suffixText.Text = defaultSuffix;
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException || ex is Newtonsoft.Json.JsonReaderException)
                {
                    saveSettings(settingFileLocation, defaultSaveLocation, defaultMediaBox, suffixText);
                }
                else
                {
                    throw ex;
                }
            }
        }

        static public void saveSettings(string settingFileLocation, TextBox textBox2, ComboBox comboBox1, TextBox textBox3)
        {
            List<settings> data = new List<settings>();
            data.Add(new settings()
            {
                path = textBox2.Text,
                player = comboBox1.Text,
                suffix = textBox3.Text
            });

            string json = JsonConvert.SerializeObject(data.ToArray());
            File.WriteAllText(settingFileLocation, json);
        }

        public class settings
        {
            public string path;
            public string player;
            public string suffix;
        }

    }
}
