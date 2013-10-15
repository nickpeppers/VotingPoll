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
using BarChart;

namespace VotingPoll
{
    [Activity(Label = "ViewChartActivity")]			
    public class ViewChartActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // split the number of votes for the bar graph
            string[]  split = VotingService.Poll.Votes.Split(',');
            int[] data = split.Select(x => int.Parse(x)).ToArray();
            split = VotingService.Poll.Choices.Split(',');

            // creates the chart
            var chart = new BarChartView(this)
            {
                ItemsSource = Array.ConvertAll(data, v => new BarModel { Value = v})
            };

            // adds the chart to the view to be shown
            AddContentView(chart, new ViewGroup.LayoutParams(
              ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent));
        }
    }
}

