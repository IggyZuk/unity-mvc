public class TileAddedEvent : BaseEvent
{
	int tileId;

	public TileAddedEvent(int tileId)
	{
		this.tileId = tileId;
	}

	public void Execute(Model model, View view)
	{
		Tile tile = TileService.GetTileWithId(model, tileId);
		if(tile != null)
		{
			ViewService.AddTileView(view, tileId, tile.position, tile.tileTile);
		}
	}
}
