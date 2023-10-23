using ProjectLibrary;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;

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
            LoadData();
        }
        public void LoadData()
        {
            Project pr = new();
            foreach (Project p in pr.AllProjects())
            {
                dgvDisplay.Items.Add(p);
            }
        }
    }
}
