using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Principal : MonoBehaviour {

	public GameObject cerca;
	public GameObject arbusto;
	public GameObject nuvem;
	public GameObject pedra;
	public GameObject canos;
	public GameObject jogadorFelpudo;
	public Text meuScore;
	public GameObject particulasPeninhas;

	public AudioClip somVoa;
	public AudioClip somScore;
	public AudioClip somBate;

	bool comecou;
	bool acabou;
	int score;

	void Start () { 
		Physics.gravity = new Vector3(0, -20.0F, 0);

	}

	void Update(){
		if(Input.anyKeyDown)
		{ 
			if(!acabou)
			{
				if(!comecou)
				{ 
					comecou = true;
					InvokeRepeating("CriaCerca", 1, 0.4F);
					InvokeRepeating("CriaObjeto", 1, 0.77F); 
					jogadorFelpudo.GetComponent<Rigidbody>().useGravity = true;
					jogadorFelpudo.GetComponent<Rigidbody>().isKinematic = false; 
					meuScore.text = score.ToString();
					meuScore.fontSize = 100;
				}
				VoaFelpudo(); 
			}
		} 
		jogadorFelpudo.transform.rotation = Quaternion.Euler(jogadorFelpudo.GetComponent<Rigidbody>().velocity.y*-3, 90,0);
	}

	void CriaCerca()
	{
		if(!acabou){
			GameObject novoObjeto = (GameObject) Instantiate(cerca);  
		}
	} 

	void CriaObjeto()
	{
		if(!acabou){ 

			var sorteiaObjeto = Random.Range(1,5); 

			float posicaoZRandom = Random.Range(-3.5f,2.0f);
			float posicaoYRandom = Random.Range(4f,7f); 
			float rotacaoYRandom = Random.Range(-0.0f,360.0f); 
 
			GameObject novoObjeto = new GameObject();

			switch (sorteiaObjeto) 
			{ 
			case 1: novoObjeto = (GameObject) Instantiate(pedra);  posicaoYRandom=0; 
				break;

			case 2: novoObjeto = (GameObject) Instantiate(arbusto); posicaoYRandom=0; 
				break;

			case 3: novoObjeto = (GameObject) Instantiate(nuvem);  
				break;
			case 4: CriaCanos();  
				break;
			default: break;
			}

			novoObjeto.transform.position = new Vector3(novoObjeto.transform.position.x,novoObjeto.transform.position.y+posicaoYRandom,novoObjeto.transform.position.z+posicaoZRandom);
			novoObjeto.transform.rotation =  Quaternion.Euler(novoObjeto.transform.rotation.x,rotacaoYRandom,novoObjeto.transform.rotation.z);

		}
	}

	void CriaCanos()
	{
		if(!acabou){
			GameObject novoObjeto = (GameObject) Instantiate(canos);
			float posicaoYRandom = Random.Range(1.8f,4.0f);
			novoObjeto.transform.position = new Vector3(novoObjeto.transform.position.x,posicaoYRandom,novoObjeto.transform.position.z);
			 
		}
	}

	void VoaFelpudo(){
		GetComponent<AudioSource>().PlayOneShot(somVoa);

		GameObject minhasParticulas = Instantiate(particulasPeninhas);
		minhasParticulas.transform.position = jogadorFelpudo.transform.position;
		minhasParticulas.transform.rotation = jogadorFelpudo.transform.rotation;

		jogadorFelpudo.GetComponent<Rigidbody>().velocity = Vector3.zero;
		jogadorFelpudo.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 10.0f, 0.0f);
	}

	void MarcaPonto(){
		GetComponent<AudioSource>().PlayOneShot(somScore);
		score++;
		meuScore.text = score.ToString();
	}
	 
	void FimDeJogo(){ 
		acabou = true;
		GetComponent<AudioSource>().PlayOneShot(somBate);
		Invoke("RecarregaCena", 2);
	}
	void RecarregaCena(){ 
		Application.LoadLevel("MinhaCena");
	}

}
