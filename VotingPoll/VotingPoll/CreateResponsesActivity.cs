using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Text;
using Android.Widget;

namespace VotingPoll
{
    [Activity (Label = "CreateResponsesActivity")]			
    public class CreateResponsesActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreateResponsesLayout);

            var responses = FindViewById<LinearLayout>(Resource.Id.ResponsesLinearLayout);
            var questionTitle = FindViewById<TextView>(Resource.Id.QuestionText);
            var createPollButton = FindViewById<Button>(Resource.Id.CreatePollButton);
            var response1 = FindViewById<EditText>(Resource.Id.Response1);
            var response2 = FindViewById<EditText>(Resource.Id.Response2);
            var response3 = FindViewById<EditText>(Resource.Id.Response3);
            var response4 = FindViewById<EditText>(Resource.Id.Response4);
            var question = Intent.GetStringExtra("Question");
            var numberOfResponses = Intent.GetIntExtra("NumberOfResponses", 2);

            questionTitle.Text = question;

            switch (numberOfResponses)
            {
                case 2:
                {
                    response1.Visibility = ViewStates.Visible;
                    response2.Visibility = ViewStates.Visible;
                    break;
                }
                case 3:
                {
                    response1.Visibility = ViewStates.Visible;
                    response2.Visibility = ViewStates.Visible;
                    response3.Visibility = ViewStates.Visible;
                    break;
                }
                case 4:
                {
                    response1.Visibility = ViewStates.Visible;
                    response2.Visibility = ViewStates.Visible;
                    response3.Visibility = ViewStates.Visible;
                    response4.Visibility = ViewStates.Visible;
                    break;
                }
            }

            var missingResponseDialog = new AlertDialog.Builder(this).SetTitle("Sorry!").SetMessage("You must enter a response in each field.").SetPositiveButton("Okay", (sender, e) =>
            {

            }).Create();
        }
    }
}

