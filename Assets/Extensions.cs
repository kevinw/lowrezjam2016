using UnityEngine;

public static class Extensions {
	static public Vector2 Clamp(this Rect rect, Vector2 vec) {
		vec.x = Mathf.Max(rect.xMin, vec.x);
		vec.x = Mathf.Min(rect.xMax, vec.x);

		vec.y = Mathf.Min(rect.yMax, vec.y);
		vec.y = Mathf.Max(rect.yMin, vec.y);

		return vec;
	}
}
