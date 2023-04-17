// See https://aka.ms/new-console-template for more information

using System.Numerics;

CitiesList cities = new CitiesList();

cities.populateMongoDB("./data/ZipCodes.csv");
Console.WriteLine("City DB ready");

string ?zipOrigin;
string ?zipDestination;
string ?continueCalc;
long n;
do
{
    Console.WriteLine("Zip Code Distance Calculation");

    do
    {
        Console.WriteLine("From:");
        zipOrigin = Console.ReadLine();
    } while (string.IsNullOrEmpty(zipOrigin) || !long.TryParse(zipOrigin, out n));

    do
    {
        Console.WriteLine("To:");
        zipDestination = Console.ReadLine();
    } while (string.IsNullOrEmpty(zipDestination) || !long.TryParse(zipOrigin, out n));

    Console.WriteLine(cities.CalculateDistance(zipOrigin, zipDestination));
    Console.WriteLine("Continue ?");
    continueCalc = Console.ReadLine();
} while (!string.IsNullOrEmpty(continueCalc) && continueCalc.ToUpper().Equals("Y"));
