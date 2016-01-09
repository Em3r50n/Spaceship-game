using UnityEngine;
using System.Collections;

public class Resolution_Adjust : MonoBehaviour {

    public float targetRatio = 10f / 16f; //O ratio_aspect no qual
                                          //o jogo foi desenvolvido.
    
    void Start() {
        Camera cam = GetComponent<Camera>();
        cam.aspect = targetRatio;
    } 
	

	void Update () {
	
	}
}
