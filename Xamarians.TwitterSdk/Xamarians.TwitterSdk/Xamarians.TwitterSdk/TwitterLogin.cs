using Xamarians.TwitterSdk.DS;

namespace Xamarians.TwitterSdk
{
    public static class TwitterLoginInstance
    {
        static ITwitterLogin _instance;
        public static ITwitterLogin Instance
        {
            get
            {
                return _instance;
            }
        }

        public static void Init(ITwitterLogin twitterLogin)
        {
            _instance = twitterLogin;
        }

    }
}