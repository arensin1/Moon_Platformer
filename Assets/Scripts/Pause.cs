using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale ==0){
                Resume();
            }
            else {
                Time.timeScale = 0;
                pauseMenuUI.SetActive(true);
                
            }
        }

    }
    public void Resume()
    {
        Time.timeScale =1;
    }
    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false; //for editing purpose
        Application.Quit();
    }
    public void StartOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
