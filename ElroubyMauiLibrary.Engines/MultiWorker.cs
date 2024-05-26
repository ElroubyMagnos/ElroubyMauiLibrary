using System;
using System.Collections.Generic;
using System.Linq;
using ElroubyMauiLibrary.Interfaces;

namespace ElroubyMauiLibrary.Engines;

public class MultiWorker : IWorker
{
	public List<Action> AllTasks = new List<Action>();

	private ElroubyTimer Timer;

	public MultiWorker(int TimeBetween, params Action[] TheActions)
	{
		AllTasks = TheActions.ToList();
		Timer = new ElroubyTimer(delegate
		{
			if (AllTasks.Count > 0)
			{
				AllTasks[0]();
				AllTasks.Remove(AllTasks[0]);
			}
		}, TimeBetween);
	}

	public void Start()
	{
		Timer.Start();
	}

	public void Stop()
	{
		Timer.Stop();
	}
}
