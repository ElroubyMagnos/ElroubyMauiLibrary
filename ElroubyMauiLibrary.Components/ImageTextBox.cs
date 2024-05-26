using ElroubyMauiLibrary.Interfaces;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Components;

public class ImageTextBox : HorizontalStackLayout, IImageTextBox
{
	private Image Image = new Image();

	private Label Label = new Label();

	public LayoutOptions VertLabel
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return ((View)Label).VerticalOptions;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((View)Label).VerticalOptions = value;
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

	public ImageTextBox()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		((Layout)this).Add((IView)(object)Image);
		((Layout)this).Add((IView)(object)Label);
		((View)Label).VerticalOptions = LayoutOptions.Center;
		double widthRequest = (((VisualElement)this).HeightRequest = 200.0);
		((VisualElement)this).WidthRequest = widthRequest;
		TextWidth = 100.0;
	}
}
