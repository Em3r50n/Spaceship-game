using UnityEngine;
using System.Collections;

public class Margem_superior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {

        if (other.CompareTag("tiro_player")) {
            DestroyObject(other.gameObject);
        }
        if (other.CompareTag("tiro_inimigo"))
        {
            DestroyObject(other.gameObject);
        }
    }
}
