using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame(){
        //At start of game lives reset to 3
        //sent to first level
        DataHolder.Lives = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
    }

    public void credits(){
        //credits
        SceneManager.LoadScene(12);
    }

    public void goBackMenu(){
        //go back to menu
        SceneManager.LoadScene(0);
    }
    public void QuitGame ()
    {
        //quiting application
        //UnityEditor.EditorApplication.isPlaying = false; //for editing purpose
        Application.Quit();
    }
}
