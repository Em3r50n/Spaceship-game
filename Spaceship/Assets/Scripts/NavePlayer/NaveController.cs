using UnityEngine;
using System.Collections;

public class NaveController : MonoBehaviour
{

    //CONSTANTES
    public const int vel = 7;

    public const float maxDist = 4.05f;

    //Outras variáveis
    private Game_Controller gamecontroller;
    private Collider collid;
    private Renderer rend;
    public Transform tiro;

    private int frameCount = 0;
    public int velocidade_disparo = 15;
    public float velSubida = 4.0f;

    public bool movimento_habilitado = true;    //Variaveis que controlam se a
    public bool tiro_habilitado = true;         //nave atira, é movida pelo player, e se vai executar
    public bool movInicial = false;             //o movimento inicial de subida.
    public bool morte = false;

    //Atributos da Classe
    private double halfScreen;


    void Awake()
    {
        halfScreen = Screen.width / 2.0;
    }

    void Start()
    {

        GameObject objGameController = GameObject.FindWithTag("GameController");
        if (objGameController != null)
        {
            gamecontroller = objGameController.GetComponent<Game_Controller>();
        }
        if (gamecontroller == null)
        {
            Debug.Log("Não encontrou nenhum Script 'Game_Controller'.");
        }

    }

    void LateUpdate()
    {

        if (morte == true)
        {
            movInicial = false;
            movimento_habilitado = false;
            tiro_habilitado = false;
            StartCoroutine(Movimento_Morte());
        }

        /* Checagem incial que verifica se é necessário
         * realizar o Movimento Inicial. (Por default a variavel "movInicial"
         * deve ser igual a "false". Sendo alterada apenas no inicio da cena
         * pelo objeto "GameController". O Metodo "Movimento_Inicial" desta classe, é responsável
         * pela habilitação dos "Tiros" e do "Movimento" do player.
         */

        if (movInicial == true)
        {
            Movimento_Inicial();
        }


        if (tiro_habilitado == true)
        {
            frameCount++;
            if (frameCount >= velocidade_disparo)
            {
                frameCount = 0;
                shoot();
            }
        }

        //Para fazer teste no computador é só descomentar esse trecho
        if (movimento_habilitado == true)
        {
            shipMoving();

            if (Input.GetKey("left"))
            {
                if (transform.position.x > -maxDist)
                {
                    transform.Translate(-vel * Time.deltaTime, 0, 0);
                }

                if (transform.position.x < -maxDist)
                {
                    transform.position = new Vector3(-maxDist, 0, 0);
                }
            }


            if (Input.GetKey("right"))
            {
                if (transform.position.x < maxDist)
                {
                    transform.Translate(vel * Time.deltaTime, 0, 0);
                }

                if (transform.position.x > maxDist)
                {
                    transform.position = new Vector3(maxDist, 0, 0);
                }
            }

        }

    }


    /**
     * @return void
     * 
     * Função responsável por capturar o movimento da nave na tela
     * 
     * */
    private void shipMoving()
    {

        ScreenTouch touchController = new ScreenTouch();

        int s = touchController.getSideTouch(transform.position, halfScreen);

        if (s == 0)
        {

            if (transform.position.x > -maxDist)
            {
                transform.Translate(Vector3.left * vel * Time.deltaTime);
            }

            if (transform.position.x < -maxDist)
            {
                transform.position = new Vector3(-maxDist, 0, 0);
            }
        }

        else if (s == 1)
        {

            if (transform.position.x < maxDist)
            {
                transform.Translate(Vector3.right * vel * Time.deltaTime);
            }

            if (transform.position.x > maxDist)
            {
                transform.position = new Vector3(maxDist, 0, 0);
            }

        }
    }

    private void shoot()
    {
        Vector3 pos = transform.position;
        pos.y -= 0.1F;
        pos.z += 0.33f;
        Instantiate(tiro, pos, tiro.transform.rotation);
    }


    /* Este metodo basicamente faz com que nave se mova para no eixo Z
     * ate que atinga o ponto 0. E em seguida habilita movimentação do player e
     * a capacidade de disparar tiros.
     */
    public void Movimento_Inicial()
    {
        transform.Translate(0, 0, velSubida * Time.deltaTime, Space.World);

        if (transform.position.z >= 0)
        {
            transform.position = new Vector3(0, 0, 0);
            tiro_habilitado = true;
            movimento_habilitado = true;
            gamecontroller.Instanciar_MeteoroSpawn();
            movInicial = false;
        }

    }


    IEnumerator Movimento_Morte()
    {

        if (transform.position.z > -1)
        {
            transform.Translate(0, 0, -velSubida / 2 * Time.deltaTime, Space.World);
        }

        if (transform.position.z <= -1)
        {

            if (gamecontroller.vida == 0)
            {
                Destroy(gameObject);
            }

            rend = GetComponent<Renderer>();
            rend.enabled = false;
            collid = GetComponent<Collider>();
            collid.enabled = false;

            yield return new WaitForSeconds(2);

            gamecontroller.pontos_vida = gamecontroller.total_pontos_vida;
            rend.enabled = true;
            collid.enabled = true;
            transform.position = new Vector3(0, 0, 0);
            movimento_habilitado = true;
            tiro_habilitado = true;
            morte = false;
        }
    }

}




	
