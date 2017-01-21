public class TileChangedTypeEvent : BaseEvent
{
	int tileId;

	public TileChangedTypeEvent(int tileId)
	{
		this.tileId = tileId;
	}

	public void Execute(Model model, View view)
	{
		Tile tile = TileService.GetTileWithId(model, tileId);
		if(tile != null)
		{
			TileView tileView = ViewService.GetTileViewWithId(view, tileId);
			if(tileView != null)
			{
				tileView.SetTileType(tile.tileTile);
				tileView.Highlight();
			}
		}
	}
}
