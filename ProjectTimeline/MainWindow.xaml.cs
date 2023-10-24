using ProjectLibrary;
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
            pgDisplay pg_display = new pgDisplay();
            frmContainer.Content = pg_display;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            pgFilter pg_filter = new();
            frmContainer.Content = pg_filter;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Employee emp = (Employee)this.Tag; //em
            this.Title = $"Welcome ({emp.EmployeeNo}): {emp.Firstname} {emp.Lastname}";

            if (emp.EmpType.Equals("admin"))
            {
                btnCapture.Visibility = Visibility.Visible;
                btnDisplay.Visibility = Visibility.Visible;
                btnFilter.Visibility = Visibility.Visible;
            }else if (emp.EmpType.Equals("user"))
            {
                btnCapture.Visibility = Visibility.Hidden;
                btnDisplay.Visibility = Visibility.Visible;
                btnFilter.Visibility = Visibility.Hidden;
            }
        }

    
    }
}
