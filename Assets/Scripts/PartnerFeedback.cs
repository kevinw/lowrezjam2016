using UnityEngine;
using UnityEngine.UI;

public class PartnerFeedback : MonoBehaviour {
	RectTransform rt;

	public enum FeedbackMode {
		Proximity
	}

	public Color exciteColor;
	Color normalColor;

	public Player player;
	Partner partner;

	Vector3 originalScale;

	void Awake() {
		if (player == null)
			player = FindObjectOfType<Player>();
		partner = GetComponent<Partner>();
		normalColor = partner.Color;
		rt = GetComponent<RectTransform>();
		originalScale = rt.localScale;
	}

	public float FlashingSpeed { get {
		return 30.0f * Game.Instance.ExciteProximityFactor;
	} }

	void Update() {
		var f = Game.Instance.ExciteProximityFactor;
		var targetColor = Color.Lerp(normalColor, exciteColor, f);
		//var targetColor = exciteColor;

		//var t = (Mathf.Sin(Time.time * FlashingSpeed) + 1.0f) / 2.0f;
		var t = Mathf.Sin(Time.time * FlashingSpeed);
		GetComponent<Partner>().Color = Color.Lerp(normalColor, targetColor, t);

		rt.localScale = originalScale * (1.0f + (0.5f * t));
	}

}


