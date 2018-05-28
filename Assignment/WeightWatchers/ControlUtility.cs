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
    public class ControlUtility
    {
        IWebDriver driver = null;
        string error = string.Empty;
        MainPageControls objControls = null;
        public ControlUtility()
        {
            objControls = new MainPageControls();
        }
        /// <summary>
        /// Launching Home page for Weight Watchers
        /// </summary>
        /// <param name="url">URL to Launch</param>
        /// <returns>WebDriver object</returns>
        public IWebDriver LaunchPage(string url)
        {
            IWebDriver objDriver = null;
            try
            {
                objDriver = new FirefoxDriver();
                objDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                objDriver.Navigate().GoToUrl(objControls.Url);
                Console.WriteLine("URL : " + objControls.Url + " launched");
            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }

            return objDriver;
        }

        /// <summary>
        /// Get Window Title
        /// </summary>
        /// <param name="driver">WebDriver Object</param>
        /// <returns>Window title</returns>
        public string GetWindowTitle(IWebDriver driver)
        {
            string title = string.Empty;
            try
            {

                title = driver.Title;
                Console.WriteLine("Window title is : " + title);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return title;
        }

        /// <summary>
        /// Compare the window titlw with expecetd result
        /// </summary>
        /// <param name="expected">Expected window title</param>
        /// <param name="actual">Actual Window Title</param>
        /// <returns>true/false</returns>
        public bool CompareTitle(string expected, string actual)
        {
            bool flag = false;
            try
            {
                Console.WriteLine("Ëxpected window Title : " + expected);
                Console.WriteLine("Actual window Title : " + actual);
                if (expected.Equals(actual))
                {
                    Console.WriteLine("---------Expected window title matches with Actual window title: SUCCESS");
                    flag = true;
                }
                else
                    Console.WriteLine("---------Expected window title does not matches with Actual window title: FAILURE");
            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return flag;
        }

        /// <summary>
        /// Click Button/Link
        /// </summary>
        /// <param name="driver">WebDriver object</param>
        /// <param name="xpath">XPath of the control</param>
        /// <param name="controlName">Name of control</param>
        /// <returns>true/false</returns>
        public bool ActionClick(IWebDriver driver, string xpath, string controlName)
        {
            bool flag = false;
            try
            {
                driver.FindElement(By.XPath(xpath)).Click();
                Console.WriteLine(controlName + " Clicked");
                flag = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return flag;
        }
        /// <summary>
        /// Enter value in Control/text box
        /// </summary>
        /// <param name="driver">WebDriver object</param>
        /// <param name="xpath">XPath of the control</param>
        /// <param name="value">Value to be entered</param>
        /// <param name="controlName">Name of control</param>
        /// <returns>true/false</returns>
        public bool EnterText(IWebDriver driver, string xpath, string value, string controlName)
        {
            bool flag = false;
            try
            {
                driver.FindElement(By.XPath(xpath)).SendKeys(value);
                Console.WriteLine(string.Format("Entered value {0} in {1}", value, controlName));
                flag = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return flag;
        }

        /// <summary>
        /// Find elements in a list
        /// </summary>
        /// <param name="driver">WebDriver object</param>
        /// <param name="xpath">XPath of the control</param>
        /// <returns>Element List</returns>
        public IList<IWebElement> FindElements(IWebDriver driver, string xpath)
        {
            IList<IWebElement> elements = null;
            try
            {
                elements = driver.FindElements(By.XPath(xpath));

            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return elements;
        }
        /// <summary>
        /// Find element 
        /// </summary>
        /// <param name="driver">WebDriver object</param>
        /// <param name="xpath">XPath of the control</param>
        /// <returns>Element </returns>
        public IWebElement FindElement(IWebDriver driver, string xpath)
        {
            IWebElement element = null;
            try
            {
                element = driver.FindElement(By.XPath(xpath));

            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return element;
        }
        /// <summary>
        /// Get value of control
        /// </summary>
        /// <param name="driver">WebDriver object</param>
        /// <param name="xpath">XPath of the control</param>
        /// <returns>Text value of  control</returns>
        public string GetText(IWebDriver driver, string xpath)
        {
            string value = string.Empty;
            try
            {
                value = driver.FindElement(By.XPath(xpath)).Text;
                Console.WriteLine(value + " retireved");
            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return value;
        }
        /// <summary>
        /// Find and print all meeting details
        /// </summary>
        /// <param name="driver">WebDriver object</param>
        /// <returns>true/false</returns>
        public bool FindAllMeetingsDetails(IWebDriver driver)
        {
            bool flag = false;
            try
            {
                IList<IWebElement> elements = FindElements(driver, objControls.Location_top);
                IList<IWebElement> locDistanceList = FindElements(driver, objControls.Location_distance);
                IList<IWebElement> locNameList = FindElements(driver, objControls.Location_name);
                IList<IWebElement> locAddressList = FindElements(driver, objControls.Location_address);
                IList<IWebElement> locCityStateZipList = FindElements(driver, objControls.Location_City_state);
                IList<IWebElement> locMeetingsList = FindElements(driver, objControls.Meeting_location_toggle);
                for (int i = 0; i < elements.Count; i++)
                {
                    if ((elements[i].Text.Contains(locDistanceList[i].Text)
                        && elements[i].Text.Contains(locNameList[i].Text)
                        && elements[i].Text.Contains(locAddressList[i].Text)
                       && elements[i].Text.Contains(locCityStateZipList[i].Text)))
                    {
                       // Console.WriteLine(string.Format("Meeting Name: {0} \nAddress: {1} \nCity-State-Zip: {2} \nNumber of Meetings: {3} \nDistance: {4}", locNameList[i].Text, locAddressList[i].Text, locCityStateZipList[i].Text, locMeetingsList[i].Text, locDistanceList[i].Text));
                       // Console.WriteLine("-----------------------");

                        flag = true;
                    }
                }

            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return flag;
        }
        /// <summary>
        /// Get Meeting name and its distance based on instance passed.
        /// </summary>
        /// <param name="driver">WebDriver Object</param>
        /// <param name="meetingName">Meeting name to be retrieved</param>
        /// <param name="distance">Distance to be retrieved</param>
        /// <param name="instance">meeting instance from list</param>
        /// <returns>true/false</returns>
        public bool GetMeetingNameWithLocation(IWebDriver driver, out string meetingName, out string distance, int instance)
        {
            meetingName = string.Empty;
            distance = string.Empty;
            bool flag = false;
            try
            {
                IList<IWebElement> locDistanceList = FindElements(driver, objControls.Location_distance);
                IList<IWebElement> locNameList = FindElements(driver, objControls.Location_name);
                if (instance <= 0)
                    instance = 0;
                else
                    instance = instance - 1;
                meetingName = locNameList[instance].Text;
                distance = locDistanceList[instance].Text;
                Console.WriteLine(string.Format("Meeting Name: {0}  \nDistance: {1}", meetingName, distance));
                flag = true;

            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return flag;
        }

        /// <summary>
        /// Click Meeting instance
        /// </summary>
        /// <param name="driver">WebDriver Object</param>
        /// <param name="instance">meeting instance to be clicked</param>
        /// <returns>true/false</returns>
        public bool ClickMeetingInstance(IWebDriver driver, int instance)
        {
            bool flag = false;
            string meeting = string.Empty;
            try
            {
                IList<IWebElement> locNameList = FindElements(driver, objControls.Location_name);
                if (instance <= 0)
                    instance = 0;
                else
                    instance = instance - 1;
                meeting = locNameList[instance].Text;
                locNameList[instance].Click();
                Console.WriteLine("Meeting instance : " + meeting + "Clicked");
                flag = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return flag;
        }

        /// <summary>
        /// Get operational hours for meeting for whole week
        /// </summary>
        /// <param name="driver">WebDriver object</param>
        /// <returns>List of Operational hours</returns>
        public ArrayList GetDayAndOperationalHours(IWebDriver driver)
        {
            ArrayList operationalHourList = new ArrayList();
            try
            {
                IList<IWebElement> operationHoursList = FindElements(driver, objControls.OperationalHours);

                foreach (IWebElement element in operationHoursList)
                {
                    operationalHourList.Add(element.Text.Replace("\r\n", "\\"));
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return operationalHourList;
        }

        /// <summary>
        /// Find respective days operational hours
        /// </summary>
        /// <param name="driver">WebDriver object</param>
        /// <param name="day">Day for which opeartional hours to be retrieved</param>
        /// <returns>List of operational hours based on the day</returns>
        public ArrayList FindTodaysOperationalHours(IWebDriver driver, string day)
        {
            ArrayList todaysHoursOfOperaton = new ArrayList();
            try
            {
                ArrayList operationalHourList = GetDayAndOperationalHours(driver);


                foreach (string str in operationalHourList)
                {

                    string[] dayHoursList = str.Split('\\');

                    if (dayHoursList[0].Equals(day))
                    {
                        for (int i = 1; i < dayHoursList.Length; i++)
                        {
                            todaysHoursOfOperaton.Add(dayHoursList[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw ex;
            }
            return todaysHoursOfOperaton;
        }
        //1. Navigate to https://www.weightwatchers.com/us/
        //2. Verify loaded page title matches “Weight Loss Program, Recipes & Help | Weight Watchers”
        //3. On the right corner of the page, click on “Find a Meeting”
        //4. Verify loaded page title contains “Get Schedules & Times Near You”
        //5. In the search field, search for meetings for zip code: 10011
        //6. Print the title of the first result and the distance (located on the right of location title/name)
        //7. Click on the first search result and then, verify displayed location name matches with the name of the first searched result that was clicked.
        //8. From this location page, print TODAY’s hours of operation (located towards the bottom of the page)
        public void TestCase()
        {
            bool isFlag = false;
            try
            {
                // Launch Page
                driver = LaunchPage(objControls.Url);

                // Get Window Title
                string getWindowTitle = GetWindowTitle(driver);

                // Compare window Title
                isFlag = CompareTitle(getWindowTitle, objControls.WindowTitle);
                if (isFlag)
                    // Click Find Meeting Link
                    if (ActionClick(driver, objControls.FindMeeting, "Find Meeting Link"))
                    {
                        // Get Find Meeting Window Title
                        getWindowTitle = GetWindowTitle(driver);

                        // Compare Find Meeting Window Title
                        isFlag = CompareTitle(getWindowTitle, objControls.FindMeetingPageTitle);


                        // Serach for 10011 area for meetings
                        if (EnterText(driver, objControls.SearchTextBox, "10011", "Search text box"))
                        {
                            // Click Search Button 
                            if (ActionClick(driver, objControls.SearchButton, "Search Button"))
                            {
                                // Find all Meeting details on first Page
                                if (FindAllMeetingsDetails(driver))
                                {
                                    // Get First Meeting name and its distance 
                                    string meetingName = string.Empty;
                                    string location = string.Empty;
                                    if (GetMeetingNameWithLocation(driver, out meetingName, out location, 1))
                                    {
                                        if (ClickMeetingInstance(driver, 1))
                                        {
                                            string dispLocName=GetText(driver, objControls.Location_name);
                                            if (dispLocName.Equals(meetingName))
                                            {
                                                Console.WriteLine(string.Format("---------Verifed displayed location name : {0} matches with the name of the first searched result: {1} that was clicked: SUCCESS",dispLocName, meetingName) );
                                                string dayToday = DateTime.Now.DayOfWeek.ToString();

                                                ArrayList todaysHoursOfOperation = FindTodaysOperationalHours(driver, dayToday);
                                                Console.WriteLine("Operational hours for Today : " + dayToday);
                                                foreach (string hours in todaysHoursOfOperation)
                                                {
                                                    Console.WriteLine(hours);
                                                }
                                            }
                                            else
                                                  Console.WriteLine(string.Format("---------Verifed displayed location name : {0} matches with the name of the first searched result: {1} that was clicked: FAILURE",dispLocName, meetingName) );
                                             
                                        }
                                    }
                                }
                            }
                        }
                    }                    
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                driver.Close();
                Console.WriteLine("---------------Test Case Completed---------------");
                Console.Read();

            }
        }
    }
}
