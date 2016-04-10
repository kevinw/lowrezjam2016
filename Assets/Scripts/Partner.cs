using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Interval {
	public Interval(float min, float max) {
		this.min = min;
		this.max = max;
	}

	public float min;
	public float max;

	public float RandomValue { get { return Random.Range(min, max); } }
}

public class Partner : PlayerDot {
	public float cpuSpeed = 30.0f;

	public Interval pauseTime = new Interval(0.1f, 0.5f);

	void Start() {
		StartCoroutine(DoRandomPoints());
	}

	Vector2 previousPoint = new Vector2(Mathf.NegativeInfinity, Mathf.NegativeInfinity);

	public float nextPointDistance = 20.0f;
		
	Vector2 NextPoint() {
		var playspace = Game.Instance.playspace;

		Vector2 candidate;
		int count = 100;
		do {
			candidate = playspace.RandomPointInside().Round();
		} while (Vector2.Distance(candidate, previousPoint) < nextPointDistance && --count > 0);

		previousPoint = candidate;
		return candidate;
	}

	IEnumerator DoRandomPoints() {
		while (true) {
			var headTo = NextPoint();
			while (Vector2.Distance(Position, headTo) > 0.05) {
				var distance = Vector2.Distance(Position, headTo);
				var myPos = rt.anchoredPosition;
				var delta = headTo - myPos;
				myPos += Vector2.ClampMagnitude(delta.normalized * cpuSpeed * Time.deltaTime, distance);
				rt.anchoredPosition = Game.Instance.playspace.Clamp(myPos);
				yield return null;
			}

			var waitTime = pauseTime.RandomValue;
			yield return new WaitForSeconds(waitTime);
		}
	}

	/*
	IEnumerator DoAI() {
		while (true) {
			var playerPos = player.anchoredPosition;
			var myPos = target.anchoredPosition;
			var deltaVec = myPos - playerPos;
			Debug.Log(playerPos + " " + myPos + " " + deltaVec);
			myPos += deltaVec.normalized * cpuSpeed * Time.deltaTime;
			target.anchoredPosition = playspace.Clamp(myPos);
			yield return null;
		}
	}
	*/
}
