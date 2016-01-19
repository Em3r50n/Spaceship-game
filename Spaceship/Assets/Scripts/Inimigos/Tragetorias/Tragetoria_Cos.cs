using UnityEngine;
using System.Collections;

public class Tragetoria_Cos : MonoBehaviour {

    public float velocidade_descida = 2.0f;
    private float variacao_x = 0.0f;
    public float acrescimo_variacao = 0.2f;
    public float numero_divisor = 20.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void LateUpdate() {

        transform.Translate((Mathf.Cos(variacao_x))/numero_divisor, velocidade_descida * Time.deltaTime, 0);
        variacao_x += acrescimo_variacao; // Quanto maior o número, menor é a variação.

    }
}
