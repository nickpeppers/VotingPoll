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
using Android.Content.PM;

namespace VotingPoll
{
    [Activity (Label = "CreateResponsesActivity", LaunchMode = LaunchMode.SingleInstance)]			
    public class CreateResponsesActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreateResponsesLayout);

            var responses = FindViewById<LinearLayout>(Resource.Id.ResponsesLinearLayout);
            var questionTitle = FindViewById<TextView>(Resource.Id.QuestionText);
            var createPollButton = FindViewById<Button>(Resource.Id.CreateResponsesCreatePollButton);
            var response1 = FindViewById<EditText>(Resource.Id.Response1);
            var response2 = FindViewById<EditText>(Resource.Id.Response2);
            var response3 = FindViewById<EditText>(Resource.Id.Response3);
            var response4 = FindViewById<EditText>(Resource.Id.Response4);
            var question = Intent.GetStringExtra("Question");
            var numberOfResponses = Intent.GetIntExtra("NumberOfResponses", 2);

            questionTitle.Text = question;

            createPollButton.Click += async (sender, e) =>
            {
                var progressDialog = new ProgressDialog(this);
                progressDialog.Show();

                string choices = "";
                string votes = "";
                if (numberOfResponses == 2)
                {
                    choices = response1.Text + "," + response2.Text;
                    votes = "0,0";
                }
                if (numberOfResponses == 3)
                {
                    choices = response1.Text + "," + response2.Text + "," + response3.Text;
                    votes = "0,0,0";
                }
                if (numberOfResponses == 4)
                {
                    choices = response1.Text + "," + response2.Text  + "," + response3.Text + "," + response4.Text;
                    votes = "0,0,0,0";
                }

                try
                {
                    await VotingService.MobileService.GetTable<Poll>().InsertAsync(new Poll
                    {
                        Question = questionTitle.Text,
                        Choices = choices,
                        Votes = votes,
                    });

                }
                catch (Exception exc)
                {
                    var errorDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("Something went wrong " + exc.ToString()).SetPositiveButton("Okay", (sender1, e1) =>
                    {

                    }).Create();
                    errorDialog.Show();
                }
                progressDialog.Hide();
                Finish();
            };

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

