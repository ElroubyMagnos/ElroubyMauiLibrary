using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using ElroubyMauiLibrary.EntryBased;
using ElroubyMauiLibrary.GridBase;
using FastMember;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Storage;

namespace ElroubyMauiLibrary.Special;

[XamlFilePath("Special\\DataGridView.xaml")]
public class DataGridView : ContentView
{
	public List<GridControl> SelectedRow = new List<GridControl>();

	public List<GridControl> SelectedColumn = new List<GridControl>();

	private int _SelectedRowIndex;

	private int _SelectedColumnIndex;

	private double _FontSizeOfColumns;

	private double _FontSizeOfCells;

	private double _CellWidth;

	private double _CellHeight;

	public Dictionary<int, Type> ColumnsDataSet = new Dictionary<int, Type>();

	private double _ImagesWidth = 100.0;

	private double _ImagesHeight = 100.0;

	private Color _ImageBackColor;

	private bool _IsReadOnly;

	private Color _CellColor;

	private Color _CellTextColor;

	private Color _CellColumnColor;

	private Color _CellColumnTextColor;

	private DataTable Core;

	private GridSaveButton GridSaveButton = new GridSaveButton();

	private GridDeleteButton GridDeleteButton = new GridDeleteButton();

	private GridAddButton GridAddButton = new GridAddButton();

	private GridReloadButton GridReloadButton = new GridReloadButton();

	private ColumnDefinition ForPanel = new ColumnDefinition();

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Grid Main;

	public bool Panel { get; set; } = false;


	public int RowsCount => Core.Rows.Count;

	public int ColumnsCount => ColumnsDataSet.Count;

	public bool ColorColumnInSelection { get; set; } = false;


	public Color SelectedRowColor { get; set; } = Color.FromRgba(0.0, 0.0, 225.0, 0.5);


	public Color SelectedColumnColor { get; set; } = Color.FromRgba(0.0, 225.0, 0.0, 0.5);


	public int SelectedRowIndex
	{
		get
		{
			return _SelectedRowIndex;
		}
		set
		{
			if (value <= -1)
			{
				return;
			}
			if (this.SelectedRowChanged != null)
			{
				this.SelectedRowChanged(this, new EventArgs());
			}
			_SelectedRowIndex = value;
			foreach (GridControl item in SelectedRow)
			{
				item.BackgroundColor = CellColor;
			}
			SelectedRow.Clear();
			bool flag = false;
			foreach (GridControl item2 in ((IEnumerable)Main).OfType<GridControl>())
			{
				if (item2.Row == _SelectedRowIndex)
				{
					SelectedRow.Add(item2);
				}
			}
			if (!flag)
			{
				SelectedRowIndex = -1;
			}
		}
	}

	public int SelectedColumnIndex
	{
		get
		{
			return _SelectedColumnIndex;
		}
		set
		{
			if (value <= -1)
			{
				return;
			}
			if (this.SelectedColumnChanged != null)
			{
				this.SelectedColumnChanged(this, new EventArgs());
			}
			_SelectedColumnIndex = value;
			foreach (GridControl item in SelectedColumn)
			{
				item.BackgroundColor = CellColor;
			}
			SelectedColumn.Clear();
			bool flag = false;
			foreach (GridControl item2 in ((IEnumerable)Main).OfType<GridControl>())
			{
				if (item2.Column == _SelectedColumnIndex)
				{
					SelectedColumn.Add(item2);
					if (ColorColumnInSelection)
					{
						item2.BackgroundColor = SelectedColumnColor;
					}
				}
			}
			if (!flag)
			{
				SelectedColumnIndex = -1;
			}
		}
	}

	public double FontSizeOfColumns
	{
		get
		{
			return _FontSizeOfColumns;
		}
		set
		{
			_FontSizeOfColumns = value;
			foreach (Entry item in ((IEnumerable)Main).OfType<Entry>())
			{
				if (((object)item).GetType() == typeof(Entry))
				{
					item.FontSize = _FontSizeOfColumns;
				}
			}
		}
	}

	public double FontSizeOfCells
	{
		get
		{
			return _FontSizeOfCells;
		}
		set
		{
			_FontSizeOfCells = value;
			foreach (StringEntry item in ((IEnumerable)Main).OfType<StringEntry>())
			{
				((Entry)item).FontSize = _FontSizeOfCells;
			}
		}
	}

	public double CellWidth
	{
		get
		{
			return _CellWidth;
		}
		set
		{
			_CellWidth = value;
			foreach (Entry item in ((IEnumerable)Main).OfType<Entry>())
			{
				((VisualElement)item).WidthRequest = _CellWidth;
			}
			foreach (ImageButton item2 in ((IEnumerable)Main).OfType<ImageButton>())
			{
				((VisualElement)item2).WidthRequest = _CellWidth;
			}
		}
	}

	public double CellHeight
	{
		get
		{
			return _CellHeight;
		}
		set
		{
			_CellHeight = value;
			foreach (Entry item in ((IEnumerable)Main).OfType<Entry>())
			{
				((VisualElement)item).HeightRequest = _CellHeight;
			}
			foreach (ImageButton item2 in ((IEnumerable)Main).OfType<ImageButton>())
			{
				((VisualElement)item2).HeightRequest = _CellHeight;
			}
		}
	}

	public double WidthRequest
	{
		get
		{
			return ((VisualElement)Main).WidthRequest;
		}
		set
		{
			double widthRequest = (((VisualElement)Main).WidthRequest = value);
			((VisualElement)this).WidthRequest = widthRequest;
		}
	}

	public double HeightRequest
	{
		get
		{
			return ((VisualElement)Main).HeightRequest;
		}
		set
		{
			double widthRequest = (((VisualElement)Main).HeightRequest = value);
			((VisualElement)this).WidthRequest = widthRequest;
		}
	}

	private Dictionary<string, string> ReplaceColumnName { get; set; } = new Dictionary<string, string>();


	private List<string> ExcludeColumns { get; set; } = new List<string>();


	private List<int> ExcludeColumnsNumber { get; set; } = new List<int>();


	public double ImagesWidth
	{
		get
		{
			return _ImagesWidth;
		}
		set
		{
			_ImagesWidth = value;
			foreach (ImageButton item in ((IEnumerable)Main).OfType<ImageButton>())
			{
				((VisualElement)item).WidthRequest = _ImagesWidth;
			}
		}
	}

	public double ImagesHeight
	{
		get
		{
			return _ImagesHeight;
		}
		set
		{
			_ImagesHeight = value;
			foreach (ImageButton item in ((IEnumerable)Main).OfType<ImageButton>())
			{
				((VisualElement)item).HeightRequest = _ImagesHeight;
			}
		}
	}

	public Color ImageBackColor
	{
		get
		{
			return _ImageBackColor;
		}
		set
		{
			_ImageBackColor = value;
			foreach (ImageButton item in ((IEnumerable)Main).OfType<ImageButton>())
			{
				((VisualElement)item).BackgroundColor = _ImageBackColor;
			}
		}
	}

	public bool IsReadOnly
	{
		get
		{
			return _IsReadOnly;
		}
		set
		{
			_IsReadOnly = value;
			foreach (StringEntry item in ((IEnumerable)Main).OfType<StringEntry>())
			{
				((InputView)item).IsReadOnly = _IsReadOnly;
			}
		}
	}

	public Color CellColor
	{
		get
		{
			return _CellColor;
		}
		set
		{
			_CellColor = value;
			foreach (StringEntry item in ((IEnumerable)Main).OfType<StringEntry>())
			{
				((VisualElement)item).BackgroundColor = _CellColor;
			}
		}
	}

	public Color CellTextColor
	{
		get
		{
			return _CellTextColor;
		}
		set
		{
			_CellTextColor = value;
			foreach (StringEntry item in ((IEnumerable)Main).OfType<StringEntry>())
			{
				((InputView)item).TextColor = _CellTextColor;
			}
		}
	}

	public Color CellColumnColor
	{
		get
		{
			return _CellColumnColor;
		}
		set
		{
			_CellColumnColor = value;
			foreach (Entry item in ((IEnumerable)Main).OfType<Entry>())
			{
				if (((object)item).GetType() == typeof(Entry))
				{
					((VisualElement)item).BackgroundColor = _CellColumnColor;
				}
			}
		}
	}

	public Color CellColumnTextColor
	{
		get
		{
			return _CellColumnTextColor;
		}
		set
		{
			_CellColumnTextColor = value;
			foreach (Entry item in ((IEnumerable)Main).OfType<Entry>())
			{
				if (((object)item).GetType() == typeof(Entry))
				{
					((InputView)item).TextColor = _CellColumnTextColor;
				}
			}
		}
	}

	public DataTable DataSource
	{
		get
		{
			return Core;
		}
		set
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			((Layout)Main).Clear();
			ColumnsDataSet.Clear();
			((DefinitionCollection<ColumnDefinition>)(object)Main.ColumnDefinitions).Clear();
			((DefinitionCollection<RowDefinition>)(object)Main.RowDefinitions).Clear();
			Core = value;
			if (Core == null)
			{
				return;
			}
			for (int i = 0; i < Core.Rows.Count + 1; i++)
			{
				Main.AddRowDefinition(new RowDefinition());
			}
			for (int j = 0; j < Core.Columns.Count; j++)
			{
				if (ExcludeColumns.Contains(Core.Columns[j].ColumnName))
				{
					Core.Columns.Remove(Core.Columns[j]);
					ExcludeColumnsNumber.Add(j);
					continue;
				}
				Main.AddColumnDefinition(new ColumnDefinition());
				Entry val = new Entry();
				if (ReplaceColumnName.Keys.Contains(Core.Columns[j].ColumnName))
				{
					((InputView)val).Text = ReplaceColumnName[Core.Columns[j].ColumnName];
				}
				else
				{
					((InputView)val).Text = Core.Columns[j].ColumnName;
				}
				((InputView)val).IsReadOnly = true;
				((VisualElement)val).BackgroundColor = CellColor;
				((InputView)val).TextColor = CellTextColor;
				val.HorizontalTextAlignment = (TextAlignment)1;
				val.VerticalTextAlignment = (TextAlignment)1;
				val.FontAttributes = (FontAttributes)1;
				ColumnsDataSet.Add(j, Core.Columns[j].DataType);
				GridExtensions.Add(Main, (IView)(object)val, j, 0);
			}
			for (int k = 0; k < Core.Rows.Count; k++)
			{
				for (int l = 0; l < Core.Rows[k].ItemArray.Count(); l++)
				{
					if (!ExcludeColumnsNumber.Contains(l))
					{
						LoadRow(l, k);
					}
				}
			}
			LoadPanel();
		}
	}

	public string SaveButtonImg
	{
		get
		{
			return ((object)((ImageButton)GridSaveButton).Source).ToString();
		}
		set
		{
			((ImageButton)GridSaveButton).Source = ImageSource.FromFile(value);
		}
	}

	public string DeleteButtonImg
	{
		get
		{
			return ((object)((ImageButton)GridDeleteButton).Source).ToString();
		}
		set
		{
			((ImageButton)GridDeleteButton).Source = ImageSource.FromFile(value);
		}
	}

	public string AddButtonImg
	{
		get
		{
			return ((object)((ImageButton)GridAddButton).Source).ToString();
		}
		set
		{
			((ImageButton)GridAddButton).Source = ImageSource.FromFile(value);
		}
	}

	public string ReloadButtonImg
	{
		get
		{
			return ((object)((ImageButton)GridReloadButton).Source).ToString();
		}
		set
		{
			((ImageButton)GridReloadButton).Source = ImageSource.FromFile(value);
		}
	}

	public event EventHandler<EventArgs> SelectedRowChanged;

	public event EventHandler<EventArgs> SelectedColumnChanged;

	public event EventHandler<EventArgs> UserDeletedRow;

	private void LoadRow(int Column, int Row)
	{
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		StringEntry E = null;
		switch (ColumnsDataSet[Column].ToString())
		{
		default:
			E = new StringEntry();
			break;
		case "System.String":
			E = new StringEntry();
			break;
		case "System.Boolean":
		{
			GridCheckBox CB = new GridCheckBox();
			CB.Text = Core.Rows[Row][Column].ToString();
			((VisualElement)CB).BackgroundColor = CellColor;
			((CheckBox)CB).IsChecked = false;
			((View)CB).HorizontalOptions = LayoutOptions.Center;
			((View)CB).VerticalOptions = LayoutOptions.Center;
			CB.Column = Column;
			CB.Row = Row;
			((VisualElement)CB).Focused += delegate
			{
				SelectedRowIndex = CB.Row - 1;
				SelectedColumnIndex = CB.Column;
				ColorSelectedRow();
			};
			GridExtensions.Add(Main, (IView)(object)CB, Column, Row + 1);
			return;
		}
		case "System.Char":
		{
			GridLabel LBL = new GridLabel();
			LBL.Text = Core.Rows[Row].ItemArray[Column].ToStringOrEmpty();
			((VisualElement)LBL).BackgroundColor = CellColor;
			((InputView)LBL).TextColor = CellTextColor;
			((Entry)LBL).HorizontalTextAlignment = (TextAlignment)1;
			((Entry)LBL).VerticalTextAlignment = (TextAlignment)1;
			LBL.Column = Column;
			LBL.Row = Row;
			((VisualElement)LBL).Focused += delegate
			{
				SelectedRowIndex = LBL.Row;
				SelectedColumnIndex = LBL.Column;
				ColorSelectedRow();
			};
			GridExtensions.Add(Main, (IView)(object)LBL, Column, Row + 1);
			return;
		}
		case "System.DateTime":
		{
			GridDate DP = new GridDate();
			((DatePicker)DP).Date = Core.Rows[Row].ItemArray[Column].ToStringOrEmpty().ConvertFromString();
			DP.IsReadOnly = IsReadOnly;
			((VisualElement)DP).BackgroundColor = CellColor;
			((DatePicker)DP).TextColor = CellTextColor;
			((View)DP).HorizontalOptions = LayoutOptions.Center;
			((View)DP).VerticalOptions = LayoutOptions.Center;
			DP.Column = Column;
			DP.Row = Row;
			((VisualElement)DP).Focused += delegate
			{
				SelectedRowIndex = DP.Row;
				SelectedColumnIndex = DP.Column;
				ColorSelectedRow();
			};
			GridExtensions.Add(Main, (IView)(object)DP, Column, Row + 1);
			return;
		}
		case "System.Double":
		case "System.Decimal":
			E = new DoubleBox();
			break;
		case "System.Single":
		case "System.UInt16":
		case "System.UInt32":
		case "System.UInt64":
		case "System.Byte":
		case "System.Int64":
		case "System.SByte":
		case "System.Int16":
		case "System.Int32":
			E = new IntegerBox();
			break;
		case "System.Byte[]":
		{
			GridImage img = new GridImage();
			img.BackgroundColor = ImageBackColor;
			((VisualElement)img).WidthRequest = ImagesWidth;
			((VisualElement)img).HeightRequest = ImagesHeight;
			img.HorizontalOptions = LayoutOptions.Center;
			img.VerticalOptions = LayoutOptions.Center;
			img.Column = Column;
			img.Row = Row;
			((ImageButton)img).Source = Extensions.ConvertFrom(Core.Rows[Row].ItemArray[Column] as byte[]);
			((VisualElement)img).Focused += delegate
			{
				SelectedRowIndex = img.Row;
				SelectedColumnIndex = img.Column;
				ColorSelectedRow();
			};
			((ImageButton)img).Clicked += async delegate
			{
				if (!IsReadOnly)
				{
					FileResult F = await FilePicker.PickAsync((PickOptions)null);
					if (File.Exists(((FileBase)F).FullPath))
					{
						((ImageButton)img).Source = ImageSource.FromFile(((FileBase)F).FullPath);
					}
				}
			};
			GridExtensions.Add(Main, (IView)(object)img, Column, Row + 1);
			return;
		}
		}
		((InputView)E).Text = Core.Rows[Row].ItemArray[Column].ToStringOrEmpty();
		((InputView)E).IsReadOnly = IsReadOnly;
		((VisualElement)E).BackgroundColor = CellColor;
		((InputView)E).TextColor = CellTextColor;
		((Entry)E).VerticalTextAlignment = (TextAlignment)1;
		((Entry)E).HorizontalTextAlignment = (TextAlignment)1;
		E.Column = Column;
		E.Row = Row;
		((VisualElement)E).Focused += delegate
		{
			SelectedRowIndex = E.Row;
			SelectedColumnIndex = E.Column;
			ColorSelectedRow();
		};
		GridExtensions.Add(Main, (IView)(object)E, Column, Row + 1);
	}

	public List<object> GetRowAt(int index)
	{
		if (index < 0 || index > Core.Rows.Count - 1)
		{
			return null;
		}
		DataRow dataRow = Core.Rows.OfType<object>().ToList()[index] as DataRow;
		return dataRow.ItemArray.ToList();
	}

	public List<object> GetFirstRow()
	{
		if (Core.Rows.Count < 1)
		{
			return null;
		}
		DataRow dataRow = Core.Rows.OfType<object>().ToList()[0] as DataRow;
		return dataRow.ItemArray.ToList();
	}

	public List<object> GetLastRow()
	{
		if (Core.Rows.Count < 1)
		{
			return null;
		}
		DataRow dataRow = Core.Rows.OfType<object>().ToList()[Core.Rows.Count - 1] as DataRow;
		return dataRow.ItemArray.ToList();
	}

	public List<GridControl> GetFirstRowControl()
	{
		List<GridControl> list = new List<GridControl>();
		foreach (GridControl item in ((IEnumerable)Main).OfType<GridControl>())
		{
			if (item.Row == 0)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public List<GridControl> GetLastRowControl()
	{
		List<GridControl> list = new List<GridControl>();
		int num = Core.Rows.Count - 1;
		foreach (GridControl item in ((IEnumerable)Main).OfType<GridControl>())
		{
			if (item.Row == num)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public List<GridControl> AddEmptyRow()
	{
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Expected O, but got Unknown
		List<GridControl> list = new List<GridControl>();
		DataRow dataRow = Core.NewRow();
		dataRow.ItemArray = Core.Rows[0].ItemArray;
		for (int i = 0; i < DataSource.Rows[0].ItemArray.Length; i++)
		{
			switch (DataSource.Rows[0].ItemArray[i].GetType().ToString())
			{
			case "System.String":
				list.Add(new StringEntry());
				dataRow[i] = "";
				break;
			case "System.Boolean":
				list.Add(new GridCheckBox());
				dataRow[i] = false;
				break;
			case "System.Char":
				list.Add(new GridLabel());
				dataRow[i] = '\0';
				break;
			case "System.DateTime":
				list.Add(new GridDate());
				dataRow[i] = DateTime.Now;
				break;
			case "System.Single":
			case "System.Double":
			case "System.UInt16":
			case "System.UInt32":
			case "System.UInt64":
			case "System.Decimal":
			case "System.Byte":
			case "System.Int64":
			case "System.SByte":
			case "System.Int16":
			case "System.Int32":
				dataRow[i] = 0.0;
				list.Add(new DoubleBox());
				break;
			case "System.Byte[]":
			{
				GridImage gridImage = new GridImage();
				((ImageButton)gridImage).Source = ImageSource.op_Implicit(AppDomain.CurrentDomain.BaseDirectory + "Photos\\emptypic.jpg");
				list.Add(gridImage);
				dataRow[i] = new byte[0];
				break;
			}
			}
		}
		Core.Rows.Add(dataRow);
		for (int j = 0; j <= list.Count; j++)
		{
			Main.AddRowDefinition(new RowDefinition());
			LoadRow(j, RowsCount - 1);
		}
		return list;
	}

	public void InsertEmptyRowAt(int RowIndex)
	{
		List<GridControl> list = new List<GridControl>();
		DataRow dataRow = Core.NewRow();
		dataRow.ItemArray = Core.Rows[0].ItemArray;
		for (int i = 0; i < DataSource.Rows[0].ItemArray.Length; i++)
		{
			switch (DataSource.Rows[0].ItemArray[i].GetType().ToString())
			{
			case "System.String":
				list.Add(new StringEntry());
				dataRow[i] = "";
				break;
			case "System.Boolean":
				list.Add(new GridCheckBox());
				dataRow[i] = false;
				break;
			case "System.Char":
				list.Add(new GridLabel());
				dataRow[i] = '\0';
				break;
			case "System.DateTime":
				list.Add(new GridDate());
				dataRow[i] = DateTime.Now;
				break;
			case "System.Single":
			case "System.Double":
			case "System.UInt16":
			case "System.UInt32":
			case "System.UInt64":
			case "System.Decimal":
			case "System.Byte":
			case "System.Int64":
			case "System.SByte":
			case "System.Int16":
			case "System.Int32":
				dataRow[i] = 0.0;
				list.Add(new DoubleBox());
				break;
			case "System.Byte[]":
			{
				GridImage gridImage = new GridImage();
				((ImageButton)gridImage).Source = ImageSource.op_Implicit(AppDomain.CurrentDomain.BaseDirectory + "Photos\\emptypic.jpg");
				list.Add(gridImage);
				dataRow[i] = new byte[0];
				break;
			}
			}
		}
		Core.Rows.InsertAt(dataRow, RowIndex);
		Reload();
	}

	public void InsertRowAt(List<object> contents, int index)
	{
		if (ColumnsCount == contents.Count)
		{
			DataRow dataRow = Core.NewRow();
			dataRow.ItemArray = contents.ToArray();
			Core.Rows.InsertAt(dataRow, index);
			Reload();
		}
	}

	public void AddRow(List<object> contents)
	{
		if (ColumnsCount == contents.Count)
		{
			DataRow dataRow = Core.NewRow();
			dataRow.ItemArray = contents.ToArray();
			Core.Rows.Add(dataRow);
			AddEmptyRow();
			for (int i = 0; i < ColumnsCount; i++)
			{
				SetCell(RowsCount - 1, i, contents[i]);
			}
		}
	}

	public void Reload()
	{
		DataSource = Core;
		LoadPanel();
	}

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

	public DataGridView()
	{
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		InitializeComponent();
		((ImageButton)GridDeleteButton).Clicked += delegate
		{
			DeleteSelected();
		};
		((ImageButton)GridAddButton).Clicked += delegate
		{
			AddEmptyRow();
		};
		((ImageButton)GridReloadButton).Clicked += delegate
		{
			Reload();
		};
		((ImageButton)GridSaveButton).Clicked += delegate
		{
			SaveAll();
		};
	}

	public void SaveAll()
	{
		foreach (GridControl item in ((IEnumerable)Main).OfType<GridControl>())
		{
			if (item.Column >= 0 && item.Row >= 0 && item.Column < ColumnsCount && item.Row < RowsCount)
			{
				Core.Rows[item.Row][item.Column] = item.Text;
			}
		}
	}

	public void EmbedArray(object[] Array)
	{
		DataTable dataTable = new DataTable();
		dataTable.Load((IDataReader)ObjectReader.Create<object>((IEnumerable<object>)Array, System.Array.Empty<string>()));
		DataSource = dataTable;
	}

	public void EmbedList<T>(List<T> List)
	{
		DataTable dataTable = new DataTable();
		dataTable.Load((IDataReader)ObjectReader.Create<T>((IEnumerable<T>)List, Array.Empty<string>()));
		DataSource = dataTable;
	}

	private void ColorSelectedRow()
	{
		foreach (GridControl item in ((IEnumerable)Main).OfType<GridControl>())
		{
			if (item.Row == SelectedRowIndex && item.GetType() != typeof(GridDeleteButton) && !ColorColumnInSelection)
			{
				item.BackgroundColor = SelectedRowColor;
			}
		}
	}

	public void SetCell(int row, int column, object Value)
	{
		foreach (GridControl item in ((IEnumerable)Main).OfType<GridControl>())
		{
			if (item.Row == row && item.Column == column)
			{
				item.Text = Value.ToString();
				Core.Rows[row][column] = item.Text;
				return;
			}
		}
		throw new Exception("Attention: row and column number not found to set its Value");
	}

	public GridControl GetCell(int row, int column)
	{
		foreach (GridControl item in ((IEnumerable)Main).OfType<GridControl>())
		{
			if (item.Row == row && item.Column == column)
			{
				return item;
			}
		}
		return null;
	}

	private void LoadPanel()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		if (Panel)
		{
			((Layout)Main).Remove((IView)(object)GridDeleteButton);
			((Layout)Main).Remove((IView)(object)GridAddButton);
			((Layout)Main).Remove((IView)(object)GridReloadButton);
			((Layout)Main).Remove((IView)(object)GridSaveButton);
			((DefinitionCollection<ColumnDefinition>)(object)Main.ColumnDefinitions).Remove(ForPanel);
			Entry val = new Entry();
			((InputView)val).Text = "Action";
			val.FontAttributes = (FontAttributes)1;
			val.HorizontalTextAlignment = (TextAlignment)1;
			GridExtensions.Add(Main, (IView)(object)val, Core.Columns.Count, 0);
			((DefinitionCollection<ColumnDefinition>)(object)Main.ColumnDefinitions).Add(ForPanel);
			GridExtensions.Add(Main, (IView)(object)GridReloadButton, Core.Columns.Count, 1);
			GridExtensions.Add(Main, (IView)(object)GridDeleteButton, Core.Columns.Count, 2);
			GridExtensions.Add(Main, (IView)(object)GridAddButton, Core.Columns.Count, 3);
			GridExtensions.Add(Main, (IView)(object)GridSaveButton, Core.Columns.Count, 4);
		}
	}

	public void DeleteSelected()
	{
		Core.Rows.RemoveAt(SelectedRowIndex);
		List<GridControl> list = new List<GridControl>();
		foreach (GridControl item in ((IEnumerable)Main).OfType<GridControl>())
		{
			if (item.Row == SelectedRowIndex)
			{
				list.Add(item);
			}
		}
		foreach (GridControl item2 in list)
		{
			((Layout)Main).Remove((IView)((item2 is IView) ? item2 : null));
		}
		if (RowsCount - 1 > SelectedRowIndex)
		{
			for (int i = SelectedRowIndex + 1; i < RowsCount; i++)
			{
				foreach (GridControl item3 in ((IEnumerable)Main).OfType<GridControl>())
				{
					if (item3.Row == i)
					{
						item3.Row = i - 1;
					}
				}
			}
		}
		SelectedRowIndex = -1;
		Reload();
		if (this.UserDeletedRow != null)
		{
			this.UserDeletedRow(this, new EventArgs());
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("Main")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<DataGridView>(this, typeof(DataGridView));
		Main = NameScopeExtensions.FindByName<Grid>((Element)(object)this, "Main");
	}
}
