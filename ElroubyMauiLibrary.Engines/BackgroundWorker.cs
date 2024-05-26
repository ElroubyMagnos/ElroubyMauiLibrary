using System;
using System.Threading;
using ElroubyMauiLibrary.Interfaces;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary.Engines;

public class BackgroundWorker : IWorker
{
	public int Interval;

	private Thread Body { get; set; }

	public bool Circle { get; set; }

	private ElroubyTimer Timer { get; set; }

	public BackgroundWorker(Action Action, bool Circle, int Interval = 1000)
	{
		this.Interval = Interval;
		Body = new Thread((ThreadStart)delegate
		{
			((BindableObject)Application.Current).Dispatcher.Dispatch(Action);
		});
		Timer = new ElroubyTimer(Action, Interval);
		this.Circle = Circle;
	}

	public void Start()
	{
		if (Circle)
		{
			Timer.Start();
		}
		else if (Body.ThreadState != 0)
		{
			Body.Start();
		}
	}

	public void Stop()
	{
		if (Circle)
		{
			Timer.Stop();
		}
	}
}
