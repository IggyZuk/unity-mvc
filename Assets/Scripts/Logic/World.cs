using UnityEngine;

public class World : MonoBehaviour
{
	public Model model;
	public View view;

	public void Init()
	{
		model = new Model();

		GameObject viewRoot = new GameObject("View");
		view = new View(viewRoot.transform);
	}

	void Update()
	{
		GetUserInput();
		ViewService.Tick(view, model);
	}

	void GetUserInput()
	{
		if(Input.GetMouseButtonDown(0))
		{
			ModelService.AddBox
			(
				model,
				new Position(Camera.main.ScreenToWorldPoint(Input.mousePosition))
			);
		}
	}

	void OnDrawGizmos()
	{
		foreach(Box box in model.boxes)
		{
			Gizmos.DrawWireCube(box.position.ToVector(), Vector3.one);
		}
	}
}
