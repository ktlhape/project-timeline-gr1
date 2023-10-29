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
    /// Interaction logic for pgFilter.xaml
    /// </summary>
    public partial class pgFilter : Page
    {
        public pgFilter()
        {
            InitializeComponent();
        }
        Project p = new Project();
        string code; //Add a textbox for the code
        private void cmbOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgvDisplay.Items.Clear();
            //List<Project> ls = Project.prList;
            List<Project> ls = Project.AllProjects();
            
            txtCode.Visibility = Visibility.Hidden;

            if (cmbOptions.SelectedIndex == 0)
            {
                ls = Project.AllProjects();

            }else if(cmbOptions.SelectedIndex == 1)
            {
                txtCode.Visibility = Visibility.Visible;
                
            }else if(cmbOptions.SelectedIndex == 2)
            {
               
                ls = Project.CompletedProjects();

            }else if(cmbOptions.SelectedIndex == 3)
            {
                //get the two dates from datepicker
            }else if(cmbOptions.SelectedIndex == 4)
            {
                ls = Project.MoreThanSixWeeks();
            }

            foreach (Project pr in ls)
            {
                dgvDisplay.Items.Add(pr);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgvDisplay.Items.Clear();
            code = txtCode.Text;
            p = p[code];
            dgvDisplay.Items.Add(p);
        }
    }
}
