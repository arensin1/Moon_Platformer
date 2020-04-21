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
        //Play music if it's set to on on previous scene
         if(DataHolder.MusicOn)
        {
            music.Play();
            DataHolder.MusicOn = true;
            
        }
        else
        {
            //Pause music if it's set to off on previous scene
            music.Pause();
            DataHolder.MusicOn = false;
            
        }
        
    }

    void Update(){
        
        //setting volumes
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
        //abillity to switch music off and on
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
