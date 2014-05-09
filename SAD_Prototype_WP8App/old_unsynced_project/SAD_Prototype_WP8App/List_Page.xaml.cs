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
    public partial class List_Page : PhoneApplicationPage
    {
        public List_Page()
        {
            InitializeComponent();
        }

        private void AppBarSave_Click(object sender, EventArgs e)
        {

        }

        private void AppBarReminder_Click(object sender, EventArgs e)
        {

        }

        private void NewItem_tb_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            CheckBox item = new CheckBox();
            
            
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (NewItem_tb.Text != string.Empty)
                {
                    item.Content = NewItem_tb.Text;
                    item.Checked += item_Checked;
                    ItemsList.Items.Add(item);
                    
                }
            }
        }

        void item_Checked(object sender, RoutedEventArgs e)
        {
            
            

            CheckBox checkedItem = sender as CheckBox;
            
            //checkedItem.Content = string.Empty;

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {

        }



        internal void loadPage()
        {
            
        }
    }
}