using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
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
		}


	}
}


