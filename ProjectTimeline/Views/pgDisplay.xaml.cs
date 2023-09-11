using ProjectLibrary;
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

namespace ProjectTimeline.Views
{
    /// <summary>
    /// Interaction logic for pgDisplay.xaml
    /// </summary>
    public partial class pgDisplay : Page
    {
        public pgDisplay()
        {
            InitializeComponent();
        }

        private void rdoAll_Click(object sender, RoutedEventArgs e)
        {
            lstDisplay.Items.Clear();
            foreach (Project p in Project.prList)
            {
                lstDisplay.Items.Add(p.ToString());
            }
        }

        private void rdoWeeks_Click(object sender, RoutedEventArgs e)
        {
            lstDisplay.Items.Clear();
            foreach (Project p in Project.MoreThanSixWeeks())
            {
                lstDisplay.Items.Add(p.ToString());
            }
        }

        private void rdoBetweenDates_Click(object sender, RoutedEventArgs e)
        {
            lstDisplay.Items.Clear();
            DateTime start = Convert.ToDateTime("05-06-2023");
            DateTime end = Convert.ToDateTime("10-09-2023");
            foreach (Project p in Project.BetweenDates(start,end))
            {
                lstDisplay.Items.Add(p.ToString());
            }
        }
    }
}
