using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    public void AllfruitCollected()
    {
        if (transform.childCount == 1)
        {
            Debug.Log("No hay mas frutas");
        }
    }
}
