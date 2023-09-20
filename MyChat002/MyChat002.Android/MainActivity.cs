using System;

using Android.App;
using Android.Content.PM;
using Android.Content;
using Android.Runtime;
using Android.OS;
using Android.Speech;
using Android.Widget;

namespace MyChat002.Droid
{
    [Activity(Label = "MyChat002", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private readonly int VOICE_RECOGNITION_REQUEST = 1234;
        private TextView resultTextView;
        private Button startButton;

        private MainPage mainPage;
        public event EventHandler<string> EditorTextChanged; // Событие с аргументом string

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var app = new App();
            var mainPage = app.MainPage as MainPage;
            EditorTextChanged += mainPage.HandleEditorTextChanged; // Подписываемся на событие

            mainPage = app.MainPage as MainPage; // Приводим MainPage к типу MainPage
            mainPage.StartButtonClicked += StartButton_Click;

            LoadApplication(app);

        }
        private void StartButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            intent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            intent.PutExtra(RecognizerIntent.ExtraPrompt, "Speak something...");

            StartActivityForResult(intent, VOICE_RECOGNITION_REQUEST);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == VOICE_RECOGNITION_REQUEST && resultCode == Result.Ok)
            {
                var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                if (matches.Count != 0)
                {
                    string text = matches[0];
                    EditorTextChanged?.Invoke(this, text);
                }
            }

            base.OnActivityResult(requestCode, resultCode, data);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}