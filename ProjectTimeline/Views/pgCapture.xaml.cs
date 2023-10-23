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
    /// Interaction logic for pgCapture.xaml
    /// </summary>
    public partial class pgCapture : Page
    {
        static int weeks = 12;
        static DateTime semesterStart = Convert.ToDateTime("05-07-2023");
        static DateTime semesterEnd = semesterStart.AddDays(7 * weeks);
        public pgCapture()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string code, prName;
            DateTime start, end;
            int duration;
            double estCost, rate;
            try
            {

                code = txtCode.Text;
                prName = txtProjectName.Text;
                start = dtpStartDate.SelectedDate.Value;
                end = dtpEndDate.SelectedDate.Value;
                rate = Convert.ToDouble(txtRate.Text);

                Project p = new Project(code, prName, start, end, rate);

                txtDuration.Text = p.Duration.ToString();
                txtEstCost.Text = p.EstimatedCost.ToString("C2");
                p.AddProject();
               // Project.prList.Add(p);
                ClearScreen();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,this.Title,MessageBoxButton.OK,MessageBoxImage.Error);
            }

            //ClearScreen();

        }
        public void ClearScreen()
        {
            txtCode.Clear();
            //txtDuration.Clear();
            //txtEstCost.Clear();
            txtProjectName.Clear();
            txtRate.Clear();
            dtpEndDate.SelectedDate = DateTime.Now.Date;
            dtpStartDate.SelectedDate = DateTime.Now.Date;
        }

        private void txtCode_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txtCode.Text.Trim().Length < 4)
            {
                MessageBox.Show("Project Code should be at least 4 characters long");
              
                
            }
           
        }

        private void txtCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCode.Text.Trim().Length == 0)
            {
                btnSave.IsEnabled = false;
            }
            else
            {
                btnSave.IsEnabled = true;
            }
        }
    }
}
