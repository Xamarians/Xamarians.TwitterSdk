using System;
using Xamarin.Auth;

namespace Xamarians.TwitterSdk
{
    public class OAuthProviderSetting
    {

        public string ClientId { get; private set; }
        public string ConsumerKey { get; private set; }
        public string ConsumerSecret { get; private set; }
        public string RequestTokenUrl { get; private set; }
        public string AccessTokenUrl { get; private set; }
        public string AuthorizeUrl { get; private set; }
        public string CallbackUrl { get; private set; }

        public OAuth1Authenticator LoginWithTwitter()
        {
            OAuth1Authenticator Twitterauth = null;
            try
            {
                Twitterauth = new OAuth1Authenticator(
                           consumerKey: "kTAoRS5nYYGufnypAsIAWqvkT",    // For Twitter login, for configure refer http://www.c-sharpcorner.com/article/register-identity-provider-for-new-oauth-application/
                           consumerSecret: "tEv8OWKGDoSBoCWQDRY7AItUJfftxRFOmhroYGYEzWFNQfyPT2",  // For Twitter login, for configure refer http://www.c-sharpcorner.com/article/register-identity-provider-for-new-oauth-application/
                           requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"), // These values do not need changing
                           authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"), // These values do not need changing
                           accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"), // These values do not need changing
                           callbackUrl: new Uri("http://placeholder.com")    // Set this property to the location the user will be redirected too after successfully authenticating
                       );
            }
            catch (Exception ex)
            {

            }
            return Twitterauth;
        }       
    }
}
