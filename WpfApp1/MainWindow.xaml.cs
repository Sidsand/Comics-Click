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
using System.Windows.Threading;
using System.Media;
using System.Threading;
using System.Net.Sockets;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer shec = new DispatcherTimer();
        DispatcherTimer avtotim = new DispatcherTimer();
        DispatcherTimer rndSob = new DispatcherTimer();

        Random rnd = new Random();

        Rectangle D = new Rectangle();

        int avto = 0;
        int kl = 0;
        int aup = 1;
        int prov = 1;
        int prov2 = 1;
        //int prov3 = 1;
        //int prov4 = 1;

        MediaPlayer sp = new MediaPlayer();
        MediaPlayer sp1 = new MediaPlayer();
        MediaPlayer mus = new MediaPlayer();
        // MediaPlayer mus1 = new MediaPlayer();


        public static string IPstr;
        public string NAMEstr;

        const int port = 8889;
        NetworkStream stream = null;
        TcpClient client = null;

        private void sp1_MediaEnded(object sender, EventArgs e)
        {
           // mus.Position = new TimeSpan(0, 0, 0, 0);
           // mus.Play();

            
            //mus1.Play(); 

            sp.Position = new TimeSpan(0, 0, 0, 0);
            sp.Stop();
            sp1.Position = new TimeSpan(0, 0, 0, 0);
            sp1.Stop();
        }

        private void mus_MediaEnded(object sender, EventArgs e)
        {
            mus.Position = new TimeSpan(0, 0, 0, 0);
            mus.Play();

        }


        public MainWindow()
        {
            InitializeComponent();

            shec.Interval = new TimeSpan(0, 0, 0, 0, 1);
            shec.Tick += new EventHandler(shecik);
            shec.Start();

            //// =====================================================================================
            avtotim.Interval = new TimeSpan(0, 0, 0, 1);
            avtotim.Tick += new EventHandler(Timer_click);

            //// =====================================================================================

            rndSob.Interval = new TimeSpan(0, 0, 180);
            rndSob.Tick += new EventHandler(rnd_sobutie);
            rndSob.Start();

            //// =====================================================================================
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

            StackPanel myStackPanel = new StackPanel();


            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(0, 0, 0, 0);
            
            //// =====================================================================================

            defks = new Image[30] {
                def1, def2, def3, def4, def5,
                def6, def7, def8, def9, def10,
                def11, def12, def13, def14, def15,
                def16, def17, def18, def19, def20,
                def21, def22, def23, def24, def25,
                def26, def27, def28, def29, def30
            };

            sp.Open(new Uri("C:/Users/Admin/Desktop/Игра 4.0/Comics-Click-master/WpfApp1/Resources/Pokupka.wav", UriKind.Relative));
            sp1.Open(new Uri("C:/Users/Admin/Desktop/Игра 4.0/Comics-Click-master/WpfApp1/Resources/Otkrut.wav", UriKind.Relative));
            mus.Open(new Uri("C:/Users/Admin/Desktop/Игра 4.0/Comics-Click-master/WpfApp1/Resources/RainbowCrash88 - Winter Wrap Up.mp3", UriKind.Relative));

            mus.Play();

            mus.Volume = 5.0 / 100.0;
            //mus1.Volume = 5.0 / 100.0;
            //// =====================================================================================
            ///

            
            IPstr = "127.0.0.1";
            NAMEstr = nameplayer.Text;

            


        }

        /////////////// server
        public void reciever()
        {
            Dispatcher.BeginInvoke(new Action(() => recordBox.Items.Add("thread up")));

            byte[] data = Encoding.Unicode.GetBytes("request");
            stream.Write(data, 0, data.Length);

            while (true)
            {
                data = new byte[64];
                StringBuilder builder = new StringBuilder();

                int bytes = 0;
                try
                {
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                    if (message == "end")
                    {
                        break;
                    }
                    Dispatcher.BeginInvoke(new Action(() => recordBox.Items.Add(message)));
                }
                catch
                {
                    throw new ArgumentException("Connection fail");

                }
                
                
            }
        }

        private void rnd_sobutie(object sender, EventArgs e)
        {
            sob.Visibility = Visibility.Visible;
            rndSob.Stop();
        }

        private void sob_MouseDown(object sender, EventArgs e)
        {
            sob.Visibility = Visibility.Hidden;
            int value = rnd.Next(1, 10);
            switch (value)
            {
                case 1:
                    MessageBox.Show("К вам в гости зашел популярный косплеер и оставил положительный отзыв о вашем магазине в сети (+5 Кл/сек)");
                    avto = avto + 5;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();
                    break;

                case 2:
                    MessageBox.Show("Статью о вашем магазине опубликовали в журнале ИгроЛамия (+2 Кл/сек)");
                    avto = avto + 2;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();
                    break;

                case 3:
                    MessageBox.Show("У вас купили был наплыв посетителей и вы продали довольно много товара (+120 Кл)");
                    kl = kl + 120;
                    sh.Content = kl + " Кл.";
                    break;

                case 4:
                    MessageBox.Show("+4 очка за клик");
                    avto = avto + 4;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();
                    break;

                case 5:
                         MessageBox.Show("+5 очка за клик");
                    avto = avto + 5;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();
                    break;

                case 6:
                         MessageBox.Show("+6 очка за клик");
                    avto = avto + 6;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();
                    break;

                case 7:
                         MessageBox.Show("+7 очка за клик");
                    avto = avto + 7;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();
                    break;

                case 8:
                    MessageBox.Show("Сломался компьютер. На починку пришлось потратить немного денег (-130 кл)");
                    kl = kl - 130;
                    sh.Content = kl + " Кл.";
                    break;
                  
                case 9:
                    MessageBox.Show("Какие-то дети кинули мяч в ваше окно и оно треснуло. На починку пришлось потратить немного -100 кл ");
                    kl = kl - 100;
                    sh.Content = kl + " Кл.";
                    break;

                case 10:
                    MessageBox.Show("+10 очка за клик");
                    avto = avto + 10;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();
                    break; 
            }
        
            rndSob.Start();
        }   ///

        private void shecik(object sender, EventArgs e) 
        {
            if (kl < 0)
            {
                sh.Content = 0 + " Кл.";
                kl = 0;
            }
            else
                sh.Content = kl + " Кл.";
        } ///
        
        private void Timer_click(object sender, EventArgs e) 
        {
          kl = kl + avto;
        } ///

        private void EXMENU_MouseDown(object sender, MouseEventArgs e)
        {
            sp1.Play();
            menuS.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;
            stats.Visibility = Visibility.Hidden;
            achiv.Visibility = Visibility.Hidden;

            shop.Visibility = Visibility.Hidden;
            stat.Visibility = Visibility.Hidden;
            achivki.Visibility = Visibility.Hidden;
            top.Visibility = Visibility.Hidden;
            exit.Visibility = Visibility.Hidden;

            EXMENU.Visibility = Visibility.Hidden;

            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
            scroll_Dost.Visibility = Visibility.Hidden;

            S1.Visibility = Visibility.Hidden;
            D1.Visibility = Visibility.Hidden;
            V1.Visibility = Visibility.Hidden;
            F1.Visibility = Visibility.Hidden;
            F2.Visibility = Visibility.Hidden;
            recordBox.Visibility = Visibility.Hidden;

            ClickMenu.Visibility = Visibility.Visible;

        }

        Image[] defks;
        int im_index = 0;

        public void reveal(object x)
        {
            try
            {
                int n = (int)x;

                Dispatcher.Invoke(() => defks[n].Visibility = Visibility.Visible);
                Thread.Sleep(4500);
                Dispatcher.Invoke(() => defks[n].Visibility = Visibility.Hidden);
            }
            catch { }
            }

        private void Fon_MouseDown(object sender, MouseEventArgs e)
        {
            kl = kl + aup;
            sh.Content = kl + " Кл.";

            if (im_index == 30)
            {
                im_index = 0;
            }
            Thread myThread = new Thread(new ParameterizedThreadStart(reveal));
            myThread.Start(im_index);
            im_index++;

            if (kl >= 1)
            {
                if (prov == 1)
                {Dos1.IsEnabled = true; }
            }
            else
            { Dos1.IsEnabled = false; }

            if (kl >= 100)
            {
                if (prov2 == 1)
                { Dos2.IsEnabled = true; }
            }
            
        } ///

        private void S1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sp1.Play();
            menuS.Visibility = Visibility.Visible;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;


            scroll_S1.Visibility = Visibility.Visible;
            scroll_D1.Visibility = Visibility.Hidden;
        }
        
        private void D1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sp1.Play();
            menuS.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Visible;
            menuV.Visibility = Visibility.Hidden;

            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Visible;
            
        }

        private void V1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sp1.Play();
            menuS.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Visible;

            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
        }
        

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sp1.Play();
            shop.Visibility = Visibility.Hidden;
            stat.Visibility = Visibility.Hidden;
            achivki.Visibility = Visibility.Hidden;
            top.Visibility = Visibility.Hidden;
            exit.Visibility = Visibility.Hidden;
            
            stats.Visibility = Visibility.Hidden;
            achiv.Visibility = Visibility.Hidden;
            menuS.Visibility = Visibility.Hidden;
            EXMENU.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;


            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
            scroll_Dost.Visibility = Visibility.Hidden;
            S1.Visibility = Visibility.Hidden;
            D1.Visibility = Visibility.Hidden;
            V1.Visibility = Visibility.Hidden;
            F1.Visibility = Visibility.Hidden;
            F2.Visibility = Visibility.Hidden;

            ClickMenu.Visibility = Visibility.Hidden;

            sh.Visibility = Visibility.Hidden;
            och.Visibility = Visibility.Hidden;

            start.Visibility = Visibility.Visible;
            exit1.Visibility = Visibility.Visible;
            main_menu.Visibility = Visibility.Visible;

            nameplayer.Visibility = Visibility.Visible;
            playe.Visibility = Visibility.Visible;
            recordBox.Visibility = Visibility.Hidden;


            mus.Stop();
            mus.Open(new Uri("C:/Users/Admin/Desktop/Игра 4.0/Comics-Click-master/WpfApp1/Resources/RainbowCrash88 - Winter Wrap Up.mp3", UriKind.Relative));
            mus.Play();

            

            rndSob.Stop();
        }

        private void Shop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sp1.Play();
            menuS.Visibility = Visibility.Visible;
            stats.Visibility = Visibility.Hidden;
            achiv.Visibility = Visibility.Hidden;

            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
            scroll_S1.Visibility = Visibility.Visible;
            scroll_Dost.Visibility = Visibility.Hidden;
            S1.Visibility = Visibility.Visible;
            D1.Visibility = Visibility.Visible;
            V1.Visibility = Visibility.Visible;
            F1.Visibility = Visibility.Hidden;
            F2.Visibility = Visibility.Hidden;
            recordBox.Visibility = Visibility.Hidden;
        }

        private void Stat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sp1.Play();
            menuS.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;
            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
            scroll_Dost.Visibility = Visibility.Hidden;
            S1.Visibility = Visibility.Hidden;
            D1.Visibility = Visibility.Hidden;
            V1.Visibility = Visibility.Hidden;
            recordBox.Visibility = Visibility.Hidden;

            stats.Visibility = Visibility.Visible;

            achiv.Visibility = Visibility.Hidden;

            F1.Visibility = Visibility.Visible;
            F2.Visibility = Visibility.Visible;
        }

        private void Achivki_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sp1.Play();
            menuS.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;
            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
            scroll_Dost.Visibility = Visibility.Visible;
            S1.Visibility = Visibility.Hidden;
            D1.Visibility = Visibility.Hidden;
            V1.Visibility = Visibility.Hidden;
            F1.Visibility = Visibility.Hidden;
            F2.Visibility = Visibility.Hidden;

            stats.Visibility = Visibility.Hidden;
            recordBox.Visibility = Visibility.Hidden;
            achiv.Visibility = Visibility.Visible;
        }

        private void Top_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sp1.Play();
            menuS.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;
            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
            scroll_Dost.Visibility = Visibility.Hidden;
            S1.Visibility = Visibility.Hidden;
            D1.Visibility = Visibility.Hidden;
            V1.Visibility = Visibility.Hidden;
            F1.Visibility = Visibility.Hidden;
            F2.Visibility = Visibility.Hidden;

            recordBox.Visibility = Visibility.Visible;

            stats.Visibility = Visibility.Hidden;

            achiv.Visibility = Visibility.Visible;

            if (stream == null)
            {
                try
                {
                    client = new TcpClient(IPstr, port);
                    stream = client.GetStream();

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Client error");
                }
            }

            recordBox.Items.Clear();

            Thread myThread1 = new Thread(new ThreadStart(reciever));

            myThread1.Start();

        }

        private void ClickMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sp1.Play();
            shop.Visibility = Visibility.Visible;
            stat.Visibility = Visibility.Visible;
            achivki.Visibility = Visibility.Visible;
            top.Visibility = Visibility.Visible;
            exit.Visibility = Visibility.Visible;

            menuS.Visibility = Visibility.Visible;
            EXMENU.Visibility = Visibility.Visible;
  
            scroll_S1.Visibility = Visibility.Visible;
            S1.Visibility = Visibility.Visible;
            D1.Visibility = Visibility.Visible;
            V1.Visibility = Visibility.Visible;

            ClickMenu.Visibility = Visibility.Hidden;
        }

        private void exit1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            // отправка строки
            if (stream == null)
            {
                try
                {
                    client = new TcpClient(IPstr, port);
                    stream = client.GetStream();

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Client error");
                }
            }

            byte[] data = Encoding.Unicode.GetBytes(nameplayer.Text + kl);
                stream.Write(data, 0, data.Length);

                stream.Close(); 
                client.Close();

                this.Close();
            //}
            //catch { }
        }

        private void start_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(nameplayer.Text == "")
            {
                MessageBox.Show("Введите имя");
            }
            else
            {
                sp1.Play();
                sp1.MediaEnded += sp1_MediaEnded;
                mus.MediaEnded += mus_MediaEnded;

                ClickMenu.Visibility = Visibility.Visible;

                sh.Visibility = Visibility.Visible;
                och.Visibility = Visibility.Visible;

                start.Visibility = Visibility.Hidden;
                exit1.Visibility = Visibility.Hidden;

                nameplayer.Visibility = Visibility.Hidden;
                playe.Visibility = Visibility.Hidden;

                main_menu.Visibility = Visibility.Hidden;

                rndSob.Start();
                mus.Open(new Uri("C:/Users/Admin/Desktop/Игра/Comics-Click-master/WpfApp1/Resources/8-Bit Never.mp3", UriKind.Relative));
                //mus1.Stop();
                mus.Play();
            }
            
        }

        int k = 1;
        int k2 = 1;
        int k3 = 1;
        int k4 = 1;
        int k5 = 1;
        int k6 = 1;
        int n = 50;
        int n2 = 100;
        int n3 = 200;
        int n4 = 400;
        int n5 = 800;
        int n6 = 1200;
        private void St1_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= n)
            {
                    sp.Play();
                if (k == 1)
                {
                        stellag1.Visibility = Visibility.Visible;
                        aup = aup + 1;
                        och.Content = "Очков за клики: " + aup;

                        kl = kl - n;
                        sh.Content = kl + " Кл.";

                }
                if (k == 2)
                {
                        stellag1_2.Visibility = Visibility.Visible;
                        aup = aup + 1;
                        och.Content = "Очков за клики: " + aup;

                        kl = kl - n;
                        sh.Content = kl + " Кл.";

                }
                if (k == 3)
                {
                        stellag1_3.Visibility = Visibility.Visible;
                        aup = aup + 1;
                        och.Content = "Очков за клики: " + aup;

                        kl = kl - n;
                        sh.Content = kl + " Кл.";

                }
                if (k == 4)
                {
                        stellag1_4.Visibility = Visibility.Visible;
                        aup = aup + 1;
                        och.Content = "Очков за клики: " + aup;

                        kl = kl - n;
                        sh.Content = kl + " Кл.";

                }
                if (k == 5)
                {
                        stellag1_5.Visibility = Visibility.Visible;
                        aup = aup + 1;
                        och.Content = "Очков за клики: " + aup;

                        kl = kl - n;
                        sh.Content = kl + " Кл.";

                        stel1.Content = "Куплено";
                        stel1.IsEnabled = false;
                }
                else
                {
                        k++;
                        n = n * k ;
                        stel1.Content = "Стеллаж (+" + k + ")  " + n + " кл. (+1 к клику)";
                }
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }
        private void St2_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= n2)
            {
                sp.Play();
                if (k2 == 1)
                {
                    stellag2.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n2;
                    sh.Content = kl + " Кл.";

                }
                if (k2 == 2)
                {
                    stellag2_2.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n2;
                    sh.Content = kl + " Кл.";

                }
                if (k2 == 3)
                {
                    stellag2_3.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n2;
                    sh.Content = kl + " Кл.";

                }
                if (k2 == 4)
                {
                    stellag2_4.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n2;
                    sh.Content = kl + " Кл.";

                }
                if (k2 == 5)
                {
                    stellag2_5.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n2;
                    sh.Content = kl + " Кл.";

                    stel2.Content = "Куплено";
                    stel2.IsEnabled = false;
                }
                else
                {
                    k2++;
                    n2 =n2 * k2;
                    stel2.Content = "Стеллаж (+" + k2 + ")  " + n2 + " кл. (+1 к клику)";
                }
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }
        private void St3_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= n3)
            {
                sp.Play();
                if (k3 == 1)
                {
                    stellag3.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n3;
                    sh.Content = kl + " Кл.";

                }
                if (k3 == 2)
                {
                    stellag3_2.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n3;
                    sh.Content = kl + " Кл.";

                }
                if (k3 == 3)
                {
                    stellag3_3.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n3;
                    sh.Content = kl + " Кл.";

                }
                if (k3 == 4)
                {
                    stellag3_4.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n3;
                    sh.Content = kl + " Кл.";

                }
                if (k3 == 5)
                {
                    stellag3_5.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n3;
                    sh.Content = kl + " Кл.";

                    stel3.Content = "Куплено";
                    stel3.IsEnabled = false;
                }
                else
                {
                    k3++;
                    n3 = n3 * k3;
                    stel3.Content = "Стеллаж (+" + k3 + ")  " + n3 + " кл. (+1 к клику)";
                }
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }
        private void St4_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= n4)
            {
                sp.Play();
                if (k4 == 1)
                {
                    stellag4.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n4;
                    sh.Content = kl + " Кл.";

                }
                if (k4 == 2)
                {
                    stellag4_2.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n4;
                    sh.Content = kl + " Кл.";

                }
                if (k4 == 3)
                {
                    stellag4_3.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n4;
                    sh.Content = kl + " Кл.";

                }
                if (k4 == 4)
                {
                    stellag4_4.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n4;
                    sh.Content = kl + " Кл.";

                }
                if (k4 == 5)
                {
                    stellag4_5.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n4;
                    sh.Content = kl + " Кл.";

                    stel4.Content = "Куплено";
                    stel4.IsEnabled = false;
                }
                else
                {
                    k4++;
                    n4 = n4 * k4;
                    stel4.Content = "Стеллаж (+" + k4 + ")  " + n4 + " кл. (+1 к клику)";
                }
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }
        private void St5_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= n5)
            {
                sp.Play();
                if (k5 == 1)
                {
                    stellag5.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n5;
                    sh.Content = kl + " Кл.";

                }
                if (k5 == 2)
                {
                    stellag5_2.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n5;
                    sh.Content = kl + " Кл.";

                }
                if (k5 == 3)
                {
                    stellag5_3.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n5;
                    sh.Content = kl + " Кл.";

                }
                if (k5 == 4)
                {
                    stellag5_4.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n5;
                    sh.Content = kl + " Кл.";

                }
                if (k5 == 5)
                {
                    stellag5_5.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n5;
                    sh.Content = kl + " Кл.";

                    stel5.Content = "Куплено";
                    stel5.IsEnabled = false;
                }
                else
                {
                    k5++;
                    n5 = n5 * k5;
                    stel5.Content = "Стеллаж (+" + k5 + ")  " + n5 + " кл. (+1 к клику)";
                }
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }
        private void St6_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= n6)
            {
                sp.Play();
                if (k6 == 1)
                {
                    polka.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n6;
                    sh.Content = kl + " Кл.";

                }
                if (k6 == 2)
                {
                    polka_2.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n6;
                    sh.Content = kl + " Кл.";

                }
                if (k6 == 3)
                {
                    polka_3.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n6;
                    sh.Content = kl + " Кл.";

                }
                if (k6 == 4)
                {
                    polka_4.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n6;
                    sh.Content = kl + " Кл.";

                }
                if (k6 == 5)
                {
                    polka_5.Visibility = Visibility.Visible;
                    aup = aup + 1;
                    och.Content = "Очков за клики: " + aup;

                    kl = kl - n6;
                    sh.Content = kl + " Кл.";

                    stel6.Content = "Куплено";
                    stel6.IsEnabled = false;
                }
                else
                {
                    k6++;
                    n6 = n6 * k6;
                    stel6.Content = "Стеллаж (+" + k6 + ")  " + n6 + " кл. (+1 к клику)";
                }
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }

        int k7 = 1;
        int k8 = 1;
        int k9 = 1;
        int k10 = 1;
        int p = 80;
        int p2 = 250;
        int p3 = 600;
        int p4 = 1100;
        private void P1_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= p)
            {
                sp.Play();
                if (k7 == 1)
                {
                    plakat1.Visibility = Visibility.Visible;

                    avto = avto + k7;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p;
                    sh.Content = kl + " Кл.";
                    
                }
                if (k7 == 2)
                {

                    avto = avto + k7;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p;
                    sh.Content = kl + " Кл.";

                }
                if (k7 == 3)
                {

                    avto = avto + k7;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p;
                    sh.Content = kl + " Кл.";

                }
                if (k7 == 4)
                {

                    avto = avto + k7;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p;
                    sh.Content = kl + " Кл.";

                }
                if (k7 == 5)
                {

                    avto = avto + k7;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p;
                    sh.Content = kl + " Кл.";

                    P1.Content = "Куплено";
                    P1.IsEnabled = false;
                }
                else
                {
                    k7++;
                    p = p * 2;
                    P1.Content = "Плакат (+" + k7 + ")  " + p + " кл. (+"+k7+" к клику)";
                }
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }

        }
        private void P2_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= p2)
            {
                sp.Play();
                if (k8 == 1)
                {
                    derevo.Visibility = Visibility.Visible;

                    avto = avto + k8;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p2;
                    sh.Content = kl + " Кл.";

                }
                if (k8 == 2)
                {

                    avto = avto + k8;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p2;
                    sh.Content = kl + " Кл.";

                }
                if (k8 == 3)
                {

                    avto = avto + k8;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p2;
                    sh.Content = kl + " Кл.";

                }
                if (k8 == 4)
                {

                    avto = avto + k8;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p2;
                    sh.Content = kl + " Кл.";

                }
                if (k8 == 5)
                {

                    avto = avto + k8;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p2;
                    sh.Content = kl + " Кл.";

                    P2.Content = "Куплено";
                    P2.IsEnabled = false;
                }
                else
                {
                    k8++;
                    p2 = p2 * 2;
                    P2.Content = "Дерево (+" + k8 + ")  " + p2 + " кл. (+" + k8 + " к клику)";
                }
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }

        }
        private void P3_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= p3)
            {
                sp.Play();
                if (k9 == 1)
                {
                    plakat2.Visibility = Visibility.Visible;

                    avto = avto + k9;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p3;
                    sh.Content = kl + " Кл.";

                }
                if (k9 == 2)
                {

                    avto = avto + k9;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p3;
                    sh.Content = kl + " Кл.";

                }
                if (k8 == 3)
                {

                    avto = avto + k9;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p3;
                    sh.Content = kl + " Кл.";

                }
                if (k9 == 4)
                {

                    avto = avto + k9;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p3;
                    sh.Content = kl + " Кл.";

                }
                if (k9 == 5)
                {

                    avto = avto + k9;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p3;
                    sh.Content = kl + " Кл.";

                    P3.Content = "Куплено";
                    P3.IsEnabled = false;
                }
                else
                {
                    k9++;
                    p3 = p3 * 2;
                    P3.Content = "Плакат (+" + k9 + ")  " + p3 + " кл. (+" + k9 + " к клику)";
                }
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }

        }
        private void P4_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= p4)
            {
                sp.Play();
                if (k10 == 1)
                {
                    knigi.Visibility = Visibility.Visible;

                    avto = avto + k10;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p4;
                    sh.Content = kl + " Кл.";

                }
                if (k10 == 2)
                {

                    avto = avto + k10;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p4;
                    sh.Content = kl + " Кл.";

                }
                if (k10 == 3)
                {

                    avto = avto + k10;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p4;
                    sh.Content = kl + " Кл.";

                }
                if (k10 == 4)
                {

                    avto = avto + k10;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p4;
                    sh.Content = kl + " Кл.";

                }
                if (k10 == 5)
                {

                    avto = avto + k10;
                    avclick.Content = "Авто: " + avto + " Кл/сек";
                    avtotim.Start();

                    kl = kl - p4;
                    sh.Content = kl + " Кл.";

                    P4.Content = "Куплено";
                    P4.IsEnabled = false;
                }
                else
                {
                    k10++;
                    p4 = p4 * 2;
                    P4.Content = "Плакат (+" + k10 + ")  " + p4 + " кл. (+" + k10 + " к клику)";
                }
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }

        }

         
        private void Dos1_Click(object sender, RoutedEventArgs e)
        {
           
            if (prov == 1)
            {
                kl = kl + 10;
                sh.Content = kl + " Кл.";
                MessageBox.Show("+10 Кл.");
                Dos1.IsEnabled = false;
                prov = 0;
                Dos1.Content = "Получено";
            }
            
        }
        private void Dos2_Click(object sender, RoutedEventArgs e)
        {
            if (prov2 == 1)
            {
                avto = avto + 2;
                avclick.Content = "Авто: " + avto + "Кл/сек";

                MessageBox.Show("+2 Кл/сек");
                Dos2.IsEnabled = false;
                prov2 = 0;
                Dos2.Content = "Получено";
                avtotim.Start();
            }

        }

        private void F1_Click(object sender, RoutedEventArgs e)
        {
            Fon1.Visibility = Visibility.Visible;
           // Fon2.Visibility = Visibility.Hidden;
            F1.IsEnabled = false;
            F2.IsEnabled = true;
        }
        private void F2_Click(object sender, RoutedEventArgs e)
        {
            Fon1.Visibility = Visibility.Hidden;
            //Fon2.Visibility = Visibility.Visible;
            F1.IsEnabled = true;
            F2.IsEnabled = false;
        }
    }
}