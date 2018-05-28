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
                    Console.WriteLine("---------Could not execute Random Numbers program becauseof invalid values");                  
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Enter key to start the Dictionary Program");
                Console.Read();
                DictionaryProgram();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Enter key to start the Selenium Program");
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
            Console.WriteLine("--------------Executing Dictionary Program-----------------");
            try
            {
                DictionaryAssignment objdictionary = new DictionaryAssignment();
                objdictionary.WriteDictionayIntoFile(@"..//..//../Files/Sample.txt", @"..//..//../Files/Dictionary.txt", true);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ënter Valid Values");
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.WriteLine("--------------Executed Dictionary Program-----------------");
            }
        }

        private static bool RandomNumber()
        {
            bool flag = false;
            Console.WriteLine("---------------------Executing Random Numbers Program-------------------");
           
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
                throw ex;
            }
            finally
            {
                Console.WriteLine("---------------------Random Numbers Program completed-------------------");              
            }
            return flag;
        }
        public static void ExecuteSeleniumTest()
        {
            Console.WriteLine("--------------------Executing Selenium Test--------------------------");           
            try
            {
                SeleniumAssignment sa = new SeleniumAssignment();
                sa.TestCase();
            }             
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
             finally
            {
                Console.WriteLine("--------------------Executed Selenium Test--------------------------");   
            }
        }
    }
}
