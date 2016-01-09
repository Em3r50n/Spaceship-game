using UnityEngine;
using System.Collections;

public class NaveController : MonoBehaviour {

	//CONSTANTES
	public const int vel = 10;
	public const float leftMargin = 0.2F;
	public const float rightMargin = 0.8F;

	//Atributos da Classe
	private double halfScreen;



	void Awake () {
		halfScreen = Screen.width / 2.0;
	}
	void Start () {
		
	}

	void LateUpdate () {

		ObjectPosition obj = new ObjectPosition (); 
		transform.position = obj.getPositionDelimited (leftMargin, rightMargin, transform.position);

		shipMoving ();



		//Para fazer teste no computador é só descomentar esse trecho
		/*
		if (Input.GetKey ("left")) {
			transform.Translate (vel * Time.deltaTime * (-1), 0, 0);
		}
		if (Input.GetKey ("right")) {
			transform.Translate (vel * Time.deltaTime, 0, 0);
		}
		*/

	}


	/**
	 * @return void
	 * 
	 * Função responsável por capturar o movimento da nave na tela
	 * 
	 * */
	private void shipMoving () {

		ScreenTouch touchController = new ScreenTouch ();

		int s = touchController.getSideTouch (transform.position, halfScreen);

		if (s == 0) {
			transform.Translate (Vector3.left * vel * Time.deltaTime);
		} else if (s == 1) {
			transform.Translate (Vector3.right * vel * Time.deltaTime);
		}

	}


}
	
