using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.Interfaces;

public interface IDGVCell
{
	string Text { get; set; }

	Color TextColor { get; set; }

	Color BackgroundColor { get; set; }

	bool IsReadOnly { get; set; }
}
