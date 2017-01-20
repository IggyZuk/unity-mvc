using Boo.Lang;
using UnityEngine;

public class View
{
	public Transform root;
	public List<BoxView> boxViews = new List<BoxView>();

	public View(Transform root)
	{
		this.root = root;
	}
}
