using System;
using ElroubyMauiLibrary.Interfaces;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.Parts;

public class CheckedListBoxCell : HorizontalStackLayout, ICell
{
	private Label TextHead = new Label();

	private CheckBox CB = new CheckBox();

	public bool IsChecked
	{
		get
		{
			return CB.IsChecked;
		}
		set
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			CheckedChangedEventArgs e = new CheckedChangedEventArgs(value);
			CB.IsChecked = value;
			if (this.CheckedChanged != null)
			{
				this.CheckedChanged(this, e);
			}
		}
	}

	public string Text
	{
		get
		{
			return TextHead.Text;
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			TextChangedEventArgs e = new TextChangedEventArgs(TextHead.Text, value);
			TextHead.Text = value;
			if (this.TextChanged != null)
			{
				this.TextChanged(this, e);
			}
		}
	}

	public int Index { get; set; } = 0;


	public object Value { get; set; } = null;


	public event EventHandler<TextChangedEventArgs> TextChanged;

	public event EventHandler<CheckedChangedEventArgs> CheckedChanged;

	public CheckedListBoxCell(string Text, object Value)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		this.Text = Text;
		this.Value = Value;
		((Layout)this).Add((IView)(object)CB);
		((View)CB).VerticalOptions = LayoutOptions.Center;
		((Layout)this).Add((IView)(object)TextHead);
		((View)TextHead).VerticalOptions = LayoutOptions.Center;
		((View)this).Margin = Thickness.op_Implicit(2.0);
		((VisualElement)this).BackgroundColor = Colors.WhiteSmoke;
	}
}
