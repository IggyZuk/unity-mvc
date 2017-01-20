public class BoxAddedEvent : BaseEvent
{
	int boxId;

	public BoxAddedEvent(int boxId)
	{
		this.boxId = boxId;
	}

	public void Execute(Model model, View view)
	{
		Box box = ModelService.GetBoxWithId(model, boxId);
		if(box != null)
		{
			ViewService.AddBoxView(view, boxId, box.position);
		}
	}
}
