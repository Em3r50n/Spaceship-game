using UnityEngine;
using System.Collections;

public class Trajetoria_Reta : MonoBehaviour {

    public float velocidade_descida = 2.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void LateUpdate() {
        transform.Translate( 0, velocidade_descida * Time.deltaTime, 0);
    }
}

