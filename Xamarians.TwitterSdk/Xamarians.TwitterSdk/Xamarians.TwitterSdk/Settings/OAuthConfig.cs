using System;
using Xamarians.TwitterSdk.Model;

namespace Xamarians.TwitterSdk.Settings
{
    public class OAuthConfig
    {

        public static UserDetail User;        
        public static Action SuccessfulLoginAction
        {            
            get
            {
                return new Action(() =>
                {
                  // App.Current.MainPage.Navigation.PushModalAsync(new HomePage());
                });
            }
        }

    }
}
