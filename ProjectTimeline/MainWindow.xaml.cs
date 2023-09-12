using ProjectTimeline.Views;
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

namespace ProjectTimeline
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        pgCapture pg_capture = new pgCapture();
        pgDisplay pg_display = new pgDisplay();
        pgFilter pg_filter = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            frmContainer.Content = pg_capture;
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            frmContainer.Content = pg_display;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            frmContainer.Content = pg_filter;
        }
    }
}
