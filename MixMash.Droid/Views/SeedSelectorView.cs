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
            var account = AccountStore.Create(this).FindAccountsForService("Spotify").FirstOrDefault();
            /*if (account != null)
            {
                AccountStore.Create().Delete(account, "Spotify");
            }*/
            if (account == null)
            {
                var auth = new OAuth2Authenticator(
                   authParams.ClientId,
                   authParams.Scope,
                   authParams.AuthorizeUrl,
                   authParams.RedirectUrl);

                auth.Completed += OnAuthenticationCompleted;
                StartActivity(auth.GetUI(this));
            }

            /*var postDictionary = new Dictionary<string, string>();
            //postDictionary.Add("refresh_token", account.Properties["refresh_token"]);
            //postDictionary.Add("client_id", "<<your_client_id>>");
            //postDictionary.Add("client_secret", "<<your_client_secret>>");
            postDictionary.Add("grant_type", "authorization_code");
            postDictionary.Add("code", account.Properties["access_token"]);
            postDictionary.Add("redirect_uri", authParams.RedirectUrl.ToString());
            postDictionary.Add("client_id", authParams.ClientId);
            postDictionary.Add("client_secret", "<<your_client_secret>>");

            var accessRequest = new OAuth2Request("POST", authParams.AccessTokenUrl, postDictionary, AccountStore.Create(this).FindAccountsForService("Spotify").FirstOrDefault());
            accessRequest.GetResponseAsync().ContinueWith(task => {
                if (task.IsFaulted)
                    Console.WriteLine("Error: " + task.Exception.InnerException.Message);
                else
                {
                    string json = task.Result.GetResponseText();
                    try
                    {
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("!!!!!Exception: {0}", exception.ToString());
                    }
                }
            });*/

            SetContentView(Resource.Layout.SeedSelectorView);
        }

        private async void OnAuthenticationCompleted(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {

            if (eventArgs.IsAuthenticated)
            {
                // Use eventArgs.Account to do wonderful things
                AccountStore.Create(this).Save(eventArgs.Account, "Spotify");
            }
            else
            {
                // The user cancelled
            }
        }
    }
}