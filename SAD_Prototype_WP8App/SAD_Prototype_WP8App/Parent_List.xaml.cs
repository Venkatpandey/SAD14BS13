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
    public partial class Parent_List : PhoneApplicationPage
    {
        public Parent_List()
        {
            InitializeComponent();

        }

        private void AddBarClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/New_Task_Page.xaml", UriKind.Relative));
        }

        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                MessageBox.Show(listBox1.SelectedItem.ToString() + " will be deleted");
                listBox1.Items.RemoveAt(listBox1.Items.IndexOf(listBox1.SelectedItem));
                ((ListBox)sender).SelectedIndex = -1;
            }
        }

        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {
            ListBox listBox = (sender as ListBox);
            listBox.SelectedIndex = -1;
        }

      
    }
}