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
            ShowPersons();
        }
        
        async void ShowPersons()
        {
            var jsonFromFile = await ReadFileAsync(path);
            if (!string.IsNullOrEmpty(jsonFromFile))
            {
                people = JsonConvert.DeserializeObject<List<Person>>(jsonFromFile);
                PeopleListView.ItemsSource = people;
            }
        }

        string getDataDirectory()
        {
            return FileSystem.AppDataDirectory;
        }

        async Task<string> ReadFileAsync(string path)
        {
            using (var stream = File.Open(path, FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        async void WriteFileAsync(string path, string content)
        {
            using (var stream = File.Open(path, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync(content);
                }
            }
        }

        void AddPersonClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PersonNameLabel.Text))
            {
                Person newPerson = new Person
                {
                    Name = PersonNameLabel.Text
                };
                people.Add(newPerson);
                var peopleJson = JsonConvert.SerializeObject(people);
                WriteFileAsync(path, peopleJson);

                ShowPersons();
            }
        }
    }
}