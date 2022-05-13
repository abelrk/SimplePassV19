using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePassV19
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        //public ObservableCollection<string> Items { get; set; }
        //public MyPassWriter Writer { get; set; }
        public HomePage()
        {
            InitializeComponent();

            /*
            Writer = new MyPassWriter("/storage/emulated/0/Download/data.csv");
            Writer.ReadPass();
            Items = new ObservableCollection<string>();

            foreach (var profile in Writer.Profiles)
            {
                Items.Add(profile.Account);
            }

            MyListView.ItemsSource = Items;
            */

            // Open the stream and read it back.
            //using (FileStream fs = File.OpenRead("/storage/emulated/0/Download/data.csv"))
            //{
            //    byte[] b = new byte[1024];
            //    UTF8Encoding temp = new UTF8Encoding(true);

            //    while (fs.Read(b, 0, b.Length) > 0)
            //    {
            //        Console.WriteLine(temp.GetString(b));
            //    }
            //}
            

            // 
           // StreamReader sr;
           // string flavor = null;
           // string path = "/storage/emulated/0/Download/accounts.csv";
           // File.SetAttributes(path, FileAttributes.Normal);

           //sr = File.OpenText(path);
           // while (sr.Peek() != -1)
           // {
           //     flavor = sr.ReadLine();

           //     Console.WriteLine(flavor);
           // }
           // sr.Close();

            //StreamWriter sw;
            //int i;
            //sw = File.CreateText("accounts.csv");
            //if()



        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAccount());
        }
                
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
