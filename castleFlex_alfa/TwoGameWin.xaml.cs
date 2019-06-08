using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Reflection;
using System.IO;
using System.Windows.Threading;
using System.Threading;

namespace castleFlex_alfa
{
    public partial class TwoGameWin : Window
    {
        int t = 0;
        ApplicationContext db;
        
        public cardsList cards;// = new cardsList();
        public Random rnd = new Random();
        public GlobalVariables global = new GlobalVariables();
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
            playerTower.Value = a.tower;
            ptv.Content = a.tower;
            playerWall.Value = a.wall;
            pwv.Content = a.wall;

            enemyMages.Content = $"{b.wiz}";
            enemyMagic.Content = $"{b.magic}";
            enemyRecruts.Content = $"{b.rec}";
            enemyArmy.Content = $"{b.army}";
            enemyMines.Content = $"{b.mine}";
            enemyOre.Content = $"{b.ore}";
            enemyTower.Value = b.tower;
            etv.Content = b.tower;
            enemyWall.Value = b.wall;
            ewv.Content = b.wall;
        }
        public void resMessage(int cost)
        {
            MessageBox.Show("Недостаточно ресурсов");
        }
        private void Timer_Tick(object sender, object e)
        {
            t += 1;
            gameTimer.Content = t;
        }

        public void endTurn()
        {
            string gameInfo =
                $"{p1.tower}*{p1.wall}*" +
                $"{p1.wiz}*{p1.magic}*" +
                $"{p1.rec}*{p1.army}*" +
                $"{p1.mine}*{p1.ore}*" +
                $"{p2.tower}*{p2.wall}*" +
                $"{p2.wiz}*{p2.magic}*" +
                $"{p2.rec}*{p2.army}*" +
                $"{p2.mine}*{p2.ore}*";
            try
            {
                net.sendData(gameInfo, global.ip , global.port);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
            try
            {
                //Thread rt = new Thread(new ThreadStart(rt));
                string gameInfo = net.receiveData(global.recport);
                string[] data = gameInfo.Split('*');

                p2.tower = Convert.ToInt32(data[0]); p2.wall = Convert.ToInt32(data[1]);
                p2.wiz = Convert.ToInt32(data[2]); p2.magic = Convert.ToInt32(data[3]);
                p2.rec = Convert.ToInt32(data[4]); p2.army = Convert.ToInt32(data[5]);
                p2.mine = Convert.ToInt32(data[6]); p2.ore = Convert.ToInt32(data[7]);

                p1.tower = Convert.ToInt32(data[8]); p1.wall = Convert.ToInt32(data[9]);
                p1.wiz = Convert.ToInt32(data[10]); p1.magic = Convert.ToInt32(data[11]);
                p1.rec = Convert.ToInt32(data[12]); p1.army = Convert.ToInt32(data[13]);
                p1.mine = Convert.ToInt32(data[14]); p1.ore = Convert.ToInt32(data[15]);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
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

            if (card1.IsEnabled == false)
            {
                int i;
                do
                {
                    i = rnd.Next(0,99);
                    p1.hand[0] = i;
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(i));
                p1.usedCards.Add(p1.hand[0]);
                card1.IsEnabled = true;
            }
            if (card2.IsEnabled == false)
            {
                int i;
                do
                {
                    i = rnd.Next(0, 99);
                    p1.hand[1] = i;
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(i));
                p1.usedCards.Add(p1.hand[1]);
                card2.IsEnabled = true;
            }
            if (card3.IsEnabled == false)
            {
                int i;
                do
                {
                    i = rnd.Next(0, 99);
                    p1.hand[2] = i;
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(i));
                p1.usedCards.Add(p1.hand[2]);
                card3.IsEnabled = true;
            }
            if (card4.IsEnabled == false)
            {
                int i;
                do
                {
                    i = rnd.Next(0, 99);
                    p1.hand[3] = i;
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(i));
                p1.usedCards.Add(p1.hand[3]);
                card4.IsEnabled = true;
            }
            if (card5.IsEnabled == false)
            {
                int i;
                do
                {
                    i = rnd.Next(0, 99);
                    p1.hand[4] = i;
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(i));
                p1.usedCards.Add(p1.hand[4]);
                card5.IsEnabled = true;
            }
            if (card6.IsEnabled == false)
            {
                int i;
                do
                {
                    i = rnd.Next(0, 99);
                    p1.hand[5] = i;
                    if (p1.usedCards.Count == 99)
                    {
                        MessageBox.Show("В колоде закончились карты!\nРаздаётся новая...", "Колода пуста!");
                        p1.usedCards.Clear();
                        break;
                    }
                } while (p1.usedCards.Contains(i));
                p1.usedCards.Add(p1.hand[5]);
                card6.IsEnabled = true;
            }
            card1.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[0]).pic));
            card2.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[1]).pic));
            card3.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[2]).pic));
            card4.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[3]).pic));
            card5.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[4]).pic));
            card6.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[5]).pic));
            p1.magic += p1.wiz;
            p1.army += p1.rec;
            p1.ore += p1.mine;
            updateInfo(p1, p2);
        }
        public TwoGameWin()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.cards.Load();
            cards = new cardsList();            
            DispatcherTimer time = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            time.Tick += Timer_Tick;
            time.Start();
            p1name.Content = global.username;
            try
            {
                net.nameChanger(global.ip, global.port, global.recport);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            updateInfo(p1, p2);
            for (int i = 0; i <= 5; i++)
            {
                p1.hand[i] = rnd.Next(0, 99);
                p1.usedCards.Add(p1.hand[i]);
            }
            card1.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[0]).pic));
            card2.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[1]).pic));
            card3.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[2]).pic));
            card4.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[3]).pic));
            card5.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[4]).pic));
            card6.Background = new ImageBrush(MainWindow.CreateImage(db.cards.Find(p1.hand[5]).pic));
        }

        private void Card1_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = p1.hand[0];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[0]).name);
            card.Invoke(this,null);
            updateInfo(p1, p2);
            if (db.cards.Find(p1.hand[0]).doubleTurn == 0)
            {
                card1.IsEnabled = false;
                endTurn();
            }
            else card1.IsEnabled = false;
        }

        private void Card2_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = p1.hand[1];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[1]).name);
            card.Invoke(this, null);
            updateInfo(p1, p2);
            if (db.cards.Find(p1.hand[1]).doubleTurn == 0)
            {
                card2.IsEnabled = false;
                endTurn();
            }
            else card2.IsEnabled = false;
        }

        private void Card3_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = p1.hand[2];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[2]).name);
            card.Invoke(this, null);
            updateInfo(p1, p2);
            if (db.cards.Find(p1.hand[2]).doubleTurn == 0)
            {
                card3.IsEnabled = false;
                endTurn();
            }
            else card3.IsEnabled = false;
        }

        private void Card4_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = p1.hand[3];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[3]).name);
            card.Invoke(this, null);
            updateInfo(p1, p2);
            if (db.cards.Find(p1.hand[3]).doubleTurn == 0)
            {
                card4.IsEnabled = false;
                endTurn();
            }
            else card4.IsEnabled = false;
        }

        private void Card5_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = p1.hand[4];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[4]).name);
            card.Invoke(this, null);
            updateInfo(p1, p2);
            if (db.cards.Find(p1.hand[4]).doubleTurn == 0)
            {
                card5.IsEnabled = false;
                endTurn();
            }
            else card5.IsEnabled = false;
        }

        private void Card6_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = p1.hand[5];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[5]).name);
            card.Invoke(this, null);
            updateInfo(p1, p2);
            if (db.cards.Find(p1.hand[5]).doubleTurn == 0)
            {
                card6.IsEnabled = false;
                endTurn();
            }
            else card6.IsEnabled = false;
        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.IsEnabled = false;
            if (MessageBox.Show("Вы действительно хотите выйти из матча?", "Выход", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                p1.usedCards.Clear();
                this.Close();                
            }
            else grid.IsEnabled = true;
        }
    }
}