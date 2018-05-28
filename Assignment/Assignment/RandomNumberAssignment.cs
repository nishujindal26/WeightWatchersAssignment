using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
  public  class RandomNumberAssignment
    {
      /// <summary>
      /// Generate random numbers and get Nth Smallest number
      /// </summary>
      /// <param name="minRange">minimum range</param>
      /// <param name="maxRange">maximum range</param>
      /// <param name="count">Total count of random numbers</param>
      /// <param name="nthSmallest">Nth Smallest Number</param>
      /// <returns>true/false</returns>
        public bool GenerateRandomNumbersAndfindNthSmallest(int minRange,int maxRange, int count, int nthSmallest)
        {
            bool flag=false;
            try
            {
                 if (minRange>maxRange || minRange<0 || maxRange<=0|| count<=0|| nthSmallest<=0|| nthSmallest>count)
                 Console.WriteLine(string.Format("Please enter valid values \n one of the values minimum range = {0}, or maximum range ={1} or count={2}, Nth Smallest number= {3} is invalid", minRange,maxRange,count,nthSmallest));
                else
                {
                List<int> lst = GenerateRandomNumbers(minRange, maxRange, count);
                Console.WriteLine("Printing Generated Random Numbers");                
                PrintList(lst);
                List<int> sortedList = SortListAssending(lst); 
                Console.WriteLine("Sorted List");
                PrintList(sortedList);


                int nthSmallestNum = FindNthSmallestNumber(lst, nthSmallest);
                Console.WriteLine(string.Format("smallest {0} th Number: {1}", nthSmallest, nthSmallestNum));
                flag = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }

        /// <summary>
        /// Method to generate random numbers
        /// </summary>
        /// <param name="min">min range for random number</param>
        /// <param name="max">max range for random number</param>
        /// <param name="count">total count of random numbers to generate</param>
        /// <returns>Integer List of random number</returns>
        public static List<int> GenerateRandomNumbers(int min, int max, int count)
        {
            Random objRandom = new Random();
            List<int> lst = new List<int>();
            int num = 0;
            for (int index = 0; index < count; index++)
            {
                num = objRandom.Next(min, max);
                lst.Add(num);
            }
            return lst;
        }    
        /// <summary>
        /// Method to find the smallest number using pre defined Sort method
        /// </summary>
        /// <param name="lst">Integer list from which smallest number to find</param>
        /// <returns>smallest number</returns>
        public static int FindSmallestNumberUsingSort(List<int> lst)
        {
            int smallestNum = 0;     
            lst.Sort();
            smallestNum = lst[0];
            return smallestNum;
        }

        /// <summary>
        /// Method to print the List
        /// </summary>
        /// <param name="lst">List </param>
        public static void PrintList(List<int> lst)
        {
            
            foreach (int val in lst)
            {
                Console.Write(val + ",");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Method to Sort the list without using the Sort method
        /// </summary>
        /// <param name="lst">Integer List to sort</param>
        /// <returns>Sorted list</returns>
        public static List<int> SortListAssending(List<int> lst)
        {           
            int temp = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                for (int j = i + 1; j < lst.Count; j++)
                {
                    if (lst[i] > lst[j])
                    {
                        temp = lst[i];
                        lst[i] = lst[j];
                        lst[j] = temp;
                    }
                }
            }            
            return lst;
        }
        /// <summary>
        /// Method to find the smallest  number from unsorted list
        /// </summary>
        /// <param name="lst">Integer list</param>
        /// <returns>smallest number</returns>
        public static int FindSmallestNumber(List<int> lst)
        {
            List<int> sortedList = SortListAssending(lst);
            return sortedList[0];   
        }
        public static int FindNthSmallestNumber(List<int> lst, int index)
        {
            int smallestNum = 0;
            List<int> sortedList = SortListAssending(lst);
            if (index <= lst.Count)
            {
                smallestNum = sortedList[index - 1];
            }
            return smallestNum;
        }
    }
}
