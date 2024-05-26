using ElroubyMauiLibrary.Parts;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Interfaces;

public interface IDialog
{
	Entry ThePath { get; set; }

	MyWindow Parent { get; set; }
}
