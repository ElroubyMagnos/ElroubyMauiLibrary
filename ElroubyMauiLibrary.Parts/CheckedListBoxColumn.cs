using System.Collections.Generic;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Parts;

public class CheckedListBoxColumn : List<CheckedListBoxCell>
{
	public CheckBoxList Parent = null;

	public void Add(string Text, object Value = null)
	{
		Add(new CheckedListBoxCell(Text, Value));
	}

	public new void Add(CheckedListBoxCell Item)
	{
		base.Add(Item);
		((Layout)Parent.Body).Children.Clear();
		for (int i = 0; i < base.Count; i++)
		{
			CheckedListBoxCell checkedListBoxCell = base[i];
			checkedListBoxCell.Index = i;
			((Layout)Parent.Body).Children.Add((IView)(object)checkedListBoxCell);
		}
		CheckedListBoxCell L = Item;
		((VisualElement)L).Focused += delegate
		{
			Parent.SelectedIndex = L.Index;
			Parent.SelectedValue = L.Value;
		};
		Parent.ItemAdded(L);
	}

	public new void Remove(CheckedListBoxCell Item)
	{
		base.Remove(Item);
		((Layout)Parent.Body).Children.Clear();
		for (int i = 0; i < base.Count; i++)
		{
			CheckedListBoxCell checkedListBoxCell = base[i];
			checkedListBoxCell.Index = i;
			((Layout)Parent.Body).Children.Add((IView)(object)checkedListBoxCell);
		}
	}
}
