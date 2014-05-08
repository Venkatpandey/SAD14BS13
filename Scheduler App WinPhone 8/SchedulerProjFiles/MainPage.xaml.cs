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
using LocalDatabaseSample.Model;

namespace sdkLocalDatabaseCS
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the page DataContext property to the ViewModel.
            this.DataContext = App.ViewModel;
        }

        private void newTaskAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewTaskPage.xaml", UriKind.Relative));
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

                App.ViewModel.DeleteToDoItem(toDoForDelete);
            }

            // Put the focus back to the main page.
            this.Focus();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Save changes to the database.
            App.ViewModel.SaveToDB();
        }

      
        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Cast the parameter as a textBlock.
            var textBlock = sender as TextBlock;

            if (textBlock != null)
            {
                // Get a handle for the to-do item bound to the textBlock
                To_Do_Item toDoForEdit = textBlock.DataContext as To_Do_Item;
                if (!string.IsNullOrEmpty(toDoForEdit.Password))
                {

                }
                NavigationService.Navigate(new Uri("/NewTaskPage.xaml?selectedItem=" + 
 (toDoForEdit.ToDoItemId.ToString()), UriKind.Relative));
             
            }

            //// Put the focus back to the main page.
            //this.Focus();
        }
    }
}
