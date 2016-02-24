using UnityEngine;
using System.Collections;

public class Player_Initializer : MonoBehaviour {

    private NaveController navecontroller;
    public GameObject nave;
    public float velSubida = 4.0f;
    public float pontoDeInicio = -4.2f;

	void Start () {

        Instantiate(nave, new Vector3(0.0f, 0.0f, pontoDeInicio), nave.transform.rotation);

        GameObject objNave = GameObject.FindWithTag("player");

        if (objNave != null) {
            navecontroller = objNave.GetComponent<NaveController>();
        }

        if (navecontroller == null) {
            Debug.Log("Não encontrou nenhum Script 'NaveController'.");
        }

        navecontroller.movimento_habilitado = false;
        navecontroller.tiro_habilitado = false;
        navecontroller.movInicial = true;
        navecontroller.velSubida = velSubida;
        Destroy(gameObject);
	}
	
	
	void Update () {

	}



}
