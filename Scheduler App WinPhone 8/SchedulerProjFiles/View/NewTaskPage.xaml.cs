using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;


// Directive
using SchedulerApp.Model;

namespace SchedulerApp.View
{
    public partial class NewTaskPage : PhoneApplicationPage
    {
        public NewTaskPage()
        {
            InitializeComponent();

            // Set  DataContext property
            this.DataContext = App.ViewModel;
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {

            if (newTaskNameTextBox.Text.Length > 0)
            {

                // Create a new to-do item.
                To_Do_Item newToDoItem = new To_Do_Item
                {
                    ItemName = newTaskNameTextBox.Text,
                    Category = (To_Do_Category)categoriesListPicker.SelectedItem,
                    Password = Password_TextBox.Password,
                    Description = Description_TextBox.Text
                };

                App.ViewModel.DeleteToDoItem(newToDoItem.ItemName,newToDoItem.Category);
                // Add the item to the ViewModel.
                App.ViewModel.AddToDoItem(newToDoItem);

                // Return to the main page.
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            }
        }

        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            // Return to the main page.
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void appBarAlarmButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/AddNotification.xaml", UriKind.RelativeOrAbsolute));
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string ID_of_ItemToBeLoaded;
            To_Do_Item ItemTobeLoaded;
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out ID_of_ItemToBeLoaded))
            {
                ItemTobeLoaded = App.ViewModel.GetToDoItem(Convert.ToInt32(ID_of_ItemToBeLoaded));
                if (ItemTobeLoaded != null)
                {
                    newTaskNameTextBox.Text = ItemTobeLoaded.ItemName;
                    PageTitle.Text = ItemTobeLoaded.ItemName;
                    categoriesListPicker.SelectedItem = ItemTobeLoaded.Category;
                    if (!string.IsNullOrEmpty(ItemTobeLoaded.Description))
                        Description_TextBox.Text = ItemTobeLoaded.Description;
                    //if (!string.IsNullOrEmpty(ItemTobeLoaded.Password != null))
                    //{
                    //    NavigationService.Navigate(new Uri("/View/PasswordPage.xaml", UriKind.Relative));
                    //}
                    
                    
                }
            }
        }
    }
}
