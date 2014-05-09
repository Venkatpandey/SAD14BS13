using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Security.Cryptography;
using System.Text;

namespace SchedulerApp.Model
{

    public class To_Do_Data_Context : DataContext
    {
        // Pass the connection string to the base class.
        public To_Do_Data_Context(string connectionString)
            : base(connectionString)
        { }

        // Make a table for the todo.
        public Table<To_Do_Item> Items;

        // make a table for categories.
        public Table<To_Do_Category> Categories;
    }

    [Table]
    public class To_Do_Item : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field : public property : database column.
        private int _toDoItemId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ToDoItemId
        {
            get { return _toDoItemId; }
            set
            {
                if (_toDoItemId != value)
                {
                    NotifyPropertyChanging("ToDoItemId");
                    _toDoItemId = value;
                    NotifyPropertyChanged("ToDoItemId");
                }
            }
        }

        // Define item name: private field : public property : database column.
        private string _item_Name;

        [Column]
        public string ItemName
        {
            get { return _item_Name; }
            set
            {
                if (_item_Name != value)
                {
                    NotifyPropertyChanging("ItemName");
                    _item_Name = value;
                    NotifyPropertyChanged("ItemName");
                }
            }
        }

        // Define completion value: private field : public property : database column.
        private bool _isComplete;

        [Column]
        public bool IsComplete
        {
            get { return _isComplete; }
            set
            {
                if (_isComplete != value)
                {
                    NotifyPropertyChanging("IsComplete");
                    _isComplete = value;
                    NotifyPropertyChanged("IsComplete");
                }
            }
        }

        // column update
        [Column(IsVersion = true)]
        private Binary _version;


        // column ID
        [Column]
        internal int _categoryId;

        // Entity reference, to the To_Do_Category database table
        private EntityRef<To_Do_Category> _category;

        // to describe the relationship between this key and that database table
        [Association(Storage = "_category", ThisKey = "_categoryId", OtherKey = "Id", IsForeignKey = true)]
        public To_Do_Category Category
        {
            get { return _category.Entity; }
            set
            {
                NotifyPropertyChanging("Category");
                _category.Entity = value;

                if (value != null)
                {
                    _categoryId = value.Id;
                }

                NotifyPropertyChanging("Category");
            }
        }

        private string _Description;
        [Column]
        public string Description
        {
            get { return _Description; }
            set
            {
                NotifyPropertyChanging("Description");
                if (!string.IsNullOrEmpty(value))
                {
                    _Description = value;
                }
                NotifyPropertyChanged("Description");
            }
        }

        [Column]
        public string Password
        {
            get { return _Password; }
            set
            {
                NotifyPropertyChanging("Password");
                if (!string.IsNullOrEmpty(value))
                {

                    _Password = HashSHA1(value); ;
                }
                NotifyPropertyChanging("Password");
            }
        }

        /// <summary>
        /// hash the password and then save to the db.
        /// </summary>
        /// <param name="value">the original password string</param>
        /// <returns>returns a 40 alphanumeric value of the given password</returns>
        public static  string HashSHA1(string value)
        {
            //var sha1 = System.Security.Cryptography.HMACSHA1;
            System.Security.Cryptography.HMACSHA1 sha1 = new HMACSHA1();
            var inputBytes = Encoding.Unicode.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;
        private string _Password;

        // notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion


        
    }


    [Table]
    public class To_Do_Category : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field : public property : database column.
        private int _id;

        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id
        {
            get { return _id; }
            set
            {
                NotifyPropertyChanging("Id");
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        // Define category name: private field : public property : database column.
        private string _name;

        [Column]
        public string Name
        {
            get { return _name; }
            set
            {
                NotifyPropertyChanging("Name");
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        // Version column 
        [Column(IsVersion = true)]
        private Binary _version;

        //  entity set for the collection side of the relationship.
        private EntitySet<To_Do_Item> _todos;

        [Association(Storage = "_todos", OtherKey = "_categoryId", ThisKey = "Id")]
        public EntitySet<To_Do_Item> ToDos
        {
            get { return this._todos; }
            set { this._todos.Assign(value); }
        }


        // Assign handlers 
        public To_Do_Category()
        {
            _todos = new EntitySet<To_Do_Item>(
                new Action<To_Do_Item>(this.attach_ToDo),
                new Action<To_Do_Item>(this.detach_ToDo)
                );
        }

        //  add operation
        private void attach_ToDo(To_Do_Item toDo)
        {
            NotifyPropertyChanging("ToDoItem");
            toDo.Category = this;
        }

        //  remove operation
        private void detach_ToDo(To_Do_Item toDo)
        {
            NotifyPropertyChanging("ToDoItem");
            toDo.Category = null;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }


}
