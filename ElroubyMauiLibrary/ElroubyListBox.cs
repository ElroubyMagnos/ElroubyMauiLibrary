using System;
using System.Data;
using ElroubyMauiLibrary.Interfaces;
using ElroubyMauiLibrary.Parts;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary;

public class ElroubyListBox : ContentView, IListBox, IDGV, IBorderSize
{
	private ScrollView SV = new ScrollView
	{
		HorizontalOptions = LayoutOptions.Center
	};

	public ListBoxColumn Items = new ListBoxColumn();

	private DataTable DT;

	public LayoutOptions HorizontalOptions
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return ((View)SV).HorizontalOptions;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((View)SV).HorizontalOptions = value;
		}
	}

	public LayoutOptions VerticalOptions
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return ((View)SV).VerticalOptions;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((View)SV).VerticalOptions = value;
		}
	}

	public VerticalStackLayout Body { get; set; } = new VerticalStackLayout();


	public DataTable DataTableSource
	{
		get
		{
			return DT;
		}
		set
		{
			Items.Clear();
			DT = value;
			if (DT == null)
			{
				return;
			}
			for (int i = 0; i < DT.Columns.Count; i++)
			{
				if (!(DT.Columns[i].ColumnName == SelectedColumn))
				{
					continue;
				}
				foreach (DataRow row in DT.Rows)
				{
					ElroubyCore item = new ElroubyCore(row.ItemArray[i].ToString(), null);
					Items.Add(item);
				}
				for (int j = 0; j < DT.Columns.Count; j++)
				{
					if (DT.Columns[j].ColumnName == ValueColumn)
					{
						for (int k = 0; k < DT.Rows.Count; k++)
						{
							Items[k].Value = DT.Rows[k].ItemArray[j];
						}
					}
				}
				break;
			}
		}
	}

	public int SelectedIndex { get; set; } = -1;


	public object SelectedValue { get; set; } = null;


	public string SelectedColumn { get; set; } = null;


	public string ValueColumn { get; set; } = null;


	public bool IsReadOnly { get; set; } = true;


	public double BorderSize
	{
		get
		{
			View content = SV.Content;
			return ((Border)((content is Border) ? content : null)).StrokeThickness;
		}
		set
		{
			View content = SV.Content;
			((Border)((content is Border) ? content : null)).StrokeThickness = value;
		}
	}

	public event EventHandler<TextChangedEventArgs> CellValueChanged;

	public event EventHandler<FocusEventArgs> CellFocused;

	public event EventHandler<FocusEventArgs> CellUnFocused;

	public void Add(ElroubyCore L)
	{
		((InputView)L).TextChanged += this.CellValueChanged;
		((VisualElement)L).Focused += this.CellFocused;
		((VisualElement)L).Unfocused += this.CellUnFocused;
		((InputView)L).IsReadOnly = IsReadOnly;
	}

	public ElroubyListBox()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		((ContentView)this).Content = (View)(object)SV;
		Border val = new Border
		{
			Stroke = Brush.op_Implicit(Color.FromRgb(0, 0, 0)),
			StrokeThickness = 2.0
		};
		SV.Content = (View)(object)val;
		val.Content = (View)(object)Body;
		double widthRequest = (((VisualElement)this).HeightRequest = 200.0);
		((VisualElement)this).WidthRequest = widthRequest;
		Items.Parent = this;
	}
}
