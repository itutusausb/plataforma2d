using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DemageObject : MonoBehaviour
{
    public AudioSource clip;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Daño");
            collision.transform.GetComponent<playerRespawn>().PlayerDamaged();
            clip.Play();
        }
    }
}
