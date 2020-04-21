using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music_on_off : MonoBehaviour
{
    public AudioSource music;
    public Pause pause_menu;
    public Animator animator;
    float current_time;
    float current_vol;
    
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
        if(SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex < 12){
            if(animator.GetBool("EndofConvo") && !animator.GetBool("Notyet")){
                    current_vol = music.volume;
                    current_time += Time.deltaTime;
                    music.volume = Mathf.Lerp(current_vol, 0f, current_time/3.5f);
            }
             //setting volumes
            else if(pause_menu.isOn || !animator.GetBool("EndofConvo"))
            {
                music.volume = 0.15f;
            }
            else
            {
                music.volume = 0.5f;
            }
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
