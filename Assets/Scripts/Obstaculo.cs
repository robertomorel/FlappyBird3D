using UnityEngine;
using System.Collections;

public class Obstaculo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(-5.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x < -10){
			Destroy(this.gameObject);
		}
	}
}
