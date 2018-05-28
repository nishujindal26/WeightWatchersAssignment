using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool flag = false;
               
                flag = RandomNumber();
                if (!flag)
                {
                    Console.WriteLine("---------Could not execute Random Numbers Test because of invalid values");                  
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Enter key to start the Dictionary Test");
                Console.Read();
                DictionaryProgram();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Enter key to start the Selenium Test");
                Console.Read();

                Console.WriteLine("-------------------------------------");
                ExecuteSeleniumTest();
                Console.WriteLine("-------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static void DictionaryProgram()
        {
            Console.WriteLine("-------------- Dictionary Test: STARTED-----------------");
            try
            {
                DictionaryAssignment objdictionary = new DictionaryAssignment();
                objdictionary.WriteDictionayIntoFile(@"..//..//../Files/Sample.txt", @"..//..//../Files/Dictionary.txt", true);

            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------- Dictionary Test: FAILED-----------------");
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.WriteLine("-------------- Dictionary Test: COMPLETED-----------------");
            }
        }

        private static bool RandomNumber()
        {
            bool flag = false;
            Console.WriteLine("-------------------- Random Numbers Test: STARTED-------------------");
           
            Console.WriteLine("Enter Minimum Range");
            string minRange = Console.ReadLine();

            Console.WriteLine("Enter Maximum Range");
            string maxRange = Console.ReadLine();

            Console.WriteLine("Enter Number of Random Numbers to Generate Range");
            string count = Console.ReadLine();

            Console.WriteLine("Enter Nth smallest number to find");
            string nthSmallestNum = Console.ReadLine();
            try
            {
                int iMin = Convert.ToInt16(minRange);
                int iMax = Convert.ToInt16(maxRange);
                int iSmall = Convert.ToInt16(nthSmallestNum);
                int iCount = Convert.ToInt16(count);

                RandomNumberAssignment objRandom = new RandomNumberAssignment();
                flag = objRandom.GenerateRandomNumbersAndfindNthSmallest(iMin, iMax, iCount, iSmall);
            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------Random Numbers Test :FAILED-------------------");    
                throw ex;
            }
            finally
            {
                Console.WriteLine("---------------------Random Numbers Test :COMPLETED-------------------");              
            }
            return flag;
        }
        public static void ExecuteSeleniumTest()
        {
            Console.WriteLine("-------------------Selenium Test: STARTED--------------------------");           
            try
            {
                SeleniumAssignment sa = new SeleniumAssignment();
                sa.TestCase();
            }             
            catch (Exception ex)
            {
                Console.WriteLine("------------------- Selenium Test: FAILED--------------------------");
                throw ex;
            }
             finally
            {
                Console.WriteLine("------------------- Selenium Test: COMPLETED--------------------------");   
            }
        }
    }
}
