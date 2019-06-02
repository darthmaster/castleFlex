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
        public cardList cards = new cardList();
        public class player
        {
            public string name;
            public int tower;
            public int wall;
            public int wiz;
            public int magic;
            public int rec;
            public int army;
            public int mine;
            public int ore;
            public int[] hand;
            public List<int> usedCards;
            public player(int tower, int wall, int wiz, int magic, int rec, int army, int mine, int ore)
            {
                this.tower = tower;
                this.wall = wall;
                this.wiz = wiz;
                this.magic = magic;
                this.rec = rec;
                this.army = army;
                this.mine = mine;
                this.ore = ore;
                hand = new int[6];
                usedCards = new List<int>() { };
            }
        }
        public static player p1 = new player(50, 0, 1, 15, 1, 15, 1, 15);
        public static player p2 = new player(50, 0, 1, 15, 1, 15, 1, 15);
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

        public void resMessage(int cost)
        {
            MessageBox.Show("Недостаточно ресурсов");
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
