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
using System.Data.Entity;
using System.IO;

namespace castleFlex_alfa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class OneGameWin : Window
    {
        ApplicationContext db;
        public OneGameWin()
        {
            InitializeComponent();
            MediaElement.Play();
            db = new ApplicationContext();
            db.cards.Load();
            //this.DataContext = db.cards.Local.ToBindingList();
            Card1.Source = CreateImage(db.cards.Find(9).pic);
            Card2.Source = CreateImage(db.cards.Find(11).pic);
            Card3.Source = CreateImage(db.cards.Find(13).pic);
            Card4.Source = CreateImage(db.cards.Find(5).pic);
            Card5.Source = CreateImage(db.cards.Find(7).pic);
            Card6.Source = CreateImage(db.cards.Find(39).pic);
            this.DataContext = db.cards.Local.ToBindingList();
        }

        public void startGame()
        {

        }

        public static System.Windows.Media.Imaging.BitmapImage CreateImage(byte[] imageData)
        {
            MemoryStream byteStream = new MemoryStream(imageData);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            return image;
        }  // функция преобразование byto to ImageSourse

        private void MediaElement_MediaEnded_1(object sender, RoutedEventArgs e)
        {
            MediaElement.Stop();
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 0);
            MediaElement.Position = ts;
            MediaElement.Play();
        } //зацикливание фона
    }
}
