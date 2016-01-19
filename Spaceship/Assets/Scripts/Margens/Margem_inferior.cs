using UnityEngine;
using System.Collections;

public class Margem_inferior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        DestroyObject(other.gameObject);
    }

}
