using Gopas.XamIntro.Course._7Database.SQLite.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._7Database.SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLitePage : ContentPage
    {
        
        public SQLitePage()
        {
            InitializeComponent();
            ShowItems();
        }

        static Database databaseWrapper;

        public static Database DatabaseWrapper
        {
            get
            {
                if (databaseWrapper == null)
                {
                    databaseWrapper = new Database(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLite.db3"));
                }
                return databaseWrapper;
            }
        }

        async void ShowItems()
        {
            var people = await DatabaseWrapper.GetItems();
            if (people == null || people.Count == 0) return;
            ItemsListView.ItemsSource = people;
        }
        async void Add_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameEntry.Text)) return;
            Item item = new Item()
            {
                Name = NameEntry.Text
            };
            await databaseWrapper.InsertOrUpdateItem(item);
            ShowItems();
        }
    }
}