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
    /// Interaction logic for pgAssignProject.xaml
    /// </summary>
    public partial class pgAssignProject : Page
    {
        List<Employee> emList = Employee.AllEmployees();
        List<Project> prList = Project.AllProjects();
        public pgAssignProject()
        {
            InitializeComponent();
            dgvEmployees.ItemsSource = emList;
            LoadProjects();
        }
        public void LoadProjects()
        {
            DataContext = prList;
        }

        private void cmbProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
          
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbProject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a project");
                cmbProject.Focus();
                cmbProject.BorderBrush = Brushes.Red;
            }
            else
            {
                int id = 3;
                string code = cmbProject.SelectedValue.ToString();
                DateTime dt = DateTime.Now;

                foreach (Employee em in dgvEmployees.SelectedItems)
                {
                    string empNo = em.EmployeeNo;
                    //Insert data
                    Assignment objAssignment = new Assignment(id, code, empNo, dt);
                    objAssignment.Assign();
                }

            }



        }
    }
}
