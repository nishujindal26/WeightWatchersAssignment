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
using WeightWatchers;

namespace Assignment
{
    enum Browser
    {
        IE,
        Chrome,
        FireFox
    }
    class SeleniumAssignment
    {
        //1. Navigate to https://www.weightwatchers.com/us/
        //2. Verify loaded page title matches “Weight Loss Program, Recipes & Help | Weight Watchers”
        //3. On the right corner of the page, click on “Find a Meeting”
        //4. Verify loaded page title contains “Get Schedules & Times Near You”
        //5. In the search field, search for meetings for zip code: 10011
        //6. Print the title of the first result and the distance (located on the right of location title/name)
        //7. Click on the first search result and then, verify displayed location name matches with the name of the first searched result that was clicked.
        //8. From this location page, print TODAY’s hours of operation (located towards the bottom of the page)
        public void Selenium(Browser browser)
        {
            IWebDriver driver = null;
            string dayToday = DateTime.Now.DayOfWeek.ToString();
            try
            {
                driver = new FirefoxDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                string windowTitle = "Weight Loss Program, Recipes & Help | Weight Watchers";
                string findMeetingPageTitle = "Get Schedules & Times Near You";

                string findMeeting = "//a[@class='find-a-meeting']";
                string searchTextBox = "//*[@id='meetingSearch']";
                string searchButton = "//span[@class='input-group-btn']";


                string location_top = "//div[@class='meeting-location__top']";
                string location_distance = "//div[@class='location__distance']";
                string location_name = "//div[@class='location__name']";
                string location_address = "//div[@class='location__address']";
                string location_City_state = "//div[@class='location__city-state-zip']";
                string meeting_location_toggle = "//div[@class='meeting-location__toggle']";
                string operationalHours = "//li[@class='hours-list-item']";
                // string geckoDriverPath= @"C:\Nishu\Assignment\Assignment\packages\geckodriver.exe";
                //   System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", geckoDriverPath);
                // FirefoxDriverService serv = FirefoxDriverService.CreateDefaultService(@"C:\Nishu\Assignment\Assignment\packages\");
                //serv.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

                string url = "https://www.weightwatchers.com/us/";
                driver.Navigate().GoToUrl(url);

                Console.WriteLine("Ëxpected window Title : " + windowTitle);
                Console.WriteLine("Actual window Title : " + driver.Title);
                if (driver.Title.Equals(windowTitle))
                    Console.WriteLine("Expected window title matches with Actual window title");
                else
                    Console.WriteLine("Expected window title does not matches with Actual window title");

                driver.FindElement(By.XPath(findMeeting)).Click();
                Thread.Sleep(1000);
                Console.WriteLine("Ëxpected Find meeting page title : " + findMeetingPageTitle);
                Console.WriteLine("Actual Find meeting page title : " + driver.Title);
                if (driver.Title.Equals(findMeetingPageTitle))
                    Console.WriteLine("Expected Find meeting window title matches with Actual find meeting window title");
                else
                    Console.WriteLine("Expected Find meeting window title doea not matches with Actual find meeting window title");
                driver.FindElement(By.XPath(searchTextBox)).SendKeys("10011");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath(searchButton)).Click();
                Thread.Sleep(1000);


                IList<IWebElement> elements = driver.FindElements(By.XPath(location_top));
                IList<IWebElement> locDistanceList = driver.FindElements(By.XPath(location_distance));
                IList<IWebElement> locNameList = driver.FindElements(By.XPath(location_name));
                IList<IWebElement> locAddressList = driver.FindElements(By.XPath(location_address));
                IList<IWebElement> locCityStateZipList = driver.FindElements(By.XPath(location_City_state));
                IList<IWebElement> locMeetingsList = driver.FindElements(By.XPath(meeting_location_toggle));
                bool flag = true;
                for (int i = 0; i < elements.Count; i++)
                {
                    flag = (elements[i].Text.Contains(locDistanceList[i].Text)
                        && elements[i].Text.Contains(locNameList[i].Text)
                        && elements[i].Text.Contains(locAddressList[i].Text)
                       && elements[i].Text.Contains(locCityStateZipList[i].Text)
                         && elements[i].Text.Contains(locMeetingsList[i].Text));
                    if (flag)
                        Console.WriteLine(string.Format("Meeting Name: {0} \nAddress: {1} \nCity-State-Zip: {2} \nNumber of Meetings: {3} \nDistance: {4}", locNameList[i].Text, locAddressList[i].Text, locCityStateZipList[i].Text, locMeetingsList[i].Text, locDistanceList[i].Text));
                }

                // click First Meeting 
                Console.WriteLine("Clicking First Meeting: " + locDistanceList[0].Text);
                locNameList[0].Click();
                Thread.Sleep(1000);

                // Match the Meeting Title Name if it matches with the meeting clicked
                string meetingTtitle = driver.FindElement(By.XPath(location_name)).Text;
                Console.WriteLine(meetingTtitle);

                ArrayList hoursList = new ArrayList();
                IList<IWebElement> operationHoursList = driver.FindElements(By.XPath(operationalHours));
                foreach (IWebElement element in operationHoursList)
                {
                    hoursList.Add(element.Text.Replace("\r\n", "\\"));
                }

                ArrayList todaysHoursOfOperaton = new ArrayList();
                foreach (string str in hoursList)
                {

                    string[] dayHoursList = str.Split('\\');

                    Console.WriteLine("Öperations hours: " + dayHoursList[0]);
                    if (dayHoursList[0].Equals(dayToday))
                        todaysHoursOfOperaton.Add(dayHoursList[0]);

                    for (int i = 1; i < dayHoursList.Length; i++)
                    {
                        Console.WriteLine(dayHoursList[i]);
                        if (dayHoursList[0].Equals(dayToday))
                            todaysHoursOfOperaton.Add(dayHoursList[i]);
                    }
                }
                Console.WriteLine("----------Todays Hours of Operation------------");
                foreach (string str in todaysHoursOfOperaton)
                {
                    Console.WriteLine(str);
                }
                Console.WriteLine();
            }


            catch (Exception ex)
            {
                string error = ex.Message;
                throw ex;
            }
            finally
            {
                driver.Close();
                Console.Read();


            }
            // distance   /html/body/div[2]/div/div[2]/div/div/ui-view/ui-view/div/div[2]/div/div[1]/div/div[1]/result-location/div/div[1]/a/location-address/div/div/div[1]/div[2]

        }

        public void TestCase()
        {
            string error = string.Empty;
            ControlUtility utils = new ControlUtility();
            try
            {
                utils.TestCase();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

    }
}
