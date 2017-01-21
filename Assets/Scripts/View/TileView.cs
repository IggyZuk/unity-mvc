using System.Collections;
using UnityEngine;

public class TileView : MonoBehaviour
{
	[SerializeField]
	MeshRenderer meshRenderer;
	[SerializeField]
	Color grassColor;
	[SerializeField]
	Color waterColor;

	public int tileId = -1;
	public Tile.TileType tileType;

	Coroutine animCoroutine;

	public void Init(int tileId, Tile.TileType tileType)
	{
		this.tileId = tileId;
		this.tileType = tileType;

		SetTileType(tileType);
	}

	public void SetTileType(Tile.TileType tileType)
	{
		this.tileType = tileType;

		Color c = Color.black;

		switch(tileType)
		{
			case Tile.TileType.Grass:
			c = grassColor;
			break;
			case Tile.TileType.Water:
			c = waterColor;
			break;
		}

		meshRenderer.material.color = c;
	}

	public void Highlight()
	{
		if(animCoroutine != null)
		{
			StopCoroutine(animCoroutine);
		}

		animCoroutine = StartCoroutine(Highlight_Coroutine());
	}

	IEnumerator Highlight_Coroutine()
	{
		Color originalColor = (tileType == Tile.TileType.Grass) ? grassColor : waterColor;

		float t = 0f;
		float tTotal = 0.25f;

		while(t < tTotal)
		{
			t += Time.deltaTime;

			meshRenderer.material.color = Color.Lerp(Color.red, originalColor, t / tTotal);
			this.transform.localScale = Vector3.one * Mathf.Lerp(2f, 1f, t / tTotal);

			yield return null;
		}
	}
}
