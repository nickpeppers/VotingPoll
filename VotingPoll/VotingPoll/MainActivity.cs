using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;

namespace VotingPoll
{
	[Activity (Label = "VotingPoll", MainLauncher = true)]
	public class MainActivity : Activity
	{
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.MainLayout);

			var viewPollButton = FindViewById<Button> (Resource.Id.ViewPollsButton);
            var createPollButton = FindViewById<Button> (Resource.Id.CreatePollButton);

            viewPollButton.Click += (sender, e) => 
            {
                StartActivity(typeof(ViewPollsActivity));
            };

            createPollButton.Click += (sender, e) => 
            {
                StartActivity(typeof(CreatePollActivity));
            };
		}
	}
}


