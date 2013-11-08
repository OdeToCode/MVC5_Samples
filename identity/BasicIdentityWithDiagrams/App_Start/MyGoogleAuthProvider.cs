using System.Threading.Tasks;
using Microsoft.Owin.Security.Google;

namespace BasicIdentityWithDiagrams
{
    class MyGoogleAuthProvider : GoogleAuthenticationProvider
    {
        public override Task Authenticated(GoogleAuthenticatedContext context)
        {        
            // custom processing ...

            return base.Authenticated(context);
        }
    }
}