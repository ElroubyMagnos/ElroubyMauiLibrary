using System;
using System.Threading;
using ElroubyMauiLibrary.Interfaces;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary;

public class ElroubyTimer : IWorker
{
	public int Interval;

	private Thread Thread = null;

	private bool IsRunning { get; set; } = false;


	public Action Action { get; set; }

	public ElroubyTimer(Action Action, int Interval = 1000)
	{
		this.Action = Action;
		this.Interval = Interval;
	}

	public void Start()
	{
		IsRunning = true;
		Thread = new Thread((ThreadStart)delegate
		{
			while (IsRunning)
			{
				((BindableObject)Application.Current).Dispatcher.Dispatch(Action);
				Thread.Sleep(Interval);
			}
		});
		Thread.Start();
	}

	public void Stop()
	{
		IsRunning = false;
	}
}
