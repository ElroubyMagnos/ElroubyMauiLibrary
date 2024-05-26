using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Interfaces;

public interface IImageTextBox
{
	double TextWidth { get; set; }

	double TextHeight { get; set; }

	double ImageWidth { get; set; }

	double ImageHeight { get; set; }

	ImageSource Source { get; set; }

	string Text { get; set; }
}
