using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;

namespace MyChat002
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private async void OnSpeechButton_Clicked(object sender, EventArgs e)
        {
            string speech = editor.Text;
            await TextToSpeech.SpeakAsync(speech);
            //await DisplayAlert("Внимание!", $"Нажата клавиша{(sender as Xamarin.Forms.Button).Text}", "Ok");
        }
        private async void OnEditorCompleted(object sender, EventArgs e)
        {
            //var speech = editor.Text;
            //await TextToSpeech.SpeakAsync(speech);
        }
        private async void OnRecognitionButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Внимание!", $"Нажата клавиша{(sender as Xamarin.Forms.Button).Text}", "Ok");
        }
    }
}
