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
using MixMash.Shared.BL.Authentication;
using Xamarin.Auth;

namespace MixMash.Droid.Services
{
    public class AuthService : IAuthService
    {      
        public void Login(AuthenticationParams authParams)
        {
            var auth = new OAuth2Authenticator(
               authParams.ClientId,
               authParams.Scope,
               authParams.AuthorizeUrl,
               authParams.RedirectUrl);

            auth.Completed += OnAuthenticationCompleted;
            var activity = Application.Context as Activity;
            activity.StartActivity(auth.GetUI(activity));
        }

        private async void OnAuthenticationCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {

            if (e.IsAuthenticated)
            {
                // Use eventArgs.Account to do wonderful things
            }
            else {
                // The user cancelled
            }
        }
    }
}