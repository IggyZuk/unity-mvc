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
}
