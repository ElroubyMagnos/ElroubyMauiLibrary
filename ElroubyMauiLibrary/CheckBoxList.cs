using System;
using System.Data;
using ElroubyMauiLibrary.Interfaces;
using ElroubyMauiLibrary.Parts;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary;

public class CheckBoxList : ContentView, IListBox
{
	public CheckedListBoxColumn DataSource = new CheckedListBoxColumn();

	private ScrollView SV { get; set; } = new ScrollView
	{
		HorizontalOptions = LayoutOptions.Center
	};


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


	private DataTable DT { get; set; }

	public DataTable DataTableSource
	{
		get
		{
			return DT;
		}
		set
		{
			DataSource.Clear();
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
					CheckedListBoxCell item = new CheckedListBoxCell(row.ItemArray[i].ToString(), null);
					DataSource.Add(item);
				}
				for (int j = 0; j < DT.Columns.Count; j++)
				{
					if (DT.Columns[j].ColumnName == ValueColumn)
					{
						for (int k = 0; k < DT.Rows.Count; k++)
						{
							DataSource[k].Value = DT.Rows[k].ItemArray[j];
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

	public event EventHandler<CheckedChangedEventArgs> CheckedChanged;

	public void ItemAdded(CheckedListBoxCell L)
	{
		L.TextChanged += this.CellValueChanged;
		((VisualElement)L).Focused += this.CellFocused;
		((VisualElement)L).Unfocused += this.CellUnFocused;
		L.CheckedChanged += this.CheckedChanged;
	}

	public CheckBoxList()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
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
		DataSource.Parent = this;
	}
}
