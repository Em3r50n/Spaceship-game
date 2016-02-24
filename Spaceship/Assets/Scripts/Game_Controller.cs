using UnityEngine;
using System.Collections;

public class Game_Controller : MonoBehaviour {

    public int vida = 3;
    public float pontos_vida = 8.0f;
    public float total_pontos_vida;
    public int pontos_score = 0;

    //Váriaveis responsáveis pelo primeiro spawn do player, subida da nave ate o ponto origem.
    private NaveController navecontroller;
    public GameObject meteoroSpawn;
    public GameObject nave;
    public float velSubida = 4.0f;
    public float pontoDeInicio = -4.2f;


	void Start () {

        total_pontos_vida = pontos_vida;



        //Instancia uma nave inicial fora do limite do lado inferior da tela e acha o Script "NaveController"
        
                Instantiate(nave, new Vector3(0.0f, 0.0f, pontoDeInicio), nave.transform.rotation);
                GameObject objNave = GameObject.FindWithTag("player");
                if (objNave != null)
                {
                  navecontroller = objNave.GetComponent<NaveController>();
                }
                if (navecontroller == null)
                {
                 Debug.Log("Não encontrou nenhum Script 'NaveController'.");
                }

                navecontroller.movimento_habilitado = false;
                navecontroller.tiro_habilitado = false;
                navecontroller.movInicial = true;
                navecontroller.velSubida = velSubida;
 
	}


    public void Pontos_vida(int valor) {
        pontos_vida += valor;

        if (pontos_vida <= 0) {
            vida--;
            navecontroller.morte = true;
            //pontos_vida = total_pontos_vida;
        }
        
    }

    public void Pontuacao (int valor) {
        pontos_score += valor;
    }

    public void Instanciar_MeteoroSpawn() {
        Instantiate(meteoroSpawn, meteoroSpawn.transform.position, meteoroSpawn.transform.rotation);
    }

    void OnGUI() // Função que exibe a VIDA do player na tela.
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Vidas: " + vida);
        GUI.Label(new Rect(10, 25, 150, 20), "Pontos de Vida: " + (pontos_vida/total_pontos_vida)*100 + "%");
        GUI.Label(new Rect(10, 40, 100, 20), "Pontuação: " + pontos_score);
    }
}
