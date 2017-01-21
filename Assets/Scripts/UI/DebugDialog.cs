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
		int boxCount = world.model.boxes.Count;
		float ticks = world.model.ticks;
		float time = world.model.ticks * Config.TICK_INTERVAL;

		debugText.text = string.Format("Boxes: {0}, Ticks: {1}, Time: {2}", boxCount, ticks, time);
	}
}
