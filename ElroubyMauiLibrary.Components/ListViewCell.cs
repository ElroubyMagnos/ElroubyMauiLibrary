using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ElroubyMauiLibrary.Components;

public class ListViewCell : VerticalStackLayout
{
	private Entry HeadX = new Entry();

	private Entry SonX = new Entry();

	public string Head
	{
		get
		{
			return ((InputView)HeadX).Text;
		}
		set
		{
			((InputView)HeadX).Text = value;
		}
	}

	public string Son
	{
		get
		{
			return ((InputView)SonX).Text;
		}
		set
		{
			((InputView)SonX).Text = value;
		}
	}

	public ListViewCell()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		((InputView)HeadX).TextColor = Colors.Black;
		((InputView)SonX).TextColor = Colors.Grey;
		((Layout)this).Add((IView)(object)HeadX);
		((Layout)this).Add((IView)(object)SonX);
		Entry headX = HeadX;
		bool isReadOnly = (((InputView)SonX).IsReadOnly = true);
		((InputView)headX).IsReadOnly = isReadOnly;
	}
}
