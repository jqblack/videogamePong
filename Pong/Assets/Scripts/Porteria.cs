using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porteria: MonoBehaviour
{

    public float Mivelocidad = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //detecto si la bola atraviesa la porteria
    void OnTriggerEnter2D(Collider2D bola)
    {
        if (bola.name == "Bola")
        {

            Mivelocidad += 5;

            //Si es la portería izquierda
            if (this.name == "Izq")
            {
                //Cuento el gol y reinicio la bola
                bola.GetComponent<Bola>().reiniciarBola("Der", Mivelocidad);
            }
            //Si es la portería derecha
            else if (this.name == "Der")
            {
                //Cuento el gol y reinicio la bola
                bola.GetComponent<Bola>().reiniciarBola("Izq", Mivelocidad);
            }

            /*if ((golesIzquierda + golesDerecha) == 1)
            {
                velocidad = velocidad + 10f;
            }
            else if ((golesIzquierda + golesDerecha) == 2)
            {
                velocidad = velocidad + 1f;
            }
            else if ((golesIzquierda + golesDerecha) == 3)
            {
                velocidad = velocidad + 1f;
            }
            else if ((golesIzquierda + golesDerecha) == 4)
            {
                velocidad = velocidad + 1f;
            }
            else if ((golesIzquierda + golesDerecha) == 5)
            {
                velocidad = velocidad + 1f;
            }
            else if ((golesIzquierda + golesDerecha) == 6)
            {
                velocidad = velocidad + 1f;
            }
            else if ((golesIzquierda + golesDerecha) == 7)
            {
                velocidad = velocidad + 1f;
            }
            else if ((golesIzquierda + golesDerecha) == 8)
            {
                velocidad = velocidad + 1f;
            }*/

        }
    }

}
