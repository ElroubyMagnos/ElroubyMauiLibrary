using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Components;

public class DGVRows : List<DGVRow>
{
	public ElroubyDGV Parent { get; set; }

	public void Add()
	{
		if (Parent != null)
		{
			Parent.Add();
		}
	}

	public void Remove(int RowIndex)
	{
		if (Parent == null)
		{
			return;
		}
		foreach (VerticalStackLayout item in ((IEnumerable)Parent.Main).OfType<VerticalStackLayout>())
		{
			((Layout)item).RemoveAt(RowIndex);
		}
		Clear();
		foreach (DGVRow row in Parent.Rows)
		{
			Add(row);
		}
		Parent.UpdateAsync();
	}
}
