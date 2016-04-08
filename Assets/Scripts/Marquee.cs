using UnityEngine;
using System.Collections;

public class Marquee : MonoBehaviour {
	RectTransform rt;
	public float speed = 1.0f;

	void Awake() {
		rt = GetComponent<RectTransform> ();
	}

	void Update () {
		var pos = rt.anchoredPosition;
		pos.x += Time.deltaTime * speed;
		rt.anchoredPosition = pos;
	}
}
