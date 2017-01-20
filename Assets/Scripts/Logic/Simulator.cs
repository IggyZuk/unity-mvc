using System.Collections;
using UnityEngine;

public class Simulator
{
	public Simulator(Context context, World world, float tickInterval)
	{
		context.StartCoroutine(Simulator_Coroutine(world.model, tickInterval));
	}

	IEnumerator Simulator_Coroutine(Model model, float tickInterval)
	{
		while(true)
		{
			ModelService.Tick(model);
			yield return new WaitForSeconds(tickInterval);
		}
	}
}
