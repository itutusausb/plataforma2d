using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
