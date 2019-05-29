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
using System.Data.SQLite;
using System.Data;
using System.Data.Entity;

namespace castleFlex_alfa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.cards.Load();
            this.DataContext = db.cards.Local.ToBindingList();
            //MessageBox.Show(db.cards.Find(3).name);
            //testImg.Source = db.cards.Find(1).pic;
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
