using System;
using System.Linq;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.EntryBased;

public class IntegerEntry : HorizontalStackLayout
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

	public int Value
	{
		get
		{
			try
			{
				return int.Parse(((InputView)Owner).Text);
			}
			catch
			{
				return 0;
			}
		}
		set
		{
			((InputView)Owner).Text = value.ToString();
		}
	}

	public int AddPlusMinus { get; set; } = 1;


	public void NE_TextChanged(object sender, EventArgs e)
	{
		if (((InputView)Owner).Text.Split('.').Last().Length != 0)
		{
			try
			{
				((InputView)Owner).Text = int.Parse(((InputView)Owner).Text).ToString();
			}
			catch
			{
				((InputView)Owner).Text = "0";
			}
		}
	}

	public IntegerEntry()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
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
