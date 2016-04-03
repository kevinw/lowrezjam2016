using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	public float fuckedStart;
	public float fuckedDelay = 1.0f;
	public float fuckedEnd;
	public float fuckedTime;
	public LeanTweenType fuckedEaseType;
	public Material material;
	public string PropertyName;
	public Light sun;

	void Start () {
		{
			material.SetFloat (PropertyName, fuckedStart);
			var tween = LeanTween.value (gameObject, fuckedStart, fuckedEnd, fuckedTime);
			tween.setDelay (fuckedDelay);
			tween.setOnUpdate (val => material.SetFloat (PropertyName, val));
			tween.setEase (fuckedEaseType);
		}

		if (sun) {
			var target = sun.transform.localEulerAngles.x;
			sun.transform.Rotate(-200, 0, 0);
			var tween = LeanTween.rotateX(sun.gameObject, target, fuckedTime);
			tween.setDelay (fuckedDelay);
		}
	}
}
