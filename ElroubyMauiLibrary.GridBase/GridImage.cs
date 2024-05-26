using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.GridBase;

[XamlFilePath("GridBase\\GridImage.xaml")]
public class GridImage : ImageButton, GridControl
{
	public int Row { get; set; }

	public int Column { get; set; }

	public Color BackgroundColor { get; set; }

	public string Text { get; set; }

	public LayoutOptions HorizontalOptions { get; set; }

	public LayoutOptions VerticalOptions { get; set; }

	public GridImage()
	{
		InitializeComponent();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GridImage>(this, typeof(GridImage));
	}
}
