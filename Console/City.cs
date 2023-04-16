using System.Text;

/// <summary>
/// Represents a city data parse from the CSV file
/// </summary>
public class City {
    public string zipCode = String.Empty ;
    public double latitude ;
    public double longitude ;
    public string name = String.Empty;


    /// <summary>
    /// Converts the city data ToString (Override)
    /// </summary>
    /// <returns></returns>
    public override string ToString() {
        StringBuilder sb = new StringBuilder();

        sb.Append(name);
        sb.Append(",");
        sb.Append(latitude);
        sb.Append(",");
        sb.Append(longitude);
        sb.Append(",");
        sb.Append(zipCode);

        return sb.ToString();
    }

}