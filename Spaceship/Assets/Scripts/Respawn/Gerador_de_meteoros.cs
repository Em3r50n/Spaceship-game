using UnityEngine;
using System.Collections;

public class Gerador_de_meteoros : MonoBehaviour {

	public Transform meteoro;
	private int frameCount;
    public int tempo = 60;

	void Awake () {
		frameCount = 0;
	}
		
	void Start () {
		instanciarMeteoro ();
	}
	
	// Update is called once per frame
	void LateUpdate () {

		frameCount++;

		if (frameCount == tempo) {
			frameCount = 0;
			instanciarMeteoro ();
		}
	
	}


	private void instanciarMeteoro () {
		Instantiate(meteoro, new Vector3(Random.Range (-3.0f, 3.0f),0,14), meteoro.transform.rotation);

	}
}
