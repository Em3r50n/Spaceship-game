using UnityEngine;
using System.Collections;

public class Pontos_vida_inimigo : MonoBehaviour {
    
    public int pontosDeVida = 1;
    public int pontos_score = 10;

    private Game_Controller gamecontroller;


    void Start()
    {
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


    void OnTriggerEnter(Collider other) {

        if (other.CompareTag("tiro_player")) {
            --pontosDeVida;
            DestroyObject(other.gameObject);

            if (pontosDeVida == 0) {
                gamecontroller.Pontuacao(pontos_score);
                DestroyObject(gameObject);
            }

        }
    }
}
