using System.Collections;
using System.Linq;
using ElroubyMauiLibrary.Interfaces;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary;

public class ElroubyListView : ContentView, IDGV, IBorderSize
{
	private BindableProperty VSLProperty = BindableProperty.Create("Body", typeof(VerticalStackLayout), typeof(ElroubyListView), (object)new VerticalStackLayout(), (BindingMode)1, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	private string _Header;

	private ScrollView Main = new ScrollView();

	public VerticalStackLayout Body
	{
		get
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			return (VerticalStackLayout)((BindableObject)this).GetValue(VSLProperty);
		}
		set
		{
			((BindableObject)this).SetValue(VSLProperty, (object)value);
		}
	}

	public double BorderSize { get; set; } = 3.0;


	public string Header
	{
		get
		{
			return _Header;
		}
		set
		{
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			bool flag = false;
			foreach (Label item in ((IEnumerable)Body).OfType<Label>())
			{
				if (item.Text == _Header)
				{
					item.Text = value;
					flag = true;
					break;
				}
			}
			_Header = value;
			if (_Header != null && !flag)
			{
				((Layout)Body).Add((IView)new Label
				{
					Text = Header,
					HorizontalOptions = LayoutOptions.Center
				});
			}
		}
	}

	public ElroubyListView()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		Border val2 = (Border)(object)(((ContentView)this).Content = (View)new Border
		{
			StrokeThickness = BorderSize,
			Stroke = Brush.op_Implicit(Colors.Black)
		});
		val2.Content = (View)(object)Main;
		((VisualElement)Main).HeightRequest = 200.0;
		Main.Content = (View)(object)Body;
		Main.Orientation = (ScrollOrientation)2;
		double widthRequest = (((VisualElement)this).HeightRequest = 200.0);
		((VisualElement)this).WidthRequest = widthRequest;
	}
}
