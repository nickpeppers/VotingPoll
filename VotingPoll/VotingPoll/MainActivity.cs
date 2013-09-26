using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace VotingPoll
{
	[Activity (Label = "VotingPoll", MainLauncher = true)]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			var button1 = FindViewById<Button> (Resource.Id.myButton);
            var button2 = FindViewById<Button> (Resource.Id.button1);
            var text = FindViewById<TextView>(Resource.Id.textView1);

            Candidate candidate1 = new Candidate { FirstName = "Bill", LastName =  "Clinton", Votes = 0 };
            Candidate candidate2 = new Candidate { FirstName = "Chuck", LastName =  "Norris", Votes = 0 };
            string dbLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Resources);

            using (var conn= new SQLite.SQLiteConnection(dbLocation))
            {
                conn.CreateTable<Candidate>();
            }

			button1.Click += (sender, e) =>
            {
                using (var db = new SQLite.SQLiteConnection(dbLocation ))
                {
                    db.Insert(candidate1);
                    db.Insert(candidate2);
                }
			};

            button2.Click += (sender, e) => 
            {

            };
		}
	}
}


