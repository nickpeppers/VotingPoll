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
using Microsoft.WindowsAzure.MobileServices;

namespace VotingPoll
{
    public static class VotingService
    {
        // voting service class to get information from Azure server need url and app key to properly find
        public static readonly MobileServiceClient MobileService = new MobileServiceClient("wesbite url", "key");

        // used mainly to set the current poll for other activities to load
        public static Poll Poll { get; set; }
    }
}
