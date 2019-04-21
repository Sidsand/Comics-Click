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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer;
        // Create a red Ellipse.
        
        Random rng = new Random();
        Rectangle ClickMenu = new Rectangle();

        public MainWindow()
        {
            InitializeComponent();
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            
                StackPanel myStackPanel = new StackPanel();

           
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromArgb(0, 0, 0, 0);

            //// =====================================================================================

                Fon.Fill = mySolidColorBrush;
            ImageBrush ib = new ImageBrush();
              ib.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Интерфейс/Фон.png"));
             Fon.Fill = ib;
            
            Fon.Width = 1280;
            Fon.Height = 720;
            Fon.MouseDown += Fon_MouseDown;

            //// =====================================================================================
            

            ClickMenu.Fill = mySolidColorBrush;
            ImageBrush CM = new ImageBrush();
              CM.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Интерфейс/Меню/Кнопка меню.png"));
            ClickMenu.Fill = CM;

            ClickMenu.Width = 140;
            ClickMenu.Height = 140;
            ClickMenu.Margin = new Thickness(1120, 10, 0, 0);
            grid.Children.Add(ClickMenu);

            ClickMenu.MouseDown += ClickMenu_MouseDown;

            //// =====================================================================================

        }

        private void ClickMenu_MouseDown(object sender, MouseEventArgs e)
        {
            menu.Visibility = Visibility.Visible;
            ex.Visibility = Visibility.Visible;
            exit.Visibility = Visibility.Visible;
        }

        private void ex_MouseDown(object sender, MouseEventArgs e)
        {
            menu.Visibility = Visibility.Hidden;
            ex.Visibility = Visibility.Hidden;
            exit.Visibility = Visibility.Hidden;
        }

        double kl = 0;
        double aup = 1;
        double Up=1;

        private void Fon_MouseDown(object sender, MouseEventArgs e)
        {
            kl = kl + aup;
            sh.Content = kl + " кл.";
        }

        private void App_Click(object sender, RoutedEventArgs e)
        { 
            if (kl >= Up)
            {
                    kl = kl - Up;
                    Up = Up * 2;
                    aup = aup + 1;
                   // apps.Text = Up + " кл.";
                    sh.Content = kl + " кл.";
                    och.Content = "Очков за клики: " + aup;
            }
            else
            {
                MessageBox.Show("Нехватает кликов");
           }
        }

       
        
        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
