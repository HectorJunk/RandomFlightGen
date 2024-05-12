using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DomainModel
{
	public class Repository
	{
		public List<Country> Countries;
		public List<Airport> Airports;
		public List<Continent> Continents;
		public List<AirportType> AirportTypes;
		public List<Runway> Runways;

		/// <summary>
		/// All Data Access
		/// </summary>
		/// <param name="dataFileLocation">Folder containing raw CSV data files</param>
		public Repository(string dataFileLocation)
		{
			Countries = GetCountries(dataFileLocation + "\\countries.csv");
			Runways = GetRunways(dataFileLocation + "\\runways.csv");
			Airports = GetAirports(dataFileLocation + "\\airports.csv");
			Continents = GetContinents();
			AirportTypes = GetAirportTypes();
		}

		/// <summary>
		/// Get all countries
		/// </summary>
		/// <param name="continent">Only get contries in continent</param>
		/// <returns></returns>
		public List<Country> Get_Countries(string continent = "")
		{
			return Countries.Where(country => continent == string.Empty || country.Continent == continent).OrderBy(order => order.Name).ToList();
		}

		public List<Airport> Get_Airports(string continent="", string country = "", List<AirportType> atypes = null)
		{
			return Airports.Where(a =>
				((continent == string.Empty || a.Continent == continent) &&
				(country == string.Empty || a.Iso_Country == country)) &&
				atypes.Any(atl => a.A_Type == atl.AType) == true).ToList();
		}

		/// <summary>
		/// Get Airport with ICAO code
		/// </summary>
		/// <param name="icao"></param>
		/// <returns></returns>
		public Airport Get_Airport(string icao)
		{
			var airport = Airports.Where(a => a.Ident == icao).SingleOrDefault();
			airport.Runways = Runways.Where(r => r.Airport_Ident == icao).ToList();
			return airport;
		}

		public List<Runway> Get_Runways_For_Airport(string icao)
		{
			return Runways.Where(r => r.Airport_Ident == icao).ToList();
		}

		public List<Airport> GetMatchingAirports(string continent, int fromDist, int toDist, Airport departAirport, List<AirportType> airportTypes)
		{
			var query = Airports.Where(a => a.Continent == continent && a.Ident != departAirport.Ident);
			if (fromDist > 0)
			{
				query = query.Where(a => Shared.GetDistanceInNM(departAirport.Coordinate, a.Coordinate) >= fromDist);
			}
			if (toDist > 0)
			{
				query = query.Where(a => Shared.GetDistanceInNM(departAirport.Coordinate, a.Coordinate) <= toDist);
			}
			if (airportTypes != null)
			{
				query = query.Where(a => airportTypes.Any(atl => a.A_Type == atl.AType));
			}

			return query.ToList();
		}

		/// <summary>
		/// Get CSV Fields from line
		/// </summary>
		/// <param name="sr">Line of CSV</param>
		/// <returns>list of fields</returns>
		public List<string> GetCSVFields(string csvLine)
		{
			int index = 0, index2;
			List<string> fieldList = new List<string>();

			while (index < csvLine.Length)
			{
				if (csvLine.Substring(index, 1) == "\"")      //Quoted value
				{
					index2 = (csvLine + ",").IndexOf("\",", index + 1);     //Find end quote, ignore escaped double quote
					fieldList.Add(csvLine.Substring(index + 1, index2 - index - 1));
					index = index2 + 2; //Skip end quote and next ,
				}
				else if (csvLine.Substring(index, 1) == ",")
				{
					fieldList.Add(null);
					index++;
				}
				else
				{
					index2 = csvLine.IndexOf(',', index + 1);
					if (index2 < 0)
						index2 = csvLine.Length;
					fieldList.Add(csvLine.Substring(index, index2 - index));
					index = index2 + 1;
				}
			}
			fieldList.Add(null);  //Add a null to list in case last field is empty

			return fieldList;
		}


		//PRIVATES

		private List<Country> GetCountries(string file)
		{
			StreamReader sr = new StreamReader(file);
			sr.ReadLine();   //Skip Header Line

			List<Country> countryList = new List<Country>();

			while (true)
			{
				string csvLine = sr.ReadLine();
				if (string.IsNullOrEmpty(csvLine))
					break;

				List<string> countryFields = GetCSVFields(csvLine);
				var country = new Country
				{
					Orig_Id = Convert.ToInt32(countryFields[0]),
					Code = countryFields[1],
					Name = countryFields[2],
					Continent = countryFields[3],
					Wiki_Link = countryFields[4],
					Keywords = countryFields[5]
				};
				countryList.Add(country);
			}
			sr.Close();

			return countryList;
		}

		private List<Airport> GetAirports(string file)
		{
			StreamReader sr = new StreamReader(file);
			sr.ReadLine();   //Skip Header Line

			List<Airport> airports = new List<Airport>();

			while (true)
			{
				string csvLine = sr.ReadLine();
				if (string.IsNullOrEmpty(csvLine))
					break;

				List<string> airportFields = GetCSVFields(csvLine);
				string airport_id = airportFields[1];
				var airport = new Airport
				{
					Orig_Id = Convert.ToInt32(airportFields[0]),
					Ident = airport_id,
					A_Type = airportFields[2],
					Name = airportFields[3],
					Latitude_Deg = Convert.ToDouble(airportFields[4]),
					Longitude_Deg = Convert.ToDouble(airportFields[5]),
					Elevation = string.IsNullOrEmpty(airportFields[6]) ? 0 : Convert.ToInt32(airportFields[6]),
					Continent = airportFields[7],
					Iso_Country = airportFields[8],
					Iso_Region = airportFields[9],
					Municipality = airportFields[10],
					Scheduled_Service = !string.IsNullOrEmpty(airportFields[11]) && airportFields[11] == "yes",
					Gps_Code = airportFields[12],
					Iata_Code = airportFields[13],
					Local_Code = airportFields[14],
					Home_Link = airportFields[15],
					Wiki_Link = airportFields[16],
					Keywords = airportFields[17]
				};
				airports.Add(airport);
			}
			sr.Close();

			return airports;
		}

		private List<Continent> GetContinents()
		{
			List<Continent> continents = new List<Continent>
			{
				new Continent { Code = "AF", Name = "Africa" },
				new Continent { Code = "AN", Name = "Antarctic" },
				new Continent { Code = "AS", Name = "Asia" },
				new Continent { Code = "EU", Name = "Europe" },
				new Continent { Code = "NA", Name = "North America" },
				new Continent { Code = "SA", Name = "South America" },
				new Continent { Code = "OC", Name = "Oceania" }
			};
			return continents;
		}

		private List<AirportType> GetAirportTypes()
		{
			List<AirportType> atypes = new List<AirportType>
			{
				new AirportType { Id = 1, AType = "small_airport" },
				new AirportType { Id = 2, AType = "medium_airport" },
				new AirportType { Id = 3, AType = "large_airport" },
				new AirportType { Id = 4, AType = "heliport" },
				new AirportType { Id = 5, AType = "seaplane_base" },
				new AirportType { Id = 6, AType = "balloonport" },
				new AirportType { Id = 7, AType = "closed" }
			};
			return atypes;
		}

		private List<Runway> GetRunways(string file)
		{
			StreamReader sr = new StreamReader(file);
			sr.ReadLine();   //Skip Header Line

			List<Runway> runways = new List<Runway>();

			while (true)
			{
				string csvLine = sr.ReadLine();
				if (string.IsNullOrEmpty(csvLine))
					break;

				List<string> runwayFields = GetCSVFields(csvLine);
				var runway = new Runway
				{
					Id = Convert.ToInt32(runwayFields[0]),
					Airport_Ref = Convert.ToInt32(runwayFields[1]),
					Airport_Ident = runwayFields[2],
					Length_Ft = Convert.ToInt32(runwayFields[3]),
					Width_Ft = Convert.ToInt32(runwayFields[4]),
					Surface = runwayFields[5],
					Lit = runwayFields[6] == "1",
					Closed = runwayFields[7] == "1",

					Runway_Le = new RunwayEnd
					{
						Ident = runwayFields[8],
						Latitude_deg = string.IsNullOrEmpty(runwayFields[9]) ? (double?)null : Convert.ToDouble(runwayFields[9]),
						Longitude_deg = string.IsNullOrEmpty(runwayFields[10]) ? (double?)null : Convert.ToDouble(runwayFields[10]),
						Elevation_ft = string.IsNullOrEmpty(runwayFields[11]) ? (int?)null : Convert.ToInt32(runwayFields[11]),
						Heading_deg = string.IsNullOrEmpty(runwayFields[12]) ? (float?)null : Convert.ToSingle(runwayFields[12]),
						Displaced_threshold_ft = string.IsNullOrEmpty(runwayFields[13]) ? (int?)null : Convert.ToInt32(runwayFields[13])
					},

					Runway_He = new RunwayEnd
					{
						Ident = runwayFields[14],
						Latitude_deg = string.IsNullOrEmpty(runwayFields[15]) ? (double?)null : Convert.ToDouble(runwayFields[15]),
						Longitude_deg = string.IsNullOrEmpty(runwayFields[16]) ? (double?)null : Convert.ToDouble(runwayFields[16]),
						Elevation_ft = string.IsNullOrEmpty(runwayFields[17]) ? (int?)null : Convert.ToInt32(runwayFields[17]),
						Heading_deg = string.IsNullOrEmpty(runwayFields[18]) ? (float?)null : Convert.ToSingle(runwayFields[18]),
						Displaced_threshold_ft = string.IsNullOrEmpty(runwayFields[19]) ? (int?)null : Convert.ToInt32(runwayFields[19])
					}
				};
				runways.Add(runway);
			}
			sr.Close();

			return runways;
		}
	}
}
