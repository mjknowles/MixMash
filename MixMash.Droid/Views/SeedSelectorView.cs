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
using MvvmCross.Droid.Views;
using MixMash.Shared.BL.Authentication;
using Xamarin.Auth;

namespace MixMash.Droid.Views
{
    [Activity(Label = "Select Your Seed")]
    public class SeedSelectorView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var authParams = new RealAuthenticationParams();

            var auth = new OAuth2Authenticator(
               authParams.ClientId,
               authParams.Scope,
               authParams.AuthorizeUrl,
               authParams.RedirectUrl);

            auth.Completed += OnAuthenticationCompleted;
            StartActivity(auth.GetUI(this));

            SetContentView(Resource.Layout.SeedSelectorView);
        }

        private async void OnAuthenticationCompleted(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {

            if (eventArgs.IsAuthenticated)
            {
                // Use eventArgs.Account to do wonderful things
                var test = "test";
            }
            else
            {
                // The user cancelled
            }
        }
    }
}