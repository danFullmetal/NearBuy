using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace NearBuy
{
	public class ResultsTableController :BaseTableViewController
	{
		public List<JsonPromos> FilteredProducts { get; set; }

		public override int RowsInSection (UITableView tableview, int section)
		{
			return FilteredProducts.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			JsonPromos jsonPromos = FilteredProducts [indexPath.Row];
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			ConfigureCell (cell, jsonPromos);
			return cell;
		}
	}
}

