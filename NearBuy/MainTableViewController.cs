using System;

using System.Collections.Generic;
using System.Linq;
using RestSharp;
using RestSharp.Deserializers;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace NearBuy
{
	public partial class MainTableViewController : BaseTableViewController
	{

		ResultsTableController resultsTableController;
		UISearchController searchController;

		List<JsonPromos> promos = new List<JsonPromos>();

		public MainTableViewController ()
		{
			Title="Busqueda";

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			GetPromoData();
			resultsTableController = new ResultsTableController {
				FilteredProducts = new List<JsonPromos> ()
			};

			searchController = new UISearchController (resultsTableController) {
				WeakDelegate = this,
				DimsBackgroundDuringPresentation = false,
				WeakSearchResultsUpdater = this
			};

			searchController.SearchBar.Placeholder="Busqueda de promociones";

			searchController.SearchBar.SizeToFit ();
			TableView.TableHeaderView = searchController.SearchBar;

			resultsTableController.TableView.WeakDelegate = this;
			searchController.SearchBar.WeakDelegate = this;

			DefinesPresentationContext = true;

		}

		[Export ("searchBarCancelButtonClicked:")]
		public virtual void CancelButtonClicked (UISearchBar searchBar)
		{
			System.Diagnostics.Debug.WriteLine ("button cancel");
		}

		[Export ("searchBarSearchButtonClicked:")]
		public virtual void SearchButtonClicked (UISearchBar searchBar)
		{
			searchBar.ResignFirstResponder ();
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return promos.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			JsonPromos jsonPromos = promos [indexPath.Row];

			UITableViewCell cell = TableView.DequeueReusableCell ((NSString)cellIdentifier, indexPath);
			ConfigureCell (cell, jsonPromos);
			return cell;

		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{

			JsonPromos selectedProduct = (tableView == TableView) ? promos [indexPath.Row] : resultsTableController.FilteredProducts [indexPath.Row];

			promos [indexPath.Row]= selectedProduct;

			NavigationController.PushViewController (new InfoView (promos [indexPath.Row]), true);
			tableView.DeselectRow (indexPath, true);
		}

		[Export ("updateSearchResultsForSearchController:")]
		public virtual void UpdateSearchResultsForSearchController (UISearchController searchController)
		{	

			var tableController = (ResultsTableController)searchController.SearchResultsController;
			tableController.FilteredProducts = PerformSearch (searchController.SearchBar.Text);
			tableController.TableView.ReloadData ();
		}

		List<JsonPromos> PerformSearch(string searchString)
		{	
			searchString = searchString.Trim ();

			string[] searchItems = string.IsNullOrEmpty (searchString)
				? new string[0]
				: searchString.Split (new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);

			var filteredProducts = new List<JsonPromos> ();

			foreach (var item in searchItems) {
				int year = Int32.MinValue;
				Int32.TryParse (item, out year);

				double price = Double.MinValue;
				Double.TryParse (item, out price);

				IEnumerable<JsonPromos> query = 
					from p in promos
						where p.titulo.IndexOf (item, StringComparison.OrdinalIgnoreCase) >= 0
					orderby p.titulo
					select p;
				filteredProducts.AddRange (query);
			}

			return filteredProducts.Distinct ().ToList ();
		}

		public void GetPromoData(){

			if (!Reachability.IsHostReachable ("www.codecags.com")) {
				var alert = new UIAlertView {
					Title = "Unable to connect to server", 
					Message = "Verify network connections"
				};
				alert.AddButton ("OK");
				alert.Show ();
			} else {
				var client = new RestClient ("http://codecags.com");
				var request = new RestRequest ("jsonAllPromos.php", Method.POST);
				request.RequestFormat = DataFormat.Json;
				var response = client.Execute (request);
				RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer ();
				promos = deserial.Deserialize<List<JsonPromos>> (response);
			}


		}

	}
}

