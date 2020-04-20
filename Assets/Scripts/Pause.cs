using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public bool isOn;
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
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
        Time.timeScale =1;
        pauseMenuUI.SetActive(false);
    }
    public void Menu()
    {
        Time.timeScale =1;
         SceneManager.LoadScene(0);
    }
    
    public void StartOver()
    {
        /*starting over the global variables for the same level
        pauseMenuUI.SetActive(false);
        animator.SetBool("Objective", false);
        animator.SetBool("Datalog", false);
        animator.SetBool("EndofConvo", false);
        Sam.obj_complete = false;
        Sam.clue_collect = false;
        isOn = false;
        */
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
