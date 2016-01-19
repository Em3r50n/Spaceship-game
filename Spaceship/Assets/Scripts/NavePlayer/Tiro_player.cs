using UnityEngine;
using System.Collections;

public class Tiro_player : MonoBehaviour {

	public float VELOCIADE_TIRO = 8.0f;
    public float margem_tela = 12.0f; /* Ponto em que o objeto deve ser destruido
                                         por sair da cena.*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.Translate(0, 0, VELOCIADE_TIRO * Time.deltaTime);

		if (transform.position.z >= margem_tela) {
			Destroy(gameObject);
		}

	}
}
