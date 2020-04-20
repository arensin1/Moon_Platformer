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
      
         if(DataHolder.MusicOn)
        {
            music.Play();
            DataHolder.MusicOn = true;
            
        }
        else
        {
            music.Pause();
            DataHolder.MusicOn = false;
            
        }
    }

    void Update(){
        
        if(animator.GetBool("EndofConvo") && !animator.GetBool("Notyet")){
            music.volume = Mathf.Lerp(music.volume, 0f,5f);
        }
        else if(pause_menu.isOn || !animator.GetBool("EndofConvo"))
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
