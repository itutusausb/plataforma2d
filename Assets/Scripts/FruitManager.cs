using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{ 
    public Text levelCleared;

    public Text totalFruits;

    public Text fruitsCollected;

    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }

    private void Update()
    {
        AllfruitCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = transform.childCount.ToString();

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
