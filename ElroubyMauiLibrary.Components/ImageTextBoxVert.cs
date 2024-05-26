using ElroubyMauiLibrary.Interfaces;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Components;

public class ImageTextBoxVert : VerticalStackLayout, IImageTextBox
{
	private Image Image = new Image();

	private Label Label = new Label();

	public LayoutOptions HorzLabel
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return ((View)Label).HorizontalOptions;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((View)Label).HorizontalOptions = value;
		}
	}

	public double TextWidth
	{
		get
		{
			return ((VisualElement)Label).WidthRequest;
		}
		set
		{
			((VisualElement)Label).WidthRequest = value;
		}
	}

	public double TextHeight
	{
		get
		{
			return ((VisualElement)Label).HeightRequest;
		}
		set
		{
			((VisualElement)Label).HeightRequest = value;
		}
	}

	public double ImageWidth
	{
		get
		{
			return ((VisualElement)Image).WidthRequest;
		}
		set
		{
			((VisualElement)Image).WidthRequest = value;
		}
	}

	public double ImageHeight
	{
		get
		{
			return ((VisualElement)Image).HeightRequest;
		}
		set
		{
			((VisualElement)Image).HeightRequest = value;
		}
	}

	public ImageSource Source
	{
		get
		{
			return Image.Source;
		}
		set
		{
			Image.Source = value;
		}
	}

	public string Text
	{
		get
		{
			return Label.Text;
		}
		set
		{
			Label.Text = value;
		}
	}

	public ImageTextBoxVert()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		((Layout)this).Add((IView)(object)Image);
		((Layout)this).Add((IView)(object)Label);
		Label label = Label;
		LayoutOptions horizontalOptions = (((View)Image).HorizontalOptions = LayoutOptions.Center);
		((View)label).HorizontalOptions = horizontalOptions;
		double widthRequest = (((VisualElement)this).HeightRequest = 200.0);
		((VisualElement)this).WidthRequest = widthRequest;
		TextWidth = 100.0;
	}
}
