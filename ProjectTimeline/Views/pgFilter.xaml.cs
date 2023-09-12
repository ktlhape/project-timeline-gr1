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
            LoadData();
        }
        public void LoadData()
        {
            foreach (Project p in Project.prList)
            {
                dgvDisplay.Items.Add(p);
            }
        }
    }
}
