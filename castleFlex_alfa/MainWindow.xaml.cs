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

namespace castleFlex_alfa
{
    public class GlobalVariables
    {
        public static string username { get; set; }
        public static string ip { get; set; }
        public static int port { get; set; }
        public static int recport { get; set; }
        public static bool server { get; set; }
    }
    public partial class MainWindow : Window
    {
        public GlobalVariables global = new GlobalVariables();
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
            GlobalVariables.username = username.Text;
            GlobalVariables.ip = ip.Text;
            GlobalVariables.port = Convert.ToInt32(port.Text);
            GlobalVariables.recport = Convert.ToInt32(recport.Text);
            TwoGameWin multiGame = new TwoGameWin();
            if (serverBtn.IsChecked==false && clientBtn.IsChecked == false)
            {
                MessageBox.Show("Вы не выбрали режим подключения");
            }
            else if (serverBtn.IsChecked == true)
            {
                GlobalVariables.server = true;
                multiGame.ShowDialog();
            }
            else if (clientBtn.IsChecked == true)
            {
                GlobalVariables.server = false;
                multiGame.Show();
            }
        }
    }
}
