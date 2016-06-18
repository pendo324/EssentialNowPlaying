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
        static public void loadSettings(string settingFileLocation, ComboBox mediaPlayerBox, ComboBox defaultMediaBox, TextBox saveLocation, TextBox defaultSaveLocation, ComboBox numberOfSpaces)
        {
            string defaultLocation = "";
            string defaultPlayer = "";
            string spaces = "";

            try
            {
                using (StreamReader file = File.OpenText(settingFileLocation))
                {
                    string jstring = file.ReadToEnd();

                    dynamic data = JsonConvert.DeserializeObject(jstring);

                    defaultPlayer = data[0].player;
                    defaultLocation = data[0].path;
                    spaces = data[0].spaces;
                }

                defaultMediaBox.SelectedIndex = mediaPlayerBox.SelectedIndex = mediaPlayerBox.FindString(defaultPlayer);
                saveLocation.Text = defaultSaveLocation.Text = defaultLocation;
                numberOfSpaces.SelectedIndex = numberOfSpaces.FindString(spaces);
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException || ex is Newtonsoft.Json.JsonReaderException)
                {
                    saveSettings(settingFileLocation, defaultSaveLocation, defaultMediaBox, numberOfSpaces);
                }
                else
                {
                    throw ex;
                }
            }
        }

        static public void saveSettings(string settingFileLocation, TextBox textBox2, ComboBox comboBox1, ComboBox numberOfSpaces)
        {
            List<settings> data = new List<settings>();
            data.Add(new settings()
            {
                path = textBox2.Text,
                player = comboBox1.Text,
                spaces = numberOfSpaces.Text
            });

            string json = JsonConvert.SerializeObject(data.ToArray());
            File.WriteAllText(settingFileLocation, json);
        }

        public class settings
        {
            public string path;
            public string player;
            public string spaces;
            public string prefix;
            public string suffix;
        }

    }
}
