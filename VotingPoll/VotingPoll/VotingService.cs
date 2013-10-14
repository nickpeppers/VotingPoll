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
        public static readonly MobileServiceClient MobileService = new MobileServiceClient("https://csintermediateproject.azure-mobile.net/", "zeBmdSnLPMjmgYyBgucUibIGUkwGER72");

        public static Poll Poll { get; set; }
    }
}