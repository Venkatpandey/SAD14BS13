
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Microsoft.Phone.Scheduler;


// Directive for the data model.
using SchedulerApp.Model;
using System;
using System.Windows;
using System.Windows.Navigation;


namespace SchedulerApp.ViewModel
{
    public class To_Do_ViewModel : INotifyPropertyChanged
    {
        
        //model class
        private To_Do_Data_Context toDo_DB;
        private ObservableCollection<To_Do_Item> _superlistItems;
        private ObservableCollection<To_Do_Item> _Personal_ToDo_Items;
        private ObservableCollection<To_Do_Item> _Office_ToDo_Items;
        private ObservableCollection<To_Do_Item> _Misc_ToDo_Items;
        private List<To_Do_Category> _categoriesList;

        // constructor
        public To_Do_ViewModel(string toDoDBConnectionString)
        {
            toDo_DB = new To_Do_Data_Context(toDoDBConnectionString);
        }

        // All to-do items, property .
        public ObservableCollection<To_Do_Item> superlistItems
        {
            get { return _superlistItems; }
            set
            {
                _superlistItems = value;
                NotifyPropertyChanged("superlistItems");
            }
        }

        // To-do items for Personal category,property.
        public ObservableCollection<To_Do_Item> PersonalToDoItems
        {
            get { return _Personal_ToDo_Items; }
            set
            {
                _Personal_ToDo_Items = value;
                NotifyPropertyChanged("PersonalToDoItems");
            }
        }

        // To-do items for Office category,property.
        public ObservableCollection<To_Do_Item> OfficeToDoItems
        {
            get { return _Office_ToDo_Items; }
            set
            {
                _Office_ToDo_Items = value;
                NotifyPropertyChanged("OfficeToDoItems");
            }
        }

        // To-do items for Misc,property.
        public ObservableCollection<To_Do_Item> MiscToDoItems
        {
            get { return _Misc_ToDo_Items; }
            set
            {
                _Misc_ToDo_Items = value;
                NotifyPropertyChanged("MiscToDoItems");
            }
        }

        // list of catagories present , next version added catagiries by the user , dynamically .
        public List<To_Do_Category> CategoriesList
        {
            get { return _categoriesList; }
            set
            {
                _categoriesList = value;
                NotifyPropertyChanged("CategoriesList");
            }
        }

        // saving to database to the database.
        public void SaveToDB()
        {
            toDo_DB.SubmitChanges();
        }

        // Query database and load the collections and list used by the pivot pages.
        public void LoadCollectionsFromDatabase()
        {

            // Specify the query for all to-do items in the database.
            var toDoItemsInDB = from To_Do_Item todo in toDo_DB.Items
                                select todo;

            // Query the database and load all to-do items.
            superlistItems = new ObservableCollection<To_Do_Item>(toDoItemsInDB);

            // Specify the query for all categories in the database.
            var toDoCategoriesInDB = from To_Do_Category category in toDo_DB.Categories
                                     select category;


            // Query the database and load all associated items to their respective collections.
            foreach (To_Do_Category category in toDoCategoriesInDB)
            {
                switch (category.Name)
                {
                    case "Personal":
                        PersonalToDoItems = new ObservableCollection<To_Do_Item>(category.ToDos);
                        break;
                    case "Office":
                        OfficeToDoItems = new ObservableCollection<To_Do_Item>(category.ToDos);
                        break;
                    case "Misc":
                        MiscToDoItems = new ObservableCollection<To_Do_Item>(category.ToDos);
                        break;
                    default:
                        break;
                }
            }

            // Load all items here .
            CategoriesList = toDo_DB.Categories.ToList();

        }

        // add the item both db and collection .
        public void AddToDoItem(To_Do_Item newToDoItem)
        {
            // Add item to the data context, of the linque class .
            toDo_DB.Items.InsertOnSubmit(newToDoItem);

            // Save changes to the database.
            toDo_DB.SubmitChanges();

            //collection of items of all the items in the app .
            superlistItems.Add(newToDoItem);

            // put the item to the approprite , catagory .
            switch (newToDoItem.Category.Name)
            {
                case "Personal":
                    PersonalToDoItems.Add(newToDoItem);
                    break;
                case "Office":
                    OfficeToDoItems.Add(newToDoItem);
                    break;
                case "Misc":
                    MiscToDoItems.Add(newToDoItem);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// delete an item .
        /// </summary>
        /// <param name="DeletableItem"> item that is to b deleted .</param>
        public void DeleteToDoItem(To_Do_Item DeletableItem)
        {
            if (DeletableItem != null)
            {
                // first do for all the 
                superlistItems.Remove(DeletableItem);

            // remove from the linque thing .
            toDo_DB.Items.DeleteOnSubmit(DeletableItem);

            // remove item catagory wise .
            switch (DeletableItem.Category.Name)
            {
                case "Personal":
                    PersonalToDoItems.Remove(DeletableItem);
                    break;
                case "Office":
                    OfficeToDoItems.Remove(DeletableItem);
                    break;
                case "Misc":
                    MiscToDoItems.Remove(DeletableItem);
                    break;
                default:
                    break;
            }

                // Save changes to the database.
                toDo_DB.SubmitChanges();
            }
        }

        public void DeleteToDoItem(string ItemName)
        {
            To_Do_Item TO_DO_Item = GetToDoItem(ItemName);
            DeleteToDoItem(TO_DO_Item);
        }

        public void DeleteToDoItem(string ItemName, To_Do_Category category)
        {
            To_Do_Item TO_DO_Item = GetToDoItem(ItemName, category);
            DeleteToDoItem(TO_DO_Item);
        }

        public To_Do_Item GetToDoItem(string ItemName)
        {
            
            foreach (To_Do_Item item in superlistItems)
            {
                if (item.ItemName == ItemName)
                {
                    return item;
                }
            }
            return null;
        }

        public To_Do_Item GetToDoItem(int ItemID)
        {

            foreach (To_Do_Item item in superlistItems)
            {
                if (item.ToDoItemId == ItemID)
                {
                    return item;
                }
            }
            return null;
        }

        public To_Do_Item GetToDoItem(string ItemName,To_Do_Category category)
        {

            foreach (To_Do_Item item in superlistItems)
            {
                if (item.ItemName == ItemName && item.Category==category)
                {
                    return item;
                }
            }
            return null;
        }

        public bool SetReminder(DateTime beginTime, DateTime expirationTime, string name, RecurrenceInterval recurrence, string TitleText)
        {
            try
            {
                Reminder reminder = new Reminder(name);
                reminder.Title = TitleText;

                reminder.BeginTime = beginTime;
                reminder.ExpirationTime = expirationTime;
                reminder.RecurrenceType = recurrence;
                //reminder.NavigationUri = navigationUri;

                // Register the reminder with the system.
                ScheduledActionService.Add(reminder);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            
            
        }

        public bool CheckPassword(string enteredPW , string ItemsPassword)
        {
            bool retVal;
            string EneredPassword_Hash =To_Do_Item.HashSHA1(enteredPW);
            String ItemsPassword_Hash = To_Do_Item.HashSHA1(ItemsPassword);
            if (!string.IsNullOrEmpty(EneredPassword_Hash) && !string.IsNullOrEmpty(ItemsPassword_Hash))
            {
                if (EneredPassword_Hash == ItemsPassword_Hash)
                {
                    retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }
            else
                retVal = false;

            return retVal;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
