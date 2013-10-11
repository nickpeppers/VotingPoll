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
            var question = Intent.GetStringExtra("Question");
            var numberOfResponses = Intent.GetIntExtra("NumberOfResponses", 2);

            questionTitle.Text = question;

            for (int i = 0; i < numberOfResponses; i++)
            {
                var editText = new EditText(this);
                editText.InputType = InputTypes.TextFlagMultiLine;
                responses.AddView(editText);
            }
        }
    }
}

