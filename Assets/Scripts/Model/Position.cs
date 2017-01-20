using UnityEngine;

public class Position
{
	public float x;
	public float y;

	public Position(float x = 0f, float y = 0f)
	{
		this.x = x;
		this.y = y;
	}

	public static Position Lerp(Position p1, Position p2, float t)
	{
		Position result = new Position();
		result.x = p1.x + (p2.x - p1.x) * t;
		result.y = p1.y + (p2.y - p1.y) * t;
		return result;
	}

	public Position(Vector3 vector)
	{
		x = vector.x;
		y = vector.y;
	}

	public Vector2 ToVector()
	{
		return new Vector2(x, y);
	}
}
