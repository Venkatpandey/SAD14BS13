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

// Directive for the ViewModel.
using SchedulerApp.Model;

namespace SchedulerApp.View
{
    public partial class MainPage : PhoneApplicationPage
    {
        //private static bool _PasswordMatch;
        //public static bool PasswordMatch
        //{
        //    get
        //    {
        //        return _PasswordMatch;
        //    }
        //    set
        //    {
        //        if (value != _PasswordMatch)
        //        {
        //            _PasswordMatch = value;
        //            PhoneApplicationPage_Loaded(null, null);
        //        }
        //    }
        //}

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the page DataContext property to the ViewModel.
            this.DataContext = App.ViewModel;
        }

        private void newTaskAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/NewTaskPage.xaml", UriKind.Relative));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Cast the parameter as a button.
            var button = sender as Button;

            if (button != null)
            {
                // Get a handle for the to-do item bound to the button.
                
                To_Do_Item toDoForDelete = button.DataContext as To_Do_Item;
                MessageBoxResult messResult = MessageBox.Show("Are you sure you want to delete the Item '" + toDoForDelete.ItemName + "'", "Warning", MessageBoxButton.OKCancel);
                if (messResult == MessageBoxResult.OK)
                    App.ViewModel.DeleteToDoItem(toDoForDelete);
                else
                    return;
            }

            // Put the focus back to the main page.
            this.Focus();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Save changes to the database.
            App.ViewModel.SaveToDB();
        }

        To_Do_Item toDoForEdit;
        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Cast the parameter as a textBlock.
            var textBlock = sender as TextBlock;

            if (textBlock != null)
            {
                // Get a handle for the to-do item bound to the textBlock
                toDoForEdit = textBlock.DataContext as To_Do_Item;
                //if (!string.IsNullOrEmpty(toDoForEdit.Password))
                //{

                //    NavigationService.Navigate(new Uri("/View/PasswordPage.xaml?Password=" +
                // (toDoForEdit.Password), UriKind.Relative));

                //    NavigationService.Navigated += NavigationService_Navigated;
                //}
                //else
                //{

                    NavigationService.Navigate(new Uri("/View/NewTaskPage.xaml?selectedItem=" +
     (toDoForEdit.ToDoItemId.ToString()), UriKind.Relative));
                //}

            }

            //// Put the focus back to the main page.
            //this.Focus();
        }


        void NavigationService_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            

 //           if (PasswordMatch)
 //           {
 //               NavigationService.Navigate(new Uri("/View/NewTaskPage.xaml?selectedItem=" +
 //(toDoForEdit.ToDoItemId.ToString()), UriKind.Relative));
 //           }
 //           else
 //           {
 //               MessageBox.Show("Please enter correct Password!!", "Password Error", MessageBoxButton.OK);
 //           }
            
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //if (NavigationContext.QueryString.TryGetValue("PasswordMatch", out ID_of_ItemToBeLoaded))
            //{
            //}
        }
    }
}
