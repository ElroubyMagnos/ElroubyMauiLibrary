using ElroubyMauiLibrary.Components;
using ElroubyMauiLibrary.Parts;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary;

public class TabControl : ContentView
{
	public delegate void TabControlEventsSingle(TabPage EventOwner);

	public delegate void TabControlEventsDouble(TabPage Old, TabPage New);

	private ScrollView SV = new ScrollView();

	public VerticalStackLayout VSL = new VerticalStackLayout();

	public HorizontalStackLayout HeadSelect = new HorizontalStackLayout();

	private TabPage _CT;

	public Color HeadColor
	{
		get
		{
			return ((VisualElement)HeadSelect).BackgroundColor;
		}
		set
		{
			((VisualElement)HeadSelect).BackgroundColor = value;
		}
	}

	public TabList TabPages { get; set; } = new TabList();


	public TabPage CurrentTab
	{
		get
		{
			return _CT;
		}
		set
		{
			if (this.TabChanged != null)
			{
				this.TabChanged(_CT, value);
			}
			((Layout)VSL).Remove((IView)(object)_CT);
			_CT = value;
			if (_CT != null)
			{
				if (!TabPages.Contains(_CT))
				{
					TabPages.Add(_CT);
				}
				((Layout)VSL).Add((IView)(object)_CT);
				((VisualElement)_CT.Head.Core).BackgroundColor = Colors.OrangeRed;
			}
		}
	}

	public event TabControlEventsDouble TabChanged;

	public TabControl()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		TabPages.Parent = this;
		((VisualElement)this).HeightRequest = 350.0;
		((ContentView)this).Content = (View)(object)SV;
		SV.Content = (View)(object)VSL;
		((Layout)VSL).Add((IView)(object)HeadSelect);
		((VisualElement)HeadSelect).HeightRequest = 25.0;
		((Layout)VSL).Add((IView)(object)CurrentTab);
	}
}
