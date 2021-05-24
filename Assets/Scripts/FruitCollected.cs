using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitCollected : MonoBehaviour
{
    int contador;
    Rigidbody rb;
    public Text puntuacion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // si colision se compara con el tag del player
        {
            GetComponent<SpriteRenderer>().enabled = false; // cogemos el componente spriterenderer y le decimos que no este habilitado
            //FindObjectOfType<FruitManager>().AllfruitCollected();   // Buscamos el metodo AllFruitManager del script FruitManager
            gameObject.transform.GetChild(0).gameObject.SetActive(true); // cogemos el gameobject hijo de la posicion 0 y activamos la animacion
            
            Destroy(gameObject, 0.5f); // se destruye el objeto en 0.5 segundos
            contador = contador + 10;
            puntuacion.text = "Puntos: " + contador;
        }

    }

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        puntuacion.text = "Puntos: " + contador;
        
    }











}

