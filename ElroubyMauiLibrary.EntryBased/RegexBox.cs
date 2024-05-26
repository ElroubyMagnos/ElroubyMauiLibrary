using System.Text.RegularExpressions;
using ElroubyMauiLibrary.Interfaces;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.EntryBased;

public class RegexBox : Entry, IDGVCell
{
	public string Patterns { get; set; }

	public RegexBox()
	{
		((InputView)this).TextChanged += delegate
		{
			RegexIt();
		};
	}

	private void RegexIt()
	{
		((InputView)this).Text = Regex.Match(((InputView)this).Text, Patterns).Value;
	}

	void IDGVCell.set_TextColor(Color value)
	{
		((InputView)this).TextColor = value;
	}

	void IDGVCell.set_BackgroundColor(Color value)
	{
		((VisualElement)this).BackgroundColor = value;
	}

	void IDGVCell.set_IsReadOnly(bool value)
	{
		((InputView)this).IsReadOnly = value;
	}
}
