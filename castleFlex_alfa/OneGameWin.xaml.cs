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
        public int k, swap, hodor, oldca = 0, cash, al, holdcart = 300, kkk = 300;
        bool dt, noncost = false;
        string isp = "Использованая карта ", ispp, hp = "Ваш ход: ", hm = "Ход компьютера: ", fh = "Недостаточно ресурсов, сброс карты ", typeignore = "";
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
        public void Cash(string f)
        {
            if (cash == 0)
            {
                c1.Text = f;
                cash++;
            }
            else if (cash == 1)
            {
                c2.Text = f;
                cash++;
            }
            else if (cash == 2)
            {
                c3.Text = f;
                cash++;
            }
            else if (cash == 3)
            {
                c4.Text = f;
                cash++;
            }
            else if (cash == 4)
            {
                c5.Text = f;
                cash++;
            }
            else if (cash == 5)
            {
                c6.Text = f;
                cash++;
            }
            else if (cash == 6)
            {
                c7.Text = f;
                cash++;
            }
            else
            {
                c1.Text = c2.Text;
                c2.Text = c3.Text;
                c3.Text = c4.Text;
                c4.Text = c5.Text;
                c5.Text = c6.Text;
                c6.Text = c7.Text;
                c7.Text = f;
            }
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
        public ref int cost(int x)
        {
            if (db.cards.Find(x).type == "red")
            {
                return ref p1.ore;
            }
            else if (db.cards.Find(x).type == "blue")
            {
                return ref p1.magic;
            }
            else if (db.cards.Find(x).type == "green")
            {
                return ref p1.army;
            }
            else
                return ref p1.ore;
        }
        public async void Machine()
        {
            updateInfo(p1, p2);
            await Task.Delay(1337);
            //MessageBox.Show("Ход противника");
            Sswap(p1, p2);
            if (al == 0)
            {
                int r;
                var rand = new Random();
                r = rand.Next(6);
                p2.hand[r] = CardInvoke(p2.hand[r]);
            }
            else if (al == 1)
            {
                int r;
                var rand = new Random();
                r = rand.Next(100) + 1;
                do
                {
                    //разыгровка
                    if (holdcart != 300)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((p2.hand[j] == holdcart) && (cost(p2.hand[j]) >= db.cards.Find(p2.hand[j]).cost))
                            {
                                kkk = p2.hand[j];
                                typeignore = "";
                                holdcart = 300;
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                    }
                    if ((p1.ore + p1.mine * 10 == 300) && (typeignore == "") && (holdcart == 300))
                    {
                        typeignore = "red";
                    } // близость победы по ресурсам
                    else if ((p1.magic + p1.wiz * 10 == 300) && (typeignore == "") && (holdcart == 300))
                    {
                        typeignore = "blue";
                    } // близость победы по ресурсам
                    else if ((p1.army + p1.rec * 10 == 300) && (typeignore == "") && (holdcart == 300))
                    {
                        typeignore = "green";
                    } // близость победы по ресурсам
                    else if (holdcart == 300)
                    {
                        typeignore = "";
                    }
                    for (int j = 0; j <= 5; j++)
                    {
                        if ((db.cards.Find(p2.hand[j]).logic == 0) && (cost(p2.hand[j]) >= db.cards.Find(p2.hand[j]).cost) && ((typeignore != db.cards.Find(p2.hand[j]).type) || (db.cards.Find(p2.hand[j]).cost == 0)))
                        {
                            kkk = p2.hand[j];
                            break;
                        }
                    }
                    if (kkk != 300) { break; }
                    if (r<69)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[0]).doubleTurn == 1) && (cost(p2.hand[j]) >= db.cards.Find(p2.hand[j]).cost) && ((typeignore != db.cards.Find(p2.hand[j]).type) || (db.cards.Find(p2.hand[j]).cost == 0)))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                    }
                    if ((p1.tower < 15 || p1.tower > 85) && (p2.tower > 10 || p2.tower < 90 || p1.tower > 95))
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 1) && (cost(p2.hand[j]) >= db.cards.Find(p2.hand[j]).cost) && ((typeignore != db.cards.Find(p2.hand[j]).type) || (db.cards.Find(p2.hand[j]).cost == 0)))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                    } //крайняя близость к победе через гонку башен или потере своей башни
                    else if ((p2.tower <= 15))
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 4) && (cost(p2.hand[j]) >= db.cards.Find(p2.hand[j]).cost) && ((typeignore != db.cards.Find(p2.hand[j]).type) || (db.cards.Find(p2.hand[j]).cost == 0)))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                            if (kkk != 300) { break; }
                        }
                    } // крайняя близость к победе связанной с потерей врагом башни             
                    else if (r <= 35)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 1) && (cost(p2.hand[j]) >= db.cards.Find(p2.hand[j]).cost) && ((typeignore != db.cards.Find(p2.hand[j]).type) || (db.cards.Find(p2.hand[j]).cost == 0)))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                    }
                    else if (k > 35 && k <= 50)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 2) && (cost(p2.hand[j]) >= db.cards.Find(p2.hand[j]).cost) && ((typeignore != db.cards.Find(p2.hand[j]).type) || (db.cards.Find(p2.hand[j]).cost == 0)))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                    }
                    else if (k > 50 && k <= 70)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 3 && (cost(p2.hand[j]) >= db.cards.Find(p2.hand[j]).cost) && ((typeignore != db.cards.Find(p2.hand[j]).type) || (db.cards.Find(p2.hand[j]).cost == 0))))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                    }
                    else if (k > 70 && k <= 95)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 4) && (cost(p2.hand[j]) >= db.cards.Find(p2.hand[j]).cost) && ((typeignore != db.cards.Find(p2.hand[j]).type) || (db.cards.Find(p2.hand[j]).cost == 0)))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                    }
                    else if (k > 95)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 5) && (cost(p2.hand[j]) >= db.cards.Find(p2.hand[j]).cost) && ((typeignore != db.cards.Find(p2.hand[j]).type) || (db.cards.Find(p2.hand[j]).cost == 0)))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                    }
                    //нехватка мана - выбор карты для накопления
                    if ((holdcart == 300) && (p1.tower < 15 || p1.tower > 85) && (p2.tower > 10 || p2.tower < 90 || p1.tower > 95))
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 1) && (db.cards.Find(p2.hand[j]).cost > 11))
                            {
                                holdcart = p2.hand[j];
                                typeignore = db.cards.Find(p2.hand[j]).type;
                                break;
                            }
                        }
                    } //крайняя близость к победе через гонку башен или потере своей башни
                    else if ((holdcart == 300) && (p2.tower <= 15))
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 4) && (db.cards.Find(p2.hand[j]).cost > 11))
                            {
                                holdcart = p2.hand[j];
                                typeignore = db.cards.Find(p2.hand[j]).type;
                                break;
                            }
                        }
                    } // крайняя близость к победе связанной с потерей врагом башни
                    if (holdcart == 300 && r <= 35)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 1) && (db.cards.Find(p2.hand[j]).cost > 11))
                            {
                                holdcart = p2.hand[j];
                                typeignore = db.cards.Find(p2.hand[j]).type;
                                break;
                            }
                        }
                    }
                    else if (holdcart == 300 && k > 35 && k <= 50)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 2) && (db.cards.Find(p2.hand[j]).cost > 11))
                            {
                                holdcart = p2.hand[j];
                                typeignore = db.cards.Find(p2.hand[j]).type;
                                break;
                            }
                        }
                    }
                    else if (holdcart == 300 && k > 50 && k <= 70)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 3) && (db.cards.Find(p2.hand[j]).cost > 11))
                            {
                                holdcart = p2.hand[j];
                                typeignore = db.cards.Find(p2.hand[j]).type;
                                break;
                            }
                        }
                    }
                    else if (holdcart == 300 && k > 70 && k <= 95)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 4) && (db.cards.Find(p2.hand[j]).cost > 11))
                            {
                                holdcart = p2.hand[j];
                                typeignore = db.cards.Find(p2.hand[j]).type;
                                break;
                            }
                        }
                    }
                    else if (holdcart == 300 && k > 95)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 5) && (db.cards.Find(p2.hand[j]).cost > 11))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                    }
                    //выбор карты для сброса
                    if (kkk == 300)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 5) && (cost(p2.hand[j]) < db.cards.Find(p2.hand[j]).cost) && (p2.hand[j]!= holdcart))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 3) && (cost(p2.hand[j]) < db.cards.Find(p2.hand[j]).cost) && (p2.hand[j] != holdcart))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 2) && (cost(p2.hand[j]) < db.cards.Find(p2.hand[j]).cost) && (p2.hand[j] != holdcart))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 4) && (cost(p2.hand[j]) < db.cards.Find(p2.hand[j]).cost) && (p2.hand[j] != holdcart))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 1) && (cost(p2.hand[j]) < db.cards.Find(p2.hand[j]).cost) && (p2.hand[j] != holdcart))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((db.cards.Find(p2.hand[j]).logic == 0) && (cost(p2.hand[j]) < db.cards.Find(p2.hand[j]).cost) && (p2.hand[j] != holdcart))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((cost(p2.hand[j]) < db.cards.Find(p2.hand[j]).cost) && (p2.hand[j] != holdcart))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((typeignore != db.cards.Find(p2.hand[j]).type))
                            {
                                kkk = p2.hand[j];
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                        for (int j = 0; j <= 5; j++)
                        {
                            if ((p2.hand[j] == holdcart))
                            {
                                kkk = p2.hand[j];
                                typeignore = "";
                                holdcart = 300;
                                break;
                            }
                        }
                        if (kkk != 300) { break; }
                    }
                } while (kkk != 300);
                for (int j = 0; j <= 5; j++)
                {
                    if (p2.hand[j] == kkk)
                    {
                        p2.hand[j] = CardInvoke(p2.hand[j]);
                        kkk = 300;
                        break;
                    }
                }
                //MessageBox.Show("Ошибка элемент: " + kkk + " Не найден среди: " + p2.hand[0] + " " + p2.hand[1] + " " + p2.hand[2] + " " + p2.hand[3] + " " + p2.hand[4] + " " + p2.hand[5]);
            }
            Sswap(p2, p1);
            Dealer();
            return;
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
            updateInfo(p1, p2);
            if (dt == false)
            {
                if (hodor == 1)
                {
                    endH();
                    hodor = 2;
                    CardGrid.IsEnabled = false;
                    Cash(hm);
                    Machine();
                }
                else if (hodor == 2)
                {
                    endH();
                    hodor = 1;
                    CardGrid.IsEnabled = true;
                    Cash(hp);
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
            

            startGame();
        }
        public void resMessage(int cost)
        {
            noncost = true;
            Cash(fh);
            //MessageBox.Show("Недостаточно ресурсов, карта сбрасывается");
        }
        public void startGame()
        {
            p1 = new player(50, 0, 1, 15, 1, 15, 1, 15);
            p2 = new player(50, 0, 1, 15, 1, 15, 1, 15);
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
            noncost = false;
            oldca = 0;
            cash = 0;
            Cash(hp);
            al = 0;
            holdcart = 300;
            kkk = 300;
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
            k = 0;
        }
        public void win()
        {
            if ((p2.tower <= 0) || (p1.tower >= 100) || (p1.magic >= 300) || (p1.army >= 300) || (p1.ore >= 300))
            {
                MessageBox.Show("Вы победили!", "Игра окончена", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else if ((p1.tower <= 0) || (p2.tower >= 100) || (p2.magic >= 300) || (p2.army >= 300) || (p2.ore >= 300))
            {
                MessageBox.Show("Вы проиграли!", "Игра окончена", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }
        public void endH()
        {
            if (hodor == 2)
            {
                p2.magic += p2.wiz;
                p2.army += p2.rec;
                p2.ore += p2.mine;
            }
            else if (hodor == 1)
            {
                p1.magic += p1.wiz;
                p1.army += p1.rec;
                p1.ore += p1.mine;
            }
            oldca = 0;
            updateInfo(p1, p2);
            win();
        }
        private int CardInvoke(int a)
        {
            cardList.id = a;
            if (cost(a) >= db.cards.Find(a).cost)
            {
                MethodInfo card = cards.GetType().GetMethod(db.cards.Find(a).name);
                card.Invoke(this, null);
            }
            else resMessage(db.cards.Find(a).cost);
            ispp = isp + db.cards.Find(a).name;
            Cash(ispp);
            if (noncost != true)
            {
                if (db.cards.Find(a).doubleTurn != 0) dt = true; else dt = false;
            }
            else { dt = false; }
            noncost = false;
            Oldcard(a);
            a = arr[k];
            if (k == 99)
            {
                Ksort();
            }
            else { k++; }
            return a;
        }
        private void kniga_Click(object sender, RoutedEventArgs e)
        {
            if (phonesList.Visibility == Visibility.Collapsed)
            {
                phonesList.Visibility = Visibility.Visible;
            }
            else phonesList.Visibility = Visibility.Collapsed;
        }
        private void mozg_Click(object sender, RoutedEventArgs e)
        {
            if (Algo.Visibility == Visibility.Collapsed)
            {
                Algo.Visibility = Visibility.Visible;
            }
            else Algo.Visibility = Visibility.Collapsed;
        }
        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            Algo.Visibility = Visibility.Collapsed;
            al = 0;
        }
        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            Algo.Visibility = Visibility.Collapsed;
            al = 1;
        }
        private void Card1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card1.IsEnabled = false;
            //p1.hand[0] = 25;
            p1.hand[0]=CardInvoke(p1.hand[0]);
            Dealer();
            Card1.IsEnabled = true;
        }
        private void Card2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card2.IsEnabled = false;
            p1.hand[1] = CardInvoke(p1.hand[1]);
            Dealer();
            Card2.IsEnabled = true;
        }
        private void Card3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card3.IsEnabled = false;
            p1.hand[2] = CardInvoke(p1.hand[2]);
            Dealer();
            Card3.IsEnabled = true;
        }
        private void Card4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card4.IsEnabled = false;
            p1.hand[3] = CardInvoke(p1.hand[3]);
            Dealer();
            Card4.IsEnabled = true;
        }
        private void Card5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card5.IsEnabled = false;
            p1.hand[4] = CardInvoke(p1.hand[4]);
            Dealer();
            Card5.IsEnabled = true;
        }
        private void Card6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card6.IsEnabled = false;
            p1.hand[5] = CardInvoke(p1.hand[5]);
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
        private void MediaElement_MouseDown(object sender, MouseButtonEventArgs e) 
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        } // движение формы
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
