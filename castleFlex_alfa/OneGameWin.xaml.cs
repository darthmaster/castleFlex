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
        public int k, swap, hodor, oldca=0;
        bool dt;
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

        public void Oldcard(int a)
        {
            if (dt == true)
            {
                if (oldca == 0)
                {
                    OldCard1.Source = null;
                    OldCard2.Source = null;
                    OldCard0.Source = CreateImage(db.cards.Find(a).pic);
                    oldca++;
                }
                else if (oldca == 1)
                {
                    OldCard1.Source = CreateImage(db.cards.Find(a).pic);
                    oldca++;
                }
                else if (oldca == 2)
                {
                    OldCard2.Source = CreateImage(db.cards.Find(a).pic);
                    oldca++;
                }
                else
                {
                    oldca = 0;
                    OldCard0.Source = CreateImage(db.cards.Find(a).pic);
                }
            }
            else
            {
                if (oldca == 0)
                {
                    OldCard1.Source = null;
                    OldCard2.Source = null;
                    OldCard0.Source = CreateImage(db.cards.Find(a).pic);
                }
                else if (oldca == 1)
                {
                    OldCard1.Source = CreateImage(db.cards.Find(a).pic);
                }
                else if (oldca == 2)
                {
                    OldCard2.Source = CreateImage(db.cards.Find(a).pic);
                }
                else
                {
                    oldca = 0;
                    OldCard0.Source = CreateImage(db.cards.Find(a).pic);
                }
            }
        }

        public void Sswap(player a, player b)
        {
            swap = a.tower;
            a.tower = b.tower;
            b.tower = swap;
            swap = a.wall;
            a.wall = b.wall;
            b.wall = swap;
            swap = a.wiz;
            a.wiz = b.wiz;
            b.wiz = swap;
            swap = a.magic;
            a.magic = b.magic;
            b.magic = swap;
            swap = a.rec;
            a.rec = b.rec;
            b.rec = swap;
            swap = a.army;
            a.army = b.army;
            b.army = swap;
            swap = a.mine;
            a.mine = b.mine;
            b.mine = swap;
            swap = a.ore;
            a.ore = b.ore;
            b.ore = swap;
        }

        public void Machine()
        {
            updateInfo(p1, p2);
            //MessageBox.Show("Ход противника");
            int r;
            Sswap(p1,p2);
            var rand = new Random();
            r = rand.Next(6);
            cardList.id = p2.hand[r];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p2.hand[r]).name);
            card.Invoke(this, null);
            //if (db.cards.Find(p2.hand[r]).doubleTurn == 0){ dt = false;}else dt = true;
            if (db.cards.Find(p2.hand[r]).doubleTurn != 0) dt = true;
            Oldcard(p2.hand[r]);
            p2.hand[r] = arr[k];
            if (k == 99)
            {
                Ksort();
            }
            else { k++; }

            Sswap(p2, p1);
            System.Threading.Thread.Sleep(500); // подумать жи надо
            Dealer();
        }

        public void Dealer()
        {
            #region debug143
            if (p1.tower < 0) { p1.tower = 0; }
            if (p1.wall < 0) { p1.wall = 0; }
            if (p1.wiz <= 0) { p1.wiz = 1; }
            if (p1.rec <= 0) { p1.rec = 1; }
            if (p1.mine <= 0) { p1.mine = 1; }
            if (p1.magic < 0) { p1.magic = 0; }
            if (p1.army < 0) { p1.army = 0; }
            if (p1.ore < 0) { p1.ore = 0; }

            if (p2.tower < 0) { p2.tower = 0; }
            if (p2.wall < 0) { p2.wall = 0; }
            if (p2.wiz <= 0) { p2.wiz = 1; }
            if (p2.rec <= 0) { p2.rec = 1; }
            if (p2.mine <= 0) { p2.mine = 1; }
            if (p2.magic < 0) { p2.magic = 0; }
            if (p2.army < 0) { p2.army = 0; }
            if (p2.ore < 0) { p2.ore = 0; }
            #endregion
            if (dt == false)
            {
                if (hodor == 1)
                {
                    endH();
                    hodor = 2;
                    CardGrid.IsEnabled = false;
                    Machine();
                }
                else if (hodor == 2)
                {
                    endH();
                    hodor = 1;
                    CardGrid.IsEnabled = true;
                }
            }
            else
            {
                dt = false;
                if (hodor == 1)
                {
                    CardGrid.IsEnabled = true;
                }
                else if (hodor == 2)
                {
                    CardGrid.IsEnabled = false;
                    Machine();
                }
                updateInfo(p1, p2);
                win();
            }
        }
        public OneGameWin()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.cards.Load();
            //player ppp = new player(50, 0, 1, 15, 1, 15, 1, 15);
            //p1 = ppp;
            //p2 = ppp;

            Ksort();

            for (int i = 0; i <= 5; i++)
            {
                p1.hand[i] = arr[i];
                p2.hand[i] = arr[i + 6];
            }
            k = 12;
            
            updateInfo(p1, p2);

            this.DataContext = db.cards.Local.ToBindingList();

            hodor = 1;
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
        }
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
        public void endH()
        {
            if (hodor == 1)
            {
                p2.magic += p2.wiz;
                p2.army += p2.rec;
                p2.ore += p2.mine;
            }
            else if (hodor == 2)
            {
                p1.magic += p1.wiz;
                p1.army += p1.rec;
                p1.ore += p1.mine;
            }
            oldca = 0;
            updateInfo(p1, p2);
            win();
        }

        private void Card1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card1.IsEnabled = false;
            //p1.hand[0] = 2;
            cardList.id = p1.hand[0];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[0]).name);
            card.Invoke(this, null);
            if (db.cards.Find(p1.hand[0]).doubleTurn != 0) dt = true;
            Oldcard(p1.hand[0]);
            p1.hand[0] = arr[k];
            if (k == 99)
            {
                Ksort();
            }
            else { k++; }
            Dealer();
            Card1.IsEnabled = true;
        }
        private void Card2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card2.IsEnabled = false;
            cardList.id = p1.hand[1];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[1]).name);
            card.Invoke(this, null);
            if (db.cards.Find(p1.hand[1]).doubleTurn != 0) dt = true;
            Oldcard(p1.hand[1]);
            p1.hand[1] = arr[k];
            if (k == 99)
            {
                Ksort();
            }
            else { k++; }
            Dealer();
            Card2.IsEnabled = true;
        }
        private void Card3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card3.IsEnabled = false;
            cardList.id = p1.hand[2];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[2]).name);
            card.Invoke(this, null);
            if (db.cards.Find(p1.hand[2]).doubleTurn != 0) dt = true;
            Oldcard(p1.hand[2]);
            p1.hand[2] = arr[k];
            if (k == 99)
            {
                Ksort();
            }
            else { k++; }
            Dealer();
            Card3.IsEnabled = true;
        }
        private void Card4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card4.IsEnabled = false;
            cardList.id = p1.hand[3];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[3]).name);
            card.Invoke(this, null);
            if (db.cards.Find(p1.hand[3]).doubleTurn != 0) dt = true;
            Oldcard(p1.hand[3]);
            p1.hand[3] = arr[k];
            if (k == 99)
            {
                Ksort();
            }
            else { k++; }
            Dealer();
            Card4.IsEnabled = true;
        }
        private void Card5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card5.IsEnabled = false;
            cardList.id = p1.hand[4];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[4]).name);
            card.Invoke(this, null);
            if (db.cards.Find(p1.hand[4]).doubleTurn != 0) dt = true;
            Oldcard(p1.hand[4]);
            p1.hand[4] = arr[k];
            if (k == 99)
            {
                Ksort();
            }
            else { k++; }
            Dealer();
            Card5.IsEnabled = true;
        }
        private void Card6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card6.IsEnabled = false;
            cardList.id = p1.hand[5];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[5]).name);
            card.Invoke(this, null);
            if (db.cards.Find(p1.hand[5]).doubleTurn != 0) dt = true;
            Oldcard(p1.hand[5]);
            p1.hand[5] = arr[k];
            if (k == 99)
            {
                Ksort();
            }
            else { k++; }
            Dealer();
            Card6.IsEnabled = true;
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
        private void MediaElement_MouseDown(object sender, MouseButtonEventArgs e) // движение формы
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void menu_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            if (MessageBox.Show("Вы действительно хотите выйти из матча?", "Выход", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
            this.IsEnabled = true;
        } // выход
    }
}
