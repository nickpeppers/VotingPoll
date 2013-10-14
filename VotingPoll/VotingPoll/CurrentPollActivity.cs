using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VotingPoll
{
    [Activity(Label = "My Activity")]
    public class CurrentPollActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CurrentPollLayout);
          
            var viewChartButton = FindViewById<Button>(Resource.Id.ViewChartButton);
            var submitResponsesButton = FindViewById<Button>(Resource.Id.SubmitResponsesButton);
            var question = FindViewById<TextView>(Resource.Id.CurrentPollQuestion);
            var choice1Text = FindViewById<TextView>(Resource.Id.Choice1);
            var choice2Text = FindViewById<TextView>(Resource.Id.Choice2);
            var choice3Text = FindViewById<TextView>(Resource.Id.Choice3);
            var choice4Text = FindViewById<TextView>(Resource.Id.Choice4);
            var choice1Edit = FindViewById<EditText>(Resource.Id.Choice1EditText);
            var choice2Edit = FindViewById<EditText>(Resource.Id.Choice2EditText);
            var choice3Edit = FindViewById<EditText>(Resource.Id.Choice3EditText);
            var choice4Edit = FindViewById<EditText>(Resource.Id.Choice4EditText);

            viewChartButton.Click += (sender, e) => 
            {
                var viewChartIntent = new Intent(this, typeof(ViewChartActivity));
                StartActivity(viewChartIntent);
            };

            submitResponsesButton.Click += (sender, e) => 
            {

            };
        }
    }
}