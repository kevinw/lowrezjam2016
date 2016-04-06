using UnityEngine;
using System.Collections;

public class Partner : MonoBehaviour {
	public float cpuSpeed = 30.0f;
	RectTransform rt;

	void Awake() {
		rt = GetComponent<RectTransform>();
	}

	void Start() {
		StartCoroutine(DoRandomPoints());
	}

	IEnumerator DoRandomPoints() {
		while (true) {
			var headTo = Game.Instance.playspace.RandomPointInside().Round() + new Vector2(0.5f, 0.5f);
			while (Vector2.Distance(rt.anchoredPosition, headTo) > 0.05) {
				var myPos = rt.anchoredPosition;
				var delta = headTo - myPos;
				myPos += delta.normalized * cpuSpeed * Time.deltaTime;
				rt.anchoredPosition = Game.Instance.playspace.Clamp(myPos);
				yield return null;
			}
			yield return new WaitForSeconds(0.5f);
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
