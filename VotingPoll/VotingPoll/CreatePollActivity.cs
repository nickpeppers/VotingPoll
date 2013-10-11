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

            var notIntDialog = new AlertDialog.Builder (this).SetTitle("Sorry!").SetMessage("The number you enter must be greater than 1 and at most 4.").SetPositiveButton("Okay",(sender, e) => 
            {
               
            }).Create();

            var noQuestionDialog = new AlertDialog.Builder (this).SetTitle("Sorry!").SetMessage("You must enter a poll question.").SetPositiveButton("Okay",(sender, e) => 
            {

            }).Create();

            createResponseButton.Click += (sender, e) => 
            {
                int num;
                if(int.TryParse(choicesEditText.Text, out num))
                {
                    if(num > 1 & num < 5 & !string.IsNullOrEmpty(questionEditText.Text))
                    {
                        var createResponses = new Intent (this, typeof(CreateResponsesActivity));
                        createResponses.PutExtra("Question", questionEditText.Text);
                        createResponses.PutExtra("NumberOfResponses", num);
                        StartActivity(createResponses);
                    }

                }
                else
                {
                    if(string.IsNullOrEmpty(questionEditText.Text))
                    {
                        noQuestionDialog.Show();
                    }
                    else
                    {
                        notIntDialog.Show();
                    }
                }
            };
        }
    }
}

