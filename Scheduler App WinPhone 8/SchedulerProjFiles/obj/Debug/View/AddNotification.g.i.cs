﻿#pragma checksum "G:\Integration\Local Database Sample_UI_ChangedV2_V2.1\C#\sdkLocalDatabaseCS\View\AddNotification.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A51CA56F0BC87B325D03B92C4FE71C36"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SchedulerApp.View {
    
    
    public partial class AddNotification : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.RadioButton reminderRadioButton;
        
        internal System.Windows.Controls.WatermarkTextBox titleTextBox;
        
        internal System.Windows.Controls.TextBlock beginTimeLabel;
        
        internal Microsoft.Phone.Controls.DatePicker beginDatePicker;
        
        internal Microsoft.Phone.Controls.TimePicker beginTimePicker;
        
        internal System.Windows.Controls.TextBlock expirationTimeLabel;
        
        internal Microsoft.Phone.Controls.DatePicker expirationDatePicker;
        
        internal Microsoft.Phone.Controls.TimePicker expirationTimePicker;
        
        internal System.Windows.Controls.RadioButton onceRadioButton;
        
        internal System.Windows.Controls.RadioButton weeklyRadioButton;
        
        internal System.Windows.Controls.RadioButton dailyRadioButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SchedulerApp;component/View/AddNotification.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.reminderRadioButton = ((System.Windows.Controls.RadioButton)(this.FindName("reminderRadioButton")));
            this.titleTextBox = ((System.Windows.Controls.WatermarkTextBox)(this.FindName("titleTextBox")));
            this.beginTimeLabel = ((System.Windows.Controls.TextBlock)(this.FindName("beginTimeLabel")));
            this.beginDatePicker = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("beginDatePicker")));
            this.beginTimePicker = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("beginTimePicker")));
            this.expirationTimeLabel = ((System.Windows.Controls.TextBlock)(this.FindName("expirationTimeLabel")));
            this.expirationDatePicker = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("expirationDatePicker")));
            this.expirationTimePicker = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("expirationTimePicker")));
            this.onceRadioButton = ((System.Windows.Controls.RadioButton)(this.FindName("onceRadioButton")));
            this.weeklyRadioButton = ((System.Windows.Controls.RadioButton)(this.FindName("weeklyRadioButton")));
            this.dailyRadioButton = ((System.Windows.Controls.RadioButton)(this.FindName("dailyRadioButton")));
        }
    }
}

