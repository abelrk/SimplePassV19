using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePassV19
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }
        public MyPassWriter Writer { get; set; }
        public HomePage()
        {
            InitializeComponent();

            Writer = new MyPassWriter("accounts.csv");
            Writer.ReadPass();
            Items = new ObservableCollection<string>();

            foreach (var profile in Writer.Profiles)
            {
                Items.Add(profile.Account);
            }

            MyListView.ItemsSource = Items;
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
