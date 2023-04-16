using System.Xml.Linq;
using ZipCodeCalculation;
/// <summary>
/// Represents the list of city, that is loaded and used for calculations
/// </summary>
public class CitiesList {
    private List<City> cities = new List<City>();

    /// <summary>
    /// Load the CSV into a list of cities
    /// </summary>
    /// <param name="path">Path to the CSV file</param>
    /// <returns></returns>
    public bool load(string path) {
        bool success = false;

        try
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                //Read the header and ignore it
                string ?line = reader.ReadLine();

                while (line != null)
                {
                    line = reader.ReadLine();
                    City? city = parseLine(line);

                    if (city != null)
                    {
                        cities.Add(city);
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
    private City? parseLine(string ?line) {
        City? city = null;

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
                Console.Error.WriteLine(String.Format("wrong city data: {0}", line));
            }
        }

        return city ;
    }

    public City? GetCityByZipCode(string zipCode)
    {
        City ?c = cities.FirstOrDefault(c => c.zipCode.Equals(zipCode));

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
        string resp = "One of the zipcode does not exist in ZipCodes.csv";
        City ?city1;
        City ?city2;

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

    /// <summary>
    /// Shows the information of the loaded cities on the console
    /// </summary>
    public void show()
    {
        foreach (City c in cities)
        {
            Console.WriteLine(c);
        }
        Console.WriteLine(String.Format("# of cities:{0}", cities.Count)) ;
    }


}
