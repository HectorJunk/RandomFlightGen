using System.Collections.Generic;
using System.Device.Location;

namespace DomainModel
{
	public class Country
	{
		public int Orig_Id { get; set; }    //Original ID
		public string Code { get; set; }
		public string Name { get; set; }
		public string Continent { get; set; }   //Continent Code
		public string Wiki_Link { get; set; }
		public string Keywords { get; set; }
	}

	public class Airport
	{
		public int Orig_Id { get; set; }
		public string Ident { get; set; }
		/// <summary>
		/// Airport Type
		/// </summary>
		public string A_Type { get; set; }
		public string Name { get; set; }
		public double Latitude_Deg { get; set; }
		public double Longitude_Deg { get; set; }
		public int Elevation { get; set; }
		public string Continent { get; set; }
		public string Iso_Country { get; set; }
		public string Iso_Region { get; set; }
		public string Municipality { get; set; }
		public bool Scheduled_Service { get; set; }
		public string Gps_Code { get; set; }
		public string Iata_Code { get; set; }
		public string Local_Code { get; set; }
		public string Home_Link { get; set; }
		public string Wiki_Link { get; set; }
		public string Keywords { get; set; }

		public List<Runway> Runways { get; set; }

		public GeoCoordinate Coordinate
		{
			get { return new GeoCoordinate(Latitude_Deg, Longitude_Deg); }
		}
	}

	public class Continent
	{
		public string Code { get; set; }
		public string Name { get; set; }
	}

	public class AirportType
	{
		public int Id { get; set; }

		/// <summary>
		/// Airport Type string as defined in Airports.csv (i.e. small_airport)
		/// </summary>
		public string AType { get; set; }

		/// <summary>
		/// Full Name (i.e. Small Airport)
		/// </summary>
		public string Description
		{
			get { return Shared.AirportTypeName(AType); }
		}
	}

	public class RunwayEnd
	{
		public string Ident { get; set; }
		public double? Latitude_deg { get; set; }
		public double? Longitude_deg { get; set; }
		public int? Elevation_ft { get; set; }
		public float? Heading_deg { get; set; }
		public int? Displaced_threshold_ft { get; set; }
	}

	public class Runway
	{
		public int Id { get; set; }
		public int Airport_Ref { get; set; }
		public string Airport_Ident { get; set; }
		public int Length_Ft { get; set; }
		public int Width_Ft { get; set; }
		public string Surface { get; set; }
		public bool Lit { get; set; }
		public bool Closed { get; set; }
		public RunwayEnd Runway_Le { get; set; }
		public RunwayEnd Runway_He { get; set; }
	}
}
