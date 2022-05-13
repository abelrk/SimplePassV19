using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimplePassV19
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AuthButton_Clicked(object sender, EventArgs e)
        {
            bool supported = await Plugin.Fingerprint.CrossFingerprint.Current.IsAvailableAsync(true);
            if (supported)
            {
                AuthenticationRequestConfiguration conf =
                    new AuthenticationRequestConfiguration("Fingerprint Authentication", "Ready to scan your fingerprint.");
                var result = await CrossFingerprint.Current.AuthenticateAsync(conf);
                if (result.Authenticated)
                {
                    //await DisplayAlert("Authenticated!", "Valid fingerprint", "Okay");
                    await Navigation.PushAsync(new HomePage()); // Navigate to HomePage
                }
                else
                {
                    await DisplayAlert("Could Not Authenticate", "Biometric read cancelled.", "Okay");
                }
            }
            else
            {
                await DisplayAlert("not supported", "not supported", "Okay");
            }
        }



    }



}

