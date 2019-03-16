using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._7Database
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JsonDatabasePage : ContentPage
    {
        List<Person> people = new List<Person>();
        string fileName = "jsonFile.json";
        string path = null;
        public JsonDatabasePage()
        {
            InitializeComponent();
            path = Path.Combine(getDataDirectory(), fileName);
        }


        async Task ShowPersons()
        {
            var jsonFromFile = await readFileAsync(path);
            if (!string.IsNullOrEmpty(jsonFromFile))
            {
                people = JsonConvert.DeserializeObject<List<Person>>(jsonFromFile);
                PeopleListView.ItemsSource = people;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ShowPersons();
        }

        string getDataDirectory()
        {
            return FileSystem.AppDataDirectory;
        }

        async Task<string> readFileAsync(string path)
        {
            if (!File.Exists(path)) return null ;

            using (var stream = File.Open(path, FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        async Task writeFileAsync(string path, string content)
        {
            using (var stream = File.Open(path, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync(content);
                }
            }
        }

        async void addPersonClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PersonNameLabel.Text))
            {
                Person newPerson = new Person
                {
                    Name = PersonNameLabel.Text
                };
                people.Add(newPerson);
                var peopleJson = JsonConvert.SerializeObject(people);
                await writeFileAsync(path, peopleJson);

                await ShowPersons();
            }
        }
    }
}