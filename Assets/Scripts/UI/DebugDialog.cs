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
		float ticks = world.model.ticks;
		float time = world.model.ticks * Config.TICK_INTERVAL;

		debugText.text = string.Format("Ticks: {0}, Time: {1}", ticks, time);
	}
}
