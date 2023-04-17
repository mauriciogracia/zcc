// See https://aka.ms/new-console-template for more information

using System.Numerics;

CitiesList cities = new CitiesList();

cities.populateMongoDB("./data/ZipCodes.csv");
Console.WriteLine("City DB ready");

string ?zipOrigin;
string ?zipDestination;
string ?continueCalc;

do
{
    Console.WriteLine("Zip Code Distance Calculation");

    zipOrigin = ReadZipCode("From:");
    zipDestination = ReadZipCode("To:");


    Console.WriteLine(cities.CalculateDistance(zipOrigin, zipDestination));
    Console.WriteLine("Continue (y/n)?");
    continueCalc = Console.ReadLine();
} while (!string.IsNullOrEmpty(continueCalc) && continueCalc.ToUpper().Equals("Y"));


static string ReadZipCode(string message)
{
    string ?zip;
    long n;

    do
    {
        Console.WriteLine(message);
        zip = Console.ReadLine();
    } while (string.IsNullOrEmpty(zip) || !long.TryParse(zip, out n));

    return zip;
}
