using System;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;


namespace Nyheder
{
    public partial class MainPage: ContentPage
    {
        public IList<Article> Articles { get; private set; }
        public MainPage()
        {
            InitializeComponent();

            //Articles = new List<Article>();

            string jsonFileName = "Nyheder.json.json";

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream(jsonFileName);
            using (var reader = new StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                //Converting JSON Array Objects into generic list    
                Articles = JsonConvert.DeserializeObject<Rootobject>(jsonString).articles;
            }

            BindingContext = this;

        }
    }
}

