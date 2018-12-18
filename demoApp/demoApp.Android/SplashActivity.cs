using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace E_WELL.Droid
{
    [Activity(Label = "E-WELL",Theme = "@style/Theme.AppCompat.NoActionBar",MainLauncher =true,NoHistory =true)]
    public class SplashActivity : Activity, Animation.IAnimationListener
    {
        public void OnAnimationEnd(Animation animation)
        {
            Intent intent = new Intent(this,typeof(MainActivity));
            StartActivity(intent);
        }

        public void OnAnimationRepeat(Animation animation)
        {
            
        }

        public void OnAnimationStart(Animation animation)
        {
            
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ImageView image = new ImageView(this);
            image.SetImageResource(Resource.Drawable.icon);
            SetContentView(image);
            var animation = new ScaleAnimation(0.1f,0.5f,0.1f,0.5f,Dimension.RelativeToSelf,0.5f,Dimension.RelativeToSelf,0.5f);
            animation.SetAnimationListener(this);
            animation.FillAfter = true;
            animation.Duration = 2000;
            image.StartAnimation(animation);
        }
    }
}