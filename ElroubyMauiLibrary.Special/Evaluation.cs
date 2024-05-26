using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace ElroubyMauiLibrary.Special;

[XamlFilePath("Special\\Evaluation.xaml")]
public class Evaluation : ContentView
{
	private int _score;

	public int _StarCount;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private HorizontalStackLayout StarContainer;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ImageButton One;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ImageButton Two;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ImageButton Three;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ImageButton Four;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ImageButton Five;

	public int Score
	{
		get
		{
			return _score;
		}
		set
		{
			_score = value;
			if (_score > 0 && _score <= 100)
			{
				One_Clicked(null, null);
			}
			else if (_score > 100 && _score <= 200)
			{
				Two_Clicked(null, null);
			}
			else if (_score > 200 && _score <= 300)
			{
				Three_Clicked(null, null);
			}
			else if (_score > 300 && _score <= 400)
			{
				Four_Clicked(null, null);
			}
			else if (_score > 400 && _score <= 500)
			{
				Five_Clicked(null, null);
			}
		}
	}

	public bool ReadOnly { get; set; }

	public double StarSize
	{
		get
		{
			return ((VisualElement)One).WidthRequest;
		}
		set
		{
			ImageButton one = One;
			ImageButton one2 = One;
			ImageButton two = Two;
			ImageButton two2 = Two;
			ImageButton three = Three;
			ImageButton three2 = Three;
			ImageButton four = Four;
			ImageButton four2 = Four;
			ImageButton five = Five;
			double num2 = (((VisualElement)Five).HeightRequest = value);
			double num4 = (((VisualElement)five).WidthRequest = num2);
			double num6 = (((VisualElement)four2).HeightRequest = num4);
			double num8 = (((VisualElement)four).WidthRequest = num6);
			double num10 = (((VisualElement)three2).HeightRequest = num8);
			double num12 = (((VisualElement)three).WidthRequest = num10);
			double num14 = (((VisualElement)two2).HeightRequest = num12);
			double num16 = (((VisualElement)two).WidthRequest = num14);
			double widthRequest = (((VisualElement)one2).HeightRequest = num16);
			((VisualElement)one).WidthRequest = widthRequest;
		}
	}

	public int StarCount
	{
		get
		{
			return _StarCount;
		}
		set
		{
			_StarCount = value;
			if (value == 1)
			{
				One.Source = ImageSource.op_Implicit("Photos/star.png");
				Two.Source = ImageSource.op_Implicit("Photos/emptystar.png");
				Three.Source = ImageSource.op_Implicit("Photos/emptystar.png");
				Four.Source = ImageSource.op_Implicit("Photos/emptystar.png");
				Five.Source = ImageSource.op_Implicit("Photos/emptystar.png");
			}
			if (value == 2)
			{
				One.Source = ImageSource.op_Implicit("Photos/star.png");
				Two.Source = ImageSource.op_Implicit("Photos/star.png");
				Three.Source = ImageSource.op_Implicit("Photos/emptystar.png");
				Four.Source = ImageSource.op_Implicit("Photos/emptystar.png");
				Five.Source = ImageSource.op_Implicit("Photos/emptystar.png");
			}
			if (value == 3)
			{
				One.Source = ImageSource.op_Implicit("Photos/star.png");
				Two.Source = ImageSource.op_Implicit("Photos/star.png");
				Three.Source = ImageSource.op_Implicit("Photos/star.png");
				Four.Source = ImageSource.op_Implicit("Photos/emptystar.png");
				Five.Source = ImageSource.op_Implicit("Photos/emptystar.png");
			}
			if (value == 4)
			{
				One.Source = ImageSource.op_Implicit("Photos/star.png");
				Two.Source = ImageSource.op_Implicit("Photos/star.png");
				Three.Source = ImageSource.op_Implicit("Photos/star.png");
				Four.Source = ImageSource.op_Implicit("Photos/star.png");
				Five.Source = ImageSource.op_Implicit("Photos/emptystar.png");
			}
			if (value == 5)
			{
				One.Source = ImageSource.op_Implicit("Photos/star.png");
				Two.Source = ImageSource.op_Implicit("Photos/star.png");
				Three.Source = ImageSource.op_Implicit("Photos/star.png");
				Four.Source = ImageSource.op_Implicit("Photos/star.png");
				Five.Source = ImageSource.op_Implicit("Photos/star.png");
			}
		}
	}

	public Evaluation()
	{
		InitializeComponent();
	}

	private void One_Clicked(object sender, EventArgs e)
	{
		if (!ReadOnly)
		{
			StarCount = 1;
		}
	}

	private void Two_Clicked(object sender, EventArgs e)
	{
		if (!ReadOnly)
		{
			StarCount = 2;
		}
	}

	private void Three_Clicked(object sender, EventArgs e)
	{
		if (!ReadOnly)
		{
			StarCount = 3;
		}
	}

	private void Four_Clicked(object sender, EventArgs e)
	{
		if (!ReadOnly)
		{
			StarCount = 4;
		}
	}

	private void Five_Clicked(object sender, EventArgs e)
	{
		if (!ReadOnly)
		{
			StarCount = 5;
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("StarContainer")]
	[MemberNotNull("One")]
	[MemberNotNull("Two")]
	[MemberNotNull("Three")]
	[MemberNotNull("Four")]
	[MemberNotNull("Five")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<Evaluation>(this, typeof(Evaluation));
		StarContainer = NameScopeExtensions.FindByName<HorizontalStackLayout>((Element)(object)this, "StarContainer");
		One = NameScopeExtensions.FindByName<ImageButton>((Element)(object)this, "One");
		Two = NameScopeExtensions.FindByName<ImageButton>((Element)(object)this, "Two");
		Three = NameScopeExtensions.FindByName<ImageButton>((Element)(object)this, "Three");
		Four = NameScopeExtensions.FindByName<ImageButton>((Element)(object)this, "Four");
		Five = NameScopeExtensions.FindByName<ImageButton>((Element)(object)this, "Five");
	}
}
