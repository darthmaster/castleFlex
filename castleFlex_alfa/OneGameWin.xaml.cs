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
using System.Reflection;

namespace castleFlex_alfa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class OneGameWin : Window
    {
        ApplicationContext db;
        public int k;
        public int[] arr = new int[100];
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
        public void updateInfo(player a, player b)
        {
            playerMages.Content = $"{a.wiz}";
            playerMagic.Content = $"{a.magic}";
            playerRecruts.Content = $"{a.rec}";
            playerArmy.Content = $"{a.army}";
            playerMines.Content = $"{a.mine}";
            playerOre.Content = $"{a.ore}";
            ptv.Content = a.tower;
            pwv.Content = a.wall;

            enemyMages.Content = $"{b.wiz}";
            enemyMagic.Content = $"{b.magic}";
            enemyRecruts.Content = $"{b.rec}";
            enemyArmy.Content = $"{b.army}";
            enemyMines.Content = $"{b.mine}";
            enemyOre.Content = $"{b.ore}";
            etv.Content = b.tower;
            ewv.Content = b.wall;
            //t3z.Height = 125;
            //System.Windows.Thickness bs = new System.Windows.Thickness(85, 125, 0, 0);
            //t3.Margin = bs;
        }
        public void krupbe()
        {

        }
        public OneGameWin()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.cards.Load();
            //player ppp = new player(50, 0, 1, 15, 1, 15, 1, 15);
            //p1 = ppp;
            //p2 = ppp;

        var rand = new Random();
            var knownNumbers = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++) // работает - не трогай!
            {
                int newElement;
                do
                {
                    newElement = rand.Next(100) + 1;
                } while (!knownNumbers.Add(newElement));
                arr[i] = newElement;
            }

            for (int i = 0; i <= 5; i++)
            {
                p1.hand[i] = arr[i];
                p1.usedCards.Add(p1.hand[i]);
            }
            Card1.Source = CreateImage(db.cards.Find(p1.hand[0]).pic);
            Card2.Source = CreateImage(db.cards.Find(p1.hand[1]).pic);
            Card3.Source = CreateImage(db.cards.Find(p1.hand[2]).pic);
            Card4.Source = CreateImage(db.cards.Find(p1.hand[3]).pic);
            Card5.Source = CreateImage(db.cards.Find(p1.hand[4]).pic);
            Card6.Source = CreateImage(db.cards.Find(p1.hand[5]).pic);
            for (int i = 0; i <= 5; i++)
            {
                p2.hand[i] = arr[i];
                p2.usedCards.Add(p2.hand[i]);
            }
            k = 12;

            
            updateInfo(p1, p2);
            //Card1.Source = CreateImage(db.cards.Find(9).pic);
            //Card2.Source = CreateImage(db.cards.Find(11).pic);
            //Card3.Source = CreateImage(db.cards.Find(13).pic);
            //Card4.Source = CreateImage(db.cards.Find(5).pic);
            //Card5.Source = CreateImage(db.cards.Find(7).pic);
            //Card6.Source = CreateImage(db.cards.Find(39).pic);
            this.DataContext = db.cards.Local.ToBindingList();
            
        }

        public void resMessage(int cost)
        {
            MessageBox.Show("Недостаточно ресурсов, карта сбрасывается");
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

        //private void MediaElement_MediaEnded_1(object sender, RoutedEventArgs e)
        //{
        //    MediaElement.Stop();
        //    TimeSpan ts = new TimeSpan(0, 0, 0, 0, 0);
        //    MediaElement.Position = ts;
        //    MediaElement.Play();
        //} //зацикливание фона
        public void endTurn()
        {
            if ((p2.tower <= 0) || (p1.tower >= 100))
            {
                MessageBox.Show("Вы победили!", "Игра окончена", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else if ((p1.tower <= 0) || (p2.tower >= 100))
            {
                MessageBox.Show("Вы проиграли!", "Игра окончена", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            newTurn();
        }
        public void newTurn()
        {
            if (p1.wiz <= 0) { p1.wiz = 1; }
            if (p1.rec <= 0) { p1.rec = 1; }
            if (p1.mine <= 0) { p1.mine = 1; }

            if (p2.wiz <= 0) { p2.wiz = 1; }
            if (p2.rec <= 0) { p2.rec = 1; }
            if (p2.mine <= 0) { p2.mine = 1; }

            if (p1.magic < 0) { p1.magic = 0; }
            if (p1.army < 0) { p1.army = 0; }
            if (p1.ore < 0) { p1.ore = 0; }

            if (p2.magic < 0) { p2.magic = 0; }
            if (p2.army < 0) { p2.army = 0; }
            if (p2.ore < 0) { p2.ore = 0; }

            if (Card1.IsEnabled == false)
            {
                do
                {
                    p1.hand[0] = arr[k];
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(k));
                p1.usedCards.Add(p1.hand[0]);
                Card1.IsEnabled = true;
                k++;
            }
            if (Card2.IsEnabled == false)
            {
                do
                {
                    p1.hand[1] = arr[k];
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(k));
                p1.usedCards.Add(p1.hand[1]);
                Card2.IsEnabled = true;
                k++;
            }
            if (Card3.IsEnabled == false)
            {
                do
                {
                    p1.hand[2] = arr[k];
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(k));
                p1.usedCards.Add(p1.hand[2]);
                Card3.IsEnabled = true;
                k++;
            }
            if (Card4.IsEnabled == false)
            {
                do
                {
                    p1.hand[3] = arr[k];
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(k));
                p1.usedCards.Add(p1.hand[3]);
                Card4.IsEnabled = true;
                k++;
            }
            if (Card5.IsEnabled == false)
            {
                do
                {
                    p1.hand[4] = arr[k];
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(k));
                p1.usedCards.Add(p1.hand[4]);
                Card5.IsEnabled = true;
                k++;
            }
            if (Card6.IsEnabled == false)
            {
                do
                {
                    p1.hand[5] = arr[k];
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(k));
                p1.usedCards.Add(p1.hand[5]);
                Card6.IsEnabled = true;
                k++;
            }
            Card1.Source = CreateImage(db.cards.Find(p1.hand[0]).pic);
            Card2.Source = CreateImage(db.cards.Find(p1.hand[1]).pic);
            Card3.Source = CreateImage(db.cards.Find(p1.hand[2]).pic);
            Card4.Source = CreateImage(db.cards.Find(p1.hand[3]).pic);
            Card5.Source = CreateImage(db.cards.Find(p1.hand[4]).pic);
            Card6.Source = CreateImage(db.cards.Find(p1.hand[5]).pic);
            p1.magic += p1.wiz;
            p1.army += p1.rec;
            p1.ore += p1.mine;
            updateInfo(p1, p2);
        }

        private void MediaElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Card1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cardList.id = p1.hand[0];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[0]).name);
            card.Invoke(this, null);
            updateInfo(p1, p2);
            if (db.cards.Find(p1.hand[0]).doubleTurn == 0)
            {
                Card1.IsEnabled = false;
                endTurn();
            } else Card1.IsEnabled = false;
        }
        private void Card2_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void Card3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("иди нахуй");
        }
        private void Card4_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void Card5_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void Card6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            if (MessageBox.Show("Вы действительно хотите выйти из матча?", "Выход", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                p1.usedCards.Clear();
                this.Close();
            }
            this.IsEnabled = true;
        }
    }
}
