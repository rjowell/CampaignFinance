using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace CampaignFinance
{
    public partial class CreateCampaign : ContentPage
    {
        Uri submitCandidate = new Uri("http://www.cvx4u.com/web_service/create_campaign.php");
        HttpClient connClient = new HttpClient();

        public CreateCampaign()
        {
            InitializeComponent();
        }

        private async void SubmitCampaignAsync(object sender, EventArgs e)
        {
            Console.WriteLine(campaignName.Text);
            Console.WriteLine(startDate.Date);
            
            String submitString = "campaignName="+campaignName.Text.Replace(" ","%20")+"&goal="+fundGoal.Text+"&startDate="+startDate.Date.ToShortDateString()+"&endDate="+endDate.Date.ToShortDateString();
            Console.WriteLine(submitString);
            var sentString = new StringContent(submitString, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
            await connClient.PostAsync(submitCandidate, sentString);
        }
    }
}
