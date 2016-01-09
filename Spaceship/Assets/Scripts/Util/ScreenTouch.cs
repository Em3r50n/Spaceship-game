using UnityEngine;
using System.Collections;

/**
 * Classe responsável por captar as interações do usuário com a tela do dispositivo;
 * 
 * OBS.: Esta classe deve conter funções genericas que possam ser utilizados por scripts desse
 * e de outros jogos.
 * 
 **/

public class ScreenTouch {


	/**
	 * @return a posição do toque na tela em um vetor.
	 * @parameter a posição atual do objeto na tela.
	 * 
	 * Função recebe como parâmetro a última posição identificada do objeto e caso
	 * haja uma interação do usuário, retorna a posição na tela onde usuário efetuou o toque.
	 * 
	 * */
	public Vector3 getTouchPosition(Vector3 position) {

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
			return Input.GetTouch (0).position;
		}

		return position;
	}

	/**
	 * 
	 * @return o lado do toque na tela: Esquerda = 0, direita = 1.
	 * @parameters Última posição identificada do objeto, Ponto médio da tela.
	 * 
	 * Função identifica qual lado foi efetuado o toque na tela, baseado no ponto médio como parâmetro.
	 * 
	 * */

	public int getSideTouch (Vector3 position, double screenWidth) {

		int side = -1;

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
			Vector3 touchPosition = Input.GetTouch (0).position;

			if (touchPosition.x < screenWidth) {
				side = 0;
			} else if (touchPosition.x > screenWidth) {
				side = 1;
			}

		}

		return side;
	}


}
