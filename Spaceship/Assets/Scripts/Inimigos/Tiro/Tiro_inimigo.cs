using UnityEngine;
using System.Collections;

public class Tiro_inimigo : MonoBehaviour {

	public float velocidade_tiro = -8.0f;
    public int dano = 1;
    private Game_Controller gamecontroller;

	// Use this for initialization
	void Start () {

        GameObject objGameController = GameObject.FindWithTag("GameController");

        if (objGameController != null)
        {
            gamecontroller = objGameController.GetComponent<Game_Controller>();
        }

        if (gamecontroller == null)
        {
            Debug.Log("Não encontrou nenhum Script 'Game_Controller'.");
        }

	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.Translate(0, 0, velocidade_tiro * Time.deltaTime);

	}

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("player"))
        {
            
                gamecontroller.Pontos_vida(-dano);
                DestroyObject(gameObject);
            
        }
    }

}
