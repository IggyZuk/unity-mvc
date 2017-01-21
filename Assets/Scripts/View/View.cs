using System.Collections.Generic;
using UnityEngine;

public class View
{
	public Transform root;
	public Dictionary<int, TileView> tileViews = new Dictionary<int, TileView>();

	public View(Transform root)
	{
		this.root = root;
	}
}
