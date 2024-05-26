using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.GridBase;

public class GridSaveButton : ImageButton
{
	public int Row { get; set; }

	public int Column { get; set; }

	public string Text { get; set; }

	public GridSaveButton()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		((VisualElement)this).BackgroundColor = Colors.Transparent;
		((ImageButton)this).Source = ImageSource.FromFile("Photos/save.png");
		((VisualElement)this).WidthRequest = 50.0;
		((VisualElement)this).HeightRequest = 50.0;
		((View)this).HorizontalOptions = LayoutOptions.Center;
		((View)this).VerticalOptions = LayoutOptions.Center;
	}
}
