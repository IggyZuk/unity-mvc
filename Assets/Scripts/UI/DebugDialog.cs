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
		float timeInSeconds = world.model.ticks * Config.TICK_INTERVAL;

		debugText.text = string.Format("Boxes: {0}, Time: {1}", boxCount, timeInSeconds);
	}
}
