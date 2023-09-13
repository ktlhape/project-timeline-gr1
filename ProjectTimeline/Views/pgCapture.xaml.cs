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

                Project.prList.Add(p);
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
    }
}
