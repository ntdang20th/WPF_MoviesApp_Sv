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
using tempapp.Model;

namespace tempapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void HandleExpanderExpanded(object sender, RoutedEventArgs e)
        {
            ExpandExculsively(sender as Expander);
        }

        private void ExpandExculsively(Expander expander)
        {
            foreach (var child in finalPanel0.Children)
            {
                if (child is Expander && child != expander)
                    ((Expander)child).IsExpanded = false;
            }
            foreach (var child in finalPanel1.Children)
            {
                if (child is Expander && child != expander)
                    ((Expander)child).IsExpanded = false;
            }
            foreach (var child in finalPanel2.Children)
            {
                if (child is Expander && child != expander)
                    ((Expander)child).IsExpanded = false;
            }
            rdbThongke.IsChecked =false;
        }
    }
}
