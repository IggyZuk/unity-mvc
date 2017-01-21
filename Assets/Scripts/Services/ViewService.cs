using UnityEngine;

public static class ViewService
{
	public static void Tick(View view, Model model)
	{
		while(model.events.Count > 0)
		{
			BaseEvent e = model.events.Dequeue();
			e.Execute(model, view);
		}

		foreach(TileView tileView in view.tileViews.Values)
		{
			Tile tile = TileService.GetTileWithId(model, tileView.tileId);
			tileView.transform.position = Position.Lerp
			(
				new Position(tileView.transform.position),
				tile.position,
				Config.VIEW_DELAY
			).ToVector();
		}
	}

	public static void AddTileView(View view, int tileId, Position position, Tile.TileType tileType)
	{
		GameObject prefab = Resources.Load<GameObject>(Config.VIEW_PATH + "TileView");
		GameObject go = Object.Instantiate<GameObject>(prefab);
		go.transform.SetParent(view.root);

		go.transform.position = position.ToVector();

		TileView tileView = go.GetComponent<TileView>();
		tileView.Init(tileId, tileType);
		view.tileViews.Add(tileId, tileView);
	}

	public static TileView GetTileViewWithId(View view, int tileId)
	{
		if(view.tileViews.ContainsKey(tileId))
		{
			return view.tileViews[tileId];
		}

		// Warn
		return null;
	}
}
