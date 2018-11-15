using System;

using System.Threading.Tasks;
using Application;
using CampaignFinance.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthenticator))]
//[assembly: Dependence      Xamarin.Forms.Dependency(typeof(FirebaseAuthenticatorDroid))]
namespace CampaignFinance.Droid
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var userID = user.User.Uid;
            Console.WriteLine(userID);
            var token = await user.User.GetTokenAsync(false);
            return token.Token;
        }

        public async Task<string> CreateNewUserAAsync(string email, string password)
        {
            Console.WriteLine("hhhhh");
            //var thing=Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, password);
            bool userCreateSuccessful = Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password).IsCompletedSuccessfully;
            if(userCreateSuccessful==true)
            {
                var user = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var theToken = await user.User.GetIdTokenAsync(false);
                Console.WriteLine(theToken.Token);
            }
            else
            {
                Console.WriteLine("it failed");
            }
            
            //Firebase.Auth.UserProfileChangeRequest request = new Firebase.Auth.UserProfileChangeRequest.Builder().SetDisplayName("John Smith").Build();

            //thing.User.UpdateProfile(request);
            return "Hello";
           
        }

        public void CreateNewUserAsync(string email, string password)
        {
            Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, password);

        }


        /*
         * 
         * 
         * 
         *  public void CreateNewUserAsync(string email, string password)
        {
            Console.WriteLine("hhhhh");
            //Auth.DefaultInstance.CreateUser(email, password,HandleAuthDataResultHandler);
            
            Auth.DefaultInstance.CreateUser(email, password, (AuthDataResult authResult, Foundation.NSError error) => {

                Console.WriteLine(error.UserInfo.Description);
                //NSLocalizedFailureReasonErrorKey
                Console.WriteLine("errror is");
                Console.WriteLine(authResult);
                authResult.User.GetIdToken((string token, Foundation.NSError error1) => 
                {
                    Console.WriteLine("Token Is");
                    Console.WriteLine(token);
                });

            });
   



        }


        void IFirebaseAuthenticator.CreateNewUserAsync(string email, string password)
        {
            Console.WriteLine("poopie");
        }*/
    }
}
