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
    // Main screen with two buttons one that take you to View Polls in database and the other takes you to created a poll
	[Activity (Label = "Voting Poll", MainLauncher = true)]
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


