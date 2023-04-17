using System;


namespace CoreConsole
{
    /// <summary>
    /// This is  the main console, that uses the ZipCodeCore .NET 2.0 library for the distance calculation
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to Docker mongoDB...");
            CitiesList cities = new CitiesList();
            Console.WriteLine("City DB ready");

            string zipOrigin;
            string zipDestination;
            string continueCalc;

            do
            {
                Console.WriteLine("Zip Code Distance Calculation");

                zipOrigin = ReadZipCode("From:");
                zipDestination = ReadZipCode("To:");


                Console.WriteLine(cities.CalculateDistance(zipOrigin, zipDestination));
                Console.WriteLine("Continue (y/n)?");
                continueCalc = Console.ReadLine();
            } while (!string.IsNullOrEmpty(continueCalc) && continueCalc.ToUpper().Equals("Y"));

        }
        /// <summary>
        /// Methods that validates that the entered zipcode is not empty and is numeric
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static string ReadZipCode(string message)
        {
            long n;
            string zip;

            do
            {
                Console.WriteLine(message);
                zip = Console.ReadLine();
            } while (string.IsNullOrEmpty(zip) || !long.TryParse(zip, out n));

            return zip;
        }

    }
}



