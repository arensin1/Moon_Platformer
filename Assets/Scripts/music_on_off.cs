using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_on_off : MonoBehaviour
{
    public AudioSource music;
    public Pause pause_menu;
    public Animator animator;
    bool musicOn;
    void Start()
    {
        musicOn = true;
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
        if(musicOn)
        {
            music.volume = 0;
            musicOn = false;
        }
        else
        {
            music.volume = 1;
            musicOn = true;
        }
    }

    
}
