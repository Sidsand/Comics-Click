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
using System.Windows.Media.Animation;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer avtotim = new DispatcherTimer();



        Random rng = new Random();

        Rectangle D = new Rectangle();

        public MainWindow()
        {
            InitializeComponent();
            avtotim.Interval = new TimeSpan(0, 0, 0, 1);
            avtotim.Tick += new EventHandler(Timer_click);

  

            //// =====================================================================================
            WindowState = WindowState.Maximized;
              WindowStyle = WindowStyle.None;

                StackPanel myStackPanel = new StackPanel();

           
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromArgb(0, 0, 0, 0);

            //// =====================================================================================

                Fon.Fill = mySolidColorBrush;
            ImageBrush ib = new ImageBrush();
              ib.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Интерфейс/Фон4.png"));
             Fon.Fill = ib;
            
            Fon.Width = 1280;
            Fon.Height = 720;
           

            //// =====================================================================================
        }

       

        int avto = 0;

        private void Timer_click(object sender, EventArgs e)
        {
            kl = kl + avto;
            sh.Content = kl + " кл.";
        }

        private void EXMENU_MouseDown(object sender, MouseEventArgs e)
        {
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

            S1.Visibility = Visibility.Hidden;
            D1.Visibility = Visibility.Hidden;
            V1.Visibility = Visibility.Hidden;

            ClickMenu.Visibility = Visibility.Visible;
        }
        

        double kl = 0;
        double aup = 1;
        double Up=1;

        private void Fon_MouseDown(object sender, MouseEventArgs e)
        {
            kl = kl + aup;
            sh.Content = kl + " кл.";
            animation_init();
        }

        Rectangle deffka = new Rectangle();
        int frame = 0;
        int transx = 0, transy = 0;
        int speed = 5;
        int direction = 1;

        const int top_limit = 0;
        const int left_limit = 0;
        const int bot_limit = 500;
        const int right_limit = 1000;

        Random rand = new Random();
        System.Windows.Threading.DispatcherTimer timer;

        // должно работать, но хз как

        //private void animation_init()
        //{
        //    ObjectAnimationUsingKeyFrames animation = new ObjectAnimationUsingKeyFrames();
        //    animation.BeginTime = TimeSpan.FromSeconds(0);
        //    Storyboard.SetTarget(animation, image);
        //    Storyboard.SetTargetProperty(animation, new PropertyPath("(Image.Source)"));
        //    DiscreteObjectKeyFrame keyFrame = new DiscreteObjectKeyFrame(BitmapFrame.Create(uri), TimeSpan.FromSeconds(0.7));
        //    animation.KeyFrames.Add(keyFrame);
        //    myStoryboard.Children.Add(animation);
        //    myStoryboard.Begin();
        //}


        // раньше работало, теперь не работает

        private void animation_init()
        {

            deffka.Height = 91;
            deffka.Width = 48;
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;

            ib.AlignmentY = AlignmentY.Top;
            ib.Stretch = Stretch.None;
            ib.ViewboxUnits = BrushMappingMode.Absolute;
            deffka.Fill = ib;
            ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/pic/deffka_slide2s.gif", UriKind.Absolute));
            deffka.Margin = new Thickness(0, 0, 0, 0);
            anime = deffka;
            //deffka.RenderTransform = new TranslateTransform(this.Width / 2, this.Height / 2);
            //transy = Convert.ToInt32(this.Height / 2);
            //transx = Convert.ToInt32(this.Width / 2);


            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            timer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (frame == 4)
            {
                frame = 0;
            }

            //if (rand.Next(1, 50) < 3)
            //{
            //    direction = rand.Next(1, 4);
            //}

            if ((transx <= left_limit))
            {
                direction = 2;
            }
            if ((transx >= right_limit))
            {
                direction = 1;
            }
            if ((transy >= bot_limit))
            {
                direction = 4;
            }
            if ((transy <= top_limit))
            {
                direction = 3;
            }

            if (direction == 1)
                walk_forvard();
            if (direction == 2)
                walk_back();
            if (direction == 3)
                walk_left();
            if (direction == 4)
                walk_right();

            frame++;
        }

        private void walk_forvard()
        {
            (deffka.Fill as ImageBrush).Viewbox = new Rect(frame * 145, 0, 145, 275);
            transx -= 2 * speed;
            transy -= 1 * speed;
            deffka.RenderTransform = new TranslateTransform(transx, transy);
        }

        private void walk_back()
        {
            (deffka.Fill as ImageBrush).Viewbox = new Rect(frame * 141, 280, 145, 560);
            transx += 2 * speed;
            transy += 1 * speed;
            deffka.RenderTransform = new TranslateTransform(transx, transy);
        }
        private void walk_right()
        {
            (deffka.Fill as ImageBrush).Viewbox = new Rect(frame * 145 + 570, 0, frame * 150 + 150, 280);
            transx += 2 * speed;
            transy -= 1 * speed;
            deffka.RenderTransform = new TranslateTransform(transx, transy);
        }
        private void walk_left()
        {
            (deffka.Fill as ImageBrush).Viewbox = new Rect(frame * 145 + 580, 280, frame * 150 + 150, 560);
            transx -= 2 * speed;
            transy += 1 * speed;
            deffka.RenderTransform = new TranslateTransform(transx, transy);
        }




        private void S1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuS.Visibility = Visibility.Visible;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;


            scroll_S1.Visibility = Visibility.Visible;
            scroll_D1.Visibility = Visibility.Hidden;
        }
        
        private void D1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuS.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Visible;
            menuV.Visibility = Visibility.Hidden;

            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Visible;
        }

        private void V1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuS.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Visible;

            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
        }



        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
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
            S1.Visibility = Visibility.Hidden;
            D1.Visibility = Visibility.Hidden;
            V1.Visibility = Visibility.Hidden;

            ClickMenu.Visibility = Visibility.Hidden;

            sh.Visibility = Visibility.Hidden;
            och.Visibility = Visibility.Hidden;

            start.Visibility = Visibility.Visible;
            exit1.Visibility = Visibility.Visible;
            main_menu.Visibility = Visibility.Visible;
            
        }

        private void Shop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuS.Visibility = Visibility.Visible;
            stats.Visibility = Visibility.Hidden;
            achiv.Visibility = Visibility.Hidden;

            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
            scroll_S1.Visibility = Visibility.Visible;
            S1.Visibility = Visibility.Visible;
            D1.Visibility = Visibility.Visible;
            V1.Visibility = Visibility.Visible;
        }

        private void Stat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuS.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;
            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
            S1.Visibility = Visibility.Hidden;
            D1.Visibility = Visibility.Hidden;
            V1.Visibility = Visibility.Hidden;

            stats.Visibility = Visibility.Visible;

            achiv.Visibility = Visibility.Hidden;
        }

        private void Achivki_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuS.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;
            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
            S1.Visibility = Visibility.Hidden;
            D1.Visibility = Visibility.Hidden;
            V1.Visibility = Visibility.Hidden;

            stats.Visibility = Visibility.Hidden;

            achiv.Visibility = Visibility.Visible;
        }

        private void Top_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuS.Visibility = Visibility.Hidden;
            menuD.Visibility = Visibility.Hidden;
            menuV.Visibility = Visibility.Hidden;
            scroll_S1.Visibility = Visibility.Hidden;
            scroll_D1.Visibility = Visibility.Hidden;
            S1.Visibility = Visibility.Hidden;
            D1.Visibility = Visibility.Hidden;
            V1.Visibility = Visibility.Hidden;

            stats.Visibility = Visibility.Hidden;

            achiv.Visibility = Visibility.Visible;
        }

        private void ClickMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
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
            this.Close();
        }

        private void start_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClickMenu.Visibility = Visibility.Visible;

            sh.Visibility = Visibility.Visible;
            och.Visibility = Visibility.Visible;

            start.Visibility = Visibility.Hidden;
            exit1.Visibility = Visibility.Hidden;

            main_menu.Visibility = Visibility.Hidden;
        }

        private void St1_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= 20)
            {
                stellag1.Visibility = Visibility.Visible;
                stel1.IsEnabled = false;

                shop.Visibility = Visibility.Hidden;
                stat.Visibility = Visibility.Hidden;
                achivki.Visibility = Visibility.Hidden;
                top.Visibility = Visibility.Hidden;
                exit.Visibility = Visibility.Hidden;

                menuS.Visibility = Visibility.Hidden;
                EXMENU.Visibility = Visibility.Hidden;

                scroll_S1.Visibility = Visibility.Hidden;
                S1.Visibility = Visibility.Hidden;
                D1.Visibility = Visibility.Hidden;
                V1.Visibility = Visibility.Hidden;

                ClickMenu.Visibility = Visibility.Visible;


                aup = aup + 1;
                och.Content = "Очков за клики: " + aup;

                kl = kl - 20;
                sh.Content = kl + " кл.";
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }
        private void St2_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= 150)
            {
                stellag2.Visibility = Visibility.Visible;
                stel2.IsEnabled = false;

                shop.Visibility = Visibility.Hidden;
                stat.Visibility = Visibility.Hidden;
                achivki.Visibility = Visibility.Hidden;
                top.Visibility = Visibility.Hidden;
                exit.Visibility = Visibility.Hidden;

                menuS.Visibility = Visibility.Hidden;
                EXMENU.Visibility = Visibility.Hidden;

                scroll_S1.Visibility = Visibility.Hidden;
                S1.Visibility = Visibility.Hidden;
                D1.Visibility = Visibility.Hidden;
                V1.Visibility = Visibility.Hidden;

                ClickMenu.Visibility = Visibility.Visible;


                aup = aup + 2;
                och.Content = "Очков за клики: " + aup;

                kl = kl - 150;
                sh.Content = kl + " кл.";
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }
        private void St3_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= 400)
            {
                stellag3.Visibility = Visibility.Visible;
                stel3.IsEnabled = false;

                shop.Visibility = Visibility.Hidden;
                stat.Visibility = Visibility.Hidden;
                achivki.Visibility = Visibility.Hidden;
                top.Visibility = Visibility.Hidden;
                exit.Visibility = Visibility.Hidden;

                menuS.Visibility = Visibility.Hidden;
                EXMENU.Visibility = Visibility.Hidden;

                scroll_S1.Visibility = Visibility.Hidden;
                S1.Visibility = Visibility.Hidden;
                D1.Visibility = Visibility.Hidden;
                V1.Visibility = Visibility.Hidden;

                ClickMenu.Visibility = Visibility.Visible;


                aup = aup + 2;
                och.Content = "Очков за клики: " + aup;

                kl = kl - 400;
                sh.Content = kl + " кл.";
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }
        private void St4_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= 80)
            {
                stellag4.Visibility = Visibility.Visible;
                stel4.IsEnabled = false;

                shop.Visibility = Visibility.Hidden;
                stat.Visibility = Visibility.Hidden;
                achivki.Visibility = Visibility.Hidden;
                top.Visibility = Visibility.Hidden;
                exit.Visibility = Visibility.Hidden;

                menuS.Visibility = Visibility.Hidden;
                EXMENU.Visibility = Visibility.Hidden;

                scroll_S1.Visibility = Visibility.Hidden;
                S1.Visibility = Visibility.Hidden;
                D1.Visibility = Visibility.Hidden;
                V1.Visibility = Visibility.Hidden;

                ClickMenu.Visibility = Visibility.Visible;


                aup = aup + 3;
                och.Content = "Очков за клики: " + aup;

                kl = kl - 800;
                sh.Content = kl + " кл.";
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }
        private void St5_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= 1200)
            {
                stellag5.Visibility = Visibility.Visible;
                stel5.IsEnabled = false;

                shop.Visibility = Visibility.Hidden;
                stat.Visibility = Visibility.Hidden;
                achivki.Visibility = Visibility.Hidden;
                top.Visibility = Visibility.Hidden;
                exit.Visibility = Visibility.Hidden;

                menuS.Visibility = Visibility.Hidden;
                EXMENU.Visibility = Visibility.Hidden;

                scroll_S1.Visibility = Visibility.Hidden;
                S1.Visibility = Visibility.Hidden;
                D1.Visibility = Visibility.Hidden;
                V1.Visibility = Visibility.Hidden;

                ClickMenu.Visibility = Visibility.Visible;


                aup = aup + 3;
                och.Content = "Очков за клики: " + aup;

                kl = kl - 1200;
                sh.Content = kl + " кл.";
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }
        private void St6_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= 1500)
            {
                polka.Visibility = Visibility.Visible;
                stel6.IsEnabled = false;

                shop.Visibility = Visibility.Hidden;
                stat.Visibility = Visibility.Hidden;
                achivki.Visibility = Visibility.Hidden;
                top.Visibility = Visibility.Hidden;
                exit.Visibility = Visibility.Hidden;

                menuS.Visibility = Visibility.Hidden;
                EXMENU.Visibility = Visibility.Hidden;

                scroll_S1.Visibility = Visibility.Hidden;
                S1.Visibility = Visibility.Hidden;
                D1.Visibility = Visibility.Hidden;
                V1.Visibility = Visibility.Hidden;

                ClickMenu.Visibility = Visibility.Visible;


                aup = aup + 3;
                och.Content = "Очков за клики: " + aup;

                kl = kl - 1200;
                sh.Content = kl + " кл.";
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
        }

        private void P1_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= 50)
            {
                stellag1.Visibility = Visibility.Visible;
                P1.IsEnabled = false;

                shop.Visibility = Visibility.Hidden;
                stat.Visibility = Visibility.Hidden;
                achivki.Visibility = Visibility.Hidden;
                top.Visibility = Visibility.Hidden;
                exit.Visibility = Visibility.Hidden;

                menuD.Visibility = Visibility.Hidden;
                EXMENU.Visibility = Visibility.Hidden;
                
                scroll_D1.Visibility = Visibility.Hidden;
                S1.Visibility = Visibility.Hidden;
                D1.Visibility = Visibility.Hidden;
                V1.Visibility = Visibility.Hidden;

                ClickMenu.Visibility = Visibility.Visible;

                kl = kl - 50;
                sh.Content = kl + " кл.";

                avto = avto + 1;
                avclick.Content = "Авто: " + avto + "Кл/сек";

                avtotim.Start();
                P1.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }
            
        }
        private void P2_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= 200)
            {


                derevo.Visibility = Visibility.Visible;
                P2.IsEnabled = false;

                shop.Visibility = Visibility.Hidden;
                stat.Visibility = Visibility.Hidden;
                achivki.Visibility = Visibility.Hidden;
                top.Visibility = Visibility.Hidden;
                exit.Visibility = Visibility.Hidden;

                menuD.Visibility = Visibility.Hidden;
                EXMENU.Visibility = Visibility.Hidden;

                scroll_D1.Visibility = Visibility.Hidden;
                S1.Visibility = Visibility.Hidden;
                D1.Visibility = Visibility.Hidden;
                V1.Visibility = Visibility.Hidden;

                ClickMenu.Visibility = Visibility.Visible;

                kl = kl - 200;
                sh.Content = kl + " кл.";

                avto = avto + 3;
                avclick.Content = "Авто: " + avto + "Кл/сек";

                avtotim.Start();
                P1.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }

        }
        private void P3_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= 500)
            {


                stellag1.Visibility = Visibility.Visible;
                P3.IsEnabled = false;

                shop.Visibility = Visibility.Hidden;
                stat.Visibility = Visibility.Hidden;
                achivki.Visibility = Visibility.Hidden;
                top.Visibility = Visibility.Hidden;
                exit.Visibility = Visibility.Hidden;

                menuD.Visibility = Visibility.Hidden;
                EXMENU.Visibility = Visibility.Hidden;

                scroll_D1.Visibility = Visibility.Hidden;
                S1.Visibility = Visibility.Hidden;
                D1.Visibility = Visibility.Hidden;
                V1.Visibility = Visibility.Hidden;

                ClickMenu.Visibility = Visibility.Visible;

                kl = kl - 500;
                sh.Content = kl + " кл.";

                avto = avto + 5;
                avclick.Content = "Авто: " + avto + "Кл/сек";

                avtotim.Start();
                P1.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }

        }
        private void P4_Click(object sender, RoutedEventArgs e)
        {
            if (kl >= 700)
            {


                knigi.Visibility = Visibility.Visible;
                P4.IsEnabled = false;

                shop.Visibility = Visibility.Hidden;
                stat.Visibility = Visibility.Hidden;
                achivki.Visibility = Visibility.Hidden;
                top.Visibility = Visibility.Hidden;
                exit.Visibility = Visibility.Hidden;

                menuD.Visibility = Visibility.Hidden;
                EXMENU.Visibility = Visibility.Hidden;

                scroll_D1.Visibility = Visibility.Hidden;
                S1.Visibility = Visibility.Hidden;
                D1.Visibility = Visibility.Hidden;
                V1.Visibility = Visibility.Hidden;

                ClickMenu.Visibility = Visibility.Visible;

                kl = kl - 700;
                sh.Content = kl + " кл.";

                avto = avto + 6;
                avclick.Content = "Авто: " + avto + "Кл/сек";

                avtotim.Start();
                P1.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Не хватает кликов");
            }

        }

       
    }
}
