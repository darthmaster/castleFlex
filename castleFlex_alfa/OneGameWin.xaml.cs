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
            }
        }
        public static player p1 = new player(50, 0, 1, 15, 1, 15, 1, 15);
        public static player p2 = new player(50, 0, 1, 15, 1, 15, 1, 15);
        public void updateInfo(player a, player b)
        {
            if (a.wiz <= 0) { a.wiz = 1; }
            if (a.rec <= 0) { a.rec = 1; }
            if (a.mine <= 0) { a.mine = 1; }
            if (a.magic < 0) { a.magic = 0; }
            if (a.army < 0) { a.army = 0; }
            if (a.ore < 0) { a.ore = 0; }
            if (b.wiz <= 0) { b.wiz = 1; }
            if (b.rec <= 0) { b.rec = 1; }
            if (b.mine <= 0) { b.mine = 1; }
            if (b.magic < 0) { b.magic = 0; }
            if (b.army < 0) { b.army = 0; }
            if (b.ore < 0) { b.ore = 0; }
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
            Card1.Source = CreateImage(db.cards.Find(p1.hand[0]).pic);
            Card2.Source = CreateImage(db.cards.Find(p1.hand[1]).pic);
            Card3.Source = CreateImage(db.cards.Find(p1.hand[2]).pic);
            Card4.Source = CreateImage(db.cards.Find(p1.hand[3]).pic);
            Card5.Source = CreateImage(db.cards.Find(p1.hand[4]).pic);
            Card6.Source = CreateImage(db.cards.Find(p1.hand[5]).pic);
            
            //t3z.Height = 125;
            //System.Windows.Thickness bs = new System.Windows.Thickness(85, 125, 0, 0);
            //t3.Margin = bs;
            
        }
        public void krupbe()
        {
            //dealer
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
            } //украинский рандом

            for (int i = 0; i <= 5; i++)
            {
                p1.hand[i] = arr[i];
                p2.hand[i] = arr[i + 6];
            }
            k = 12;
            
            updateInfo(p1, p2);

            this.DataContext = db.cards.Local.ToBindingList();
            
        }

        public void resMessage(int cost)
        {
            MessageBox.Show("Недостаточно ресурсов, карта сбрасывается");
        }

        public void startGame()
        {

        }

        public void Ksort()
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

        public void win()
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
        }
        public void newTurn()
        {
            p1.magic += p1.wiz;
            p1.army += p1.rec;
            p1.ore += p1.mine;
            p2.magic += p2.wiz;
            p2.army += p2.rec;
            p2.ore += p2.mine;


            updateInfo(p1, p2);
            win();
        }

        private void MediaElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Card1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card1.IsEnabled = false;
            cardList.id = p1.hand[0];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[0]).name);
            card.Invoke(this, null);
            //if (db.cards.Find(p1.hand[0]).doubleTurn == 0) {}

            p1.hand[0] = arr[k];
            if (k == 100)
            {
                Ksort();
            }
            else { k++; }
            newTurn();
            Card1.IsEnabled = true;
        }
        private void Card2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card2.IsEnabled = false;
            cardList.id = p1.hand[1];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[1]).name);
            card.Invoke(this, null);
            //if (db.cards.Find(p1.hand[1]).doubleTurn == 0) {}

            p1.hand[1] = arr[k];
            if (k == 100)
            {
                Ksort();
            }
            else { k++; }
            newTurn();
            Card2.IsEnabled = true;
        }
        private void Card3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card3.IsEnabled = false;
            cardList.id = p1.hand[2];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[2]).name);
            card.Invoke(this, null);
            //if (db.cards.Find(p1.hand[2]).doubleTurn == 0) {}

            p1.hand[2] = arr[k];
            if (k == 100)
            {
                Ksort();
            }
            else { k++; }
            newTurn();
            Card3.IsEnabled = true;
        }
        private void Card4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card4.IsEnabled = false;
            cardList.id = p1.hand[3];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[3]).name);
            card.Invoke(this, null);
            //if (db.cards.Find(p1.hand[3]).doubleTurn == 0) {}

            p1.hand[3] = arr[k];
            if (k == 100)
            {
                Ksort();
            }
            else { k++; }
            newTurn();
            Card4.IsEnabled = true;
        }
        private void Card5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card5.IsEnabled = false;
            cardList.id = p1.hand[4];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[4]).name);
            card.Invoke(this, null);
            //if (db.cards.Find(p1.hand[4]).doubleTurn == 0) {}

            p1.hand[4] = arr[k];
            if (k == 100)
            {
                Ksort();
            }
            else { k++; }
            newTurn();
            Card5.IsEnabled = true;
        }
        private void Card6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card6.IsEnabled = false;
            cardList.id = p1.hand[5];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[5]).name);
            card.Invoke(this, null);
            //if (db.cards.Find(p1.hand[5]).doubleTurn == 0) {}

            p1.hand[5] = arr[k];
            if (k == 100)
            {
                Ksort();
            }
            else { k++; }
            newTurn();
            Card6.IsEnabled = true;
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            if (MessageBox.Show("Вы действительно хотите выйти из матча?", "Выход", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
            this.IsEnabled = true;
        }
    }
}
