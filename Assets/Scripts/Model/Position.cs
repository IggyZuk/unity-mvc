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

	public static Position operator +(Position left, Position right)
	{
		return new Position(left.x + right.x, left.y + right.y);
	}

	public static Position operator -(Position left, Position right)
	{
		return new Position(left.x - right.x, left.y - right.y);
	}

	public static Position operator *(Position left, long multiplier)
	{
		return new Position(left.x * multiplier, left.y * multiplier);
	}

	public static Position operator /(Position left, long multiplier)
	{
		return new Position(left.x / multiplier, left.y / multiplier);
	}

	public override bool Equals(object other)
	{
		return Equals(other as Position);
	}

	public bool Equals(Position other)
	{
		if(ReferenceEquals(other, null))
		{
			return false;
		}
		if(ReferenceEquals(other, this))
		{
			return true;
		}

		if(x != other.x) return false;
		if(y != other.y) return false;

		return true;
	}

	public override int GetHashCode()
	{
		int hash = 1;
		if(x != 0L) hash ^= x.GetHashCode();
		if(y != 0L) hash ^= y.GetHashCode();

		return hash;
	}
}
