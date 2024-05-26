using System;
using System.Linq;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.EntryBased;

public class DoubleEntry : HorizontalStackLayout
{
	private Entry Owner = new Entry();

	public string Placeholder
	{
		get
		{
			return ((InputView)Owner).Placeholder;
		}
		set
		{
			((InputView)Owner).Placeholder = value;
		}
	}

	public double Value
	{
		get
		{
			try
			{
				return double.Parse(((InputView)Owner).Text);
			}
			catch
			{
				return 0.0;
			}
		}
		set
		{
			((InputView)Owner).Text = value.ToString();
		}
	}

	public double AddPlusMinus { get; set; } = 1.0;


	public void NE_TextChanged(object sender, EventArgs e)
	{
		if (((InputView)Owner).Text.Split('.').Last().Length != 0)
		{
			try
			{
				((InputView)Owner).Text = double.Parse(((InputView)Owner).Text).ToString();
			}
			catch
			{
				((InputView)Owner).Text = "0";
			}
		}
	}

	public DoubleEntry()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		((InputView)Owner).TextChanged += NE_TextChanged;
		((VisualElement)Owner).WidthRequest = 100.0;
		((Layout)this).Add((IView)(object)Owner);
		HorizontalStackLayout val = new HorizontalStackLayout();
		Button val2 = new Button();
		val2.Text = "↑";
		((VisualElement)val2).HeightRequest = 5.0;
		((VisualElement)val2).WidthRequest = 10.0;
		val2.Clicked += delegate
		{
			Value += AddPlusMinus;
		};
		((Layout)val).Add((IView)(object)val2);
		Button val3 = new Button();
		val3.Text = "↓";
		((VisualElement)val3).HeightRequest = 5.0;
		((VisualElement)val3).WidthRequest = 10.0;
		val3.Clicked += delegate
		{
			Value -= AddPlusMinus;
		};
		((Layout)val).Add((IView)(object)val3);
		((Layout)this).Add((IView)(object)val);
	}
}
