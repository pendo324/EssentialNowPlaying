using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Essential_Now_Playing
{
    abstract class SourceHandler
    {
        string source;
        public SourceHandler() { }

        public SourceHandler(string s)
        {
            source = s;
        }

        public abstract void stop();

        public abstract Task pollForSongChanges();

        Form currentForm = Form.ActiveForm;

        // wrapper for File.WriteAllText
        public void writeToPath(string path, string text, bool writePreview=false)
        {
            string tmpStr = text;

            if (((CheckBox)currentForm.Controls.Find("checkPrefix", true)[0]).Checked)
                tmpStr = tmpStr.Insert(0, currentForm.Controls.Find("prefixBox", true)[0].Text);
            if (((CheckBox)currentForm.Controls.Find("checkSuffix", true)[0]).Checked)
                tmpStr = tmpStr.Insert(tmpStr.Length, currentForm.Controls.Find("suffixBox", true)[0].Text);

            if (writePreview)
                currentForm.Controls.Find("previewBox", true)[0].Text = tmpStr;

            System.IO.File.WriteAllText(path, tmpStr);
        }
    }
}
