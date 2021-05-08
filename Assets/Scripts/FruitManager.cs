using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    private void Update()
    {
        AllfruitCollected();
    }
    public void AllfruitCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No hay mas frutas");
        }
    }
}
