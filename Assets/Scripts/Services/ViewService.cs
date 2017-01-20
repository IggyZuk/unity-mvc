using UnityEngine;

public static class ViewService
{
	public static void Tick(View view, Model model)
	{
		if(model.events.Count > 0)
		{
			BaseEvent e = model.events.Dequeue();
			e.Execute(model, view);
		}

		foreach(BoxView boxView in view.boxViews)
		{
			Box box = ModelService.GetBoxWithId(model, boxView.boxId);
			boxView.transform.position = Position.Lerp
			(
				new Position(boxView.transform.position),
				box.position,
				Config.ViewDelay
			).ToVector();
		}
	}

	public static void AddBoxView(View view, int boxId, Position position)
	{
		GameObject prefab = Resources.Load<GameObject>("Box");
		GameObject go = Object.Instantiate<GameObject>(prefab);
		go.transform.SetParent(view.root);

		go.transform.position = position.ToVector();

		BoxView boxView = go.GetComponent<BoxView>();
		boxView.Init(boxId);
		view.boxViews.Add(boxView);
	}
}
