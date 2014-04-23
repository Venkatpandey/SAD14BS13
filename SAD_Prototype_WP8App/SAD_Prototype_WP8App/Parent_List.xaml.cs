using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SAD_Prototype_WP8App
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void AddBarClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/New Task Page.xaml", UriKind.Relative));
        }

        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {

        }

      
    }
}