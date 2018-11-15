using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Application;
using CampaignFinance.iOS;
using Firebase;
using Firebase.Auth;
[assembly: Xamarin.Forms.Dependency(typeof(FirebaseAuthenticator))]

namespace CampaignFinance.iOS
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
            Console.WriteLine(user.User.GetIdTokenAsync().Id);
            return await user.User.GetIdTokenAsync();
        }



        Firebase.Auth.AuthStateDidChangeListenerHandler thisListener = new AuthStateDidChangeListenerHandler((Auth auth, User user) => {

            Console.WriteLine("here we areee");
            Console.WriteLine(auth.CurrentUser.Uid);

        });
       





        public void CreateNewUserAsync(string email, string password)
        {
            Console.WriteLine("hhhhh");
            //Auth.DefaultInstance.CreateUser(email, password,HandleAuthDataResultHandler);
            Auth.DefaultInstance.AddAuthStateDidChangeListener(thisListener);
            Auth.DefaultInstance.CreateUserAsync(email, password);
            Auth.DefaultInstance.SignInWithPasswordAsync(email, password);

            /*Auth.DefaultInstance.CreateUser(email, password, (AuthDataResult authResult, Foundation.NSError error) =>
            {


                Auth.DefaultInstance.SignInWithPassword(email, password, (AuthDataResult authResult1, Foundation.NSError error1) =>
                {

                });






                //authResult.User.SendEmailVerificationAsync();
                Console.WriteLine(error.UserInfo.Description);
                
                //NSLocalizedFailureReasonErrorKey
                Console.WriteLine("errror is");
                Console.WriteLine(authResult);
                authResult.User.GetIdToken((string token, Foundation.NSError error1) => 
                {
                    Console.WriteLine("Token Is");
                    Console.WriteLine(token);
                });

            });*/
   



        }

       


       


    }
}
