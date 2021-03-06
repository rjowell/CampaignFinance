﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Application;

using Xamarin.Forms;


namespace CampaignFinance
{


    public partial class CreateUser : ContentPage
    {
        Button[] partyButtons;
        Uri submitCandidate = new Uri("http://www.cvx4u.com/web_service/create_user.php");
        HttpClient connClient = new HttpClient();
        Entry[] entryArray;         Label[] entryLabels;
        String partySelection;

        bool isSupporter;

        public void CreateNewUser(object sender, EventArgs e)
        {

        }

        public CreateUser(bool setSupporter)
        {

            InitializeComponent();
            isSupporter = setSupporter;
            otherPartyLabel.IsVisible = false;
            candidateParty.IsVisible = false;
            successFrame.IsVisible = false;
            if (isSupporter==true)
            {
                partyLabel.IsVisible = false;
                demButton.IsVisible = false;
                gopButton.IsVisible = false;
                websiteLabel.IsVisible = false;
                candidateWebsite.IsVisible = false;
                createWindowLabel.Text = "Create Supporter";

                entryArray = new Entry[] { firstNameField, lastNameField, eMailField, phoneNumberField, usernameField, passwordField };
                entryLabels = new Label[] { firstNameLabel, lastNameLabel, eMailLabel, phoneLabel, usernameLabel, passwordLabel };
            }
            else
            {
                createWindowLabel.Text = "Create Candidate";
                partyButtons = new Button[] { demButton, gopButton, otherPartyButton };


                entryArray = new Entry[] { firstNameField, lastNameField, eMailField, phoneNumberField, candidateWebsite, usernameField, passwordField };
                entryLabels = new Label[] { firstNameLabel, lastNameLabel, eMailLabel, phoneLabel, websiteLabel, usernameLabel, passwordLabel };

            }



           
        }

        private void ReturnToLogin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }




        private async void SubmitDataAsync(object sender, EventArgs e)
        {
            int count = 0;
            bool formComplete=true;
            foreach(Entry entries in entryArray)
            {
                if(entries.Text=="")
                {
                    entryLabels[count].TextColor = Color.Red;
                    formComplete = false;
                }
                count++;
            }
            if(partySelection==null)
            {
                formComplete = false;
            }

            if(formComplete==true)
            {

                if (isSupporter == true)
                {

                }
                else
                {
                    String content = "firstName=" + firstNameField.Text + "&lastName=" + lastNameField.Text + "&eMail=" + eMailField.Text + "&phone=" + phoneNumberField.Text + "&website=" + candidateWebsite.Text + "&party=" + partySelection;
                    Console.WriteLine("success");
                    Console.WriteLine(content);
                    var sentString = new StringContent(content, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
                   
                    Console.WriteLine("jerkoff");
                    DependencyService.Get<IFirebaseAuthenticator>().CreateNewUserAsync(eMailField.Text, passwordField.Text);
                    await connClient.PostAsync(submitCandidate, sentString);
                    Console.WriteLine("your result is");
                    //Console.WriteLine(whoDe);
                    //var thisObject = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(eMailField.Text, passwordField.Text);

                    //Console.WriteLine(thisObject.Length);
                }
                successFrame.IsVisible = true;
            }
        }

        private void ProcessPartyButton(Button sender, EventArgs e)
        {
            sender.BackgroundColor = Color.Blue;
            sender.TextColor = Color.White;
            

            foreach(Button thisButton in partyButtons)
            {
                if(thisButton.Text != sender.Text)
                {
                    thisButton.BackgroundColor = Color.White;
                    thisButton.TextColor = Color.Default;
                }
            }



            if(sender.Text=="Other")
            {
                otherPartyLabel.IsVisible = true;
                candidateParty.IsVisible = true;
                partySelection = candidateParty.Text;
            }
            else
            {
                otherPartyLabel.IsVisible = false;
                candidateParty.IsVisible = false;
                partySelection = sender.Text;
            }
        }
    }
}
