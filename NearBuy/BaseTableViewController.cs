using System;
using MonoTouch.UIKit;

namespace NearBuy
{
	public class BaseTableViewController : UITableViewController
	{
		protected const string cellIdentifier = "cellID";

		public BaseTableViewController ()
		{
		}

		protected void ConfigureCell (UITableViewCell cell, JsonPromos jsonPromos)
		{
			cell.TextLabel.Text = jsonPromos.titulo;
			string detailedStr = string.Format ("{0:C} | {1}", jsonPromos.precio, jsonPromos.descuento);
			cell.DetailTextLabel.Text = detailedStr;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			TableView.RegisterNibForCellReuse (UINib.FromName ("TableCell", null), cellIdentifier);
		}
	}
}

