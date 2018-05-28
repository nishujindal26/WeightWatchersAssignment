using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Threading;
using System.Collections;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
namespace WeightWatchers
{
    public class MainPageControls
    {
        public MainPageControls() { }
        private string url = "https://www.weightwatchers.com/us/";
        private string windowTitle = "Weight Loss Program, Recipes & Help | Weight Watchers";
        private string findMeetingPageTitle = "Get Schedules & Times Near You";

        /// <summary>
        /// Property to store URL
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        /// <summary>
        /// Property to store window Title
        /// </summary>
        public string WindowTitle
        {
            get { return windowTitle; }
            set { windowTitle = value; }
        }

        /// <summary>
        /// Property To Store Find Meeting Page title
        /// </summary>
        public string FindMeetingPageTitle
        {
            get { return findMeetingPageTitle; }
            set { findMeetingPageTitle = value; }
        }
   
        //[FindsBy(How = How.XPath, Using = "//a[@class='find-a-meeting']")]
        //public IWebElement FindMeetingLink { get; set; }
      
        //[FindsBy(How = How.XPath, Using = "//*[@id='meetingSearch']")]
        //public IWebElement SearchTextBox { get; set; }

        //[FindsBy(How = How.XPath, Using = "//span[@class='input-group-btn']")]
        //public IWebElement SearchButton { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@class='meeting-location__top']")]
        //public IWebElement Location_top { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@class='location__distance']")]
        //public IWebElement LocationDistance { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@class='location__name']")]
        //public IWebElement LocationName { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@class='location__address']")]
        //public IWebElement LocationAddress { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@class='location__city-state-zip']")]
        //public IWebElement LocationCityStateZip { get; set; }

        //[FindsBy(How = How.XPath, Using ="//div[@class='meeting-location__toggle']")]
        //public IWebElement MeetingLocationToggle { get; set; }

        //[FindsBy(How = How.XPath, Using = "//li[@class='hours-list-item']")]
        //public IWebElement OperationalHours { get; set; }




        string findMeeting = "//a[@class='find-a-meeting']";

        public string FindMeeting
        {
            get { return findMeeting; }
            set { findMeeting = value; }
        }
        string searchTextBox = "//*[@id='meetingSearch']";

        public string SearchTextBox
        {
            get { return searchTextBox; }
            set { searchTextBox = value; }
        }
        string searchButton = "//span[@class='input-group-btn']";

        public string SearchButton
        {
            get { return searchButton; }
            set { searchButton = value; }
        }


        string location_top = "//div[@class='meeting-location__top']";

        public string Location_top
        {
            get { return location_top; }
            set { location_top = value; }
        }
        string location_distance = "//div[@class='location__distance']";

        public string Location_distance
        {
            get { return location_distance; }
            set { location_distance = value; }
        }
        string location_name = "//div[@class='location__name']";

        public string Location_name
        {
            get { return location_name; }
            set { location_name = value; }
        }
        string location_address = "//div[@class='location__address']";

        public string Location_address
        {
            get { return location_address; }
            set { location_address = value; }
        }
        string location_City_state = "//div[@class='location__city-state-zip']";

        public string Location_City_state
        {
            get { return location_City_state; }
            set { location_City_state = value; }
        }
        string meeting_location_toggle = "//div[@class='meeting-location__toggle']";

        public string Meeting_location_toggle
        {
            get { return meeting_location_toggle; }
            set { meeting_location_toggle = value; }
        }
        string operationalHours = "//li[@class='hours-list-item']";

        public string OperationalHours
        {
            get { return operationalHours; }
            set { operationalHours = value; }
        }
    }
}
