using UnityEngine;

public class World : MonoBehaviour
{
	public Model model;
	public View view;

	public void Init()
	{
		model = new Model();

		GameObject viewRoot = new GameObject("View");
		view = new View(viewRoot.transform);

		TileService.MakeGrid(model, Config.GRID_SQ_SIZE, Config.GRID_SQ_SIZE);
		Tile tile = TileService.GetTileAtPosition(model, new Position(Config.GRID_SQ_SIZE / 2, Config.GRID_SQ_SIZE / 2));
		tile.tileTile = Tile.TileType.Water;

		Camera.main.transform.position = new Vector3
		(
			Config.GRID_SQ_SIZE / 2f - 0.5f,
			Config.GRID_SQ_SIZE / 2f - 0.5f,
			-10f
		);
	}

	void Update()
	{
		GetUserInput();
		ViewService.Tick(view, model);
	}

	void GetUserInput()
	{
		if(Input.GetMouseButton(0))
		{
			Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPos.x = (float)System.Math.Round(worldPos.x);
			worldPos.y = (float)System.Math.Round(worldPos.y);

			Tile clickedTile = TileService.GetTileAtPosition
			(
				model,
				new Position(worldPos)
			);

			if(clickedTile != null)
			{
				clickedTile.tileTile = Tile.TileType.Grass;
				model.events.Enqueue(new TileChangedTypeEvent(clickedTile.id));
			}
		}
	}

	void OnDrawGizmos()
	{
		foreach(Position tilePos in model.tiles.Keys)
		{
			Gizmos.DrawWireCube(tilePos.ToVector(), Vector3.one);
		}
	}
}
