using ElroubyMauiLibrary.Interfaces;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.Parts;

public class DGVCell : Entry, IDGVCell
{
	public Border CellBorder;

	public int CurrentRow { get; set; } = 0;


	public int CurrentColumn { get; set; } = 0;


	public string CurrentColumnName { get; set; }

	public DGVCell(double BorderSize)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		((InputView)this).IsReadOnly = true;
		((InputView)this).TextColor = Color.FromRgb(0, 0, 0);
		double widthRequest = (((VisualElement)this).HeightRequest = 100.0);
		((VisualElement)this).WidthRequest = widthRequest;
		CellBorder = new Border
		{
			Stroke = Brush.op_Implicit(Color.FromArgb("#000000")),
			StrokeThickness = BorderSize,
			HorizontalOptions = LayoutOptions.Center
		};
		CellBorder.Content = (View)(object)this;
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
