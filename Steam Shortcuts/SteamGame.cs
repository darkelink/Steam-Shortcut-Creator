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

        public SteamGame(int Id, string Name, string installDir)
        {
            this.Id = Id;
            this.Name = Name;
            this.installDir = installDir;
        }

        public string[] FindExecutables()
        {
            return Directory.GetFiles(getInstalledDir(), "*.exe");
        }

        public bool CreateShortcut(WshShell shell, string path, string icon)
        {
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(path + @"\" + installDir + ".lnk");
            shortcut.Description = Name;
            shortcut.TargetPath = Properties.Settings.Default.steamDir + @"\steam.exe";
            shortcut.WorkingDirectory = Properties.Settings.Default.steamDir;
            shortcut.Arguments = "-applaunch " + Id;
            shortcut.IconLocation = FindExecutables()[0];
            shortcut.Save();
            return true;
        }

        public bool CreateShortcut(WshShell shell)
        {
            return CreateShortcut(shell, Properties.Settings.Default.shortcutDir, FindExecutables()[0]);
        }

        protected string getInstalledDir()
        {
            return Properties.Settings.Default.steamDir + @"\steamapps\common\" + installDir;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
