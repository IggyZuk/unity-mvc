using System.Collections.Generic;

public class Model
{
	public Queue<BaseEvent> events = new Queue<BaseEvent>();

	public int ticks = 0;
	public int nextBoxId = 0;
	public List<Box> boxes = new List<Box>();
}
