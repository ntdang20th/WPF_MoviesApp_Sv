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
using System.Windows.Threading;

namespace tempapp
{
    /// <summary>
    /// Interaction logic for PlayFilmWindow.xaml
    /// </summary>
    public partial class PlayFilmWindow : Window
    {

        string duongdangoc = "D:\\data\\";
        public PlayFilmWindow(string tenFileVideo)
        {
            InitializeComponent();
            VideoControl.Source = new Uri(duongdangoc + tenFileVideo);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VideoControl.Stop();
        }
    }
}
