using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary;

public class SliderShow : ContentView
{
	private bool _HB;

	private VerticalStackLayout VSL = new VerticalStackLayout();

	private Image Show = new Image();

	private int _Setter;

	private ElroubyTimer ET;

	private ElroubyTimer Timer;

	private Button Move = new Button();

	private Button Back = new Button();

	private Button Next = new Button();

	private HorizontalStackLayout HSL = new HorizontalStackLayout();

	public double ShowWidth
	{
		get
		{
			return ((VisualElement)Show).WidthRequest;
		}
		set
		{
			((VisualElement)Show).WidthRequest = value;
		}
	}

	public double ShowHeight
	{
		get
		{
			return ((VisualElement)Show).HeightRequest;
		}
		set
		{
			((VisualElement)Show).HeightRequest = value;
		}
	}

	public bool HideButtons
	{
		get
		{
			return _HB;
		}
		set
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Expected O, but got Unknown
			if (value)
			{
				((Layout)HSL).Clear();
				return;
			}
			HorizontalStackLayout val = new HorizontalStackLayout();
			((Layout)val).Add((IView)(object)Back);
			((Layout)val).Add((IView)(object)Next);
			HSL = val;
		}
	}

	public List<string> Paths { get; set; } = new List<string>();


	public int Interval { get; set; } = 2000;


	private int Setter
	{
		get
		{
			return _Setter;
		}
		set
		{
			if (Paths.Count() != 0)
			{
				_Setter = value;
				if (_Setter < 0)
				{
					_Setter = Paths.Count - 1;
				}
				else if (_Setter > Paths.Count - 1)
				{
					_Setter = 0;
				}
				if (Paths.Count() > 1)
				{
					((VisualElement)Show).Opacity = 0.0;
					Show.Source = ImageSource.op_Implicit(Paths[_Setter]);
					SlowShow();
				}
			}
		}
	}

	private void SlowShow()
	{
		ET = new ElroubyTimer(delegate
		{
			Image show = Show;
			((VisualElement)show).Opacity = ((VisualElement)show).Opacity + 0.1;
			if (((VisualElement)Show).Opacity == 1.0)
			{
				ET.Stop();
			}
		}, 100);
		ET.Start();
	}

	public SliderShow()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		((ContentView)this).Content = (View)(object)VSL;
		((Layout)VSL).Add((IView)(object)Show);
		((VisualElement)this).HeightRequest = 200.0;
		((VisualElement)Move).WidthRequest = 100.0;
		Move.Text = "Move";
		HorizontalStackLayout val = new HorizontalStackLayout();
		((Layout)val).Add((IView)(object)Back);
		((Layout)val).Add((IView)(object)Next);
		HSL = val;
		Back.Text = "«";
		Back.Clicked += delegate
		{
			Timer.Stop();
			Setter--;
			if (!((Layout)VSL).Contains((IView)(object)Move))
			{
				((Layout)VSL).Add((IView)(object)Move);
			}
		};
		Next.Text = "»";
		Next.Clicked += delegate
		{
			Timer.Stop();
			Setter++;
			if (!((Layout)VSL).Contains((IView)(object)Move))
			{
				((Layout)VSL).Add((IView)(object)Move);
			}
		};
		((VisualElement)Show).HeightRequest = ((VisualElement)this).HeightRequest - ((VisualElement)this).HeightRequest / 4.0;
		((Layout)VSL).Add((IView)(object)HSL);
		((View)HSL).HorizontalOptions = LayoutOptions.Center;
		Timer = new ElroubyTimer(delegate
		{
			if (Paths.Count() > 1)
			{
				Setter++;
			}
		}, Interval);
		Move.Clicked += delegate
		{
			((Layout)VSL).Remove((IView)(object)Move);
			Timer.Start();
		};
		((VisualElement)this).Loaded += delegate
		{
			if (Paths.Count() == 1)
			{
				Show.Source = ImageSource.op_Implicit(Paths[0]);
			}
		};
		Timer.Start();
	}

	public void SetImages(params string[] Images)
	{
		Paths.AddRange(Images);
	}
}
