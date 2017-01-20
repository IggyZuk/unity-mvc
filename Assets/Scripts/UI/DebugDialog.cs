using UnityEngine;
using UnityEngine.UI;

public class DebugDialog : BaseDialog
{
	[SerializeField]
	Text boxCountText;

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
		boxCountText.text = string.Format("Boxes: {0}", world.model.boxes.Count);
	}
}
