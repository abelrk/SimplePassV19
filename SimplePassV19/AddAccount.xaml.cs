using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePassV19
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAccount : ContentPage
    {
        //string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        public MyPassWriter Writer { get; set; }
        public AddAccount()
        {
            InitializeComponent();
            Writer = new MyPassWriter("/storage/emulated/0/Download/accounts.csv");
        }

        // add another acccount item
        private async void AddAccount_Clicked(object sender, EventArgs e)
        {
            // save into csv file
            // update HomePage
            
            string account = accountType.Text;
            string username = userEntry.Text;
            string password = passwordEntry.Text;

            Writer.WritePass(account, username, password);
            //int numButtons = Writer.ReadPass();
     await DisplayAlert("TEST1", "In AddAccount.", "OK");// --------------------------TEST---------------------------------

            //update buttons
            foreach (var profile in Writer.Profiles)
            {
                Debug.WriteLine(profile.Account);
                //button update per profile
            }
    await DisplayAlert("TEST2", "In AddAccount.", "OK"); // --------------------------TEST---------------------------------
            await Navigation.PushAsync(new HomePage()); // Navigate to HomePage
        }
    }
}