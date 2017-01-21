public static class ModelService
{
	public static void Tick(Model model)
	{
		foreach(Tile tile in model.tiles.Values)
		{
			int r = model.rng.Next(0, 100);
			if(r <= 5)
			{
				tile.tileTile = Tile.TileType.Water;
				model.events.Enqueue(new TileChangedTypeEvent(tile.id));
			}
		}
		model.ticks++;
	}
}
