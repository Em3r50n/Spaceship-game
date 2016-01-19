using UnityEngine;
using System.Collections;

public class Gerador_de_meteoros : MonoBehaviour {

	public Transform meteoro;
	private int frameCount;

	void Awake () {
		frameCount = 0;
	}
		
	void Start () {
		instanciarMeteoro ();
	}
	
	// Update is called once per frame
	void LateUpdate () {

		frameCount++;

		if (frameCount == 60) {
			frameCount = 0;
			instanciarMeteoro ();
		}
	
	}


	private void instanciarMeteoro () {
		Vector3 pos = transform.position;
		pos.x = Random.Range (-3, 3);

		Instantiate(meteoro, pos, transform.rotation);

	}
}
