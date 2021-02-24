using UnityEngine;
using System.Collections;

public class AnimaPiso : MonoBehaviour {

	private float velociade = -0.75f;
	public Material materialPiso;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * velociade;
		materialPiso.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
