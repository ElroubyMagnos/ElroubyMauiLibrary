using System.Collections.Generic;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.Parts;

public class ListBoxColumn : List<ElroubyCore>
{
	public ElroubyListBox Parent = null;

	public void Add(string Text, object Value = null)
	{
		Add(new ElroubyCore(Text, Value));
	}

	public new void Add(ElroubyCore Item)
	{
		base.Add(Item);
		((Layout)Parent.Body).Children.Clear();
		for (int i = 0; i < base.Count; i++)
		{
			ElroubyCore elroubyCore = base[i];
			elroubyCore.Index = i;
			((InputView)elroubyCore).TextColor = Color.FromRgb(0, 0, 0);
			((Layout)Parent.Body).Children.Add((IView)(object)elroubyCore);
		}
		ElroubyCore L = Item;
		((VisualElement)L).Focused += delegate
		{
			Parent.SelectedIndex = L.Index;
			Parent.SelectedValue = L.Value;
		};
		Parent.Add(L);
	}

	public new void Remove(ElroubyCore Item)
	{
		base.Remove(Item);
		((Layout)Parent.Body).Children.Clear();
		for (int i = 0; i < base.Count; i++)
		{
			ElroubyCore elroubyCore = base[i];
			elroubyCore.Index = i;
			((InputView)elroubyCore).TextColor = Color.FromRgb(0, 0, 0);
			((Layout)Parent.Body).Children.Add((IView)(object)elroubyCore);
		}
	}
}
