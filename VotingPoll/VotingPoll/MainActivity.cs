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

		public static MobileServiceClient MobileService = new MobileServiceClient
		(
			"https://csintermediateproject.azure-mobile.net/",
			"zeBmdSnLPMjmgYyBgucUibIGUkwGER72"
		);

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			var button1 = FindViewById<Button> (Resource.Id.myButton);
            var button2 = FindViewById<Button> (Resource.Id.button1);
            var text = FindViewById<TextView>(Resource.Id.textView1);

			var poll1 = new Poll 
			{
				Question = "How much would could a woodchuck chuck?",
				Choices = new string[] {"WoodChuck's can't chuck wood", "2", "10000"},
				Votes = new int[] {2,5,10}
			};

			button1.Click += (sender, e) => 
			{
				MobileService.GetTable<Poll>().InsertAsync(poll1).ContinueWith (t => { });
			};
		}
	}
}


