using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Data.SQLite;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace castleFlex_alfa
{
    class card
    {
        public int id { get; set; }
        public byte[] pic { get; set; }
        public int cost { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public int doubleTurn { get; set; }
    }

    public class cardsList
    {
        static ApplicationContext db = new ApplicationContext();
        public static int id;
        
        static TwoGameWin TwoGameWin = new TwoGameWin();
        #region Эффекты карт
        public static void Attack(int a) //нанесение урона врагу
        {
            if ((TwoGameWin.p2.wall - a) <= 0)
            {
                TwoGameWin.p2.tower -= a - TwoGameWin.p2.wall;
                TwoGameWin.p2.wall = 0;
            }
            else TwoGameWin.p2.wall -= a;
        }
        public static void SelfAttack(int a) //нанесение урона по себе
        {
            if ((TwoGameWin.p1.wall - a) <= 0)
            {
                TwoGameWin.p1.tower -= a - TwoGameWin.p1.wall;
                TwoGameWin.p1.wall = 0;
            }
            else TwoGameWin.p1.wall -= a;
        }
        public static void PWlP(int a) //стена +
        {
            TwoGameWin.p1.wall += a;
        }
        public static void PWlM(int a) //стена -
        {
            TwoGameWin.p1.wall -= a;
        }
        public static void EWlP(int a) //вражеская стена +
        {
            TwoGameWin.p2.wall += a;
        }
        public static void EWlM(int a) //вражеская стена -
        {
            TwoGameWin.p2.wall -= a;
        }
        public static void PTP(int a) //башня +
        {
            TwoGameWin.p1.tower += a;
        }
        public static void PTM(int a) //башня -
        {
            TwoGameWin.p1.tower -= a;
        }
        public static void ETP(int a) //вражеская башня +
        {
            TwoGameWin.p2.tower += a;
        }
        public static void ETM(int a) //вражеская башня -
        {
            TwoGameWin.p2.tower -= a;
        }

        public static void PWP(int a) //монастыри +
        {
            //p1 wiz +
            TwoGameWin.p1.wiz += a;
        }
        public static void PWM(int a) //монастыри -
        {
            //p1 wiz -
            TwoGameWin.p1.wiz -= a;

        }
        public static void PMP(int a) //магия +
        {
            TwoGameWin.p1.magic += a;
        }
        public static void PMM(int a) //магия -
        {
            TwoGameWin.p1.magic -= a;
        }
        public static void PRP(int a) //казармы +
        {
            TwoGameWin.p1.rec += a;
        }
        public static void PRM(int a) //казармы -
        {
            TwoGameWin.p1.rec -= a;
        }
        public static void PAP(int a) //войска +
        {
            TwoGameWin.p1.army += a;
        }
        public static void PAM(int a) //войска -
        {
            TwoGameWin.p1.army -= a;
        }
        public static void PMiP(int a) //шахты +
        {
            TwoGameWin.p1.mine += a;
        }
        public static void PMiM(int a) //шахты -
        {
            TwoGameWin.p1.mine -= a;
        }
        public static void POP(int a) //руда +
        {
            TwoGameWin.p1.ore += a;
        }
        public static void POM(int a) //руда -
        {
            TwoGameWin.p1.ore -= a;
        }
        public static void EWP(int a) //вражеские монастыри +
        {
            //p1 wiz +
            TwoGameWin.p2.wiz += a;
        }
        public static void EWM(int a) //вражеские монастыри -
        {
            //p1 wiz -
            TwoGameWin.p2.wiz -= a;

        }
        public static void EMP(int a) //... я заебался писать комменты
        {
            TwoGameWin.p2.magic += a;
        }
        public static void EMM(int a)
        {
            TwoGameWin.p2.magic -= a;
        }
        public static void ERP(int a)
        {
            TwoGameWin.p2.rec += a;
        }
        public static void ERM(int a)
        {
            TwoGameWin.p2.rec -= a;
        }
        public static void EAP(int a)
        {
            TwoGameWin.p2.army += a;
        }
        public static void EAM(int a)
        {
            TwoGameWin.p2.army -= a;
        }
        public static void EMiP(int a)
        {
            TwoGameWin.p2.mine += a;
        }
        public static void EMiM(int a)
        {
            TwoGameWin.p2.mine -= a;
        }
        public static void EOP(int a)
        {
            TwoGameWin.p2.ore += a;
        }
        public static void EOM(int a)
        {
            TwoGameWin.p2.ore -= a;
        }
        #endregion


        #region Красные
        public static void Бастион()
        {
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(12);
            }
            else TwoGameWin.resMessage(db.cards.Find(1).cost);
        }
        public static void БлагодатнаяПочва()
        {
            //1;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                //TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                //TwoGameWin.p1.wall += 1;
                POM(db.cards.Find(id).cost);
                PWlP(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
            //играем снова
        }
        public static void БольшаяЖила()
        {
            //4;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                if (TwoGameWin.p1.mine < TwoGameWin.p2.mine)
                {
                    //TwoGameWin.p1.mine += 2;
                    PMiP(2);
                }
                else PMiP(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void БольшаяСтена()
        {
            //3;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(4);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void БракованнаяРуда()
        {
            //0;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                POM(8);
                EOM(8);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ВеликаяСтена()
        {
            //8;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(8);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void ВеличайшаяСтена()
        {
            //16;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(15);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void Галереи()
        {
            //9;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(5);

                TwoGameWin.p1.rec += 1;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ГномыШахтёры()
        {
            //7;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wall += 4;
                TwoGameWin.p1.mine += 1;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ГрунтовыеВоды()
        {
            //6;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                if (TwoGameWin.p1.wall < TwoGameWin.p2.wall)
                {
                    TwoGameWin.p1.rec -= 1;
                    TwoGameWin.p1.tower -= 2;
                }
                else if (TwoGameWin.p1.wall > TwoGameWin.p2.wall)
                {
                    TwoGameWin.p2.rec -= 1;
                    TwoGameWin.p2.tower -= 2;
                }
                else
                {
                    TwoGameWin.p1.rec -= 1;
                    TwoGameWin.p1.tower -= 2;
                    TwoGameWin.p2.rec -= 1;
                    TwoGameWin.p2.tower -= 2;
                }
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Землетрясение()
        {
            //0;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.mine -= 1;
                TwoGameWin.p2.mine -= 1;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void Казармы()
        {
            //10;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.army += 6;
                TwoGameWin.p1.wall += 6;
                if (TwoGameWin.p1.rec < TwoGameWin.p2.rec)
                {
                    TwoGameWin.p1.rec += 1;
                }
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void КражаТехнологий()
        {
            //5;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                if (TwoGameWin.p1.mine < TwoGameWin.p2.mine)
                {
                    TwoGameWin.p1.mine = TwoGameWin.p2.mine;
                }
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void МагическаяГора()
        {
            //9;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wall += 7;
                TwoGameWin.p1.magic += 7;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void НовоеОборудование()
        {
            //6;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.mine += 2;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Новшества()
        {
            //2;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.mine += 1;
                TwoGameWin.p2.mine += 1;
                TwoGameWin.p1.magic += 4;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void НовыеУспехи()
        {
            //15;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wall += 8;
                TwoGameWin.p1.tower += 5;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Обвал()
        {
            //4;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p2.mine -= 1;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ОбвалРудника()
        {
            //0;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.mine -= 1;
                TwoGameWin.p1.wall += 10;
                TwoGameWin.p1.magic += 5;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void ОбычнаяСтена()
        {
            //2;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wall += 3;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ПоющийУголь()
        {
            //11;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wall += 6;
                TwoGameWin.p1.tower += 3;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void РабскийТруд()
        {
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wall += 9;
                TwoGameWin.p1.army -= 5;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void СадКамней()
        {
            //1;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wall += 1;
                TwoGameWin.p1.tower += 1;
                TwoGameWin.p1.army += 2;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Сверхурочные()
        {
            //2;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wall += 5;
                TwoGameWin.p1.magic -= 6;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Сдвиг()
        {
            //17;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                int buf = TwoGameWin.p1.wall;
                TwoGameWin.p1.wall = TwoGameWin.p2.wall;
                TwoGameWin.p2.wall = buf;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void СекретнаяПещера()
        {
            //8;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wiz += 1;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

            //играем снова
        }
        public static void СердцеДракона()
        {
            //24;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wall += 20;
                TwoGameWin.p1.tower += 8;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Скаломёт()
        {
            //18;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wall += 6;
                Attack(10);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void СчастливаяМонетка()
        {
            //0;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.ore += 2;
                TwoGameWin.p1.magic += 2;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

            //играем снова
        }
        public static void Толчки()
        {
            //7;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                TwoGameWin.p1.wall -= 5;
                TwoGameWin.p2.wall -= 5;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

            //играем снова
        }
        public static void Укрепления()
        {
            //14;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                TwoGameWin.p1.ore -= db.cards.Find(id).cost;
                PWP(7);
                Attack(6);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void УсиленнаяСтена()
        {
            //5;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(6);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Фундамент()
        {
            //3;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                if (TwoGameWin.p1.wall == 0) { PWlP(5); }
                else { PWlP(3); }
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Шахтёры()
        {
            //3;
            if (TwoGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PMiP(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        #endregion
        #region Синие
        public static void Алмаз()
        {
            //16;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(15);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Аметист()
        {
            //2;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Бижутерия()
        {
            //0;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                if (TwoGameWin.p1.tower < TwoGameWin.p2.tower)
                {
                    PTP(2);
                }
                else PTP(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ВзрывСилы()
        {
            //3;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                TwoGameWin.p1.tower -= 5;
                PWP(2);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Вступление()
        {
            //5;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(4);
                PAM(3);
                TwoGameWin.p2.tower -= 2;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Гармония()
        {
            //7;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PWP(1);
                PTP(3);
                PWlP(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ГлазДракона()
        {
            //21;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(20);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void Дробление()
        {
            //8;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PWM(1);
                ETM(9);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ДымчатыйКварц()
        {
            //2;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                ETM(1);
                //играем снова
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ЖемчугМудрости()
        {
            //9;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(5);
                PWP(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Затмение()
        {
            //4;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(2);
                ETM(2);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Кварц()
        {
            //1;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(1);
                //играем снова
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void КристальныйЩит()
        {
            //12;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(8);
                PWlP(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Копье()
        {
            //4;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                ETM(5);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Матрица()
        {
            //4;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PWP(1);
                PTP(3);
                ETP(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Медитизм()
        {
            //18;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(13);
                PAP(6);
                POP(6);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Молния()
        {
            //11;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                if (TwoGameWin.p1.tower > TwoGameWin.p2.wall)
                {
                    ETM(8);
                }
                else
                {
                    Attack(8);
                    SelfAttack(8);
                }
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Монастырь()
        {
            //15;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(10);
                PWP(5);
                PAP(5);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void МягкийКамень()
        {
            //7;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(5);
                EOM(6);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ОгненныйРубин()
        {
            //13;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(6);
                ETP(4);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Отвердение()
        {
            //8;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(11);
                PWM(6);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Паритет()
        {
            //7;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                if (TwoGameWin.p1.wiz < TwoGameWin.p2.wiz)
                {
                    TwoGameWin.p1.wiz = TwoGameWin.p2.wiz;
                }
                else TwoGameWin.p2.wiz = TwoGameWin.p1.wiz;
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ПомощьВРаботе()
        {
            //4;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(7);
                POM(10);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Радуга()
        {
            //0;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(1);
                ETP(1);
                PMP(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Раздоры()
        {
            //5;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTM(7);
                ETM(7);
                PWM(1);
                EWM(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Рубин()
        {
            //3;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(5);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void РуднаяЖила()
        {
            //5;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(8);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Сапфир()
        {
            //10;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(11);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void СияющийКамень()
        {
            //17;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(12);
                Attack(6);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ТкачиЗаклинаний()
        {
            //3;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PWP(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Трещина()
        {
            //2;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                ETM(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Эмельральд()
        {
            //6;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(8);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Эмпатия()
        {
            //14;
            if (TwoGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(8);
                PRP(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        #endregion
        #region Зелёные
        public static void АрмияГоблинов()
        {
            //3; 
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(6);
                SelfAttack(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Берсерк()
        {
            //4;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(8);
                PTM(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void БешенаяОвца()
        {
            //6;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(6);
                EAM(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Вампир()
        {
            //17;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(10);
                EAM(5);
                ERM(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Воитель()
        {
            //13;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(13);
                PMM(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Вор()
        {
            //12;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                EOM(4);
                EMM(10);
                POP(2);
                PMP(5);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ВсадникНаПегасе()
        {
            //18;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                ETM(12);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Гномы()
        {
            //5;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(4);
                PWlP(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Гоблины()
        {
            //1;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(4);
                PMM(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ГоблиныЛучники()
        {
            //4;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                ETM(3);
                SelfAttack(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ГремлинВБашне()
        {
            //8;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(2);
                PWlP(4);
                PTP(2);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Дракон()
        {
            //25;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(20);
                EMM(10);
                ERM(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Единорог()
        {
            //9;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                if (TwoGameWin.p1.wiz > TwoGameWin.p2.wiz) { Attack(12); }
                else Attack(8);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ЕдкоеОблако()
        {
            //11;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                if (TwoGameWin.p2.wall > 10) { Attack(10); }
                else Attack(7);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Жучара()
        {
            //8;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                if (TwoGameWin.p2.wall == 0) { Attack(10); }
                else Attack(6);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void КаменныйГигант()
        {
            //15;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(10);
                PWlP(4);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Камнееды()
        {
            //11;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(8);
                EMiM(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Карлик()
        {
            //2;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(3);
                PMP(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Копьеносец()
        {
            //2;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                if (TwoGameWin.p1.wall > TwoGameWin.p2.wall) { Attack(3); }
                else Attack(2);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void КоровьеБешенство()
        {
            //0;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                PAM(6);
                EAM(6);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Крушитель()
        {
            //5;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(6);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void МаленькиеЗмейки()
        {
            //6;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                ETM(4);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Минотавр()
        {
            //3;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                PRP(1);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Оборотень()
        {
            //9;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(9);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Огр()
        {
            //6;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(7);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Орк()
        {
            //3;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(5);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Полнолуние()
        {
            //0;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                PRP(1);
                ERP(1);
                PAP(3);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ПризрачнаяФея()
        {
            //6;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                ETM(2);
                //играем снова 
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Суккубы()
        {
            //14;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                ETM(5);
                EAM(6);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ТролльНаставник()
        {
            //7;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                PRP(2);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Фея()
        {
            //1;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(2);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

            //играем снова
        }
        public static void Бес()
        {
            //5;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(6);
                POM(5);
                PMM(5);
                PAM(5);
                EOM(5);
                EMM(5);
                EAM(5);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ЭльфыЛучники()
        {
            //10;
            if (TwoGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                if (TwoGameWin.p1.wall > TwoGameWin.p2.wall) { ETM(6); }
                else Attack(6);
            }
            else TwoGameWin.resMessage(db.cards.Find(id).cost);

        }
        #endregion
    }

    public class cardList
    {
        static ApplicationContext db = new ApplicationContext();
        public static int id;

        static OneGameWin OneGameWin = new OneGameWin();
        #region Эффекты карт
        public static void Attack(int a) //нанесение урона врагу
        {
            if ((OneGameWin.p2.wall - a) <= 0)
            {
                OneGameWin.p2.tower -= a - OneGameWin.p2.wall;
                OneGameWin.p2.wall = 0;
            }
            else OneGameWin.p2.wall -= a;
        }
        public static void SelfAttack(int a) //нанесение урона по себе
        {
            if ((OneGameWin.p1.wall - a) <= 0)
            {
                OneGameWin.p1.tower -= a - OneGameWin.p1.wall;
                OneGameWin.p1.wall = 0;
            }
            else OneGameWin.p1.wall -= a;
        }
        public static void PWlP(int a) //стена +
        {
            OneGameWin.p1.wall += a;
        }
        public static void PWlM(int a) //стена -
        {
            OneGameWin.p1.wall -= a;
        }
        public static void EWlP(int a) //вражеская стена +
        {
            OneGameWin.p2.wall += a;
        }
        public static void EWlM(int a) //вражеская стена -
        {
            OneGameWin.p2.wall -= a;
        }
        public static void PTP(int a) //башня +
        {
            OneGameWin.p1.tower += a;
        }
        public static void PTM(int a) //башня -
        {
            OneGameWin.p1.tower -= a;
        }
        public static void ETP(int a) //вражеская башня +
        {
            OneGameWin.p2.tower += a;
        }
        public static void ETM(int a) //вражеская башня -
        {
            OneGameWin.p2.tower -= a;
        }

        public static void PWP(int a) //монастыри +
        {
            //p1 wiz +
            OneGameWin.p1.wiz += a;
        }
        public static void PWM(int a) //монастыри -
        {
            //p1 wiz -
            OneGameWin.p1.wiz -= a;

        }
        public static void PMP(int a) //магия +
        {
            OneGameWin.p1.magic += a;
        }
        public static void PMM(int a) //магия -
        {
            OneGameWin.p1.magic -= a;
        }
        public static void PRP(int a) //казармы +
        {
            OneGameWin.p1.rec += a;
        }
        public static void PRM(int a) //казармы -
        {
            OneGameWin.p1.rec -= a;
        }
        public static void PAP(int a) //войска +
        {
            OneGameWin.p1.army += a;
        }
        public static void PAM(int a) //войска -
        {
            OneGameWin.p1.army -= a;
        }
        public static void PMiP(int a) //шахты +
        {
            OneGameWin.p1.mine += a;
        }
        public static void PMiM(int a) //шахты -
        {
            OneGameWin.p1.mine -= a;
        }
        public static void POP(int a) //руда +
        {
            OneGameWin.p1.ore += a;
        }
        public static void POM(int a) //руда -
        {
            OneGameWin.p1.ore -= a;
        }
        public static void EWP(int a) //вражеские монастыри +
        {
            //p1 wiz +
            OneGameWin.p2.wiz += a;
        }
        public static void EWM(int a) //вражеские монастыри -
        {
            //p1 wiz -
            OneGameWin.p2.wiz -= a;

        }
        public static void EMP(int a) //... я заебался писать комменты
        {
            OneGameWin.p2.magic += a;
        }
        public static void EMM(int a)
        {
            OneGameWin.p2.magic -= a;
        }
        public static void ERP(int a)
        {
            OneGameWin.p2.rec += a;
        }
        public static void ERM(int a)
        {
            OneGameWin.p2.rec -= a;
        }
        public static void EAP(int a)
        {
            OneGameWin.p2.army += a;
        }
        public static void EAM(int a)
        {
            OneGameWin.p2.army -= a;
        }
        public static void EMiP(int a)
        {
            OneGameWin.p2.mine += a;
        }
        public static void EMiM(int a)
        {
            OneGameWin.p2.mine -= a;
        }
        public static void EOP(int a)
        {
            OneGameWin.p2.ore += a;
        }
        public static void EOM(int a)
        {
            OneGameWin.p2.ore -= a;
        }
        #endregion


        #region Красные
        public static void Бастион()
        {
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(12);
            }
            else OneGameWin.resMessage(db.cards.Find(1).cost);
        }
        public static void БлагодатнаяПочва()
        {
            //1;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                //OneGameWin.p1.ore -= db.cards.Find(id).cost;
                //OneGameWin.p1.wall += 1;
                POM(db.cards.Find(id).cost);
                PWlP(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
            //играем снова
        }
        public static void БольшаяЖила()
        {
            //4;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                if (OneGameWin.p1.mine < OneGameWin.p2.mine)
                {
                    //OneGameWin.p1.mine += 2;
                    PMiP(2);
                }
                else PMiP(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void БольшаяСтена()
        {
            //3;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(4);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void БракованнаяРуда()
        {
            //0;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                POM(8);
                EOM(8);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ВеликаяСтена()
        {
            //8;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(8);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void ВеличайшаяСтена()
        {
            //16;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(15);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void Галереи()
        {
            //9;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(5);

                OneGameWin.p1.rec += 1;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ГномыШахтёры()
        {
            //7;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wall += 4;
                OneGameWin.p1.mine += 1;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ГрунтовыеВоды()
        {
            //6;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                if (OneGameWin.p1.wall < OneGameWin.p2.wall)
                {
                    OneGameWin.p1.rec -= 1;
                    OneGameWin.p1.tower -= 2;
                }
                else if (OneGameWin.p1.wall > OneGameWin.p2.wall)
                {
                    OneGameWin.p2.rec -= 1;
                    OneGameWin.p2.tower -= 2;
                }
                else
                {
                    OneGameWin.p1.rec -= 1;
                    OneGameWin.p1.tower -= 2;
                    OneGameWin.p2.rec -= 1;
                    OneGameWin.p2.tower -= 2;
                }
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Землетрясение()
        {
            //0;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.mine -= 1;
                OneGameWin.p2.mine -= 1;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void Казармы()
        {
            //10;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.army += 6;
                OneGameWin.p1.wall += 6;
                if (OneGameWin.p1.rec < OneGameWin.p2.rec)
                {
                    OneGameWin.p1.rec += 1;
                }
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void КражаТехнологий()
        {
            //5;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                if (OneGameWin.p1.mine < OneGameWin.p2.mine)
                {
                    OneGameWin.p1.mine = OneGameWin.p2.mine;
                }
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void МагическаяГора()
        {
            //9;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wall += 7;
                OneGameWin.p1.magic += 7;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void НовоеОборудование()
        {
            //6;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.mine += 2;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Новшества()
        {
            //2;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.mine += 1;
                OneGameWin.p2.mine += 1;
                OneGameWin.p1.magic += 4;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void НовыеУспехи()
        {
            //15;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wall += 8;
                OneGameWin.p1.tower += 5;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Обвал()
        {
            //4;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p2.mine -= 1;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ОбвалРудника()
        {
            //0;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.mine -= 1;
                OneGameWin.p1.wall += 10;
                OneGameWin.p1.magic += 5;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void ОбычнаяСтена()
        {
            //2;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wall += 3;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ПоющийУголь()
        {
            //11;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wall += 6;
                OneGameWin.p1.tower += 3;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void РабскийТруд()
        {
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wall += 9;
                OneGameWin.p1.army -= 5;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void СадКамней()
        {
            //1;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wall += 1;
                OneGameWin.p1.tower += 1;
                OneGameWin.p1.army += 2;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Сверхурочные()
        {
            //2;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wall += 5;
                OneGameWin.p1.magic -= 6;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Сдвиг()
        {
            //17;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                int buf = OneGameWin.p1.wall;
                OneGameWin.p1.wall = OneGameWin.p2.wall;
                OneGameWin.p2.wall = buf;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void СекретнаяПещера()
        {
            //8;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wiz += 1;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

            //играем снова
        }
        public static void СердцеДракона()
        {
            //24;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wall += 20;
                OneGameWin.p1.tower += 8;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Скаломёт()
        {
            //18;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wall += 6;
                Attack(10);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void СчастливаяМонетка()
        {
            //0;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.ore += 2;
                OneGameWin.p1.magic += 2;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

            //играем снова
        }
        public static void Толчки()
        {
            //7;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                OneGameWin.p1.wall -= 5;
                OneGameWin.p2.wall -= 5;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

            //играем снова
        }
        public static void Укрепления()
        {
            //14;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                OneGameWin.p1.ore -= db.cards.Find(id).cost;
                PWP(7);
                Attack(6);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void УсиленнаяСтена()
        {
            //5;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PWlP(6);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Фундамент()
        {
            //3;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                if (OneGameWin.p1.wall == 0) { PWP(5); }
                else { PWP(3); }
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Шахтёры()
        {
            //3;
            if (OneGameWin.p1.ore >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                PMiP(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        #endregion
        #region Синие
        public static void Алмаз()
        {
            //16;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(15);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Аметист()
        {
            //2;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Бижутерия()
        {
            //0;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                POM(db.cards.Find(id).cost);
                if (OneGameWin.p1.tower < OneGameWin.p2.tower)
                {
                    PTP(2);
                }
                else PTP(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ВзрывСилы()
        {
            //3;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                OneGameWin.p1.tower -= 5;
                PWP(2);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Вступление()
        {
            //5;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(4);
                PAM(3);
                OneGameWin.p2.tower -= 2;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Гармония()
        {
            //7;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PWP(1);
                PTP(3);
                PWlP(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ГлазДракона()
        {
            //21;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(20);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);
        }
        public static void Дробление()
        {
            //8;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PWM(1);
                ETM(9);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ДымчатыйКварц()
        {
            //2;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                ETM(1);
                //играем снова
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ЖемчугМудрости()
        {
            //9;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(5);
                PWP(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Затмение()
        {
            //4;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(2);
                ETM(2);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Кварц()
        {
            //1;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(1);
                //играем снова
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void КристальныйЩит()
        {
            //12;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(8);
                PWlP(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Копье()
        {
            //4;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                ETM(5);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Матрица()
        {
            //4;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PWP(1);
                PTP(3);
                ETP(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Медитизм()
        {
            //18;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(13);
                PAP(6);
                POP(6);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Молния()
        {
            //11;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                if (OneGameWin.p1.tower > OneGameWin.p2.wall)
                {
                    ETM(8);
                }
                else
                {
                    Attack(8);
                    SelfAttack(8);
                }
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Монастырь()
        {
            //15;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(10);
                PWP(5);
                PAP(5);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void МягкийКамень()
        {
            //7;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(5);
                EOM(6);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ОгненныйРубин()
        {
            //13;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(6);
                ETP(4);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Отвердение()
        {
            //8;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(11);
                PWM(6);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Паритет()
        {
            //7;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                if (OneGameWin.p1.wiz < OneGameWin.p2.wiz)
                {
                    OneGameWin.p1.wiz = OneGameWin.p2.wiz;
                }
                else OneGameWin.p2.wiz = OneGameWin.p1.wiz;
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ПомощьВРаботе()
        {
            //4;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(7);
                POM(10);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Радуга()
        {
            //0;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(1);
                ETP(1);
                PMP(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Раздоры()
        {
            //5;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTM(7);
                ETM(7);
                PWM(1);
                EWM(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Рубин()
        {
            //3;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(5);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void РуднаяЖила()
        {
            //5;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(8);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Сапфир()
        {
            //10;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(11);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void СияющийКамень()
        {
            //17;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(12);
                Attack(6);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ТкачиЗаклинаний()
        {
            //3;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PWP(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Трещина()
        {
            //2;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                ETM(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Эмельральд()
        {
            //6;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(8);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Эмпатия()
        {
            //14;
            if (OneGameWin.p1.magic >= db.cards.Find(id).cost)
            {
                PMM(db.cards.Find(id).cost);
                PTP(8);
                PRP(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        #endregion
        #region Зелёные
        public static void АрмияГоблинов()
        {
            //3; 
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(6);
                SelfAttack(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Берсерк()
        {
            //4;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(8);
                PTM(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void БешенаяОвца()
        {
            //6;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(6);
                EAM(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Вампир()
        {
            //17;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(10);
                EAM(5);
                ERM(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Воитель()
        {
            //13;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(13);
                PMM(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Вор()
        {
            //12;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                EOM(4);
                EMM(10);
                POP(2);
                PMP(5);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ВсадникНаПегасе()
        {
            //18;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                ETM(12);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Гномы()
        {
            //5;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(4);
                PWlP(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Гоблины()
        {
            //1;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(4);
                PMM(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ГоблиныЛучники()
        {
            //4;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                ETM(3);
                SelfAttack(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ГремлинВБашне()
        {
            //8;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(2);
                PWlP(4);
                PTP(2);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Дракон()
        {
            //25;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(20);
                EMM(10);
                ERM(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Единорог()
        {
            //9;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                if (OneGameWin.p1.wiz > OneGameWin.p2.wiz) { Attack(12); }
                else Attack(8);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ЕдкоеОблако()
        {
            //11;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                if (OneGameWin.p2.wall > 10) { Attack(10); }
                else Attack(7);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Жучара()
        {
            //8;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                if (OneGameWin.p2.wall == 0) { Attack(10); }
                else Attack(6);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void КаменныйГигант()
        {
            //15;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(10);
                PWlP(4);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Камнееды()
        {
            //11;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(8);
                EMiM(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Карлик()
        {
            //2;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(3);
                PMP(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Копьеносец()
        {
            //2;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                if (OneGameWin.p1.wall > OneGameWin.p2.wall) { Attack(3); }
                else Attack(2);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void КоровьеБешенство()
        {
            //0;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                PAM(6);
                EAM(6);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Крушитель()
        {
            //5;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(6);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void МаленькиеЗмейки()
        {
            //6;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                ETM(4);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Минотавр()
        {
            //3;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                PRP(1);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Оборотень()
        {
            //9;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(9);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Огр()
        {
            //6;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(7);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Орк()
        {
            //3;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(5);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Полнолуние()
        {
            //0;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                PRP(1);
                ERP(1);
                PAP(3);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ПризрачнаяФея()
        {
            //6;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                ETM(2);
                //играем снова 
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Суккубы()
        {
            //14;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                ETM(5);
                EAM(6);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ТролльНаставник()
        {
            //7;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                PRP(2);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void Фея()
        {
            //1;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(2);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

            //играем снова
        }
        public static void Бес()
        {
            //5;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                Attack(6);
                POM(5);
                PMM(5);
                PAM(5);
                EOM(5);
                EMM(5);
                EAM(5);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        public static void ЭльфыЛучники()
        {
            //10;
            if (OneGameWin.p1.army >= db.cards.Find(id).cost)
            {
                PAM(db.cards.Find(id).cost);
                if (OneGameWin.p1.wall > OneGameWin.p2.wall) { ETM(6); }
                else Attack(6);
            }
            else OneGameWin.resMessage(db.cards.Find(id).cost);

        }
        #endregion
    }
}
