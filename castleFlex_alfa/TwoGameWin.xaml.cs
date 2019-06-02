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

namespace castleFlex_alfa
{
    public partial class TwoGameWin : Window
    {
        ApplicationContext db;
        public cardsList cards = new cardsList();
        public Random rnd = new Random();
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
            //playerTower.Value = a.tower;
            ptv.Content = a.tower;
            //playerWall.Value = a.wall;
            pwv.Content = a.wall;

            enemyMages.Content = $"{b.wiz}";
            enemyMagic.Content = $"{b.magic}";
            enemyRecruts.Content = $"{b.rec}";
            enemyArmy.Content = $"{b.army}";
            enemyMines.Content = $"{b.mine}";
            enemyOre.Content = $"{b.ore}";
            //enemyTower.Value = b.tower;
            etv.Content = b.tower;
            //enemyWall.Value = b.wall;
            ewv.Content = b.wall;
        }
        public void resMessage(int cost)
        {
            MessageBox.Show("Недостаточно ресурсов");
        }

        public TwoGameWin()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.cards.Load();
            updateInfo(p1, p2);
            for (int i = 0; i <= 5; i++)
            {
                p1.hand[i] = rnd.Next(1, 50);
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
        }

        private void Card2_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = p1.hand[1];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[1]).name);
            card.Invoke(this, null);
            updateInfo(p1, p2);
        }

        private void Card3_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = p1.hand[2];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[2]).name);
            card.Invoke(this, null);
            updateInfo(p1, p2);
        }

        private void Card4_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = p1.hand[3];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[3]).name);
            card.Invoke(this, null);
            updateInfo(p1, p2);
        }

        private void Card5_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = p1.hand[4];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[4]).name);
            card.Invoke(this, null);
            updateInfo(p1, p2);
        }

        private void Card6_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = p1.hand[5];
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(p1.hand[5]).name);
            card.Invoke(this, null);
            updateInfo(p1, p2);
        }
    }
}