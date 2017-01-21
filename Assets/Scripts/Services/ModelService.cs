using System.Collections.Generic;

public static class ModelService
{
	public static void Tick(Model model)
	{
		List<Tile> waterNeightbours = TileService.GetWaterNeightbours(model);

		foreach(Tile tile in waterNeightbours)
		{
			int r = model.rng.Next(0, 100);
			if(r <= 10)
			{
				tile.tileTile = Tile.TileType.Water;
				model.events.Enqueue(new TileChangedTypeEvent(tile.id));
			}
		}
		model.ticks++;
	}
}
