using UnityEngine;
using System.Collections;

public class Game_Controller : MonoBehaviour {

    public int vida = 3;
    public float pontos_vida = 8.0f;
    public float total_pontos_vida;
    public int pontos_score = 0;


	void Start () {
        total_pontos_vida = pontos_vida;
	}


    public void Pontos_vida(int valor) {
        pontos_vida += valor;

        if (pontos_vida <= 0)
        {
            vida--;
            pontos_vida = total_pontos_vida;
        }
        if (vida < 0)
        {
            // Destruir a nave aqui!
        }
    }

    public void Pontuacao (int valor) {
        pontos_score += valor;
    }

    void OnGUI() // Funão que exibe a VIDA do player na tela.
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Vidas: " + vida);
        GUI.Label(new Rect(10, 25, 150, 20), "Pontos de Vida: " + (pontos_vida/total_pontos_vida)*100 + "%");
        GUI.Label(new Rect(10, 40, 100, 20), "Pontuação: " + pontos_score);
    }
}
