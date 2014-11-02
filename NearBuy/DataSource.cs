﻿using System;

//Nuevas librerias
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace NearBuy
{
	public class DataSource : UITableViewSource
	{
		UIViewController parentController;
		static NSString Identificador = new NSString ("Tabla Prueba");
		List<JsonTienda> ListaDatos;

		public DataSource (List <JsonTienda> _listadatos, UIViewController parentController)
		{
			ListaDatos = _listadatos;
			this.parentController = parentController;
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
			celda.TextLabel.Text = ListaDatos [indexPath.Row].nombre;
			celda.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return celda;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{

			parentController.NavigationController.PushViewController (new PromosViewController (ListaDatos [indexPath.Row].idTienda), true);
			tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return "Lista Datos";
		}

		public override string TitleForFooter (UITableView tableView, int section)
		{
			if (ListaDatos.Count > 0) {
				return "Elementos: " + ListaDatos.Count;
			} else {
				return "Elementos: 0";
			}
		}
	}
}


