using UnityEngine;
using System.Collections;

public class NaveController : MonoBehaviour {

    //CONSTANTES
    public const int vel = 10;
    public const float maxDist = 4.05f;
    //public const float leftMargin = 0.2F;
    //public const float rightMargin = 0.8F;

    //Atributos da Classe
    private double halfScreen;



    void Awake() {
        halfScreen = Screen.width / 2.0;
    }

    void Start() {

    }

    void LateUpdate() {

        shipMoving();

        //ObjectPosition obj = new ObjectPosition (); 
        //transform.position = obj.getPositionDelimited (leftMargin, rightMargin, transform.position);


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
}




	
