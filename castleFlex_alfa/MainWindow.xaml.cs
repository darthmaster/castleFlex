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

namespace castleFlex_alfa
{
    public class GlobalVariables
    {
        public static string username { get; set; }
        public static string ip { get; set; }
        public static int port { get; set; }
        public static int recport { get; set; }
        public static bool server { get; set; }
    }
    public partial class MainWindow : Window
    {
        public GlobalVariables global = new GlobalVariables();
        ApplicationContext db;
        public static BitmapImage CreateImage(byte[] imageData)
        {
            MemoryStream byteStream = new MemoryStream(imageData);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            return image;
        }  // функция преобразование byte to ImageSourse
        
        public MainWindow()
        {
            InitializeComponent();
            multi.Visibility = Visibility.Collapsed;
            guideBox.Visibility = Visibility.Collapsed;
            MediaElement.Play();
            db = new ApplicationContext();
            db.cards.Load();
            this.DataContext = db.cards.Local.ToBindingList();
        }
        private void OneGame(object sender, RoutedEventArgs e) 
        {
            OneGameWin onegame = new OneGameWin();
            onegame.Show();
        }
        private void TwoGether(object sender, RoutedEventArgs e)
        {
            if (guideBox.Visibility == Visibility.Visible)
            {
                guideBox.Visibility = Visibility.Collapsed;
            }
            if (multi.Visibility == Visibility.Visible)
            {
                multi.Visibility = Visibility.Hidden;
            }
            else multi.Visibility = Visibility.Visible;
        }
        private void MediaElement_MediaEnded_1(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 0);
            MediaElement.Position = ts;
            MediaElement.Play();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            guideBox.Text = "    У каждого игрока имеется случайный набор из 6 карт, башня, стена, ресурсы трёх типов и их источники. \n    Ресурсы: " +
                "\n    - Магия\n    - Отряды\n    - Руда" +
                "\n    Источники ресурсов(соответственно):" +
                "\n    - Монастырь\n    - Казармы\n    - Шахта" +
                "\n    В начале каждого хода источники увеличивают количества соответствующих ресурсов игрока на текущие уровни этих источников. " +
                "Каждый ход игрок должен использовать или сбросить одну из своих карт. Для использования карты требуется определённое количество " +
                "одного из ресурсов.После использования карта выполняет комбинацию некоторых действий и вместо неё игроку случайным образом " +
                "выдаётся другая. Далее, если карта не предписывает иное, ход переходит к другому игроку. \n    Действия карт:" +
                "\n    - Причинение вреда стене и/или башне (противника или как противника, так и своей)" +
                "\n    - Изменение количества ресурсов или уровней их источников у себя и/или противника" +
                "\n    - Увеличение собственных стены и/или башни" +
                "\n    Правила игры допускают победу любым из следующих способов:" +
                "\n    - Строительство своей башни до 100" +
                "\n    - Накопление любого ресурса до 300" +
                "\n    - Уничтожение башни противника" +
                "\n    Как правило, карты, требующие одинаковый тип ресурсов, сходны по действию. " +
                "Магия — увеличение башни и нанесение урона, Руда — увеличение стен и башни, Отряды — на нанесение урона противнику. " +
                "Урон может быть направлен конкретно на башню или стену, или иметь общий характер. " +
                "Во втором случае в первую очередь урон принимает стена, затем башня.";
            if (multi.Visibility == Visibility.Visible)
            {
                multi.Visibility = Visibility.Collapsed;
            }
            if (guideBox.Visibility == Visibility.Collapsed)
            {
                guideBox.Visibility = Visibility.Visible;
            } else guideBox.Visibility = Visibility.Collapsed;
        }

        private void OtherButton_Click(object sender, RoutedEventArgs e)
        {
            guideBox.Text = "\n \n \n \n     Игра разработана студентами колледжа информатики и программирования, Беловым Александром Игоревичем и Султановым Альбертом Ильдаровичем в 2019 году.";
            if (multi.Visibility == Visibility.Visible)
            {
                multi.Visibility = Visibility.Collapsed;
            }
            if (guideBox.Visibility == Visibility.Collapsed)
            {
                guideBox.Visibility = Visibility.Visible;
            }
            else guideBox.Visibility = Visibility.Collapsed;
        }

        private void MediaElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void MultiStart_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.username = username.Text;
            GlobalVariables.ip = ip.Text;
            GlobalVariables.port = Convert.ToInt32(port.Text);
            GlobalVariables.recport = Convert.ToInt32(recport.Text);
            TwoGameWin multiGame = new TwoGameWin();
            if (serverBtn.IsChecked==false && clientBtn.IsChecked == false)
            {
                MessageBox.Show("Вы не выбрали режим подключения");
            }
            else if (serverBtn.IsChecked == true)
            {
                GlobalVariables.server = true;
                multiGame.ShowDialog();
            }
            else if (clientBtn.IsChecked == true)
            {
                GlobalVariables.server = false;
                multiGame.Show();
            }
        }
    }
}
