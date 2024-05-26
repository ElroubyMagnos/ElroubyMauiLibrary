using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ElroubyMauiLibrary.Parts;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace ElroubyMauiLibrary;

[XamlFilePath("ComboBox.xaml")]
public class ComboBox : ContentView
{
	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Button Down;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ComboEntry Space;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	public VerticalStackLayout Items;

	public int SelectedIndex
	{
		get
		{
			for (int i = 0; i < ((IEnumerable<IView>)Items).Count(); i++)
			{
				if (((Layout)Items)[i] == SelectedItem)
				{
					return i;
				}
			}
			return -1;
		}
		set
		{
			for (int i = 0; i < ((IEnumerable<IView>)Items).Count(); i++)
			{
				if (((Layout)Items)[i] == SelectedItem)
				{
					SelectedItem = ((Layout)Items)[i] as ElroubyCore;
					break;
				}
			}
		}
	}

	public ElroubyCore SelectedItem
	{
		get
		{
			foreach (ElroubyCore item in (Layout)Items)
			{
				if (((VisualElement)item).IsFocused)
				{
					return item;
				}
			}
			return null;
		}
		set
		{
			foreach (ElroubyCore item in (Layout)Items)
			{
				if (item == value)
				{
					SelectedItem = item;
					break;
				}
			}
		}
	}

	public bool IsReadOnly
	{
		get
		{
			return ((InputView)Space).IsReadOnly;
		}
		set
		{
			((InputView)Space).IsReadOnly = value;
			foreach (ElroubyCore item in (Layout)Items)
			{
				((InputView)item).IsReadOnly = ((InputView)Space).IsReadOnly;
			}
		}
	}

	public double WidthofBox
	{
		get
		{
			return ((VisualElement)Space).WidthRequest;
		}
		set
		{
			((VisualElement)Space).WidthRequest = value;
		}
	}

	public event EventHandler SelectedIndexChanged;

	public ElroubyCore FindCoreByValue(object Value)
	{
		foreach (ElroubyCore item in (Layout)Items)
		{
			if (item.Value == Value)
			{
				return item;
			}
		}
		return null;
	}

	public ElroubyCore FindCoreByName(string Name)
	{
		foreach (ElroubyCore item in (Layout)Items)
		{
			if (((InputView)item).Text.Contains(Name))
			{
				return item;
			}
		}
		return null;
	}

	public ComboBox()
	{
		InitializeComponent();
		WidthofBox = 112.0;
	}

	private void Items_ChildAdded(object sender, ElementEventArgs e)
	{
		try
		{
			ElroubyCore EC = e.Element as ElroubyCore;
			((VisualElement)EC).Focused += delegate(object? s, FocusEventArgs e)
			{
				((VisualElement)Items).IsVisible = false;
				ElroubyCore elroubyCore = s as ElroubyCore;
				((InputView)Space).Text = ((InputView)elroubyCore).Text;
				Space.Value = elroubyCore.Value;
				((VisualElement)Space).Focus();
				this.SelectedIndexChanged(EC, null);
			};
			((InputView)EC).IsReadOnly = ((InputView)Space).IsReadOnly;
			((VisualElement)Items).IsVisible = false;
		}
		catch
		{
			throw new Exception("You only can add ElroubyCore to the List items.");
		}
	}

	private void Down_Clicked(object sender, EventArgs e)
	{
		((VisualElement)Items).IsVisible = !((VisualElement)Items).IsVisible;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("Down")]
	[MemberNotNull("Space")]
	[MemberNotNull("Items")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<ComboBox>(this, typeof(ComboBox));
		Down = NameScopeExtensions.FindByName<Button>((Element)(object)this, "Down");
		Space = NameScopeExtensions.FindByName<ComboEntry>((Element)(object)this, "Space");
		Items = NameScopeExtensions.FindByName<VerticalStackLayout>((Element)(object)this, "Items");
	}
}
