using Android.OS;
using Android.Views;
using System;

namespace AudioFilMobile
{
    public class MP3Play : AsyncTask<string, string, string>
    {
        private MainActivity mainActivity;

        public MP3Play(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }

        protected override void OnPreExecute()
        {
            mainActivity.progressBar.Visibility = ViewStates.Visible;
            base.OnPreExecute();
        }

        protected override string RunInBackground(params string[] @params)
        {
            try
            {
                mainActivity.mediaPlayer.SetDataSource(@params[0]);
                mainActivity.mediaPlayer.Prepare();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }

        protected override void OnPostExecute(string result)
        {
            if (!mainActivity.mediaPlayer.IsPlaying)
            {
                mainActivity.mediaPlayer.Start();
            }
            mainActivity.progressBar.Visibility = ViewStates.Invisible;
        }
    }
}