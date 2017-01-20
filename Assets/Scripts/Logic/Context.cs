using UnityEngine;

public class Context : MonoBehaviour
{
	World world;
	Simulator simulator;

	private void Awake()
	{
		world = this.gameObject.AddComponent<World>();
		world.Init();

		simulator = new Simulator(this, world, Config.TickInterval);
	}
}
