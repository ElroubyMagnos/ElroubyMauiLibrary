using System.Collections.Generic;
using ElroubyMauiLibrary.Components;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Parts;

public class TabList : List<TabPage>
{
	public TabControl Parent;

	public event TabControl.TabControlEventsSingle TabAdded;

	public event TabControl.TabControlEventsSingle TabRemoved;

	public new void Add(TabPage TP)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		if (Contains(TP))
		{
			((Layout)Parent.HeadSelect).Remove((IView)(object)GetTab(TP.Name).Head);
			Remove(TP);
		}
		if (!((Layout)Parent.HeadSelect).Contains((IView)(object)TP.Head))
		{
			((Layout)Parent.HeadSelect).Add((IView)(object)TP.Head);
		}
		base.Add(TP);
		TP.Parent = Parent;
		((View)TP.Head).Margin = new Thickness(0.0, 0.0, 10.0, 0.0);
		if (this.TabAdded != null)
		{
			this.TabAdded(TP);
		}
	}

	public TabPage GetTab(string Name)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				TabPage current = enumerator.Current;
				if (current.Name == Name)
				{
					return current;
				}
			}
		}
		return null;
	}

	public new void Remove(TabPage TP)
	{
		base.Remove(TP);
		((Layout)Parent.HeadSelect).Remove((IView)(object)TP.Head);
		if (this.TabRemoved != null)
		{
			this.TabRemoved(TP);
		}
	}

	public new bool Contains(TabPage TP)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				TabPage current = enumerator.Current;
				if (current.Name == TP.Name)
				{
					return true;
				}
			}
		}
		return false;
	}
}
