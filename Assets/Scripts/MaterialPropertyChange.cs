using UnityEngine;
using System.Collections.Generic;

public class MaterialPropertyChange : MonoBehaviour {
	public string propertyName;
	public float value;

	Renderer[] renderers;
	readonly Dictionary<Material, Material> materialCopies = new Dictionary<Material, Material>();

	void Awake () {
		renderers = GetComponentsInChildren<Renderer>();

		foreach (var r in renderers) {
			var sharedMaterial = r.sharedMaterial;
			if (!sharedMaterial.HasProperty(propertyName))
				continue;

			Material materialCopy;
			if (!materialCopies.TryGetValue(r.sharedMaterial, out materialCopy)) {
				materialCopy = Instantiate<Material>(r.sharedMaterial);
				materialCopies[r.sharedMaterial] = materialCopy;
			}
			r.material = materialCopy;
		}
	}
	
	void Update () {
		foreach (var materialCopy in materialCopies.Values) {
			materialCopy.SetFloat(propertyName, value);
		}
	}
}
