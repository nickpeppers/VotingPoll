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

//			var poll1 = new Poll 
//			{
//				Question = "How much would could a woodchuck chuck?",
//				Choices = new string[] {"WoodChuck's can't chuck wood", "2", "10000"},
//				Votes = new int[] {2,5,10}
//			};
//
//			button1.Click += (sender, e) => 
//			{
//				MobileService.GetTable<Poll>().InsertAsync(poll1).ContinueWith (t => { });
//			};
		}
	}
}


