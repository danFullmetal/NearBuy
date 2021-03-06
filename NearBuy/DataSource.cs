﻿using System;

//Nuevas librerias
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Linq;
using MonoTouch.Dialog.Utilities;

/// <summary>
/// Data source.
/// </summary>
using SDWebImage;


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

		public  override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell celda = tableView.DequeueReusableCell (Identificador);
			if (celda == null) {
				celda = new UITableViewCell (UITableViewCellStyle.Subtitle, Identificador);
			}
			celda.SelectionStyle = UITableViewCellSelectionStyle.Blue;
			celda.TextLabel.Text = ListaDatos [indexPath.Row].nombre;
			celda.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			if (Reachability.IsHostReachable ("www.codecags.com")) {
				celda.ImageView.SetImage (
					url: new NSUrl ("http://www.codecags.com/Img/" + ListaDatos [indexPath.Row].logo), 
					placeholder: UIImage.FromBundle ("placeholder.jpg")
				);
			}
			celda.DetailTextLabel.Text = "Promociones disponibles: " + ListaDatos [indexPath.Row].promociones.ToString();
			celda.DetailTextLabel.TextColor = UIColor.Gray;
			return celda;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
		
			parentController.NavigationController.PushViewController (new PromosViewController (ListaDatos [indexPath.Row].idTienda, ListaDatos [indexPath.Row].nombre), true);
			tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return "Tiendas";
		}
			

	}
}


