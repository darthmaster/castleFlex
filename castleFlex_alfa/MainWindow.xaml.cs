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

namespace castleFlex_alfa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OneGame(object sender, RoutedEventArgs e)
        {
            OneGameWin onegame = new OneGameWin();
            onegame.Show();
        }
        private void TwoGether(object sender, RoutedEventArgs e)
        {
            TwoGameWin toggame = new TwoGameWin();
            toggame.Show();
        }
    }
}
