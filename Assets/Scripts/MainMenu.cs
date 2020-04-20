using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame(){
        DataHolder.Lives = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
    }

    public void credits(){
        SceneManager.LoadScene(10);
    }

    public void goBackMenu(){
        SceneManager.LoadScene(0);
    }
    public void QuitGame ()
    {
        UnityEditor.EditorApplication.isPlaying = false; //for editing purpose
        Application.Quit();
    }
}
