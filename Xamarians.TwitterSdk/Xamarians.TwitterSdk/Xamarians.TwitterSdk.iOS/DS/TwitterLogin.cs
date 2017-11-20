using System.Threading.Tasks;
using UIKit;
using Xamarians.TwitterSdk.DS;
using Xamarians.TwitterSdk.Model;
using Xamarians.TwitterSdk.Settings;

namespace Xamarians.TwitterSdk.iOS.DS
{
    public class TwitterLogin : ITwitterLogin
    {
        public static void Initialize()
        {
            TwitterLoginInstance.Init(new TwitterLogin());
        }


        private UIViewController GetController()
        {
            return UIApplication.SharedApplication.KeyWindow.RootViewController;
        }

        public Task<UserDetail> SignIn()
        {
			bool showLogin = true;

			var tcs = new TaskCompletionSource<UserDetail>();

            var controller = GetController();


            if (showLogin && OAuthConfig.User == null)
            {
                showLogin = false;

                //Create OauthProviderSetting class with Oauth Implementation .Refer Step 6
                OAuthProviderSetting oauth = new OAuthProviderSetting();


                var auth = oauth.LoginWithTwitter();
                // After Twitter  login completed 
                auth.Completed += (sender, eventArgs) =>
                {
                    controller.DismissViewController(true, null);

                    if (eventArgs.IsAuthenticated)
                    {
                        OAuthConfig.User = new UserDetail();
                        // Get and Save User Details 
                        OAuthConfig.User.Token = eventArgs.Account.Properties["oauth_token"];
                        OAuthConfig.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
                        OAuthConfig.User.TwitterId = eventArgs.Account.Properties["user_id"];
                        OAuthConfig.User.ScreenName = eventArgs.Account.Properties["screen_name"];
                        OAuthConfig.User.Name = eventArgs.Account.Username;

                        tcs.SetResult(OAuthConfig.User);
                    }
                    else
                    {
                        tcs.SetResult(null);

                        // The user cancelled
                    }
                };

                controller.PresentViewController(auth.GetUI(), false, null);

            }
            return tcs.Task;

        }
    }
}

           
     