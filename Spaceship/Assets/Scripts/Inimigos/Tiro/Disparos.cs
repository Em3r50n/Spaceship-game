using UnityEngine;
using System.Collections;

public class Disparos : MonoBehaviour
{

    public Transform tiro;
    public int ciclo_disparo = 15;
    public float chance_disparar = 1.0f;
    private int framecount = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void LateUpdate() {

        framecount++;

        if (framecount == ciclo_disparo) {
            framecount = 0;

           /* Se chance_disprar for igual a 1
           * este inimigo sempre irá atirar a
           * cada ciclo de disparo (de 15 em 15
           * frames, por default).
           * EX.: Se chanche_disparar for igual
           * a 3, a chance de disparar é de 33.3%
           * 
                                       \/         */
            if (Random.Range(0, chance_disparar) <= 1)
            {
                shoot();
            }
        }


    }

    private void shoot() {

        Vector3 pos = transform.position;
        pos.y -= 0.1F;
        pos.z -= 0.025f;
        Instantiate(tiro, pos, tiro.transform.rotation);
    }
}
