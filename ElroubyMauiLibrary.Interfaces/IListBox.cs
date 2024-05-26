using System;
using System.Data;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Interfaces;

public interface IListBox
{
	LayoutOptions HorizontalOptions { get; set; }

	LayoutOptions VerticalOptions { get; set; }

	VerticalStackLayout Body { get; set; }

	DataTable DataTableSource { get; set; }

	int SelectedIndex { get; set; }

	object SelectedValue { get; set; }

	string SelectedColumn { get; set; }

	string ValueColumn { get; set; }

	double BorderSize { get; set; }

	event EventHandler<TextChangedEventArgs> CellValueChanged;

	event EventHandler<FocusEventArgs> CellFocused;

	event EventHandler<FocusEventArgs> CellUnFocused;
}
