using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Interfaces;

public interface IDialogIcon
{
	IView Parent { get; set; }

	Label L { get; set; }
}
