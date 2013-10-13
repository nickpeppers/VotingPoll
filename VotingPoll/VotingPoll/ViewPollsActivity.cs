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
        Poll[] polls;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            polls = new Poll[] { new Poll { Question = "Whats your favorite color?" }, new Poll { Question = "Whats your favorite day of the week" } };
            ListAdapter = new ArrayAdapter<Poll>(this, Android.Resource.Layout.SimpleListItem1, polls);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var poll = polls[position];
            var viewCurrentPoll = new Intent(this, typeof(CurrentPollActivity));
            //viewCurrentPoll.put.PutExtra("CurrentPoll", poll);
            StartActivity(viewCurrentPoll);
        }
    }
}