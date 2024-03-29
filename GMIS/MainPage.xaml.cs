﻿/**
 * @auther Shengya Ji
 * @date 07/05/2022
 */
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

namespace GMIS
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void classbutton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage(GlobalsType.ClassManagementType));
        }

        private void meettingbutton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage(GlobalsType.MeettingManagementType));
        }

        private void studentbutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NO CONTRIBUTION!");
        }

        private void groupbutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NO CONTRIBUTION!");
        }
    }
}
