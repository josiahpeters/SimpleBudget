using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Interfaces
{
    public interface ICredentialsAuthProvider
    {
        bool TryAuthenticate(IServiceBase authService, string userName, string password);
        void OnAuthenticated(IServiceBase authService, IAuthSession session, IOAuthTokens tokens, Dictionary<string, string> authInfo);

    }
}
