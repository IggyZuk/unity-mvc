using System.Collections.Generic;

public class Model
{
	public Queue<BaseEvent> events = new Queue<BaseEvent>();

	public int ticks = 0;
	public int nextTileId = 0;
	public Dictionary<Position, Tile> tiles = new Dictionary<Position, Tile>();
	public System.Random rng = new System.Random();
}
