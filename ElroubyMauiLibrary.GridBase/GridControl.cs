using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.GridBase;

public interface GridControl
{
	int Row { get; set; }

	int Column { get; set; }

	Color BackgroundColor { get; set; }

	string Text { get; set; }
}
