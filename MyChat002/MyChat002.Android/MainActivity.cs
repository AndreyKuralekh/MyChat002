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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            SetContentView(Resource.Layout.Main);

            resultTextView = FindViewById<TextView>(Resource.Id.resultTextView);
            startButton = FindViewById<Button>(Resource.Id.startButton);
            startButton.Click += StartButton_Click;
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
                    resultTextView.Text = "Recognized: " + text;
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