using Android.App;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.Media.MediaPlayer;
using static Android.Views.View;

namespace AudioFilMobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    { 
        public ImageButton btn_play, btn_stop;
        public ProgressBar progressBar;
        public MediaPlayer mediaPlayer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            btn_play = FindViewById<ImageButton>(Resource.Id.btn_play);
            btn_play.Click += (s, e) =>
            {
                mediaPlayer = new MediaPlayer();
                new MP3Play(this).Execute("http://poznan7.radio.pionier.net.pl:8000/tuba9-1.mp3");
            };

            btn_stop = FindViewById<ImageButton>(Resource.Id.btn_stop);
            btn_stop.Click += (s, e) =>
            {
                mediaPlayer.Stop();
                mediaPlayer = null;
            };
        }
    }
}