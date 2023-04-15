// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

CitiesList cities = new CitiesList();

cities.load("./data/ZipCodes.csv");
cities.show();
