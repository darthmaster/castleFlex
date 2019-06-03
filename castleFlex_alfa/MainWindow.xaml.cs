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
using System.IO;
//using System.Drawing;
namespace castleFlex_alfa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public static BitmapImage CreateImage(byte[] imageData)
        {
            MemoryStream byteStream = new MemoryStream(imageData);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            return image;
        }  // функция преобразование byto to ImageSourse
        //OneGameWin onegame = new OneGameWin();
        //TwoGameWin toggame = new TwoGameWin();
        public MainWindow()
        {
            InitializeComponent();
            //multi.IsVisible=false;
            MediaElement.Play();
            db = new ApplicationContext();
            db.cards.Load();
            this.DataContext = db.cards.Local.ToBindingList();
        }
        private void OneGame(object sender, RoutedEventArgs e) 
        {
            OneGameWin onegame = new OneGameWin();
            onegame.Show();
            //onegame.InitializeComponent();
        }
        private void TwoGether(object sender, RoutedEventArgs e)
        {
            TwoGameWin toggame = new TwoGameWin();
            toggame.Show();
            //toggame.InitializeComponent();
        }
        private void MediaElement_MediaEnded_1(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 0);
            MediaElement.Position = ts;
            MediaElement.Play();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OtherButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
