using System;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Parts;

public class MyWindow : Window
{
	public bool Saved = false;

	private Action AfterClose = null;

	public MyWindow(Action AfterClose)
	{
		this.AfterClose = AfterClose;
	}
}
