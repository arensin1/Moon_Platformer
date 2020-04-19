using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    bool musicOn;
    void Start()
    {
        musicOn = true;
    }

    // Update is called once per frame
    void MusicSwitch()
    {
        if(musicOn)
        {
            music.volume = 0;
        }
        else
        {
            music.volume = 1;
        }
    }
}
