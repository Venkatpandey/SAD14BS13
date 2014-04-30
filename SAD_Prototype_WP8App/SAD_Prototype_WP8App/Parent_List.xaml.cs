
﻿using System;
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
        List_Page list1 = new List_Page();
        List_Page list2 = new List_Page();
        List<List_Page> oList = new List<List_Page>();



        public Parent_List()
        {
            InitializeComponent();
            list1.Name = "TestList1";
            list2.Name = "TestList2";

            oList.Add(list1);
            oList.Add(list2);
            ListOfLists.ItemsSource = oList;


        }

        private void AddBarClick(object sender, EventArgs e)
        {
            switch (MainPivot.SelectedIndex)
            {
                case 0:
                    {
                        //        _navigation.Navigate(
                        //        _navigation.UriFor<StockDetailsViewModel>()
                        //.WithParam(m => m.Symbol, snapshot.Symbol)
                        //.Navigate();
                        NavigationService.Navigate(new Uri("/List_Page.xaml", UriKind.Relative));
                    }
                    break;

                case 1:

                    NavigationService.Navigate(new Uri("/Note_Page.xaml", UriKind.Relative));
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {
            switch (MainPivot.SelectedIndex)
            {
                case 0:

                    break;

                case 1:

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //if (textBox1.Text != "")
            //{
            //    listBox1.Items.Add(textBox1.Text);
            //    textBox1.Text = "";
            //}
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (e.AddedItems.Count > 0)
            //{
            //    MessageBox.Show(listBox1.SelectedItem.ToString() + " will be deleted");
            //    listBox1.Items.RemoveAt(listBox1.Items.IndexOf(listBox1.SelectedItem));
            //    ((ListBox)sender).SelectedIndex = -1;
            //}
        }

        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {
            ListBox listBox = (sender as ListBox);
            listBox.SelectedIndex = -1;
        }

        private void Notes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Lists_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListsPivotFocused(object sender, RoutedEventArgs e)
        {

        }


    }
}