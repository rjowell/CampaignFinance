using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CampaignFinance
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void ProcessLogin(object sender, EventArgs e)
        {
            Console.WriteLine(usernameField.Text);
            Console.WriteLine(passwordField.Text);
            Navigation.PushAsync(new CandidateDashboard());
        }

        private void CreateUser(object sender, EventArgs e)
        {

            Button currentButton = sender as Button;

            if(currentButton.Text== "I am a candidate")
            {
                Console.WriteLine("candiate button clicked");
                Navigation.PushAsync(new CreateUser(false));
            }
            else
            {
                Console.WriteLine("candiate button clicked--1");
                Navigation.PushAsync(new CreateUser(true));
            }
        }
    }
}
