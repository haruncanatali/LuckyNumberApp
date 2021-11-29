using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace LuckyNumberApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button rollButton = null;
        private TextView resultTxt = null;
        private SeekBar intervalSeekBar = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Tanimla();
        }

        private void Tanimla()
        {
            rollButton = FindViewById<Button>(Resource.Id.hesaplaBtn);
            resultTxt = FindViewById<TextView>(Resource.Id.sansliSayiTxt);
            intervalSeekBar = FindViewById<SeekBar>(Resource.Id.aralikSeek);

            rollButton.Click += delegate
            {
                var sayi = (new Random()).Next(intervalSeekBar.Progress) + 1;
                resultTxt.Text = sayi.ToString();
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}