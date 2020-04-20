using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_on_off : MonoBehaviour
{
    public AudioSource music;
    public Pause pause_menu;
    public Animator animator;
    
    void Start()
    {
        Debug.Log("Start");
         if(DataHolder.MusicOn)
        {
            music.Play();
            DataHolder.MusicOn = true;
            Debug.Log("Music_On");
        }
        else
        {
            music.Pause();
            DataHolder.MusicOn = false;
            Debug.Log("Music_Off");
        }
    }

    void Update(){
        
        if(pause_menu.isOn || !animator.GetBool("EndofConvo"))
        {
            music.volume = 0.15f;
        }
        else
        {
            music.volume = 0.5f;
        }
    }


    public void MusicSwitch()
    {
        if(DataHolder.MusicOn)
        {
            music.Pause();
            DataHolder.MusicOn = false;
        }
        else
        {
            music.Play();
            DataHolder.MusicOn = true;
        }
    }

    
}
