using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Bola : MonoBehaviour
{

    public float velocidad = 30.0f;

    //Audio Source
    AudioSource fuenteDeAudio;

    //Clips de audio
    public AudioClip audioGol, audioRaqueta, audioRebote;

    //Contadores de goles
    public int golesIzquierda = 0;
    public int golesDerecha = 0;

    //Cajas de texto de los contadores
    public Text ContadorIzq;
    public Text ContadorDer;


    // Start is called before the first frame update
    void Start()    
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;

        //Recupero el componente audio source;
        fuenteDeAudio = GetComponent<AudioSource>();

        //Pongo los contadores a 0
        ContadorIzq.text = golesIzquierda.ToString();
        ContadorDer.text = golesDerecha.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Se ejecuta al colisionar
    void OnCollisionEnter2D(Collision2D micolision)
    {
        //Col contiene toda la información de la colisión
        //Si la bola colisiona con la raqueta:
        // micolision.gameObject es la raqueta
        // micolision.transform.position es la posición de la raqueta


        if (micolision.gameObject.name == "RaquetaIzq")
        {
            //Valor de x
            int x = 1;
            //Valor de y
            int y = direccionY(transform.position,
            micolision.transform.position);
            //Calculo dirección
            Vector2 direccion = new Vector2(x, y);
            //Aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            //Reproduzco el sonido del rebote
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();

        }
        //Si choca con la raqueta derecha
        else if (micolision.gameObject.name == "Raquetader")
        {
            //Valor de x
            int x = -1;
            //Valor de y
            int y = direccionY(transform.position,
            micolision.transform.position);
            //Calculo dirección (normalizada para que de 1 o -1)
            Vector2 direccion = new Vector2(x, y);
            //Aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            //Reproduzco el sonido del rebote
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();

        }

        //Para el sonido del rebote
        if (micolision.gameObject.name == "Arriba" ||
        micolision.gameObject.name == "Abajo")
        {
            //Reproduzco el sonido del rebote
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();
        }

    }

    //Direccion Y
    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta)
    {
        if (posicionBola.y > posicionRaqueta.y)
        {
            return 1;
        }
        else if (posicionBola.y < posicionRaqueta.y)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    //Reinicio la posición de la bola
    public void reiniciarBola(string direccion, float velo)
    {
        //Posición 0 de la bola
        transform.position = Vector2.zero;
        //Vector2.zero es lo mismo que new Vector2(0,0);

        velocidad = velocidad + velo;

        //Velocidad y dirección
        if (direccion == "Der")
        {
            //Incremento goles al de la derecha
            golesDerecha++;
            //Lo escribo en el marcador
            ContadorDer.text = golesDerecha.ToString();
            //Reinicio la bola
            GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
            //Vector2.right es lo mismo que new Vector2(1,0)
        }
        else if (direccion == "Izq")
        {
            //Incremento goles al de la izquierda
            golesIzquierda++;
            //Lo escribo en el marcador
            ContadorIzq.text = golesIzquierda.ToString();
            //Reinicio la bola
            GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
            //Vector2.right es lo mismo que new Vector2(-1,0)
        }

        //Reproduzco el sonido del gol
        fuenteDeAudio.clip = audioGol;
        fuenteDeAudio.Play();

        if(golesDerecha == 5 || golesIzquierda == 5)
        {
            SceneManager.LoadScene("Final");
        }

        //Velocidad inicial de la bola
        
        


        //Incremento la velocidad de la bola

    }



}

