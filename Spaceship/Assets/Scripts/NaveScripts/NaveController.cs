using UnityEngine;
using System.Collections;

public class NaveController : MonoBehaviour {

    //CONSTANTES
    public const int vel = 7;
    public const float maxDist = 4.05f;
	public Transform tiro;
	private int frameCount;

    //Atributos da Classe
    private double halfScreen;





    void Awake() {
        halfScreen = Screen.width / 2.0;
		frameCount = 0;
    }

    void Start() {

    }

    void LateUpdate() {

		frameCount++;

        shipMoving();

		if (frameCount == 15) {
			frameCount = 0;
			shoot ();
		}


        //Para fazer teste no computador é só descomentar esse trecho
        
        if (Input.GetKey ("left")) {

            if (transform.position.x > -maxDist) {
                transform.Translate(-vel * Time.deltaTime, 0, 0);
            }

            if (transform.position.x < -maxDist) {
                transform.position = new Vector3(-maxDist, 0, 0);
            }

        }

        if (Input.GetKey ("right")) {

            if (transform.position.x < maxDist) {
                transform.Translate(vel * Time.deltaTime, 0, 0);
            }

            if (transform.position.x > maxDist) {
                transform.position = new Vector3(maxDist, 0, 0);
            }

        }
        

    }


    /**
     * @return void
     * 
     * Função responsável por capturar o movimento da nave na tela
     * 
     * */
    private void shipMoving() {

        ScreenTouch touchController = new ScreenTouch();

        int s = touchController.getSideTouch(transform.position, halfScreen);

        if (s == 0) {

            if (transform.position.x > -maxDist) {
                transform.Translate(Vector3.left * vel * Time.deltaTime);
            }

            if (transform.position.x < -maxDist) {
                transform.position = new Vector3(-maxDist, 0, 0);
            }

        }

        else if (s == 1) {

            if (transform.position.x < maxDist) {
                transform.Translate(Vector3.right * vel * Time.deltaTime);
            }

            if (transform.position.x > maxDist) {
                transform.position = new Vector3(maxDist, 0, 0);
            }

        }
    }

	private void shoot() {
		Vector3 pos = transform.position;
		pos.y -= 0.5F;
		Instantiate(tiro, pos, tiro.transform.rotation);
	}
}




	
