// See https://aka.ms/new-console-template for more information

CitiesList cities = new CitiesList();

cities.load("./data/ZipCodes.csv");
//cities.show(); debug data loading

string ?zipOrigin;
string ?zipDestination;
string ?continueCalc;

do
{
    Console.WriteLine("Zip Code Distance Calculation");

    do
    {
        Console.WriteLine("From:");
        zipOrigin = Console.ReadLine();
    } while (string.IsNullOrEmpty(zipOrigin));

    do
    {
        Console.WriteLine("To:");
        zipDestination = Console.ReadLine();
    } while (string.IsNullOrEmpty(zipDestination));

    Console.WriteLine(cities.CalculateDistance(zipOrigin, zipDestination));
    Console.WriteLine("Continue ?");
    continueCalc = Console.ReadLine();
} while (!string.IsNullOrEmpty(continueCalc) && continueCalc.ToUpper().Equals("Y"));
