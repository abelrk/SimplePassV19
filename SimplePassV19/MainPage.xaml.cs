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


        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool supported = await Plugin.Fingerprint.CrossFingerprint.Current.IsAvailableAsync(true);
            if (supported)
            {
                AuthenticationRequestConfiguration conf =
                    new AuthenticationRequestConfiguration("Access our account", "Access your account");
                var result = await CrossFingerprint.Current.AuthenticateAsync(conf);
                if (result.Authenticated)
                {
                    await DisplayAlert("Success!", "Success", "ok");

                }
                else
                {
                    await DisplayAlert("Sorry", "Sorry", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Sorry", "Sorry", "Ok");
            }
        }



    }



}

