using System;

//Nuevas librerias
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace NearBuy
{
	public class DataSource : UITableViewSource
	{
		static NSString Identificador = new NSString("Tabla Prueba");
		List <string> ListaDatos;
		public DataSource (List <string> _listadatos)
		{
			ListaDatos = _listadatos;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return ListaDatos.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell celda = tableView.DequeueReusableCell (Identificador);
			if (celda == null) {
				celda = new UITableViewCell (UITableViewCellStyle.Default, Identificador);
			}
			celda.SelectionStyle = UITableViewCellSelectionStyle.Blue;
			celda.TextLabel.Text = ListaDatos [indexPath.Row];
			celda.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return celda;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			new UIAlertView("Row Selected", ListaDatos[indexPath.Row], null, "OK", null).Show();
			tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return "Lista Datos";
		}

		public override string TitleForFooter (UITableView tableView, int section)
		{
			return "Elementos: "+ListaDatos.Count;
		}
	}
}


