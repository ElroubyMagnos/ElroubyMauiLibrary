using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.EntryBased;

public class AdvancedPasswordEntry : HorizontalStackLayout
{
	private Entry Content = new Entry();

	private ImageButton btn = new ImageButton();

	public string PhotoSource
	{
		get
		{
			return btn.Source.ToStringOrEmpty<ImageSource>();
		}
		set
		{
			btn.Source = ImageSource.op_Implicit(value);
		}
	}

	public double HeadBoxWidth
	{
		get
		{
			return ((VisualElement)Content).WidthRequest;
		}
		set
		{
			((VisualElement)Content).WidthRequest = value;
		}
	}

	public AdvancedPasswordEntry()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		Content.IsPassword = true;
		btn.Clicked += delegate
		{
			Content.IsPassword = !Content.IsPassword;
		};
		btn.Source = ImageSource.op_Implicit("Photos/eye.png");
		((VisualElement)btn).WidthRequest = 40.0;
		((VisualElement)btn).HeightRequest = 40.0;
		((Layout)this).Add((IView)(object)Content);
		((Layout)this).Add((IView)(object)btn);
	}
}
