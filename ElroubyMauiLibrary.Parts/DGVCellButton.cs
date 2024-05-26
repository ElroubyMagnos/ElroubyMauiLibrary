using ElroubyMauiLibrary.Interfaces;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.Parts;

public class DGVCellButton : Button, IDGVCell
{
	public bool IsReadOnly { get; set; } = false;


	public int Number { get; set; } = 0;


	void IDGVCell.set_Text(string value)
	{
		((Button)this).Text = value;
	}

	void IDGVCell.set_TextColor(Color value)
	{
		((Button)this).TextColor = value;
	}

	void IDGVCell.set_BackgroundColor(Color value)
	{
		((VisualElement)this).BackgroundColor = value;
	}
}
