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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Достижения.xaml
    /// </summary>
    public partial class Достижения : Window
    {
        public Достижения()
        {
            InitializeComponent();

            if (int.Parse(sh1.Content.ToString()) >= 1000)
            {  k1000.Opacity = 100;  }
            if (int.Parse(sh1.Content.ToString()) >= 800)
            {
                k800.Opacity = 100;
            }
            if (int.Parse(sh1.Content.ToString()) >= 666)
            {
                k666.Opacity = 100;
            }
            if (int.Parse(sh1.Content.ToString()) >= 500)
            {
                k666.Opacity = 100;
            }
            if (int.Parse(sh1.Content.ToString()) >= 250)
            {
                k250.Opacity = 100;
            }

            if (int.Parse(sh1.Content.ToString()) >= 100)
            {
             k100.Opacity = 100;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

          
    }
}
