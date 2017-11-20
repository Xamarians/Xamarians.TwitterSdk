using System;
using Xamarin.Forms;
namespace Sample
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        async void LoginClick(object sender, EventArgs args)
        {

            if (Xamarians.TwitterSdk.Settings.OAuthConfig.User == null)
            {

                var result = await Xamarians.TwitterSdk.TwitterLoginInstance.Instance.SignIn();
                if (result == null)
                {
                    return;
                }
               if(result.IsAuthenticated == true)
                {
                     Application.Current.MainPage= new HomePage();
                }

            }
        }
    }
}
