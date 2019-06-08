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
    public class GlobalVariables
    {
        public static MainWindow mw = new MainWindow();
        public string username = mw.username.Text;
        public string ip = mw.ip.Text;
        public int port = Convert.ToInt32(mw.port.Text);
        public int recport = Convert.ToInt32(mw.recport.Text);
        public bool server;
    }
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
        }  // функция преобразование byte to ImageSourse
        public OneGameWin onegame = new OneGameWin();
        public MainWindow()
        {
            InitializeComponent();
            multi.Visibility = Visibility.Hidden;
            MediaElement.Play();
            db = new ApplicationContext();
            db.cards.Load();
            this.DataContext = db.cards.Local.ToBindingList();
        }
        private void OneGame(object sender, RoutedEventArgs e) 
        {
            onegame.Show();
        }
        private void TwoGether(object sender, RoutedEventArgs e)
        {
            if (multi.Visibility == Visibility.Visible)
            {
                multi.Visibility = Visibility.Hidden;
            }
            else multi.Visibility = Visibility.Visible;
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

        private void MediaElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void MultiStart_Click(object sender, RoutedEventArgs e)
        {
            TwoGameWin multiGame = new TwoGameWin();
            GlobalVariables global = new GlobalVariables();
            if (serverBtn.IsChecked==false && clientBtn.IsChecked == false)
            {
                MessageBox.Show("Вы не выбрали режим подключения");
            }
            else if (serverBtn.IsChecked == true)
            {
                global.server = true;
                multiGame.Show();
            }
            else if (clientBtn.IsChecked == true)
            {
                global.server = false;
                multiGame.Show();
            }
        }

        //просто бессмысленный коммент
    }
}
