using System;
using ElroubyMauiLibrary.Parts;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Components;

public class TabPage : VerticalStackLayout
{
	public TabControl Parent
	{
		get
		{
			return Head.Parent;
		}
		set
		{
			Head.Parent = value;
		}
	}

	public string Name { get; set; }

	public string Text
	{
		get
		{
			return Head.Text;
		}
		set
		{
			Head.Text = value;
		}
	}

	public TabHead Head { get; set; }

	public TabPage(string Name, string Text)
	{
		TabHead head = new TabHead(this);
		Head = head;
		this.Name = Name;
		this.Text = Text;
	}

	public TabPage()
	{
		TabHead head = new TabHead(this);
		Head = head;
		Name = new Random().Next().ToString();
		Text = "Not Set";
	}
}
