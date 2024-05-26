using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ElroubyMauiLibrary.Components;
using ElroubyMauiLibrary.Interfaces;
using ElroubyMauiLibrary.Parts;
using FastMember;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary;

public class ElroubyDGV : ContentView, IBorderSize
{
	private int _SelectedRow = 0;

	public HorizontalStackLayout Main = new HorizontalStackLayout
	{
		HorizontalOptions = LayoutOptions.Center
	};

	private DataTable DT = null;

	private Dictionary<string, string> ReplaceColumnName { get; set; } = new Dictionary<string, string>();


	private List<string> ExcludeColumns { get; set; } = new List<string>();


	public Color DeleteButtonTextColor { get; set; } = Colors.Red;


	public Color AddButtonTextColor { get; set; } = Colors.Black;


	public Color AddButtonColor { get; set; } = Colors.BlueViolet;


	public Color CellColor { get; set; } = Colors.White;


	public Color CellTextColor { get; set; } = Colors.Black;


	public DGVRow SelectedRowCells
	{
		get
		{
			DGVRow dGVRow = new DGVRow();
			for (int i = 0; i < ((IEnumerable)Main).OfType<VerticalStackLayout>().Count(); i++)
			{
				if (((object)((IEnumerable)((IEnumerable)Main).OfType<VerticalStackLayout>().ToList()[i]).OfType<Border>().ToList()[SelectedRow + 1].Content).GetType() != typeof(DGVCellButton))
				{
					dGVRow.Add(((IEnumerable)((IEnumerable)Main).OfType<VerticalStackLayout>().ToList()[i]).OfType<Border>().ToList()[SelectedRow + 1].Content as DGVCell);
				}
			}
			return dGVRow;
		}
	}

	public List<string> SelectedRowData
	{
		get
		{
			List<string> list = new List<string>();
			try
			{
				for (int i = 0; i < ((IEnumerable)Main).OfType<VerticalStackLayout>().Count(); i++)
				{
					if (((object)((IEnumerable)((IEnumerable)Main).OfType<VerticalStackLayout>().ToList()[i]).OfType<Border>().ToList()[SelectedRow + 1].Content).GetType() != typeof(DGVCellButton))
					{
						list.Add(((InputView)(((IEnumerable)((IEnumerable)Main).OfType<VerticalStackLayout>().ToList()[i]).OfType<Border>().ToList()[SelectedRow + 1].Content as DGVCell)).Text);
					}
				}
			}
			catch
			{
			}
			return list;
		}
	}

	public bool ShowSelected { get; set; } = true;


	public int SelectedRow
	{
		get
		{
			return _SelectedRow;
		}
		set
		{
			int selectedRow = _SelectedRow;
			IView obj = ((Layout)Main).Children[0];
			if (selectedRow < ((Layout)((obj is VerticalStackLayout) ? obj : null)).Children.Count - 1)
			{
				for (int i = 0; i < ((Layout)Main).Children.Count; i++)
				{
					if (((object)((Layout)Main).Children[i]).GetType() == typeof(VerticalStackLayout))
					{
						IView obj2 = ((Layout)Main).Children[i];
						IView obj3 = ((Layout)((obj2 is VerticalStackLayout) ? obj2 : null))[_SelectedRow + 1];
						((Border)((obj3 is Border) ? obj3 : null)).StrokeThickness = BorderSize;
					}
				}
			}
			_SelectedRow = value;
			int selectedRow2 = _SelectedRow;
			IView obj4 = ((Layout)Main).Children[0];
			if (selectedRow2 >= ((Layout)((obj4 is VerticalStackLayout) ? obj4 : null)).Children.Count - 1 || !ShowSelected)
			{
				return;
			}
			for (int j = 0; j < ((Layout)Main).Children.Count; j++)
			{
				if (((object)((Layout)Main).Children[j]).GetType() == typeof(VerticalStackLayout))
				{
					IView obj5 = ((Layout)Main).Children[j];
					IView obj6 = ((Layout)((obj5 is VerticalStackLayout) ? obj5 : null))[_SelectedRow + 1];
					((Border)((obj6 is Border) ? obj6 : null)).StrokeThickness = BorderSize * 2.0;
				}
			}
		}
	}

	public DGVRows Rows
	{
		get
		{
			DGVRows dGVRows = new DGVRows();
			dGVRows.Parent = this;
			List<VerticalStackLayout> list = ((Layout)Main).Children.OfType<VerticalStackLayout>().ToList();
			for (int i = 0; i < list.Count; i++)
			{
				DGVRow dGVRow = new DGVRow();
				dGVRow.Parent = this;
				for (int j = 0; j < ((Layout)list[i]).Count; j++)
				{
					dGVRow.Add(GetCell(i, j));
				}
				if (!dGVRow.Contains(null))
				{
					dGVRows.Add(dGVRow);
				}
			}
			return dGVRows;
		}
	}

	public int SelectedColumn { get; set; } = 0;


	public bool Addedable { get; set; } = false;


	public bool Deletable { get; set; } = false;


	public LayoutOptions HorizontalOptions
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return ((View)Main).HorizontalOptions;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((View)Main).HorizontalOptions = value;
		}
	}

	public LayoutOptions VerticalOptions
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return ((View)Main).VerticalOptions;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((View)Main).VerticalOptions = value;
		}
	}

	public bool IsReadOnly { get; set; } = true;


	public double BorderSize { get; set; } = 1.0;


	public int HeaderHeight { get; set; } = 50;


	public int CellWidth { get; set; } = 100;


	public int CellHeight { get; set; } = 35;


	public DataTable DataSource
	{
		get
		{
			return DT;
		}
		set
		{
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0348: Expected O, but got Unknown
			//IL_055a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0561: Expected O, but got Unknown
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Expected O, but got Unknown
			//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_04da: Expected O, but got Unknown
			((Layout)Main).Clear();
			DT = value;
			if (DT == null)
			{
				return;
			}
			for (int i = 0; i < DT.Columns.Count; i++)
			{
				if (ExcludeColumns.Contains(DT.Columns[i].ColumnName))
				{
					continue;
				}
				DGVCell dGVCell = new DGVCell(BorderSize);
				int currentColumn = (dGVCell.CurrentRow = -1);
				dGVCell.CurrentColumn = currentColumn;
				((InputView)dGVCell).IsReadOnly = true;
				if (ReplaceColumnName.Keys.Contains(DT.Columns[i].ColumnName))
				{
					((InputView)dGVCell).Text = ReplaceColumnName[DT.Columns[i].ColumnName];
				}
				else
				{
					((InputView)dGVCell).Text = DT.Columns[i].ColumnName;
				}
				dGVCell.CurrentColumnName = DT.Columns[i].ColumnName;
				((VisualElement)dGVCell).WidthRequest = CellWidth;
				((VisualElement)dGVCell).HeightRequest = HeaderHeight;
				((VisualElement)dGVCell).Focused += delegate
				{
					UpdateAsync();
				};
				((VisualElement)dGVCell).BackgroundColor = CellColor;
				((InputView)dGVCell).TextColor = CellTextColor;
				VerticalStackLayout val = new VerticalStackLayout();
				((Layout)val).Add((IView)(object)dGVCell.CellBorder);
				VerticalStackLayout val2 = val;
				((Layout)Main).Add((IView)(object)val2);
				for (int j = 0; j < DT.Rows.Count; j++)
				{
					DGVCell EX = new DGVCell(BorderSize);
					((InputView)EX).IsReadOnly = IsReadOnly;
					EX.CurrentRow = j;
					EX.CurrentColumn = i;
					EX.CurrentColumnName = DT.Columns[i].ColumnName;
					((VisualElement)EX).Focused += delegate
					{
						UpdateAsync();
						SelectedRow = EX.CurrentRow;
						SelectedColumn = EX.CurrentColumn;
					};
					((VisualElement)EX).WidthRequest = CellWidth;
					((VisualElement)EX).HeightRequest = CellHeight;
					((InputView)EX).Text = DT.Rows[j].ItemArray[i].ToString();
					((InputView)EX).TextChanged += this.CellValueChanged;
					((VisualElement)EX).Focused += this.CellFocused;
					((VisualElement)EX).Unfocused += this.CellUnFocused;
					((VisualElement)EX).BackgroundColor = CellColor;
					((InputView)EX).TextColor = CellTextColor;
					((Layout)val2).Add((IView)(object)EX.CellBorder);
				}
			}
			if (Deletable)
			{
				VerticalStackLayout VSL = new VerticalStackLayout();
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					IView obj = ((Layout)Main).Children[0];
					if (num3 >= ((Layout)((obj is VerticalStackLayout) ? obj : null)).Children.Count)
					{
						break;
					}
					if (num2 == 0)
					{
						DGVCell dGVCell2 = new DGVCell(BorderSize);
						((InputView)dGVCell2).IsReadOnly = true;
						((VisualElement)dGVCell2).Focused += delegate
						{
							UpdateAsync();
						};
						((Layout)VSL).Add((IView)(object)dGVCell2.CellBorder);
						((VisualElement)dGVCell2).WidthRequest = CellWidth;
						((VisualElement)dGVCell2).HeightRequest = HeaderHeight;
						((VisualElement)dGVCell2).BackgroundColor = CellColor;
						((InputView)dGVCell2).TextColor = CellTextColor;
						num2++;
					}
					DGVCellButton E = new DGVCellButton();
					((Button)E).Text = "Delete";
					E.Number = num2;
					((Button)E).TextColor = Color.FromRgb(255, 0, 0);
					((VisualElement)E).WidthRequest = CellWidth;
					((VisualElement)E).HeightRequest = CellHeight;
					((VisualElement)E).BackgroundColor = CellColor;
					((Button)E).TextColor = DeleteButtonTextColor;
					((Button)E).Clicked += delegate
					{
						EClicked(E.Number, VSL);
					};
					Border val3 = new Border
					{
						Stroke = Brush.op_Implicit(Color.FromArgb("#000000")),
						StrokeThickness = BorderSize,
						HorizontalOptions = LayoutOptions.Center
					};
					val3.Content = (View)(object)E;
					((Layout)VSL).Add((IView)(object)val3);
					num2++;
				}
				((Layout)Main).Add((IView)(object)VSL);
			}
			if (Addedable)
			{
				IsReadOnly = false;
				Button val4 = new Button();
				((VisualElement)val4).WidthRequest = 75.0;
				((VisualElement)val4).HeightRequest = 50.0;
				val4.Text = "Add";
				((VisualElement)val4).BackgroundColor = AddButtonColor;
				val4.TextColor = AddButtonTextColor;
				val4.Clicked += delegate
				{
					Add();
				};
				((Layout)Main).Add((IView)(object)val4);
			}
		}
	}

	public event EventHandler<EventArgs> SelectedRowChanged;

	public event EventHandler<TextChangedEventArgs> CellValueChanged;

	public event EventHandler<FocusEventArgs> CellFocused;

	public event EventHandler<FocusEventArgs> CellUnFocused;

	public void AddColumnNameToReplace(string First, string Second)
	{
		if (!ReplaceColumnName.Keys.Contains(First))
		{
			ReplaceColumnName.Add(First, Second);
		}
	}

	public void AddExcludedColumn(params string[] All)
	{
		ExcludeColumns.AddRange(All);
	}

	public void EmbedList<T>(List<T> List)
	{
		DataTable dataTable = new DataTable();
		dataTable.Load((IDataReader)ObjectReader.Create<T>((IEnumerable<T>)List, Array.Empty<string>()));
		DataSource = dataTable;
	}

	public void EmbedArray(object[] Array)
	{
		DataTable dataTable = new DataTable();
		dataTable.Load((IDataReader)ObjectReader.Create<object>((IEnumerable<object>)Array, System.Array.Empty<string>()));
		DataSource = dataTable;
	}

	public string GetValue(int row, int column)
	{
		foreach (VerticalStackLayout item in ((Layout)Main).Children.OfType<VerticalStackLayout>())
		{
			foreach (Border item2 in ((IEnumerable)item).OfType<Border>())
			{
				if (((object)item2.Content).GetType() != typeof(DGVCellButton))
				{
					DGVCell dGVCell = item2.Content as DGVCell;
					if (dGVCell.CurrentRow == row && dGVCell.CurrentColumn == column)
					{
						return ((InputView)dGVCell).Text;
					}
				}
			}
		}
		return null;
	}

	public void SetValue(int row, int column, string Data)
	{
		foreach (VerticalStackLayout item in ((Layout)Main).Children.OfType<VerticalStackLayout>())
		{
			foreach (Border item2 in ((IEnumerable)item).OfType<Border>())
			{
				if (((object)item2.Content).GetType() != typeof(DGVCellButton))
				{
					DGVCell dGVCell = item2.Content as DGVCell;
					if (dGVCell.CurrentRow == row && dGVCell.CurrentColumn == column)
					{
						((InputView)dGVCell).Text = Data;
					}
				}
			}
		}
	}

	public DGVCell GetCell(int row, int column)
	{
		foreach (VerticalStackLayout item in ((Layout)Main).Children.OfType<VerticalStackLayout>())
		{
			foreach (Border item2 in ((IEnumerable)item).OfType<Border>())
			{
				if (((object)item2.Content).GetType() != typeof(DGVCellButton))
				{
					DGVCell dGVCell = item2.Content as DGVCell;
					if (dGVCell.CurrentRow == row && dGVCell.CurrentColumn == column)
					{
						return dGVCell;
					}
				}
			}
		}
		return null;
	}

	public ElroubyDGV()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		((ContentView)this).Content = (View)(object)Main;
	}

	private void EClicked(int Number, VerticalStackLayout VSL)
	{
		List<Border> list = ((IEnumerable)VSL).OfType<Border>().ToList();
		for (int i = 1; i < list.Count(); i++)
		{
			(list[i].Content as DGVCellButton).Number = i;
		}
		foreach (VerticalStackLayout item in ((IEnumerable)Main).OfType<VerticalStackLayout>())
		{
			((Layout)item).RemoveAt(Number);
		}
	}

	public void UpdateAsync()
	{
		List<VerticalStackLayout> list = ((IEnumerable)Main).OfType<VerticalStackLayout>().ToList();
		for (int i = 1; i < list.Count; i++)
		{
			List<Border> list2 = ((IEnumerable)list[i]).OfType<Border>().ToList();
			for (int j = 1; j < list2.Count; j++)
			{
				if (((object)list2[j].Content).GetType() != typeof(DGVCellButton))
				{
					(list2[j].Content as DGVCell).CurrentRow = j - 1;
					(list2[j].Content as DGVCell).CurrentColumn = i - 1;
				}
			}
		}
	}

	public void Add()
	{
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		int num = 0;
		List<VerticalStackLayout> list = ((IEnumerable)Main).OfType<VerticalStackLayout>().ToList();
		int currentRow = ((IEnumerable)list[0]).OfType<Border>().Count() - 1;
		foreach (VerticalStackLayout VSL in ((IEnumerable)Main).OfType<VerticalStackLayout>())
		{
			if (num == list.Count - 1 && Deletable)
			{
				DGVCellButton E = new DGVCellButton();
				((Button)E).Text = "Delete";
				E.Number = num;
				((Button)E).TextColor = Color.FromRgb(255, 0, 0);
				((VisualElement)E).WidthRequest = CellWidth;
				((VisualElement)E).HeightRequest = CellHeight;
				((VisualElement)E).BackgroundColor = CellColor;
				((Button)E).TextColor = DeleteButtonTextColor;
				((Button)E).Clicked += delegate
				{
					EClicked(E.Number, VSL);
				};
				Border val = new Border
				{
					Stroke = Brush.op_Implicit(Color.FromArgb("#000000")),
					StrokeThickness = BorderSize,
					HorizontalOptions = LayoutOptions.Center
				};
				val.Content = (View)(object)E;
				((Layout)VSL).Add((IView)(object)val);
			}
			else
			{
				DGVCell DC = new DGVCell(BorderSize);
				((InputView)DC).IsReadOnly = false;
				((VisualElement)DC).WidthRequest = CellWidth;
				((VisualElement)DC).HeightRequest = CellHeight;
				((VisualElement)DC).BackgroundColor = CellColor;
				((InputView)DC).TextColor = CellTextColor;
				DC.CurrentRow = currentRow;
				DC.CurrentColumn = num;
				((VisualElement)DC).Focused += delegate
				{
					UpdateAsync();
					SelectedRow = DC.CurrentRow;
					SelectedColumn = DC.CurrentColumn;
				};
				((Layout)VSL).Add((IView)(object)DC.CellBorder);
				num++;
			}
		}
	}
}
