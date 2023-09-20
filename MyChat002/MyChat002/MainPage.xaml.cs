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
        public event EventHandler StartButtonClicked;
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
        private void StartButton_Clicked(object sender, EventArgs e)
        {
            StartButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        public void HandleEditorTextChanged(object sender, string newText)
        {
            editor.Text = newText; // Передаем текст в поле editor
        }
    }
}
