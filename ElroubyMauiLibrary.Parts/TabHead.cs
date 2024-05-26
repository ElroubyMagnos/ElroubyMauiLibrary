using System.Collections;
using System.Linq;
using ElroubyMauiLibrary.Components;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.Parts;

public class TabHead : HorizontalStackLayout
{
	public Button Core = new Button();

	public TabControl Parent;

	public TabPage HeadOf;

	public string Text
	{
		get
		{
			return Core.Text;
		}
		set
		{
			Core.Text = value;
		}
	}

	public event TabControl.TabControlEventsSingle TabClosed;

	public TabHead(TabPage HeadOf)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		TabHead tabHead = this;
		((VisualElement)this).BackgroundColor = Colors.BlueViolet;
		this.HeadOf = HeadOf;
		Core.Clicked += delegate
		{
			tabHead.Parent.CurrentTab = HeadOf;
			foreach (TabHead item in ((IEnumerable)tabHead.Parent.HeadSelect).OfType<TabHead>())
			{
				((VisualElement)item.Core).BackgroundColor = Colors.BlueViolet;
				((VisualElement)item.Core).IsEnabled = true;
			}
			((VisualElement)tabHead.Core).IsEnabled = false;
			((VisualElement)tabHead.Core).BackgroundColor = Colors.OrangeRed;
		};
		((VisualElement)Core).BackgroundColor = Colors.BlueViolet;
		Core.CornerRadius = 0;
		((View)Core).Margin = Thickness.op_Implicit(0.0);
		Core.Padding = Thickness.op_Implicit(5.0);
		((Layout)this).Add((IView)(object)Core);
		Button val = new Button();
		val.Text = "X";
		((VisualElement)val).BackgroundColor = Colors.Red;
		((VisualElement)val).WidthRequest = 25.0;
		val.Padding = Thickness.op_Implicit(3.0);
		val.CornerRadius = 0;
		((View)val).Margin = Thickness.op_Implicit(0.0);
		val.Clicked += delegate
		{
			((Layout)tabHead.Parent.HeadSelect).Remove((IView)(object)tabHead.Core);
			tabHead.Parent.TabPages.Remove(HeadOf);
			if (((Layout)tabHead.Parent.HeadSelect).Count > 0)
			{
				tabHead.Parent.CurrentTab = tabHead.Parent.TabPages[0];
				foreach (TabHead item2 in ((IEnumerable)tabHead.Parent.HeadSelect).OfType<TabHead>())
				{
					((VisualElement)item2.Core).BackgroundColor = Colors.BlueViolet;
					((VisualElement)item2.Core).IsEnabled = true;
				}
				((VisualElement)tabHead.Parent.TabPages[0].Head.Core).IsEnabled = false;
				((VisualElement)tabHead.Parent.TabPages[0].Head.Core).BackgroundColor = Colors.OrangeRed;
			}
			else if (((Layout)tabHead.Parent.HeadSelect).Count == 0)
			{
				((Layout)tabHead.Parent.VSL).Clear();
				((Layout)tabHead.Parent.VSL).Add((IView)(object)tabHead.Parent.HeadSelect);
			}
			if (tabHead.TabClosed != null)
			{
				tabHead.TabClosed(HeadOf);
			}
		};
		((Layout)this).Add((IView)(object)val);
	}
}
