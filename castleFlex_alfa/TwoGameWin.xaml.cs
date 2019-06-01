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

namespace castleFlex_alfa
{
    public partial class TwoGameWin : Window
    {
        ApplicationContext db;
        //public delegate void del();
        public cardsList cards = new cardsList(); 
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cardsList.id = 1;
            MethodInfo card = cards.GetType().GetMethod(db.cards.Find(1).name);
            card.Invoke(this,null);
            updateInfo(p1, p2);
        }
    }
}