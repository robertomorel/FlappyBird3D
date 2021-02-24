using UnityEngine;
using System.Collections;

public class Felpudo : MonoBehaviour {

	public GameObject cameraPrincipal;

	void OnTriggerEnter(Collider objeto)
	{
		if(objeto.gameObject.tag == "Finish")
		{   
		 GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().velocity = new Vector3(-15.0f, 15.0f, 0.0f);
			GetComponent<Rigidbody>().AddTorque(new Vector3(-100,-100,-100));
			cameraPrincipal.SendMessage("FimDeJogo");
		}
	}

	void OnTriggerExit(Collider objeto)
	{
		if(objeto.gameObject.tag == "GameController")
		{
			Destroy(objeto.gameObject);
			cameraPrincipal.SendMessage("MarcaPonto");
		}
	}
}
