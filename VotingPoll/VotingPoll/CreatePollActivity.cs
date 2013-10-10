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
    [Activity (Label = "CreatePollActivity")]			
    public class CreatePollActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreatePollActivityLayout);

            var questionEditText = FindViewById<EditText>(Resource.Id.QuestionEditText);
            var choicesEditText = FindViewById<EditText>(Resource.Id.ChoicesEditText);
            var createResponseButton = FindViewById<Button>(Resource.Id.CreateChoicesButton);

            createResponseButton.Click += (sender, e) => 
            {

            };
        }
    }
}

