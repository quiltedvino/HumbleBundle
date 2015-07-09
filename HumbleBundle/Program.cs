using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbleBundle
{
    class Program
    {
        static void Main(string[] args)
        {

            int totalCustomerCount, eliteCustomerCount, rationalCustomerCount, thriftyCustomerCount, scumbagCustomerCount, customerType = 0;
            int[] customerTypes = { 6, 350, 700 };
            double totalRevenue;
            double currentAverage;
            FileStream fs = new FileStream("output.csv", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            Console.SetOut(sw);

            const int totalPurchases = 50000;
            Random r = new Random();

            Console.Write("Revenue,Average,Elite,%,Rational,%,Thrifty,%,Scumbag,%,Total, %");
            Console.WriteLine();

            for (int i = 0; i < 1000; i++)
            {
                totalCustomerCount = 0;
                eliteCustomerCount = 0;
                rationalCustomerCount = 0;
                thriftyCustomerCount = 0;
                scumbagCustomerCount = 0;
                customerType = 0;
                totalRevenue = 1;
                currentAverage = 1;

                for (totalCustomerCount = 1; totalCustomerCount <= totalPurchases; totalCustomerCount++)
                {
                    // determine what kind of user we are working with
                    customerType = r.Next(1, 1000);

                    if ((customerType <= customerTypes[0]) || (totalCustomerCount <7))
                    {
                        totalRevenue += (totalCustomerCount % 50) + 100;
                        eliteCustomerCount++;
                    }
                    else if (customerType <= customerTypes[1])
                    {
                        totalRevenue += 12;
                        rationalCustomerCount++;
                    }
                    else if (customerType <= customerTypes[2])
                    {
                        totalRevenue += Math.Round(currentAverage + 0.01, 2);
                        thriftyCustomerCount++;
                    }
                    else
                    {
                        totalRevenue += 1;
                        scumbagCustomerCount++;
                    }

                    currentAverage = Math.Round(totalRevenue / totalCustomerCount, 2);
                }
                

                Console.Write(Math.Round(totalRevenue, 2));
                Console.Write(',');
                Console.Write(currentAverage);
                Console.Write(',');
                Console.Write(eliteCustomerCount);
                Console.Write(',');
                Console.Write(Math.Round(((double)eliteCustomerCount / totalCustomerCount) * 100, 2));
                Console.Write(',');
                Console.Write(rationalCustomerCount);
                Console.Write(',');
                Console.Write(Math.Round(((double)rationalCustomerCount / totalCustomerCount) * 100, 2));
                Console.Write(',');
                Console.Write(thriftyCustomerCount);
                Console.Write(',');
                Console.Write(Math.Round(((double)thriftyCustomerCount / totalCustomerCount) * 100, 2));
                Console.Write(',');
                Console.Write(scumbagCustomerCount);
                Console.Write(',');
                Console.Write(Math.Round(((double)scumbagCustomerCount / totalCustomerCount) * 100, 2));
                Console.Write(',');
                Console.Write(totalCustomerCount);
                Console.Write(',');
                Console.Write(Math.Round(((double)totalCustomerCount / totalCustomerCount) * 100, 2));
                Console.Write(',');
                Console.Write(Environment.NewLine);
            }
        }

    }
}