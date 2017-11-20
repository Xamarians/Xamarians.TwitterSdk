using Android.App;
using Android.Content;
using System.Threading.Tasks;
using Xamarians.TwitterSdk.DS;
using Xamarians.TwitterSdk.Model;
using Xamarians.TwitterSdk.Settings;
using Xamarin.Forms;

namespace Xamarians.TwitterSdk.Droid.DS
{
    public class TwitterLogin : ITwitterLogin
    {
        static Context _context;

        public TwitterLogin()
        {

        }
        public static void Initialize(Context context)
        {
            _context = context;
            TwitterLoginInstance.Init(new TwitterLogin());
        }
        public Task<UserDetail> SignIn()
		{
			bool showLogin = true;
            var activity = Forms.Context as Activity;

			var tcs = new TaskCompletionSource<UserDetail>();

			if (showLogin && OAuthConfig.User == null)
			{
				showLogin = false;

				//Create OauthProviderSetting class with Oauth Implementation .
				OAuthProviderSetting oauth = new OAuthProviderSetting();


				var auth = oauth.LoginWithTwitter();
				// After Twitter  login completed 
				auth.Completed += (sender, eventArgs) =>
				{

					if (eventArgs.IsAuthenticated)
					{
                        OAuthConfig.User = new UserDetail
                        {
                            // Get and Save User Details 
                            Token = eventArgs.Account.Properties["oauth_token"],
                            TokenSecret = eventArgs.Account.Properties["oauth_token_secret"],
                            TwitterId = eventArgs.Account.Properties["user_id"],
                            ScreenName = eventArgs.Account.Properties["screen_name"],
                            Name = eventArgs.Account.Username
                        };

                        tcs.SetResult(OAuthConfig.User);
					}
					else
					{
						tcs.SetResult(null);

						// The user cancelled
					}
				};

				activity.StartActivity(auth.GetUI(activity));

			}
			return tcs.Task;

		}
	}
}



