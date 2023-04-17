using System;

namespace ZipCodeCalculation
{
    // calculate distance Between Two Points on Earth
    // Taken from - https://www.geeksforgeeks.org/program-distance-two-points-earth/ - is contributed by / Manish Shaw(manishshaw1) to 
    // The code has been improved by MGG to allow KM and Miles calculation
    class DistanceCalculator
    {
        static double earthRadiusKM = 6371;
        static double earthRadiusMiles = 3956;

        static double toRadians(double angleIn10thofaDegree)
        {
            // Angle in 10th  of a degree
            return (angleIn10thofaDegree *
                        Math.PI) / 180;
        }

        public static double CalculateInMiles(double lat1, double lat2, double lon1, double lon2)
        {
            return Calculate(lat1, lat2, lon1, lon2,earthRadiusMiles);
        }

        public static double CalculateInKilometers(double lat1, double lat2, double lon1, double lon2)
        {
            return Calculate(lat1, lat2, lon1, lon2, earthRadiusKM);
        }
        private static double Calculate(
            double lat1,
            double lat2,
            double lon1,
            double lon2,
            double earthRadius)
        {

            lon1 = toRadians(lon1);
            lon2 = toRadians(lon2);
            lat1 = toRadians(lat1);
            lat2 = toRadians(lat2);

            // Haversine formula
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Pow(Math.Sin(dlon / 2), 2);

            double dist = 2 * Math.Asin(Math.Sqrt(a)) * earthRadius;

            return dist;
        }
    }
}
