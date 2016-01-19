using UnityEngine;
using System.Collections;

public class meteoro : MonoBehaviour {


	public int vel = 4;
	public int vida = 1;
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
	
	void LateUpdate () {
		transform.Translate (0, 0, vel * Time.deltaTime * (-1));
	}

	public void OnTriggerEnter (Collider other) {

		if (other.CompareTag ("player")) {
			gamecontroller.Pontos_vida(-dano);
			Destroy(gameObject);
		}


		if (other.CompareTag ("tiro_player")) {

			if (vida == 0) {
				gamecontroller.Pontuacao (20);
				Destroy (gameObject);
			} else {
				vida--;
			}
		}
	}
}
