using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;

namespace SchedulerApp.View
{
    public partial class AddNotification : PhoneApplicationPage
    {
        public AddNotification()
        {
            InitializeComponent();
        }

        private void ApplicationBarSaveButton_Click(object sender, EventArgs e)
        {
            String name = System.Guid.NewGuid().ToString();
            // Get the begin time for the notification by combining the DatePicker
            // value and the TimePicker value.
            DateTime date = (DateTime)beginDatePicker.Value;
            DateTime time = (DateTime)beginTimePicker.Value;
            DateTime beginTime = date + time.TimeOfDay;

            // Make sure that the begin time has not already passed.
            if (beginTime < DateTime.Now)
            {
                MessageBox.Show("the begin date must be in the future.");
                return;
            }

            // Get the expiration time for the notification.
            date = (DateTime)expirationDatePicker.Value;
            time = (DateTime)expirationTimePicker.Value;
            DateTime expirationTime = date + time.TimeOfDay;

            // Make sure that the expiration time is after the begin time.
            if (expirationTime < beginTime)
            {
                MessageBox.Show("expiration time must be after the begin time.");
                return;
            }

            // Determine which recurrence radio button is checked.
            RecurrenceInterval recurrence = RecurrenceInterval.None;
            if (dailyRadioButton.IsChecked == true)
            {
                recurrence = RecurrenceInterval.Daily;
            }
            else if (weeklyRadioButton.IsChecked == true)
            {
                recurrence = RecurrenceInterval.Weekly;
            }


            if (App.ViewModel.SetReminder(beginTime, expirationTime, name, recurrence, titleTextBox.Text))
            {
                // Navigate back to the main reminder list page.
                NavigationService.GoBack();
            }
        }
    }
}