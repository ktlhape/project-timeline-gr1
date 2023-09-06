﻿using ProjectTimeline.Views;
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
    }
}
