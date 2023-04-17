using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text;

/// <summary>
/// Represents a city data, both from the CSV and the Mongo Collection
/// </summary>
public class City {
    [BsonId]
    public string zipCode = String.Empty ;
    
    [BsonElement("latitude")]
    public double latitude ;

    [BsonElement("longitude")]
    public double longitude ;

    [BsonElement("name")]
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