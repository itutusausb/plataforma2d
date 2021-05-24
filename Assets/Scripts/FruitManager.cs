using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{ 
    public Text levelCleared;

    private void Update()
    {
        AllfruitCollected();
    }
    public void AllfruitCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No hay mas frutas");
            levelCleared.gameObject.SetActive(true);
            Invoke("ChangeScene", 1);
            
        }
    }

    void ChangeScene()

    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
