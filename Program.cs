// See https://aka.ms/new-console-template for more information

CitiesList cities = new CitiesList();

cities.load("./data/ZipCodes.csv");
//cities.show(); debug data loading

string zipOrigin;
string zipDestination;

zipOrigin = "92801";
zipDestination = "92649";

Console.WriteLine(cities.CalculateDistance(zipOrigin, zipDestination));
