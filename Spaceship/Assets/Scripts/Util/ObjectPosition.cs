using UnityEngine;
using System.Collections;

public class ObjectPosition {


	/**
	 * @return a posição do objeto na cena, dentro da margem da câmera.
	 * @parameter Um limite no lado esquero, um limite no lado direito, e a última posição identificada do objeto.
	 * 
	 * Função indentifica a posição atual do objeto e verifica se o mesmo se encontra dentro da margem delimitada
	 * (leftMargin/rightMargin). Caso não esteja a função atualiza a posição do objeto para a posição máxima permitida
	 * 
	 * */
	public Vector3 getPositionDelimited(float leftMargin, float rightMargin, Vector3 Objposition) {

		Vector3 objPos = new Vector3 ();

		Vector3 pos = Camera.main.WorldToViewportPoint (Objposition);
		pos.x = Mathf.Clamp01(pos.x);

		if (pos.x >= leftMargin && pos.x <= rightMargin) {
			objPos =  Camera.main.ViewportToWorldPoint (pos);
		} else {
			if (pos.x > rightMargin) {
				pos.x = rightMargin;
				objPos = Camera.main.ViewportToWorldPoint (pos);
			} else if (pos.x < leftMargin) {
				pos.x = leftMargin;
				objPos = Camera.main.ViewportToWorldPoint (pos);
			}
		}

		return objPos;

	}

}
