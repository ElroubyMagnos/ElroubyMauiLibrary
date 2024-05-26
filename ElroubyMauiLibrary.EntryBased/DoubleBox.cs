using System;
using System.Linq;
using ElroubyMauiLibrary.Interfaces;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.EntryBased;

public class DoubleBox : StringEntry, IDGVCell
{
	public double Value
	{
		get
		{
			return ((InputView)this).Text.DoubleOrDefault();
		}
		set
		{
			((InputView)this).Text = value.ToStringOrEmpty();
		}
	}

	public DoubleBox()
	{
		((InputView)this).TextChanged += NumbersOnly;
	}

	private void NumbersOnly(object sender, EventArgs e)
	{
		try
		{
			char c = ((InputView)this).Text.Last();
			if (!char.IsDigit(c) && c != '.')
			{
				((InputView)this).Text = ((InputView)this).Text.Remove(((InputView)this).Text.Length - 1);
			}
			if (c == '.' && ((InputView)this).Text.Remove(((InputView)this).Text.Length - 1).Contains('.'))
			{
				((InputView)this).Text = ((InputView)this).Text.Remove(((InputView)this).Text.Length - 1);
			}
		}
		catch
		{
		}
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
