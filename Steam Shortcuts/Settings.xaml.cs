using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Steam_Shortcuts
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private FolderBrowserDialog fbd;

        public Settings()
        {
            InitializeComponent();
            steam_txb.Text = Properties.Settings.Default.steamDir;
            shortcut_txb.Text = Properties.Settings.Default.shortcutDir;
            fbd = new FolderBrowserDialog();
        }

        private void steam_btn_Click(object sender, RoutedEventArgs e)
        {
            fbd.SelectedPath = steam_txb.Text;
            fbd.ShowDialog();
            steam_txb.Text = fbd.SelectedPath;
        }

        private void shortcut_btn_Click(object sender, RoutedEventArgs e)
        {
            fbd.SelectedPath = shortcut_txb.Text;
            fbd.ShowDialog();
            shortcut_txb.Text = fbd.SelectedPath;
        }

        private void ok_btn_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.steamDir = steam_txb.Text;
            Properties.Settings.Default.shortcutDir = shortcut_txb.Text;
            Properties.Settings.Default.Save();
            Close();
        }

    }
}
