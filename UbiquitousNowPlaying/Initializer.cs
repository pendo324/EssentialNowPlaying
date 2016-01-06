using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubiquitous_Now_Playing
{
    class Initializer
    {
        public static void init()
        {
            initRegistry();
        }

        static string extensionId = "aocghdlnkcebaipehcejjpeiijpdjldo";

        private static void initRegistry()
        {
            // look for the two registry keys that indicate the plugin is installed correctly

            // check if NativeMessagingInterface has been propery registered to work with Chrome
            RegistryKey NMIKey = Registry.CurrentUser.OpenSubKey("Software\\Google\\Chrome\\NativeMessagingHosts\\com.flyinglawnmower.obsnp", true);

            addManifest();


            string local = Environment.GetEnvironmentVariable("LocalAppData");
            if (!Directory.Exists(local + "Google\\User Data\\Default\\Extensions\\" + extensionId + "\\"))
            {
                //addExtension();
            }
        }

        private static void addManifest()
        {
            // create the registry entry, assume that NativeMessagingInterface is in the CWD
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Google\\Chrome\\NativeMessagingHosts");
            key.Close();
            key = Registry.CurrentUser.CreateSubKey("Software\\Google\\Chrome\\NativeMessagingHosts\\com.flyinglawnmower.obsnp");

            // generate the manifest file needed for NativeMessagingInterface.exe to work with Chrome
            string cd = AppDomain.CurrentDomain.BaseDirectory;
            var manifest = new Dictionary<string, object>
                {
                    { "name", "com.flyinglawnmower.obsnp" },
                    {"description", "Now Playing Helper"},
                    {"path", cd + "NativeMessagingInterface.exe"},
                    {"type", "stdio"},
                    {"allowed_origins", new[] { "chrome-extension://" + extensionId + "/"} }
                };

            string json = JsonConvert.SerializeObject(manifest);
            File.WriteAllText(cd + "manifest.json", json);

            key.SetValue("", cd + "manifest.json");
            key.Close();
        }

        private static void addExtension()
        {
            // check if its already installed first
            string updateUrl = "https://clients2.google.com/service/update2/crx?response=redirect&x=id%3Daocghdlnkcebaipehcejjpeiijpdjldo%26uc&prodversion=32";

            // install extension via regsitry if it is not already installed
            if (Environment.Is64BitOperatingSystem)
            {
                // key goes in HKEY_LOCAL_MACHINE\Software\Wow6432Node\Google\Chrome\Extensions
                RegistryKey key = Registry.LocalMachine.CreateSubKey("Software\\Wow6432Node\\Google\\Chrome");
                key.Close();
                key = Registry.LocalMachine.CreateSubKey("Software\\Wow6432Node\\Google\\Chrome\\Extensions\\");
                key.Close();
                key = Registry.LocalMachine.CreateSubKey("Software\\Wow6432Node\\Google\\Chrome\\Extensions\\" + extensionId);

                key.SetValue("update_url", updateUrl);
                key.Close();
            }
            else
            {
                // key goes in HKEY_LOCAL_MACHINE\Software\Google\Chrome\Extensions
                RegistryKey key = Registry.LocalMachine.CreateSubKey("Software\\Google\\Chrome\\Extensions\\" + extensionId);
                key.SetValue("update_url", updateUrl);
                key.Close();
            }

        }
    }
}
