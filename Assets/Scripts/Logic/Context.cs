using UnityEngine;

public class Context : MonoBehaviour
{
	[SerializeField]
	RootUI rootUI;

	World world;
	Simulator simulator;

	void Awake()
	{
		MessageDialog messageDialog = rootUI.AddDialog<MessageDialog>(Config.MESSAGE_DIALOG_PATH);
		messageDialog.Init(Config.GREETINGS_MESSAGE, () =>
		{
			rootUI.CloseDialog(messageDialog.GetDialogId());

			CreateWorld();

			DebugDialog debugDialog = rootUI.AddDialog<DebugDialog>(Config.DEBUG_DIALOG_PATH);
			debugDialog.Init(world);
		});
	}

	void CreateWorld()
	{
		world = this.gameObject.AddComponent<World>();
		world.Init();

		simulator = new Simulator(this, world, Config.TICK_INTERVAL);
	}
}
