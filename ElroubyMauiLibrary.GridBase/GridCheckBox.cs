using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.GridBase;

public class GridCheckBox : CheckBox, GridControl
{
	public int Row { get; set; }

	public int Column { get; set; }

	public string Text
	{
		get
		{
			return ((CheckBox)this).IsChecked.ToString();
		}
		set
		{
			((CheckBox)this).IsChecked = value.ToUpper() == "TRUE";
		}
	}

	public GridCheckBox()
	{
		((CheckBox)this).IsChecked = false;
	}

	void GridControl.set_BackgroundColor(Color value)
	{
		((VisualElement)this).BackgroundColor = value;
	}
}
