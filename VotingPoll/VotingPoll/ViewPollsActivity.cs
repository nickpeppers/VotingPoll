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
    public class ViewPollsActivity : ListActivity
    {
        List<Poll> polls;

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var progressDialog = new ProgressDialog(this);
            progressDialog.Show();
            {
                try
                {
                    polls = await VotingService.MobileService.GetTable<Poll>().ToListAsync();
                }
                catch (Exception exc)
                {
                    var errorDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("Something went wrong " + exc.ToString()).SetPositiveButton("Okay", (sender1, e1) =>
                    {

                    }).Create();
                    errorDialog.Show();
                }
            };
            progressDialog.Dismiss();

            ListAdapter = new ArrayAdapter<Poll>(this, Android.Resource.Layout.SimpleListItem1, polls);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var poll = polls[position];
            var viewCurrentPoll = new Intent(this, typeof(CurrentPollActivity));
            VotingService.Poll = poll;
            StartActivity(viewCurrentPoll);
        }
    }
}