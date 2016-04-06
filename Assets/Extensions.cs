using UnityEngine;

public static class Extensions {
	static public Vector2 RandomPointInside(this Rect rect) {
		return new Vector2(
			Random.Range(rect.xMin, rect.xMax),
			Random.Range(rect.yMin, rect.yMax));
	}

	static public Vector2 Clamp(this Rect rect, Vector2 vec) {
		vec.x = Mathf.Max(rect.xMin, vec.x);
		vec.x = Mathf.Min(rect.xMax, vec.x);

		vec.y = Mathf.Min(rect.yMax, vec.y);
		vec.y = Mathf.Max(rect.yMin, vec.y);

		return vec;
	}

	static public Vector2 Round(this Vector2 round) {
		round.x = Mathf.Round(round.x);
		round.y = Mathf.Round(round.y);
		return round;
	}
}
