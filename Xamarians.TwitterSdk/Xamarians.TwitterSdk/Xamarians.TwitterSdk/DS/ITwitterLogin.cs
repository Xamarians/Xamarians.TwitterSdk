using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarians.TwitterSdk.Model;

[assembly: InternalsVisibleTo("Xamarians.TwitterSdk.Droid")]
[assembly: InternalsVisibleTo("Xamarians.TwitterSdk.iOS")]
namespace Xamarians.TwitterSdk.DS
{
    public interface ITwitterLogin
    {
        Task<UserDetail> SignIn();

    }
}
