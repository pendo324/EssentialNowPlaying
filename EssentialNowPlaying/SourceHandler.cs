using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Essential_Now_Playing
{
    abstract class SourceHandler
    {
        string source;
        string spaces;
        public SourceHandler() { }

        public SourceHandler(string s)
        {
            source = s;
        }

        public abstract void stop();

        public abstract Task pollForSongChanges();

        Form currentForm = Form.ActiveForm;
        
        // wrapper for File.WriteAllText
        public void writeToPath(string path, string text)
        {
            System.IO.File.WriteAllText(path, text.TrimEnd() + string.Join("", Enumerable.Repeat(" ", System.Convert.ToInt32(currentForm.Controls.Find("numberOfSpaces", true)[0].Text))));
        }
    }
}
