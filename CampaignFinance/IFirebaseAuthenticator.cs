using System;
using System.Threading.Tasks;


namespace Application
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        void CreateNewUserAsync(string email, string password);
    }
}
