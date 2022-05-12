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


        private async void Button_ScanFingerPrint(object sender, EventArgs e)
        {
            bool supported = await Plugin.Fingerprint.CrossFingerprint.Current.IsAvailableAsync(true);
            if (supported)
            {
                AuthenticationRequestConfiguration conf =
                    new AuthenticationRequestConfiguration("Fingerprint Authentication", "Ready to scan your fingerprint.");
                var result = await CrossFingerprint.Current.AuthenticateAsync(conf);
                if (result.Authenticated)
                {
                    await DisplayAlert("Success!", "Fingerprint successfully authenticated.", "OK");

                }
                else
                {
                    await DisplayAlert("Sorry...", "There was an error. Please try again.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error...", "Your device either doesn't support or is not properly configured.", "OK");
            }
        }



    }



}

