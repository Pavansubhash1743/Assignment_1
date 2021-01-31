using System;
using System.Collections.Generic;
using System.Linq;

namespace Pavan
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Question 1
                Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
                int n = Convert.ToInt32(Console.ReadLine());
                PrintTriangle(n);
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid Integer from 1 to N");
            }
            try
            {
                //Question 2:
                Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
                int n2 = Convert.ToInt32(Console.ReadLine());
                PrintPellSeries(n2);
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Enter a valid Integer from 1 to N");
            }
            try
            {
                //Question 3:
                Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
                int n3 = Convert.ToInt32(Console.ReadLine());
                bool flag = SquareSums(n3);
                if (flag)
                {
                    Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
                }
                else
                {
                    Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
                }
            }
            catch
            {
                Console.WriteLine("Enter a valid Integer from 1 to N");
            }
            //Question 4:
            int[] arr = new int[] { 1, 3, 1, 5, 4 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = DiffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);
            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5:The number of unique emails is " + ans5);
            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" }, { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6:Destination city is " + destination);
        }
        private static void PrintTriangle(int n)
        {
            try
            {
                if (n > 0)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        for (int j = 1; j <= n - i; j++)
                        {       //printing spaces
                            Console.Write(" ");
                        }
                        for (int l = 1; l <= 2 * i - 1; l++)
                        {       //printing stars
                            Console.Write("*");
                        }
                        Console.Write("\n");
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a Postive integer");
            }
        }
        private static void PrintPellSeries(int n2)
        {
            try
            {
                if (n2 > 0)
                {
                    int a = 0;
                    int b = 1;
                    int c;
                    if (n2 == 1)
                    {
                        Console.WriteLine(a);
                    }
                    else
                    {           //printing the 2 items of series
                        Console.WriteLine(a + b);
                    }
                    for (int i = 2; i <= n2; i++)
                    {
                        c = (2 * b) + a;        //printing the req series
                        Console.WriteLine(c + " ");
                        a = b;
                        b = c;
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a  valid number");
            }
        }
        private static bool SquareSums(int n3)
        {
            try
            {
                if (n3 > 0)
                {
                    for (int a = 0; a <= n3; a++)
                    {
                        for (int b = 0; b <= n3; b++)
                        {
                            int sum = a * a + b * b;
                            //Checking whether Sum is equal to given number
                            if (sum == n3)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a Valid integer from 1 to N");
                throw;
            }
        }
        private static int DiffPairs(int[] nums, int k)
        {
            try
            {
                HashSet<int> hs = new HashSet<int>();
                HashSet<int> repeat = new HashSet<int>();
                if (k < 0)
                    return 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (hs.Contains(nums[i]))       //checking for number
                        repeat.Add(nums[i]);
                    else
                        hs.Add(nums[i]);
                }
                int count = 0;
                foreach (int val in hs)
                {
                    if (hs.Contains(val + k))
                        count++;
                }
                if (k == 0)
                {               //counting the pairs
                    return repeat.Count;
                }
                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }
        }
        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                var hasSet = new HashSet<string>();
                foreach (var email in emails)
                {
                    var splitName = email.Split('@');       //splitting the email
                    var localName = splitName[0];
                    var domainName = splitName[1];
                    localName = localName.Replace(".", "");//replacing char "."
                    if (localName.Contains('+'))        //removing the chars after "+"
                    {
                        localName = localName.Split('+')[0];
                        localName = localName.TrimEnd();        //trimming the mail
                    }
                    hasSet.Add(localName + "@" + domainName);
                }
                return hasSet.Count;        //counting unique pairs
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        private static string DestCity(string[,] paths)
        {
            try
            {
                List<string> source = new List<string>();
                List<string> dest = new List<string>();
                int i = 0;
                foreach (string c in paths)
                {
                    //Splitting into destination and source from all cities
                    if ((i % 2) != 0)
                    {
                        dest.Add(c);
                        i++;            //copying into dest list
                    }

                    else if (i % 2 == 0)
                    {
                        source.Add(c);
                        i++;        //copying into source list

                    }


                }

                foreach (string d in dest)
                { //Checking for dest city in source city list
                    if (source.Contains(d) == false)
                    {
                        string final = d;
                        return final;

                    }
                }
                return "";

            }
            catch (Exception e)
            {

                Console.WriteLine("Invalid route" + e.Message);
                throw;
            }
        }
    }
}
