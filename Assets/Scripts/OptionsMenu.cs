using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeMaster;
    public Toggle mute;
    public AudioMixer mixer;
    private float lastVolume;

    private void Awake()
    {
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }

    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }


    public void setMute()
    {
        if (mute.isOn)
        {
            mixer.GetFloat("VolMaster", out lastVolume);

            mixer.SetFloat("VolMaster", -80);
        }
           
        else
        {
            mixer.SetFloat("VolMaster", lastVolume);
        }
            
    }

    public void ExitOptions()
    {

        SceneManager.LoadScene("MainMenu");
    }


}
