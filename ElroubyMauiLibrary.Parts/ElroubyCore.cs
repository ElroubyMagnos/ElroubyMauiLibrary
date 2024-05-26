using ElroubyMauiLibrary.Interfaces;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Parts;

public class ElroubyCore : Entry, ICell
{
	public int Index { get; set; } = 0;


	public object Value { get; set; } = null;


	public ElroubyCore(string Text, object Value)
	{
		((InputView)this).Text = Text;
		this.Value = Value;
	}
}
