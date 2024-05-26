using System;
using System.Linq;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.EntryBased;

public class BeautyBox : VerticalStackLayout
{
	private string _title;

	public Label Label = new Label();

	public Entry Entry = new Entry();

	private bool _N;

	public Color PlaceHolderColor
	{
		get
		{
			return ((InputView)Entry).PlaceholderColor;
		}
		set
		{
			((InputView)Entry).PlaceholderColor = value;
		}
	}

	public bool IsPassword
	{
		get
		{
			return Entry.IsPassword;
		}
		set
		{
			Entry.IsPassword = value;
		}
	}

	public bool OnRight { get; set; } = false;


	public string Title
	{
		get
		{
			return _title;
		}
		set
		{
			_title = value;
			((InputView)Entry).Placeholder = value;
		}
	}

	public string Text
	{
		get
		{
			return ((InputView)Entry).Text;
		}
		set
		{
			((InputView)Entry).Text = value;
		}
	}

	public bool Numeric
	{
		get
		{
			return _N;
		}
		set
		{
			_N = value;
			if (Numeric)
			{
				((InputView)Entry).TextChanged += NumbersOnly;
			}
			else
			{
				((InputView)Entry).TextChanged -= NumbersOnly;
			}
		}
	}

	public event EventHandler<FocusEventArgs> Focused;

	public event EventHandler<FocusEventArgs> Unfocused;

	public event EventHandler<TextChangedEventArgs> TextChanged;

	public BeautyBox()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((VisualElement)Entry).Focused += delegate
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			((InputView)Entry).Placeholder = "";
			Label.Text = Title;
			((View)Label).HorizontalOptions = ((!OnRight) ? LayoutOptions.Start : LayoutOptions.End);
		};
		((VisualElement)Entry).Unfocused += delegate
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			Label.Text = "";
			((InputView)Entry).Placeholder = Title;
			((View)Label).HorizontalOptions = ((!OnRight) ? LayoutOptions.Start : LayoutOptions.End);
		};
		((Layout)this).Add((IView)(object)Label);
		((Layout)this).Add((IView)(object)Entry);
		((VisualElement)Entry).Loaded += delegate
		{
			((InputView)Entry).TextChanged += this.TextChanged;
			((VisualElement)Entry).Focused += this.Focused;
			((VisualElement)Entry).Unfocused += this.Unfocused;
		};
		Entry.HorizontalTextAlignment = (TextAlignment)1;
		((InputView)Entry).Placeholder = Title;
	}

	private void NumbersOnly(object sender, EventArgs e)
	{
		if (((InputView)Entry).Text.Length > 0)
		{
			char c = ((InputView)Entry).Text.Last();
			if (!char.IsDigit(c))
			{
				((InputView)Entry).Text = ((InputView)Entry).Text.Remove(((InputView)Entry).Text.Length - 1);
			}
		}
	}
}
