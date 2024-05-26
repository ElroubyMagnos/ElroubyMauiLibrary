using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.GridBase;

public class GridLabel : Entry, GridControl
{
	public int Row { get; set; }

	public int Column { get; set; }

	public string Text
	{
		get
		{
			return ((InputView)this).Text;
		}
		set
		{
			((InputView)this).Text = ((value.ToStringOrEmpty().Length == 0) ? '\0'.ToString() : value.ToStringOrEmpty()[0].ToString());
		}
	}

	void GridControl.set_BackgroundColor(Color value)
	{
		((VisualElement)this).BackgroundColor = value;
	}
}
