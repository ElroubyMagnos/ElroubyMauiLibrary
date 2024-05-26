using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.GridBase;

public class GridDate : DatePicker, GridControl
{
	public ElroubyTimer ET;

	public bool IsReadOnly { get; set; }

	public DateTime OldDate { get; set; }

	public int Row { get; set; }

	public int Column { get; set; }

	public string Text
	{
		get
		{
			return ((DatePicker)this).Date.ToStringOrEmpty();
		}
		set
		{
			((DatePicker)this).Date = value.ConvertFromString();
		}
	}

	public GridDate()
	{
		OldDate = ((DatePicker)this).Date;
		ET = new ElroubyTimer(delegate
		{
			if (IsReadOnly)
			{
				if (OldDate != ((DatePicker)this).Date)
				{
					((DatePicker)this).Date = OldDate;
				}
			}
			else
			{
				ET.Stop();
			}
		}, 100);
		ET.Start();
	}

	void GridControl.set_BackgroundColor(Color value)
	{
		((VisualElement)this).BackgroundColor = value;
	}
}
