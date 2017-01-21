using UnityEngine;
using UnityEngine.UI;

public class DebugDialog : BaseDialog
{
	[SerializeField]
	Text debugText;

	World world;

	public void Init(World world)
	{
		this.world = world;
	}

	public override string GetDialogId()
	{
		return "DebugDialog";
	}

	void Update()
	{
		int ticks = world.model.ticks;

		int waterCount = 0;
		foreach(Tile tile in world.model.tiles.Values)
		{
			if(tile.tileTile == Tile.TileType.Water)
			{
				waterCount++;
			}
		}

		debugText.text = string.Format("Tick: {0}, Water: {1}", ticks, waterCount);
	}
}
