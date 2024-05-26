using ElroubyMauiLibrary.GridBase;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.EntryBased;

public class StringEntry : Entry, GridControl
{
	public int Row { get; set; }

	public int Column { get; set; }

	void GridControl.set_BackgroundColor(Color value)
	{
		((VisualElement)this).BackgroundColor = value;
	}
}
