using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using SimpleBudget.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget
{
    public class CustomCredentialsAuthProvider : CredentialsAuthProvider
    {
        IRepositoryUnitOfWork repositoryUnitOfWork;

        public CustomCredentialsAuthProvider(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            this.repositoryUnitOfWork = repositoryUnitOfWork;
        }

        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            //Add here your custom auth logic (database calls etc)
            //Return true if credentials are valid, otherwise false
            return repositoryUnitOfWork.Users.AuthenticateUser(userName, password);
        }

        public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IOAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            //Fill the IAuthSession with data which you want to retrieve in the app eg:
            session.FirstName = "some_firstname_from_db";
            //...

            //Important: You need to save the session!
            authService.SaveSession(session, SessionExpiry);
        }
    }
}
