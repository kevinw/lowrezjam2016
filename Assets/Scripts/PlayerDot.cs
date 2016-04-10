using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class PlayerDot : MonoBehaviour {
	protected RectTransform rt;
	protected Image image;

	void Awake() {
		rt = GetComponent<RectTransform>();
		image = GetComponent<Image>();
	}

	public Vector2 Position { get {
		return rt.anchoredPosition;
	} }

	public Color Color {
		get { return image.color; }
		set { image.color = value; }
	}
}
