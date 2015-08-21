using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Steam_Shortcuts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Settings settings_diag;
        WshShell shell;

        public MainWindow()
        {
            InitializeComponent();
            settings_diag = new Settings();
            shell = new WshShell();
            try {
                listBox.ItemsSource = SteamDB.GetGames();
            } catch (Exception ex) {
                System.Console.WriteLine(ex);
            }
        }

        private void settings_btn(object sender, RoutedEventArgs e)
        {
            settings_diag.ShowDialog();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            try {
                listBox.ItemsSource = SteamDB.RefreshGames();
            } catch (Exception ex) {
                System.Console.WriteLine(ex);
            }
        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try {
                ((SteamGame)listBox.SelectedItem).CreateShortcut(shell);
            } catch (Exception ex)
            {
                MessageBox.Show("Could not create shortcut");
            }
        }
    }
}
