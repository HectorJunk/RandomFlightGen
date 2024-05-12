using System.Device.Location;

namespace DomainModel
{
	public static class Shared
	{
		/// <summary>
		/// Get Distance between 2 coordinates
		/// </summary>
		/// <param name="lat1">Latitude1 degrees</param>
		/// <param name="lon1">Longitude1 degrees</param>
		/// <param name="lat2">Latitide2 degrees</param>
		/// <param name="lon2">Longitude2 degrees</param>
		/// <returns>Distance in Nautical Miles</returns>
		/// <remarks>
		/// Test with 	var result = Shared.GetDistanceInNM(-37.0080986, 174.7920074, -41.32720184, 174.8049927);
		/// Should = 259.54 (Distance between Auckland (NZAA) and Wellington (NZWN)
		/// </remarks>
		public static double GetDistanceInNM(double lat1, double lon1, double lat2, double lon2)
		{
			var sCoord = new GeoCoordinate(lat1, lon1);
			var eCoord = new GeoCoordinate(lat2, lon2);

			return sCoord.GetDistanceTo(eCoord) / 1852;		//1KM = 1.852 NM
		}

		/// <summary>
		/// Get Distance between 2 coordinates
		/// </summary>
		/// <returns>Distance in Nautical Miles</returns>
		public static double GetDistanceInNM(GeoCoordinate sCoord, GeoCoordinate eCoord)
		{
			return sCoord.GetDistanceTo(eCoord) / 1852;		//1KM = 1.852 NM
		}

		/// <summary>
		/// Convert Airport Type to full name
		/// </summary>
		/// <param name="airport_type"></param>
		/// <returns></returns>
		public static string AirportTypeName(string airport_type)
		{
			switch (airport_type)
			{
				case "balloonport":
					return "Balloon Port";
				case "small_airport":
					return "Small Airport";
				case "medium_airport":
					return "Medium Airport";
				case "large_airport":
					return "Large Airport";
				case "seaplane_base":
					return "Seaplane Base";
				default:
					return airport_type.Substring(0, 1).ToUpper() + airport_type.Substring(1);
			}
		}
	}
}
