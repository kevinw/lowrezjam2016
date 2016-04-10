using UnityEngine;
using System.Collections;

public class MaterialUVChange : MonoBehaviour {
	Material mat;
	public Vector2 uvOffset;
	public Vector2 uvScale;
	public string textureName = "_MainTex";

	void Awake() {
		mat = GetComponent<Renderer> ().material;
		//uvScale = mat.GetTextureScale (textureName);
		//uvOffset = mat.GetTextureOffset (textureName);
	}

	void Update() {
		mat.SetTextureOffset (textureName, uvOffset);
		mat.SetTextureScale (textureName, uvScale);
	}

}
