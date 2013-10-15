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

            // splits the poll votes into corresponding numbers to be displayed based off of the number of choices
            string[] split = VotingService.Poll.Votes.Split(',');
            switch (split.Length)
            {
                case 2:
                {
                    choice1Edit.Text = split[0];
                    choice2Edit.Text = split[1];
                    choice3Edit.Visibility = ViewStates.Gone;
                    choice4Edit.Visibility = ViewStates.Gone;
                    break;
                }
                case 3:
                {
                    choice1Edit.Text = split[0];
                    choice2Edit.Text = split[1];
                    choice3Edit.Text = split[2];
                    choice4Edit.Visibility = ViewStates.Gone;
                    break;
                }
                case 4:
                {
                    choice1Edit.Text = split[0];
                    choice2Edit.Text = split[1];
                    choice3Edit.Text = split[2];
                    choice4Edit.Text = split[3];
                    break;
                }
            }
            // splits the choices of the poll into the corresponding text choices
            split = VotingService.Poll.Choices.Split(',');
            switch (split.Length)
            {
                case 2:
                    {
                        choice1Text.Text = split[0];
                        choice2Text.Text = split[1];
                        choice3Text.Visibility = ViewStates.Gone;
                        choice4Text.Visibility = ViewStates.Gone;
                        break;
                    }
                case 3:
                    {
                        choice1Text.Text = split[0];
                        choice2Text.Text = split[1];
                        choice3Text.Text = split[2];
                        choice4Text.Visibility = ViewStates.Gone;
                        break;
                    }
                case 4:
                    {
                        choice1Text.Text = split[0];
                        choice2Text.Text = split[1];
                        choice3Text.Text = split[2];
                        choice4Text.Text = split[3];
                        break;
                    }
            }

            // takes you to view a bar graph of the number of votes per choice
            viewChartButton.Click += (sender, e) => 
            {
                var viewChartIntent = new Intent(this, typeof(ViewChartActivity));
                StartActivity(viewChartIntent);
            };

            // submits the number of votes to the server
            submitResponsesButton.Click += async (sender, e) => 
            {
                switch (split.Length)
                {
                    case 2:
                    {
                        VotingService.Poll.Votes = choice1Edit.Text + "," + choice2Edit.Text;
                        break;
                    }
                    case 3:
                    {
                        VotingService.Poll.Votes = choice1Edit.Text + "," + choice2Edit.Text + "," + choice3Edit.Text;
                        break;
                    }
                    case 4:
                    {
                        VotingService.Poll.Votes = choice1Edit.Text + "," + choice2Edit.Text + "," + choice3Edit.Text + "," + choice4Edit.Text;
                        break;
                    }
                }

                // shows spinner while it trys updating ther database
                var progressDialog = new ProgressDialog(this);
                progressDialog.Show();
                
                try
                {
                    // updating the number of votes in the database
                    await VotingService.MobileService.GetTable<Poll>().UpdateAsync(VotingService.Poll);
                }
                catch (Exception exc)
                {
                    // shows an error if it fails
                    var errorDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("Something went wrong " + exc.ToString()).SetPositiveButton("Okay", (sender1, e1) =>
                    {

                    }).Create();
                    errorDialog.Show();
                }
                // hides spinner when done
                progressDialog.Hide();
            };
        }
    }
}