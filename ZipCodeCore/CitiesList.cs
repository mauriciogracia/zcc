using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.IO;
using System.Xml.Linq;
using ZipCodeCalculation;
/// <summary>
/// Represents the list of city, that is loaded and used for calculations
/// </summary>
public class CitiesList {
    public IMongoCollection<City> Cities { get; set; }
    MongoClient client = new MongoClient("mongodb://localhost:27017");

    /// <summary>
    /// Load the CSV into a list of cities
    /// </summary>
    /// <param name="path">Path to the CSV file</param>
    /// <returns></returns>
    public bool prepareMongoDB() {
        bool success = false;
        string path = "./data/ZipCodes.csv";

        try
        {
            var database = client.GetDatabase("GeeksArrayStore");
            this.Cities = database.GetCollection<City>("Cities");

            //If the collection is empty populate it with the CSV file
            if (!this.Cities.AsQueryable().Any()) {
                FileStream fileStream = new FileStream(path, FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    //Read the header and ignore it
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        line = reader.ReadLine();
                        City city = ParseLine(line);

                        if (city != null)
                        {
                            Cities.InsertOne(city);
                        }
                    }
                }
            }
            success= true;
        }
        catch (Exception e) 
        {
            //log the error
            Console.Error.WriteLine(e);
        }

        return success ;
    }

    /// <summary>
    /// Parse a single line from the CSV file and create a City instance
    /// </summary>
    /// <param name="line">The line read</param>
    /// <returns></returns>
    private City ParseLine(string line) {
        City city = null;

        if (line != null)
        {
            string[] parts = line.Split(',');

            if (parts.Length >= 4)
            {
                city = new City
                {
                    zipCode = parts[0],
                    latitude = Double.Parse(parts[1]),
                    longitude = Double.Parse(parts[2]),
                    name = parts[3]
                };

                //Some city names have "," on its name we need to concatenate that into a single city name
                if (parts.Length > 4)
                {
                    for (int i = 4; i < parts.Length; i++)
                    {
                        city.name += parts[i];
                    }
                }
            }
            else
            {
                Console.Error.WriteLine(string.Format("wrong city data: {0}", line));
            }
        }

        return city ;
    }

    /// <summary>
    /// Find the City in the cities collection by zipcode
    /// </summary>
    /// <param name="zipCode"></param>
    /// <returns></returns>
    public City GetCityByZipCode(string zipCode)
    {
        var filter = Builders<City>.Filter.Eq("zipCode", zipCode);
        City c = this.Cities.Find(filter).FirstOrDefault();

        return c;
    }

    /// <summary>
    /// Calculate the distance in miles between two zip codes 
    /// </summary>
    /// <param name="zipOrig"></param>
    /// <param name="zipDest"></param>
    /// <returns></returns>
    public string CalculateDistance(string zipOrig, string zipDest)
    {
        string resp = "One of the zipcode does not exist in the CITIES database";
        City city1;
        City city2;

        city1 = GetCityByZipCode(zipOrig);

        if(city1 != null)
        {
            city2 = GetCityByZipCode(zipDest);

            if (city2 != null)
            {
                //Calculate distance in MILES
                var d = DistanceCalculator.CalculateInMiles(city1.latitude, city2.latitude, city1.longitude, city2.longitude);

                //The distance between Anaheim (92801) to Huntington Beach (92649) is 10.307 miles
                resp = String.Format("The distance between {0} ({1}) to {2} ({3}) is {4}", city1.name, zipOrig, city2.name, zipDest, d);
            }
        }

        return resp;
    }



}
