using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VotingPoll
{
    [Activity(Label = "CreatePollActivity", LaunchMode = LaunchMode.SingleInstance)]			
    public class CreatePollActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreatePollActivityLayout);

            var questionEditText = FindViewById<EditText>(Resource.Id.QuestionEditText);
            var choicesEditText = FindViewById<EditText>(Resource.Id.ChoicesEditText);
            var createResponseButton = FindViewById<Button>(Resource.Id.CreateChoicesButton);

            // shows if the number entered is acceptable or not
            var notIntDialog = new AlertDialog.Builder (this).SetTitle("Sorry!").SetMessage("The number you enter must be greater than 1 and at most 4.").SetPositiveButton("Okay",(sender, e) => 
            {
               
            }).Create();

            // shows if the question field is left blank
            var noQuestionDialog = new AlertDialog.Builder (this).SetTitle("Sorry!").SetMessage("You must enter a poll question.").SetPositiveButton("Okay",(sender, e) => 
            {

            }).Create();

            createResponseButton.Click += (sender, e) => 
            {
                //checks to make sure number of poll choices is at least one and at most 5 then takes you to Create the choice screen
                int num;
                if(int.TryParse(choicesEditText.Text, out num))
                {
                    if(num > 1 & num < 5 & !string.IsNullOrEmpty(questionEditText.Text))
                    {
                        var createResponses = new Intent (this, typeof(CreateResponsesActivity));
                        createResponses.PutExtra("Question", questionEditText.Text);
                        createResponses.PutExtra("NumberOfResponses", num);
                        StartActivity(createResponses);
                        Finish();
                    }
                }
                else
                {
                    // shows popup saying you left question or number of choices field blank
                    if(string.IsNullOrEmpty(questionEditText.Text))
                    {
                        noQuestionDialog.Show();
                    }
                    else if( string.IsNullOrEmpty(choicesEditText.Text))
                    {
                        notIntDialog.Show();
                    }
                }
            };
        }
    }
}

