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
        static public void loadSettings(string settingFileLocation, ComboBox mediaPlayerBox, ComboBox defaultMediaBox, TextBox saveLocation, TextBox defaultSaveLocation, TextBox prefixBox, TextBox suffixBox, CheckBox addPrefixCB, CheckBox addSuffixCB)
        {
            string defaultLocation = "";
            string defaultPlayer = "";
            string prefix = "";
            string suffix = "";
            bool addSuffixB = false;
            bool addPrefixB = false;

            try
            {
                using (StreamReader file = File.OpenText(settingFileLocation))
                {
                    string jstring = file.ReadToEnd();

                    dynamic data = JsonConvert.DeserializeObject(jstring);

                    defaultPlayer = data[0].player;
                    defaultLocation = data[0].path;
                    prefix = data[0].prefix;
                    suffix = data[0].suffix;
                    if (data[0].addPrefix != null)
                        addPrefixB = data[0].addPrefix;
                    if (data[0].addSuffix != null)
                        addSuffixB = data[0].addSuffix;

                }

                defaultMediaBox.SelectedIndex = mediaPlayerBox.SelectedIndex = mediaPlayerBox.FindString(defaultPlayer);
                saveLocation.Text = defaultSaveLocation.Text = defaultLocation;
                prefixBox.Text = prefix;
                suffixBox.Text = suffix;
                addPrefixCB.Checked = addPrefixB;
                addSuffixCB.Checked = addSuffixB;
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException || ex is Newtonsoft.Json.JsonReaderException)
                {
                    saveSettings(settingFileLocation, defaultSaveLocation, defaultMediaBox, prefixBox, suffixBox, addPrefixCB, addSuffixCB);
                }
                else
                {
                    throw ex;
                }
            }
        }

        static public void saveSettings(string settingFileLocation, TextBox textBox2, ComboBox comboBox1, TextBox prefixBox, TextBox suffixBox, CheckBox addPrefixCB, CheckBox addSuffixCB)
        {
            List<settings> data = new List<settings>();
            data.Add(new settings()
            {
                path = textBox2.Text,
                player = comboBox1.Text,
                prefix = prefixBox.Text,
                suffix = suffixBox.Text,
                addPrefix = addPrefixCB.Checked,
                addSuffix = addSuffixCB.Checked
            });

            string json = JsonConvert.SerializeObject(data.ToArray());
            File.WriteAllText(settingFileLocation, json);
        }

        public class settings
        {
            public string path;
            public string player;
            public string prefix;
            public string suffix;
            public bool addPrefix;
            public bool addSuffix;
        }

    }
}
