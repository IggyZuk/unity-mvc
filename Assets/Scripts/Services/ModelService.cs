using UnityEngine;

public static class ModelService
{
	public static void Tick(Model model)
	{
		foreach(Box box in model.boxes)
		{
			box.position.x += (float)System.Math.Cos((float)(box.life) / 2f) * 1f;
			box.position.y += (float)System.Math.Sin((float)(box.life) / 2f) * 1f;
			box.life++;
		}

		model.ticks++;
		Debug.Log(model.ticks);
	}

	public static void AddBox(Model model, Position position)
	{
		Box box = new Box();
		box.id = model.nextBoxId;
		model.nextBoxId++;
		box.position = position;
		box.life = 0;

		model.boxes.Add(box);
		model.events.Enqueue(new BoxAddedEvent(box.id));
	}

	public static Box GetBoxWithId(Model model, int boxId)
	{
		foreach(Box box in model.boxes)
		{
			if(box.id == boxId)
			{
				return box;
			}
		}

		// Warn
		return null;
	}
}
