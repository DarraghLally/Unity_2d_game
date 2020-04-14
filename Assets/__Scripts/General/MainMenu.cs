using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake() {
        // On awake play intro music
        FindObjectOfType<AudioController>().Play("Intro");
    }
    // Play button on main maenu
    public void PlayGame() {
        // Use the scene manager to find the index of the current scene and 
        // add one to it to get the next scene in the stack
        FindObjectOfType<AudioController>().Play("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        // Play a sound when clicked
        FindObjectOfType<AudioController>().Play("ButtonClick");
    }

    public void QuitGame() {
        // Call to quit the app - does not happen in Unity editor
        // Debug added to show it works
        FindObjectOfType<AudioController>().Play("ButtonClick");
        Debug.Log("Quit!");
        Application.Quit();
    }
}
