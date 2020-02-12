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

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy Piąte.xaml
    /// </summary>
    public partial class Piąte : Page
    {
        public Piąte()
        {
            InitializeComponent();
        }

        private void Button_zakoncz_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_zlozkolejne_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
            Window win = (Window)this.Parent;
            win.Close();
        }
    }
}
