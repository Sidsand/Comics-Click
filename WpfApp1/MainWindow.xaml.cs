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
        int i = 85;
        bool st = true;

        public MainWindow()
        {
            InitializeComponent();
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void Tick1(object sender, EventArgs e)
        {
            if (i < 4) { Timer.Stop(); st = false; }
            else
            {
                Stack.Width = i;
                Frame.Margin = new Thickness((i - 4), 0, 0, 0);
                i -= 4;
            }
        }

        private void Tick2(object sender, EventArgs e)
        {
            if (i > 354) { Timer.Stop(); st = true; }
            else
            {
                Stack.Width = i;
                Frame.Margin = new Thickness((i + 4), 0, 0, 0);
                i += 4;
            }
        }

        private void m1_Click(object sender, RoutedEventArgs e)
        {

            if (st == true)
            {
                Timer.Tick += new EventHandler(Tick1);
                Timer.Start();

            }

            else
            {
                Timer.Tick += new EventHandler(Tick2);
                Timer.Start();
            }
        }

        double kl = 0;
        double aup = 1;
       double Up=1;

        private void Clik_Click(object sender, RoutedEventArgs e)
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
                    apps.Text = Up + " кл.";
                    sh.Content = kl + " кл.";
                    och.Content = "Очков за клики: " + aup;
            }
            else
            {
                MessageBox.Show("Нехватает кликов");
           }
        }

        private void dos_Click(object sender, RoutedEventArgs e)
        {   Достижения och = new Достижения();

            och.sh1.Content = sh.Content;
            if (och.ShowDialog() == true)
            {
            }

        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
