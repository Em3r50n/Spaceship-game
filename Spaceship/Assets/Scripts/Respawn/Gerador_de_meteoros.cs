using UnityEngine;
using System.Collections;

public class Gerador_de_meteoros : MonoBehaviour {

	public Transform meteoro;
    public bool gerarMeteoro_habilitado = true;
	private int frameCount;
    public int tempo = 60;

	void Awake () {
		frameCount = 0;
	}
		
	void Start () {
	
	}
	
	// Update is called once per frame
    void LateUpdate()
    {


        if (gerarMeteoro_habilitado == true)
        {
            frameCount++;

            if (frameCount == tempo)
            {
                frameCount = 0;
                instanciarMeteoro();
            }

        }
    }


	private void instanciarMeteoro () {
		Instantiate(meteoro, new Vector3(Random.Range (-3.0f, 3.0f),0,14), meteoro.transform.rotation);

	}
}
