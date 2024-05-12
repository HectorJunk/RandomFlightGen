using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DomainModel;

namespace RandomFlightGen
{
	public partial class MainForm : Form
	{
		List<Country> Countries;
		List<Airport> Airports;
		readonly Repository repo = new Repository(Properties.Settings.Default.RawAirportDataLoc);
		/// <summary>
		/// Has finished initialising form
		/// </summary>
		bool Initialised;

		private readonly Random RndGen = new Random();

		public MainForm()
		{
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			Init();
		}

		private void Init()
		{
			lblDestMatches.Text = "";
			BuildContinentDropdown();
			BuildCountryDropdown();
			BuildAirportTypeChecklist();
			Airports = repo.Airports;
			Initialised = true;

			SetRandomAirport();
		}


		private void ButRandomCountry_Click(object sender, EventArgs e)
		{
			cbCountry.SelectedIndex = RndGen.Next(1, cbCountry.Items.Count);
		}

		/// <summary>
		/// Set Random Departure airport based on selected criteria
		/// </summary>
		private void SetRandomAirport()
		{
			var continent = GetSelectedContinentCode();
			var country = GetSelectedCountryCode();
			var atypes = GetSelectedAirportTypes();
			List<Airport> airports = repo.Get_Airports(continent, country, atypes);
			if (airports.Count > 0)
			{
				Airport airport = airports[RndGen.Next(0, airports.Count)];
				tbICAO.Text = airport.Ident;
				wbDep.DocumentText = BuildAirportInfo(airport);
			}
			else
			{
				tbICAO.Text = string.Empty;
				wbDep.DocumentText = "NO MATCH FOUND";
			}
			lblMatches.Text = $"{airports.Count} Matches Found";
		}

		private void SetRandomDestination()
		{
			int fromDist = string.IsNullOrEmpty(tbDistanceFrom.Text) ? 0 : Convert.ToInt32(tbDistanceFrom.Text);
			int toDist = string.IsNullOrEmpty(tbDistanceTo.Text) ? 0 : Convert.ToInt32(tbDistanceTo.Text);

			//We want to only find destinations in the same Continent as Departure
			var departAirport = repo.Get_Airport(tbICAO.Text);
			string continentCode = GetSelectedContinentCode();
			List<AirportType> airportTypes = GetSelectedAirportTypes();
			if (string.IsNullOrEmpty(continentCode))
			{
				continentCode = departAirport.Continent;
			}

			var airports = repo.GetMatchingAirports(continentCode, fromDist, toDist, departAirport, airportTypes);
			if (airports.Count > 0)
			{
				Airport airport = airports[RndGen.Next(0, airports.Count)];
				tbDestICAO.Text = airport.Ident;
				wbDest.DocumentText = BuildAirportInfo(airport, departAirport);
				lblDestMatches.Text = $"{airports.Count} Matches found";
			}
			else
			{
				wbDest.DocumentText = "NO MATCHES FOUND";
				tbDestICAO.Text = "";
				lblDestMatches.Text = "";
			}
		}

		private string BuildAirportInfo(Airport airport, Airport departAirport = null)
		{
			StringBuilder info = new StringBuilder("<style>table, th, td { border: 1px solid #cccccc; border-collapse: collapse; }</style>\r\n");
			info.Append($"{airport.Name}");
			if (!string.IsNullOrEmpty(airport.Municipality) && airport.Name.IndexOf(airport.Municipality) < 0)
			{
				info.Append($", {airport.Municipality}");
			}
			var country = Countries.Where(c => c.Code == airport.Iso_Country).FirstOrDefault();
			if (country != null)
			{
				info.Append($", {country.Name}");
			}
			if (departAirport != null)
			{
				var distance = Shared.GetDistanceInNM(departAirport.Coordinate, airport.Coordinate);
				info.AppendFormat("<br /><b>Distance:</b> {0:0} NM", distance);
			}
			info.Append($"<br /><b>Type:</b> {Shared.AirportTypeName(airport.A_Type)}");
			airport.Runways = repo.Get_Runways_For_Airport(airport.Ident);
			if (airport.Runways.Count > 0)
			{
				info.Append("<br /><b>Runways:</b><br /><table style=\"border: 1px solid #cccccc;\"><tr><th>Numbers</th><th>Surface</th><th>Length Ft</th><th>Width Ft</th></tr>");
				foreach (var runway in airport.Runways)
				{
					info.Append($"<tr><td>{runway.Runway_Le.Ident}/{runway.Runway_He.Ident}</td><td>{runway.Surface}</td><td>{runway.Length_Ft}</td><td>{runway.Width_Ft}</td></tr>");
				}
				info.Append("</table>");
			}
			return info.ToString();
		}

		private void CbContinent_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialised) {
				BuildCountryDropdown(GetSelectedContinentCode());
				SetRandomAirport();
			}
		}

		private string GetSelectedContinentCode()
		{
			string selected_code = string.Empty;
			if (cbContinent.SelectedIndex > 0)
			{
				dynamic selected_item = (dynamic)cbContinent.SelectedItem;  //Because SelectedItem is an anonymous type
				selected_code = selected_item.Code;
			}

			return selected_code;
		}

		private string GetSelectedCountryCode()
		{
			string selected_code = string.Empty;
			if (cbCountry.SelectedIndex > 0)
			{
				dynamic selected_item = (dynamic)cbCountry.SelectedItem;  //Because SelectedItem is an anonymous type
				selected_code = selected_item.Code;
			}

			return selected_code;
		}

		private List<AirportType> GetSelectedAirportTypes()
		{
			List<AirportType> checkedList = new List<AirportType>();
			List<AirportType> allTypes = repo.AirportTypes;
			foreach (var item in clbAirportTypes.CheckedItems)
			{
				checkedList.Add(allTypes.Where(at => at.Description == item.ToString()).Single());
			}

			return checkedList;
		}

		private void BuildCountryDropdown(string continent = "")
		{
			cbCountry.Items.Clear();
			cbCountry.DisplayMember = "name";
			cbCountry.ValueMember = "code";
			cbCountry.Items.Add(new { code = "", name = "ANY" });
			cbCountry.SelectedIndex = 0;

			Countries = repo.Get_Countries(continent);

			foreach (var country in Countries)
			{
				cbCountry.Items.Add(new { country.Code, country.Name });
			}
		}

		private void BuildContinentDropdown()
		{
			cbContinent.DisplayMember = "name";
			cbContinent.ValueMember = "code";
			cbContinent.Items.Add(new { code = "", name = "ANY" });
			cbContinent.SelectedIndex = 0;

			foreach (var continent in repo.Continents)
			{
				cbContinent.Items.Add(new { continent.Code, continent.Name });
			}
		}

		private void BuildAirportTypeChecklist()
		{
			/*
			cbAirportType.Items.Add("ANY");

			foreach (var atype in repo.AirportTypes)
			{
				cbAirportType.Items.Add(atype.Description);
			}

			cbAirportType.SelectedIndex = 0;
			*/
			foreach (var atype in repo.AirportTypes)
			{
				clbAirportTypes.Items.Add(atype.Description);
			}
			//Default small,medium and large selected
			clbAirportTypes.SetItemChecked(0, true);
			clbAirportTypes.SetItemChecked(1, true);
			clbAirportTypes.SetItemChecked(2, true);
		}

		private void CbCountry_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetRandomAirport();
		}

		private void ButRandomAirport_Click(object sender, EventArgs e)
		{
			SetRandomAirport();
		}

		private void ButRandomDest_Click(object sender, EventArgs e)
		{
			SetRandomDestination();
		}

		private void TBICAO_KeyUp(object sender, KeyEventArgs e)
		{
			var t = tbICAO.Text;
			var airport = repo.Get_Airport(t);
			if (airport != null)
			{
				tbICAO.Text = airport.Ident;
				wbDep.DocumentText = BuildAirportInfo(airport);
			}
			else
			{
				wbDep.DocumentText = "NO MATCH FOUND";
			}
		}

		private void CLB_AirportTypes_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			/*
			//Because ItemCheck is invoked before item is actually ticked we need to use this for delayed execution
			//pity MS didn't add a ItemChecked method
			this.BeginInvoke((MethodInvoker)(
			() => SetRandomAirport()));
			*/
		}

		private void TB_DestICAO_KeyUp(object sender, KeyEventArgs e)
		{
			var t = tbDestICAO.Text;
			var airport = repo.Get_Airport(t);
			if (airport != null)
			{
				tbDestICAO.Text = airport.Ident;
				wbDest.DocumentText = BuildAirportInfo(airport);
			}
			else
			{
				wbDest.DocumentText = string.Empty;
				lblDestMatches.Text = "NO MATCH FOUND";
			}
		}
	}
}
