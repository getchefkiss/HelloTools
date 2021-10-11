using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;

namespace HoloSuite.source.features
{
    public sealed partial class Fake_Info : Page
    {
        public Random rand = new Random();
        private string name;
        private int zip = 1476;
        private string adress;
        private string city;
        private string json;

        public Fake_Info()
        {
            this.InitializeComponent();

            GenerateName();
            GenerateAdress();
            GenerateCity();

            SetData();

            GenerateJSON();
        }

        private void Regenerate_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            GenerateName();
            GenerateAdress();
            GenerateCity();

            SetData();

            GenerateJSON();
        }

        private void GenerateName()
        {
            string[] names = { "Liam", "Olivia", "Noah", "Emma", "Oliver", "Ava", "Elijah", "Charlotte" };

            name = names[rand.Next(0, names.Length)];
        }
        private void GenerateAdress()
        {
            int buildingNumber = rand.Next(1, 100);
            string[] streetNames = { "Neshagi", "Hofsvallagata", "Einimelur", "Ægisíða", "Faxaskjól", "Laugavegur", "Grettisgata", "Njálsgata", "Bergþórugata" };
            string[] streetTypes = { "Alley", "Street", "Avenue", "Boulevard", "Circle", "Culdesac", "Drive", "Lane", "Loop", "Place", "Plaza", "Way" };

            adress = $"{buildingNumber} {streetNames[rand.Next(0, streetNames.Length)]} {streetTypes[rand.Next(0, streetTypes.Length)]}";
        }
        private void GenerateCity()
        {
            string[] citys = { "Reykjavik", "Kópavogur", "Hafnarfjörður", "Reykjanesbær", "Akureyri", "Garðabær", "Mosfellsbær", "Árborg", "Akranes", "Fjarðabyggð" };

            city = citys[rand.Next(0, citys.Length)];
        }
        private void GenerateJSON()
        {
            json = "{\n" +
                   $"   \"name\": \"{PersonName.Text}\",\n" +
                   $"   \"email\": \"{Email.Text}\",\n" +
                   $"   \"username\": \"{Username.Text}\",\n" +
                   $"   \"password\": \"{Password.Text}\",\n" +
                   $"   \"phone\": \"{Phone.Text}\",\n" +
                   $"   \"company\": \"{Company.Text}\",\n" +
                   $"   \"zip\": \"{Zip.Text},\"\n" +
                   $"   \"adress\": \"{Adress.Text}\",\n" +
                   $"   \"date\": \"{Date.Text}\",\n" +
                   $"   \"city\": \"{City.Text}\",\n" +
                   "}";
            JSON.Text = json;
        }

        private void SetData()
        {
            PersonName.Text = name;
            Email.Text = $"{name.ToLower()}.domain.com";
            Username.Text = $"{name.ToLower()}124";
            Password.Text = $"{name.ToLower()}849";
            Phone.Text = "+0 (123) 456 7890";
            Company.Text = "HoloSoftware";
            Zip.Text = zip.ToString();
            Adress.Text = adress;
            Date.Text = DateTime.Now.ToString();
            City.Text = city;
        }

        private void Clopy_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(json);
            Clipboard.SetContent(dataPackage);
        }
    }
}
