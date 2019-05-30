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
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.cards.Load();
            this.DataContext = db.cards.Local.ToBindingList();
            MessageBox.Show(db.cards.Find(3).name);
            //картинка не работает: с
            //testImg.Source = (db.cards.Find(1).pic);
            //работает если всё нормально преобразовать!
            testImg.Source = CreateImage(db.cards.Find(9).pic);

            // хороший код, но хуйня жи столько строчек не выносить в другую функцю
            //MemoryStream byteStream = new MemoryStream(db.cards.Find(1).pic);
            //BitmapImage image = new BitmapImage();
            //image.BeginInit();
            //image.StreamSource = byteStream;
            //image.EndInit();
            //testImg.Source = image;
        }

        //public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //    return ms.ToArray();
        //}
        //public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
        //    return returnImage;
        //} //говнокод для вин форм и System.Drawing, т.к. мы используем WPF - юзелес



        public static System.Windows.Media.Imaging.BitmapImage CreateImage(byte[] imageData)
        {
            MemoryStream byteStream = new MemoryStream(imageData);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            return image;
        }  // функция преобразование byto to ImageSourse


        private void FromStream(MemoryStream mStream)
        {
            throw new NotImplementedException();
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
