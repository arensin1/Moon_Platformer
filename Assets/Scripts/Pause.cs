using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public bool isOn; // check if pause is on or off
  
 
    // Update is called once per frame
    void Update()
    {
        //prssing escape turns off or on pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale ==0){
                Resume();
                isOn = false;
            }
            else {
                Time.timeScale = 0;
                pauseMenuUI.SetActive(true);
                isOn = true;
                
            }
        }

    }
    public void Resume()
    {
        //resume game
        Time.timeScale =1;
        pauseMenuUI.SetActive(false);
    }
    public void Menu()
    {
        //go back to start menu
        Time.timeScale =1;
         SceneManager.LoadScene(0);
    }
    
    public void StartOver()
    {
        
        //start over
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
