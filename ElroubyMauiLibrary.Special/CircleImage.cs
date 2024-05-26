using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.Special;

[XamlFilePath("Special\\CircleImage.xaml")]
public class CircleImage : ContentView
{
	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Frame FrameOut;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Image ImageInside;

	public float CornerRadius
	{
		get
		{
			return FrameOut.CornerRadius;
		}
		set
		{
			FrameOut.CornerRadius = value;
		}
	}

	public double HeightRequest
	{
		get
		{
			return ((VisualElement)this).HeightRequest;
		}
		set
		{
			((VisualElement)this).HeightRequest = value + 20.0;
			((VisualElement)FrameOut).HeightRequest = value + 10.0;
			((VisualElement)ImageInside).HeightRequest = value;
		}
	}

	public double WidthRequest
	{
		get
		{
			return ((VisualElement)this).WidthRequest;
		}
		set
		{
			((VisualElement)this).WidthRequest = value + 20.0;
			((VisualElement)FrameOut).WidthRequest = value + 10.0;
			((VisualElement)ImageInside).WidthRequest = value;
		}
	}

	public string ImageSource
	{
		get
		{
			return ImageInside.Source.ToStringOrEmpty<ImageSource>();
		}
		set
		{
			ImageInside.Source = ImageSource.op_Implicit(value);
		}
	}

	public Color BorderColor
	{
		get
		{
			return FrameOut.BorderColor;
		}
		set
		{
			FrameOut.BorderColor = value;
		}
	}

	public CircleImage()
	{
		InitializeComponent();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("FrameOut")]
	[MemberNotNull("ImageInside")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<CircleImage>(this, typeof(CircleImage));
		FrameOut = NameScopeExtensions.FindByName<Frame>((Element)(object)this, "FrameOut");
		ImageInside = NameScopeExtensions.FindByName<Image>((Element)(object)this, "ImageInside");
	}
}
