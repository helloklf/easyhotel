﻿using System;
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
using System.Windows.Shapes;

namespace Project_Term2
{
    /// <summary>
    /// BlankForm.xaml 的交互逻辑
    /// </summary>
    public partial class BlankForm : Window
    {
        public BlankForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = Values.SurfaceSetting.Surface;
            this.GRID_.DataContext = Values.SurfaceSetting;
        }
    }
}
