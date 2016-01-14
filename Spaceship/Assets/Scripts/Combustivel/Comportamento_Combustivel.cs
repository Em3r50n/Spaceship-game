using UnityEngine;
using System.Collections;

public class Comportamento_Combustivel : MonoBehaviour {

    public float velocidade = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update() {


        /*Checa se o objeto saiu da tela
          Se sim, ele é deletado.
          Se não, continua indo para baixo.
        */
        if (transform.position.z < -4f) {
            DestroyObject(gameObject);
        }

        else {
            transform.Translate(0, -velocidade * Time.deltaTime, 0);
        }

    }


    void OnTriggerEnter(Collider other) { //Chega o que entra na area de colisão.

        if (other.CompareTag("player")) {
            //Inserir aqui código para aumentar o combustivel
            DestroyObject(gameObject);
        }

    }
}
