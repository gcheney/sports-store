using System.Web;
using System.Web.Security;

using SportsStore.WebUI.Infrastructure.Abstract;

namespace SportsStore.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            #pragma warning disable 612, 618
            bool result = FormsAuthentication.Authenticate(username, password);
            #pragma warning restore 612, 618

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
}