using System;
using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Xamarin.Forms;

namespace CampaignFinance
{

    

    public class Campaign
    {
        public String campaignName { get; set; }
        public String startDate { get; set; }
        public String endDate { get; set; }
        public String progress { get; set; }

        public Campaign(string Name, string Start, string End, string Goal)
        {
            campaignName = Name;
            startDate = Start;
            endDate = End;
            progress = Goal;
        }
    }

    public class InputObject
    {
        public String CampaignName { get; set; }
        public String FundGoal { get; set; }
        public String EndDate { get; set; }
        public String AmountRaised { get; set; }

        public InputObject(string Campaign, string Goal, string CampEndDate, string FundsRaised)
        {
            CampaignName = Campaign;
            FundGoal = Goal;
            EndDate = CampEndDate;
            AmountRaised = FundsRaised;
        }
    }



    public partial class CandidateDashboard : ContentPage
    {

       
        List<Campaign> fieldData;
        String jsonData = new WebClient().DownloadString("http://www.cvx4u.com/web_service/getCampaigns.php");
        List<InputObject> junkStuff;

        public CandidateDashboard()
        {
            //JObject thisJunk = JObject.Parse(jsonData);
            junkStuff = new List<InputObject>();

            JObject stuff=JObject.Parse(jsonData);
            

            Console.WriteLine(stuff.Count);

            Console.WriteLine(stuff);     
             
            //JArray newStuff = (Newtonsoft.Json.Linq.JArray)stuff["C1001_1"];
            //Console.WriteLine(newStuff.Count);
            

            //Object stuff = thisJunk;

            //List<InputObject> inObjects = JsonConvert.DeserializeObject<List<InputObject>>(jsonData);
            //Console.WriteLine(inObjects);
           
            InitializeComponent();

            campaignDisplay.ItemsSource = fieldData;

        }

        private void OpenCreateCampaign(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateCampaign());
        }
    }
}
