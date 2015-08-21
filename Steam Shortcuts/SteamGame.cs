using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Shortcuts
{
    class SteamGame
    {
        public readonly int Id;
        public string Name { get; set; }

        protected string installDir;

        protected static string steamDir = Properties.Settings.Default.steamDir;

        public SteamGame(int Id, string Name, string installDir)
        {
            this.Id = Id;
            this.Name = Name;
            this.installDir = installDir;
        }

        public static void ChangeDir(string dir)
        {
            steamDir = dir;
        }

        public string[] FindExecutables()
        {
            return Directory.GetFiles(getInstalledDir(), "*.exe");
        }

        public bool CreateShortcut(WshShell shell, string path, string icon)
        {
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(path + @"\" + Name + ".lnk");
            shortcut.Description = Name;
            shortcut.TargetPath = steamDir + "steam.exe";
            shortcut.Arguments = "applaunch " + Id;
            shortcut.IconLocation = FindExecutables()[0];
            shortcut.Save();
            return true;
        }

        public bool CreateShortcut(WshShell shell, string path)
        {
            return CreateShortcut(shell, path, FindExecutables()[0]);
        }

        protected string getInstalledDir()
        {
            return steamDir + @"steamapps\common\" + installDir;
        }

    }
}
