using System.Collections.Generic;

public static class TileService
{
	public static void MakeGrid(Model model, int width, int height)
	{
		for(int y = 0; y < height; y++)
		{
			for(int x = 0; x < width; x++)
			{
				AddTile(model, new Position(x, y), Tile.TileType.Grass);
			}
		}
	}

	public static Tile AddTile(Model model, Position position, Tile.TileType tileTile)
	{
		Tile tile = new Tile();
		tile.id = model.nextTileId;
		model.nextTileId++;
		tile.position = position;
		tile.tileTile = tileTile;

		model.tiles.Add(position, tile);
		model.events.Enqueue(new TileAddedEvent(tile.id));

		return tile;
	}

	public static Tile GetTileAtPosition(Model model, Position position)
	{
		if(model.tiles.ContainsKey(position))
		{
			return model.tiles[position];
		}

		// Warn
		return null;
	}

	public static Tile GetTileWithId(Model model, int tileId)
	{
		foreach(Tile tile in model.tiles.Values)
		{
			if(tile.id == tileId)
			{
				return tile;
			}
		}

		// Warn
		return null;
	}

	public static List<Tile> GetWaterNeightbours(Model model)
	{
		List<Tile> result = new List<Tile>();

		foreach(Tile tile in model.tiles.Values)
		{
			if(tile.tileTile == Tile.TileType.Water)
			{
				for(int x = -1; x <= 1; x++)
				{
					for(int y = -1; y <= 1; y++)
					{
						if(x == 0 && y == 0) continue;

						Tile subTile = TileService.GetTileAtPosition(model, tile.position + new Position(x, y));
						if(subTile != null)
						{
							if(subTile.tileTile != Tile.TileType.Water)
							{
								result.Add(subTile);
							}
						}
					}
				}
			}
		}

		return result;
	}
}
